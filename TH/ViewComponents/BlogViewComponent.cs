using TH.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
namespace TH.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        public readonly HarmicContext _context;
        public BlogViewComponent(HarmicContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult>InvokeAsync()
        {
            var items = _context.TbBlogs.Include(m => m.Category)
                .Where(m=>(bool)m.IsActive);
            return await Task.FromResult<IViewComponentResult>(View(items.OrderByDescending(m=>m.BlogId).ToList()));
        }
    }
}
