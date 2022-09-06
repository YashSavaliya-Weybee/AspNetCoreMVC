using BookStore.Enums;
using BookStore.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookModel
    {

        public int ID { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Enter Title of book")]
        //[MyCustomValidation("mvc")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter Author of book")]
        public string Author { get; set; }

        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

        public string Category { set; get; }

        [Required(ErrorMessage = "Select language of book")]
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage = "Enter Total Pages of book")]
        [Display(Name = "Total pages of book")]
        public int? TotalPages { get; set; }

        [Display(Name = "Choose cover image of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }

        public string CoverImageUrl { get; set; }

        [Display(Name = "Choose gallery images of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }


        [Display(Name = "Upload Your book in pdf Formate")]
        [Required]
        public IFormFile BookPdf { get; set; }

        public string BookPdfUrl { get; set; }
    }
}
