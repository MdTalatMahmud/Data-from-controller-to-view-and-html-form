using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Class3.Models;

namespace Class3.Controllers
{
    public class ItemController : Controller
    {
        ItemGateway aGateway = new ItemGateway();
        //GET:
        public ActionResult Save(Item anItem)
        {
            if (anItem.Code!=null && anItem.Name!=null && anItem.UnitPrice!=null)
            {
                aGateway.Save(anItem);
            }
            return View();
        }

        public ActionResult Show()
        {
            List<Item> showList = aGateway.GetTheList();
            return View(showList);
        }
        // GET: Item
        
    }
}