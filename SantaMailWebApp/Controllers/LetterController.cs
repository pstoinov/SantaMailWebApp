using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace SantaMailWebApp.Controllers
{
    public class LetterController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SaveLetter(string name, string wish)
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

            // Потвърждение и пренасочване
            ViewBag.Message = "Email-a ти е изпратен успешно!";
            return View("Confirmation");
        }
    }
}

