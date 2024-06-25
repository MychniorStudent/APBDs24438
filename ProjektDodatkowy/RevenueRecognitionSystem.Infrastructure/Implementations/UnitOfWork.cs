using RevenueRecognitionSystem.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Infrastructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReveuneDbContext _context;
        public IIndividualClientRepository IndividualClientRepository { get; set; }
        public ICompanyClientRepository CompanyClientRepository { get; set; }
        public ISoftwareSystemRepository SoftwareSystemRepository { get; set; }
        public UnitOfWork(ReveuneDbContext context)
        {

            _context = context;
            IndividualClientRepository = new IndividualClientRepository(_context);
            CompanyClientRepository = new CompanyClientRepository(_context);
            SoftwareSystemRepository = new SoftwareSystemRepository(_context);

        }
        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
