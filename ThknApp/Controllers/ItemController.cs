using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThknApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ThknApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;
        public ItemController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        [Authorize(Roles = "User")]
        public IActionResult ListFood()
        {
            var userName = User.Identity.Name;
            List<Item> RightItems = _db.Items.Where(n => n.ApplicationUser == _db.Users.Where(a => a.Email == userName).FirstOrDefault()).ToList();
            return View(RightItems.Where(f => f.IsItFood == true).ToList());
        }


        [Authorize(Roles = "User")]
        public IActionResult List()
        {
            var userName = User.Identity.Name;
            List<Item> RightItems = _db.Items.Where(n => n.ApplicationUser == _db.Users.Where(a => a.Email == userName).FirstOrDefault()).ToList();
            return View(RightItems);


            //var itemId = _userManager.GetUserId(User);
            //int tempNum = Convert(itemId);


            //IEnumerable<Item> objList = _db.Items.Where(x => x.AppUserId == tempNum);
            //return View(objList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public Dictionary<char, int> letters = new Dictionary<char, int>
        {
            {'a',1},
            {'b',2},
            {'c',3},
            {'d',4},
            {'e',5},
            {'f',6},
            {'g',7},
            {'h',8},
            {'i',9},
            {'j',10},
            {'k',11},
            {'l',12},
            {'m',13},
            {'n',14},
            {'o',15},
            {'p',16},
            {'q',17},
            {'r',18},
            {'s',19},
            {'t',20},
            {'u',21},
            {'v',22},
            {'w',23},
            {'x',24},
            {'y',25},
            {'z',26}
        };
        public int Convert(string str)
        {
            string retNum = "";
            foreach (char l in str)
            {
                if (char.IsNumber(l))
                {
                     retNum += l;

                }
                if (char.IsLetter(l))
                {
                    if (letters.Keys.Contains(l))
                    {
                        retNum += letters.GetValueOrDefault(l);
                    }
                }
            }

            return int.Parse(retNum.Substring(0, 7));
        }


        [HttpPost]
        public IActionResult Create(Item obj)
        {

            var a = User.Identity.Name;
            var u = _db.Users.Where(n => n.Email == a);
            obj.ApplicationUser = u.FirstOrDefault();
            var itemId = _userManager.GetUserId(User);
            int tempNum = Convert(itemId);
            obj.AppUserId = tempNum;
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("List");
        }


        public IActionResult Delete(int? id)
        {
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Items.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Update(obj);
                var itemId = _userManager.GetUserId(User);
                int tempNum = Convert(itemId);
                obj.AppUserId = tempNum;
                _db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(obj);

        }
    }
}
