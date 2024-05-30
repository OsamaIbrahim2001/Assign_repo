using AssignmentTask_Api.Iservices;
using AssignmentTask_Api.Models;

namespace AssignmentTask_Api.IWork
{
    public interface IUnitOfWork:IDisposable
    {
        IGenaricService<Book> BookService { get; }
        IGenaricService<Customer> CustomerService { get; }
        IGenaricService<Room> RoomService { get; }
        int SaveChanges();
    }
}
