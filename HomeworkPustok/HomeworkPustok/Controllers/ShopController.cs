using HomeworkPustok.DAL;
using HomeworkPustok.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeworkPustok.Controllers
{
    public class ShopController : Controller
    {
        private readonly PustokDbContext _context;

        public ShopController(PustokDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int authorId,List<int> genresIds,decimal? minPriceBook,decimal? maxPriceBook )
        {
            var books= _context.Books.Include(x => x.Author).Include(x => x.Images.Where(x => x.PhotoNumber < 3)).Include(x => x.BookTag).ThenInclude(x => x.Tag).Include(x => x.Genre).AsQueryable();

            if (authorId>0)
            {
                books = books.Where(x => x.AuthorId == authorId);
            }
            if (genresIds.Count>0)
            {
                books = books.Where(x => genresIds.Contains(x.GenreId));
            }
            if (minPriceBook!=null)
            {
                books = books.Where(x=>x.Price>minPriceBook && x.Price<maxPriceBook);
            }
			var vm = new ShopVM() 
            { 
                Books=books.ToList(),
                Authors=_context.Authors.Include(x=>x.Books).ToList(),
                Genres=_context.Genres.Include(x=>x.Books).ToList(),
                SelectedAuthorId=authorId,
                SelectedGenres=genresIds,
                minPrice=minPriceBook==null?0:minPriceBook,
                maxPrice=maxPriceBook==null?700:maxPriceBook,
            };



            return View(vm);
        }
    }
}
