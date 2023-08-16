using Microsoft.AspNetCore.Mvc;

namespace AnotherArea.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class TTTController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
