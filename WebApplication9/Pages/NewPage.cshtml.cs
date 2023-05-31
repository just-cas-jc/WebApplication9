using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication9.Data;
using WebApplication9.Models;

namespace WebApplication9.Pages
{
    public class NewPageModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public NewPageModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Number { get; set; }

        public List<Item> Items { get; set; }

        public IActionResult OnGet()
        {
            Items = _dbContext.Items.ToList(); // Получаем все сохраненные объекты

            return Page();
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Создание нового объекта и сохранение его в базе данных
                var newItem = new Item
                {
                    Id = Id,
                    Name = Name,
                    Number = Number
                };

                _dbContext.Items.Add(newItem);
                _dbContext.SaveChanges();

                return RedirectToPage("./NewPage");
            }

            return Page();
        }
    }
}
