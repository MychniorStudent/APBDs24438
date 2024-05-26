using TripApp.DTOs;
using TripApp.Models;

namespace TripApp.Interfaces
{
    public interface ITripRepository
    {
        Task <List<TripsResponse>> getTrips();
        Task <List<Trip>> getTripsByClientId(int clientId);
        Task<bool> deleteClientById(int clientId);
        Task<Client> getClientByID(int clientId);
        Task<Client> getClientByPESEL(string PESEL);
        Task<Client> addClient(Client client);
        Task<bool> assignClientToTrip(ClientTripAssignDTO inputData);
        Task<Trip> getTripByName(string tripName);

    }
}
