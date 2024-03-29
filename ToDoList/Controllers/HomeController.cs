using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
      private readonly ToDoListContext _db;

      public HomeController(ToDoListContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
    public ActionResult Index()
    {
      Category[] cats = _db.Categories.ToArray();
      Item[] items = _db.Items.ToArray();
      Dictionary<string,object[]> model = new Dictionary<string, object[]>();
      model.Add("categories", cats);
      model.Add("items", items);
      return View(model);
    }

    }
}

// can also be written as 
// public ActionResult Index()
//     {
//       Category[] cats = _db.Categories.ToArray();
//       Item[] items = _db.Items.ToArray();
//       Dictionary<string,object[]> model = new Dictionary<string, object[]>
//       {
//           { "categories", cats },
//           { "items", items }
//       };
//       return View(model);
//     }

// or
// [HttpGet("/")]
//       public ActionResult Index()
//       {
//         List<Category> cats = _db.Categories.ToList();
//         List<Item> items = _db.Items.ToList();
//         ViewBag.categories = cats;
//         ViewBag.items = items;
//         return View();
//       }

