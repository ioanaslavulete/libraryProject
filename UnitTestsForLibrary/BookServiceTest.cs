using LibraryProject;
using LibraryProject.Models;
using LibraryProject.Services;
using Moq;

namespace UnitTestsForLibrary
{
    public class BookServiceTest
    {
        [Fact]
        public void TestGetAllBooks ()
        {
            var context = new Mock<LibraryDbContext>();
            var bookService = new Mock<BookService>();
            var book = new Book
            {
                Title = "Gone With the Wind",
                ISBN = "ABC123#25AC",
                Price = 20,
                NumberOfCopies = 1
            };
            context.Setup(x => x.Books.Add(book));

            var result = bookService.Setup(x => x.GetAllBooks());

            Assert.True(result != null);
        }
    }
}