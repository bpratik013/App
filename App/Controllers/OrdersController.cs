using App.Models;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace App.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

       //Post action for Save data to 

        [HttpPost]
        public JsonResult SaveOrder(OrderVM O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext dc = new ApplicationDbContext())
                {
                    Order order = new Order
                    {
                        OrderNo = O.OrderNo,
                        OrderDate = O.OrderDate,
                        Description = O.Description
                    };
                    foreach (var i in O.OrderDetails)
                    {
                        order.OrderDetails.Add(i);
                    }
                    dc.Orders.Add(order);
                    dc.SaveChanges();
                    status = true;
                }
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }


        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            ApplicationDbContext dc = new ApplicationDbContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = dc.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(OrderVM O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext dc = new ApplicationDbContext())
                {
                    Order order = new Order
                    {
                        OrderNo = O.OrderNo,
                        OrderDate = O.OrderDate,
                        Description = O.Description
                    };
                    foreach (var i in O.OrderDetails)
                    {
                        order.OrderDetails.Add(i);
                    }

                    dc.Entry(order).State = EntityState.Modified;
                    dc.SaveChanges();
                    status = true;
                }
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}