using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Models;

namespace ZkConstruction.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Product.OrderByDescending(c=> c.id).ToList());
        }
        public IActionResult Create(Product Product)
        {
            return View(Product);
        }
        [HttpPost]
        public IActionResult Save(Product Product, string[] Na ,decimal[] Cp,decimal[] Sp ,string Nae ,decimal Cpe,decimal Spe)
        {
            string dir = "";
            if(Product.id == 0)
            {
                for (int i = 0; i < Na.Count(); i++)
                {
                    _context.Database.ExecuteSqlRaw("INSERT INTO Product (Name, CostPrice, SalePrice) VALUES " +
                    "('"+ Na[i] +"','"+ Cp[i] +"','"+ Sp[i] +"') ");
                }
                TempData["Insert"] = "Inserted Successfully.";
                dir = "Create";
            }
            else
            {
                _context.Database.ExecuteSqlRaw("UPDATE Product SET Name ='"+ Nae +"', CostPrice ='"+ Cpe +"', SalePrice ='"+ Spe +"' WHERE (id ='"+ Product.id +"')");
                TempData["Update"] = "Updated Successfully.";
                dir = "Index";
            }
            return RedirectToAction(dir);
        }
        public IActionResult Edit(int id)
        {
            var lst = _context.Product.SingleOrDefault(c=> c.id == id);
            return View("Create",lst);
        }
    }
}
