//using System;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using FunGuide.Data;
//using FunGuide.Models;
//using NuGet.Protocol;

//namespace FunGuide.Controllers
//{
//    public class ShoppingCartController : Controller
//    {
//        FunGuideContext db = new FunGuideContext();
//        private string strCart = "Cart";


//        // GET: ShoppingCart
//        public ActionResult Index()
//        {
//            //var cartItems = GetCartItems();
//            //return View(cartItems);
//            return View();
//        }

//        // GET: AddToCart
//        public ActionResult AddToCart(int id)
//        {
//            var activity = db.Activities.Find(id);
//            if (activity != null)
//            {
//                var cartItem = new CartItem
//                {
//                    Activity = activity,
//                    Quantity = 1,
                    
//                };

//                //db.CartItems.Add(cartItem);
//                db.SaveChanges();
//            }

//            return RedirectToAction("Index");
//        }

//        private class CartItem
//        {
//            public Activities Activity { get; set; }
//            public int Quantity { get; internal set; }
//        }
//    }






//    //public class ShoppingCartController : Controller
//    //{
//    //    FunGuideContext db = new FunGuideContext();
//    //    private string strCart = "Cart";


//    //    public object Session { get; private set; }



//    //    public IActionResult Index()
//    //    {
//    //        return View();
//    //    }

//    //    public IActionResult OrderNow(int? id)
//    //    {
//    //        if (id == null)
//    //        {
//    //            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

//    //        }
//    //        if (Session["strCart"] != null)
//    //        {
//    //            HttpContext.Session.SetString("Test", "Session Value");
//    //            List<Cart> lsCart = (List<Cart>)Session["strCart"];
//    //            lsCart.Add(new Cart(db.Activities.Find(id), 1));
//    //            Session["strCart"] = lsCart;
//    //            HttpContext.Session.SetString("strCart", "lsCart");
//    //        }
//    //        else
//    //        {
//    //            List<Cart> lsCart = new List<Cart>
//    //            {
//    //                new Cart(db.Activities.Find(id), 1)
//    //            };
//    //            Session["strCart"] = lsCart;
//    //        }
//    //        return View("Index");
//    //    }
//    //    public string ShoppingCartId { get; set; }
//    //    public object Session { get; private set; }

//    //    private FunGuideContext _db = new FunGuideContext();

//    //    public const string CartSessionKey = "CartId";

//    //    public void AddToCart(int id)
//    //    {
//    //        // Retrieve the product from the database.
//    //        ShoppingCartId = GetCartId();
//    //        var cartItem = _db.ShoppingCartItems.SingleOrDefault(
//    //        c => c.CartId == ShoppingCartId
//    //        && c.ProductId == id);


//    //        IQueryable<string> shoppingQuery = from m in _context.Activities
//    //                                           orderby m.Category
//    //                                           select m.Category;
//    //        var activity = from m in _context.Activities
//    //                       select m;

//    //    }

//    //}
//}
