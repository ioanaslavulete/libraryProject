using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        void RentABook(int bookId, DateTimeOffset lastDayOfRental);

        void ReturnABook(int orderId);
    }
}
