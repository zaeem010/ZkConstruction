using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Models;
using ZkConstruction.ViewModel;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Customer.OrderByDescending(c=> c.id).ToList());
        }
        public IActionResult Create(Customer customer)
        {
            var viewmodel = new Cutomer_VM
            {
                Cities = _context.City.OrderBy(c=> c.Name).ToList(),
                Customer=customer,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult save(Customer customer,ThirdLevel thirdLevel)
        {
            string direction = "";
                if (customer.id == 0)
            {   
                    var count = _context.ThirdLevel.Where(c => c.AccountTitle == customer.Name && c.Headid == 1).Count();
                
                    
                if (count != 0)
                    {
                        var viewmodel = new Cutomer_VM
                        {
                            Cities = _context.City.OrderBy(c => c.Name).ToList(),
                            Customer = customer,
                        };
                        TempData["Duplicate"] = " Customer With Name " + customer.Name + " Already Exists ";
                    return View("Create",viewmodel);
                }
                else
                {
                    if (_context.ThirdLevel.Where(c => c.Headid == 1).Count() == 0)
                    {
                        customer.AccountNo = 1100001;
                    }
                    else
                    {

                        customer.AccountNo = _context.ThirdLevel.Where(c => c.Headid == 1).Max(x => x.AccountNo) + 1;
                    }
                    _context.Add(customer);
                    _context.Database.ExecuteSqlRaw("INSERT INTO ThirdLevel (AccountNo, Headid, SubHeadid, SecondHeadid, AccountTitle, AccountType, Dr, Cr, Comid) " +
                        "VALUES ('" + customer.AccountNo + "','1','1001','1000002','" + customer.Name + "','Customer',0,0,1)");
                    TempData["Insert"] = "Submitted Successfully";
                    direction = "Create";
                }
            }
                    
                else
                {
                    var db = _context.Customer.SingleOrDefault(c => c.id == customer.id);
                    db.Name = customer.Name;
                    db.Email = customer.Email;
                    db.Mobile = customer.Mobile;
                    db.Tel = customer.Tel;
                    db.Cnic = customer.Cnic;
                    db.City = customer.City;
                    db.Country = customer.Country;
                    db.Address = customer.Address;
                    db.State = customer.State;
                    _context.Database.ExecuteSqlRaw("Update ThirdLevel Set AccountTitle= '" + customer.Name + "' WHERE AccountNo=" + customer.AccountNo + " ");
                    TempData["update"] = "Updated Successfully";
                    direction = "Index";
                }
                _context.SaveChanges();
            
            return RedirectToAction(direction);
        }
        public ActionResult Edit(int? id)
        {
            var listed = _context.Customer.SingleOrDefault(c => c.id == id);
            var viewmodel = new Cutomer_VM
            {
                Customer = listed,
                Cities = _context.City.OrderByDescending(c => c.Name).ToList(),
            };
            return View("Create", viewmodel);
        }
        public IActionResult Delete(int Acc)
        {
            var lst = _context.Customer.SingleOrDefault(c => c.AccountNo == Acc);
            var lstt = _context.ThirdLevel.SingleOrDefault(c => c.AccountNo == Acc);
            _context.Remove(lst);
            _context.Remove(lstt);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
