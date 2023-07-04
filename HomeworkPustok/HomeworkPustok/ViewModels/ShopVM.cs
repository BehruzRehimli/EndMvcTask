using HomeworkPustok.Models;

namespace HomeworkPustok.ViewModels
{
    public class ShopVM
    {
        public List<Book> Books { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Author> Authors { get; set; }   
        public int SelectedAuthorId { get; set; }
        public List<int> SelectedGenres { get; set; } = new List<int>();
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }


    }
}
