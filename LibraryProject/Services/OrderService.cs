using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services
{
    public class OrderService : IOrderService
    {
        private readonly LibraryDbContext _context;

        public OrderService()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase("Library")
                .Options;

            _context = new LibraryDbContext(options);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders;
        }


        public void ReturnABook(int orderId)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            
            if(order != null)
            {
                var book = _context.Books.FirstOrDefault(x => x.Id == order.BookId);
                book.NumberOfCopies++;
                _context.Books.Update(book);

                var differenceBetweenLastDayOfRentalAndNow = (DateTime.Now - order.LastDayOfRental).Days;
                if (differenceBetweenLastDayOfRentalAndNow >0)
                {
                    var penalityPrice = 0.01 * order.TotalPrice * differenceBetweenLastDayOfRentalAndNow;
                }
            }
        }

        public void RentABook(int bookId, DateTimeOffset lastDayOfRental)
        {
           var book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            if (book != null)
            {
                if (book.NumberOfCopies != 0)
                {
                    book.NumberOfCopies--;
                    _context.Books.Update(book);
                    Order order = new Order()
                    {
                        BookId = bookId,
                        FirstDayOfRental = DateTime.Now,
                        LastDayOfRental = lastDayOfRental,
                        TotalPrice = book.Price * (lastDayOfRental - DateTime.Now).Days
                    };

                    _context.Orders.Add(order);
                    _context.SaveChanges();
                }
                
            }

        }
    }
}
