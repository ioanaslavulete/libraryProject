using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    public class Order
    {

        [Key]
        public int Id { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public DateTimeOffset FirstDayOfRental { get; set; }
        public DateTimeOffset LastDayOfRental { get; set; }
        public int TotalPrice { get; set; }
    }
}
