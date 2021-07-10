using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;

namespace ZkConstruction.Controllers
{
    public class AbsentUserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AbsentUserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
