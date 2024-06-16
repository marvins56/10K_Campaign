using Microsoft.AspNetCore.Mvc;

namespace FSH.Starter.Host.Controllers.Campaign;
public class AccountsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
