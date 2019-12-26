using DotrA.Models.Cart;
using System.Web.Mvc;

namespace DotrA.Controllers
{
    public class ShoppingCartController : Controller
    {
        //取得目前購物車頁面
        public ActionResult GetCart()
        {
            return PartialView("_CartPartial");
        }

        //以id加入Product至購物車，並回傳購物車頁面
        public ActionResult AddToCart(int id)
        {
            var currentCart = Operation.GetCurrentCart();
            currentCart.AddProduct(id);
            return PartialView("_CartPartial");
        }
        //以id刪除Product至購物車，並回傳購物車頁面
        public ActionResult RemoveFromCart(int id)
        {
            var currentCart = Operation.GetCurrentCart();
            currentCart.RemoveProduct(id);
            return PartialView("_CartPartial");
        }
        //以id刪除全部Product至購物車，並回傳購物車頁面
        public ActionResult ClearCart()
        {
            var currentCart = Operation.GetCurrentCart();
            currentCart.ClearCart();
            return PartialView("_CartPartial");
        }
    }
}