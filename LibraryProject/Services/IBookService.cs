using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        int GetNumberOfCopiesForBook(string bookTitle);

        void SaveBook(Book book);
    }
}
