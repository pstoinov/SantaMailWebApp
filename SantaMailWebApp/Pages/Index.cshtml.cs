using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace SantaMailWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public string Message { get; set; }

        public async Task OnPostAsync(string name, string wish)
        {
            // Проверка дали директорията съществува
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "letters");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Създаване на име за файла
            string fileName = $"{name}_{System.DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string filePath = Path.Combine(directoryPath, fileName);

            // Съдържанието на писмото
            string content = $"Име: {name}\nЖелание: {wish}\nДата: {System.DateTime.Now}";

            // Записване на файла
            await System.IO.File.WriteAllTextAsync(filePath, content, Encoding.UTF8);

            // Съобщение за потвърждение
            Message = "Email-a ти беше изпратен!";
        }
    }
}
