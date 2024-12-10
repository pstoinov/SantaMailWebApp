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
            // �������� ���� ������������ ����������
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "letters");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // ��������� �� ��� �� �����
            string fileName = $"{name}_{System.DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string filePath = Path.Combine(directoryPath, fileName);

            // ������������ �� �������
            string content = $"���: {name}\n�������: {wish}\n����: {System.DateTime.Now}";

            // ��������� �� �����
            await System.IO.File.WriteAllTextAsync(filePath, content, Encoding.UTF8);

            // ��������� �� ������������
            Message = "Email-a �� ���� ��������!";
        }
    }
}
