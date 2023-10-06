using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    public static class LibraryDbContextSeedData
    {
        static object synchlock = new object();
        static volatile bool seeded = false;

        public static void EnsureSeedData(this LibraryDbContext context)
        {
            if (!seeded && context.Books.Count() == 0)
            {
                lock (synchlock)
                {
                    if (!seeded)
                    {
                        var books = GenerateBooks();
                        context.Books.AddRange(books);
                        context.SaveChanges();
                        seeded = true;
                    }
                }
            }
        }

        public static Book[] GenerateBooks()
        {
            return new Book[]
            {
                new Book
                {
                    Title = "Gone With the Wind",
                    ISBN ="ABC123#25AC",
                    Price = 20,
                    NumberOfCopies = 1
                },

                 new Book
                {
                    Title = "Sherlock Holmes",
                    ISBN ="ABC123#25ACZD",
                    Price = 10,
                    NumberOfCopies = 1
                },

            };
        }
    }
}
