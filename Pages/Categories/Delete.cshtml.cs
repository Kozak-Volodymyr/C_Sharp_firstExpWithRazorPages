using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category category { get; set; }

        public void OnGet(int id)
        {
            category = _db.Category.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {

            var categoryFromDb = _db.Category.Find(category.Id);
            if (categoryFromDb != null)
            {
                _db.Category.Remove(categoryFromDb);
                await _db.SaveChangesAsync();

            }
            return RedirectToPage("Index");


            return Page();

        }
    }
}

