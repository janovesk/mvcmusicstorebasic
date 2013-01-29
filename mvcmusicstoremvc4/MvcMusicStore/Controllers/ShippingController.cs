using System.Web.Mvc;
using MvcMusicStore.Models;
using ShipmentService.Commands;

namespace MvcMusicStore.Controllers
{
    [Authorize]
    public class ShippingController : Controller
    {
        // GET: /Shipping
        public ActionResult Index(string orderId, string amount)
        {
            ViewBag.OrderId = orderId;
            ViewBag.Amount = amount;
            return View();
        }

        // POST: /Shipping/Address
        [HttpPost]
        public ActionResult Address(FormCollection values)
        {
            var shippingAddress = new ShippingAddress();
            TryUpdateModel(shippingAddress);

            var orderId = values["OrderId"];
            var amount = values["Amount"];

            MvcApplication.Bus.Send<ShipToCommand>(c =>
                                                       {
                                                           c.OrderId = orderId;
                                                           c.Name = shippingAddress.FirstName + " " + shippingAddress.LastName;
                                                           c.Address = shippingAddress.Address;
                                                           c.Zip = shippingAddress.PostalCode;
                                                           c.City = shippingAddress.City;
                                                       });


            //return RedirectToAction("Index", "Payment", new {orderId, amount }); //go to payment
            return RedirectToAction("Complete", "Payment", new { orderId, amount }); //go directly to summary 
        }
    }
}
