using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookModel
    {
        //[DataType(DataType.EmailAddress)]
        //[Display(Name = "Enter Email")]
        //public String MyField { get; set; }


        public int ID { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Enter Title of book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Enter Author of book")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; }
        public string Category { set; get; }

        [Required(ErrorMessage = "Select language of book")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Enter Total Pages of book")]
        [Display(Name = "Total pages of book")]
        public int? TotalPages { get; set; }
    }
}
