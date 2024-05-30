using AssignmentTask_Api.Iservices;
using AssignmentTask_Api.IWork;
using AssignmentTask_Api.Models;
using AssignmentTask_Api.Models.Context;
using AssignmentTask_Api.Services;

namespace AssignmentTask_Api.Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            BookService = new GenaricService<Book>(_context);
            CustomerService = new GenaricService<Customer>(_context);
            RoomService = new GenaricService<Room>(_context);
        }
        public IGenaricService<Book> BookService { get; private set; }
  

        public IGenaricService<Customer> CustomerService { get; private set; }

        public IGenaricService<Room> RoomService { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
           return _context.SaveChanges();
        }
    }
}
