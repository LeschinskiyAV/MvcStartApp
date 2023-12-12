using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogRepository _repo;

        public LogsController(ILogRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            Request[] logs = await _repo.GetLogs();
            return View(logs);
        }
    }
}
