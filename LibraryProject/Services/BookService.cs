using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;
        
        public BookService()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase("Library")
                .Options;

            _context = new LibraryDbContext(options);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books;
        }

        public int GetNumberOfCopiesForBook(string bookTitle)
        {
            Book book = new Book();
      
            try
            {
                book = _context.Books.FirstOrDefault(x => x.Title == bookTitle);
                if(book == null)
                {
                    throw new NullReferenceException();
                }
            }

            catch (Exception ex)
            {
                //log the exception here
            }

            return book.NumberOfCopies;  
        }

        public void SaveBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }
}
