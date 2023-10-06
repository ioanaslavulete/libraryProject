using LibraryProject.Models;
using LibraryProject.Services;
using Microsoft.Extensions.DependencyInjection;


    var serviceProvider = new ServiceCollection()
        .AddTransient<IBookService, BookService>()
        .AddTransient<IOrderService, OrderService>()
        .BuildServiceProvider();


    var bookService = serviceProvider.GetService<IBookService>();
var orderService = serviceProvider.GetService<IOrderService>();



    
void ReturnABook()
{
    Console.WriteLine("Enter the id of the order: ");
    int id = Int32.Parse(Console.ReadLine());
    orderService.ReturnABook(id);
}

void RentABook()
{
    Console.WriteLine("Enter the id of the book the user wants to rent: ");
    int id = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Enter the last day of rental in format dd/MM/yyyy ");
    DateTimeOffset lastDayOfRental = DateTimeOffset.Parse(Console.ReadLine());
    orderService.RentABook(id, lastDayOfRental);

}

void GetAllOrders()
{
    Console.WriteLine("************Orders**********************");
    Console.WriteLine($"ID        BookId         First Day Of Rental         Last Day Of Rental           Total Price");
    foreach (var order in orderService.GetAllOrders())
    {
        Console.WriteLine($"{order.Id}   {order.BookId}   {order.FirstDayOfRental}   {order.LastDayOfRental}     {order.TotalPrice}");
    }

    Console.ReadKey();
}


 void GetAllBooks()
{

    Console.WriteLine("************Books**********************");
    Console.WriteLine($"ID        Title         ISBN         Price           NumberOfCopies");
    foreach (var book in bookService.GetAllBooks())
    {
        Console.WriteLine($"{book.Id}   {book.Title}   {book.ISBN}  {book.Price}    {book.NumberOfCopies}");
    }

    Console.ReadKey();
}

void GetNumberOfCopies()
{
    Console.WriteLine("Please insert the title of the book you are searching");
    var bookTitle = Console.ReadLine();
    var numberOfCopies = bookService.GetNumberOfCopiesForBook(bookTitle);
 
    Console.WriteLine("The book {0} has {1} copies in our library", bookTitle, numberOfCopies);
}

void SaveBook()
{
    Console.WriteLine("You are about to add a book into the system");

    Book book = new Book();

    Console.WriteLine("Enter book title: ");
    book.Title = Console.ReadLine();

    Console.WriteLine("Enter book ISBN: ");
    book.ISBN = Console.ReadLine();

    Console.WriteLine("Enter book price: ");
    book.Price = Int32.Parse( Console.ReadLine());

    Console.WriteLine("Enter number of copies available: ");
    book.NumberOfCopies = Int32.Parse(Console.ReadLine());

    bookService.SaveBook(book);

}