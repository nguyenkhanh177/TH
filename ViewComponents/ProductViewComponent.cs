using TH.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace TH.ViewComponents
{
	public class ProductViewComponent : ViewComponent
	{
		private readonly HarmicContext _context;
		public ProductViewComponent(HarmicContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = _context.TbProducts.Include(m=>m.CategoryProduct)
				.Where(m=>(bool)m.IsActive).Where(m=>m.IsNew);
			return await Task.FromResult<IViewComponentResult>(View(items.OrderBy(m=>m.ProductId).ToList()));
		}
	}
}
