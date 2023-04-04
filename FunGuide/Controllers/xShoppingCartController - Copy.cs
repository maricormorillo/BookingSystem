//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using FunGuide.Data;
//using FunGuide.Models; 

//namespace FunGuide.Controllers
//{
//    public class ShoppingCartController : Controller
//    {
//        public string ShoppingCartId { get; set; }

//        private FunGuideContext _db = new FunGuideContext();

//        public const string CartSessionKey = "CartId";

//        public void AddToCart(int id)
//        {
//            // Retrieve the product from the database.
//            ShoppingCartId = GetCartId();
//            var cartItem = _db.ShoppingCartItems.SingleOrDefault(
//            c => c.CartId == ShoppingCartId
//            && c.ProductId == id);


//            IQueryable<string> shoppingQuery = from m in _context.Activities
//                                               orderby m.Category
//                                               select m.Category;
//            var activity = from m in _context.Activities
//                           select m;

//        }
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
