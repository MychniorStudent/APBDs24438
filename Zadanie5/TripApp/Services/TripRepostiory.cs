using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TripApp.Context;
using TripApp.DTOs;
using TripApp.Interfaces;
using TripApp.Models;

namespace TripApp.Services
{
    public class TripRepostiory : ITripRepository
    {
        public async Task<Client> addClient(Client client)
        {
            try
            {
                S24438Context context = new S24438Context();
                var result = await context.Clients.AddAsync(client);
                await context.SaveChangesAsync();
                return client;
            }catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> assignClientToTrip(ClientTripAssignDTO inputData)
        {
            S24438Context context = new S24438Context();
            Client client = await getClientByPESEL(inputData.PESEL);
            if (client == null)
            {
                client = await addClient(new Client
                {
                    FirstName = inputData.FirstName,
                    LastName = inputData.LastName,
                    Email = inputData.email,
                    Telephone = inputData.Telephone,
                    Pesel = inputData.PESEL
                });
            }
            if((await getTripsByClientId(client.IdClient)).Any(x=>x.Name == inputData.TripName))
            {
                throw new Exception("Klient jest juz zapisany na tą wycieczke");
            }
            Trip trip = await getTripByName(inputData.TripName);
            if(trip == null)
            {
                throw new Exception("Taki trip nie istnieje");
            }
            client = await getClientByPESEL(inputData.PESEL);
            await context.ClientTrips.AddAsync(new ClientTrip
            {
                IdClient = client.IdClient,
                IdTrip = trip.IdTrip,
                RegisteredAt = DateTime.UtcNow,
                PaymentDate = inputData.PaymentDate,
            });
            return true;
        }

        public async Task<bool> deleteClientById(int clientId)
        {
            try
            {
                var trips = await getTripsByClientId(clientId);

                if (!trips.IsNullOrEmpty())
                    throw new Exception("Klient ma przypisane wycieczki, nie można go usunąć");

                if (await getClientByID(clientId) == null)
                    throw new Exception("Nie istnieje klient o podanym ID");

                S24438Context context = new S24438Context();
                context.Clients.Remove(await getClientByID(clientId));
                await context.SaveChangesAsync();
            }catch (Exception ex)
            {
                throw;
            }
                return true;
        }

        public async Task<Client> getClientByID(int clientId)
        {
            S24438Context context = new S24438Context();
            return await context.Clients.FirstOrDefaultAsync(x => x.IdClient == clientId);
        }

        public async Task<Client> getClientByPESEL(string PESEL)
        {
            S24438Context context = new S24438Context();
            return await context.Clients.FirstOrDefaultAsync(x => x.Pesel == PESEL);
        }

        public async Task<Trip> getTripByName(string tripName)
        {
            S24438Context context = new S24438Context();
            return await context.Trips.FirstOrDefaultAsync(x => x.Name == tripName);
        }

        public async Task<List<TripsResponse>> getTrips()
        {
            S24438Context context = new S24438Context();
            var result = (from t in context.Trips orderby t.DateFrom descending
                        select new TripsResponse
                        {
                            Name = t.Name,
                            Description = t.Description,
                            DateFrom = t.DateFrom,
                            DateTo = t.DateTo,
                            MaxPeople = t.MaxPeople,
                            Countries = (from c in context.Countries where c.IdTrips.Any(x => x.IdTrip == t.IdTrip) select new CountryInfoDTO { Name = c.Name }).ToList(),
                            Clients = (from c in context.Clients
                                       where c.ClientTrips.Any(x=>x.IdTrip == t.IdTrip)
                                       select new ClientInfoDTO
                                       {
                                           FirstName = c.FirstName,
                                           LastName = c.LastName
                                       }).ToList()

                        }).ToListAsync();
            return await result;

        }

        public async Task<List<Trip>> getTripsByClientId(int clientId)
        {
            S24438Context context = new S24438Context();
            return await (from t in context.Trips
                          join clt_trips in context.ClientTrips on t.IdTrip equals clt_trips.IdTrip
                          join clt in context.Clients on clt_trips.IdClient equals clt.IdClient
                          where clt.IdClient == clientId
                          select t).ToListAsync();
        }
    }
}
