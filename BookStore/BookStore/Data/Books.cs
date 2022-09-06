using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { set; get; }
        public int LanguageId { get; set; }
        public int TotalPages { get; set; }
        public String CoverImageUrl { get; set; }
        public string BookPdfUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public Language Language { get; set; }

        public ICollection<BookGallery> bookGallery { get; set; }
    }
}
