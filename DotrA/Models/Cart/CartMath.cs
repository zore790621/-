using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.Context;
using DotrA_Lab.ORM.RepositoryPattern;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotrA.Models.Cart
{
    public class CartMath : IEnumerable<CartItem>
    {
        private readonly List<CartItem> _cartItems;
        //建構式
        public CartMath()
        {
            this._cartItems = new List<CartItem>();
        }

        public int Count
        {
            get
            {
                return this._cartItems.Count;
            }
        }
        public decimal GetTotal
        {
            get
            {
                decimal getTotal = 0.0m;
                foreach (var cartItem in this._cartItems)
                {
                    getTotal += cartItem.Total;
                }
                return getTotal;
            }
        }


        //新增一筆Product，使用ProductId
        public bool AddProduct(int ProductId)
        {
            var findItem = this._cartItems
                            .Where(s => s.ProductId == ProductId)
                            .Select(s => s)
                            .FirstOrDefault();

            //判斷相同Id的CartItem是否已經存在購物車內
            if (findItem == default(CartItem))
            {   //不存在購物車內，則新增一筆
                var product = (from s in new GenericRepository<Product>(new DotrADbContext()).Reads()
                               where s.ProductID == ProductId
                               select s).FirstOrDefault();
                if (product != default(Product))
                {
                    this.AddProduct(product);
                }
            }
            else
            {   //存在購物車內，則將商品數量累加
                findItem.Quantity += 1;
            }
            return true;
        }
        //新增一筆Product，使用Product物件
        private bool AddProduct(Product product)
        {
            //將Product轉為CartItem
            var cartItem = new CartItem()
            {
                ProductId = product.ProductID,
                ProductName = product.ProductName,
                Price = product.SalesPrice,
                Quantity = 1
            };

            //加入CartItem至購物車
            this._cartItems.Add(cartItem);
            return true;
        }

        //刪除一筆Product，使用ProductId
        public bool RemoveProduct(int ProductId)
        {
            var findItem = this._cartItems
                            .Where(s => s.ProductId == ProductId)
                            .Select(s => s)
                            .FirstOrDefault();

            //判斷相同Id的CartItem是否已經存在購物車內
            if (findItem == default(CartItem))
            {
                //不存在購物車內，不需做任何動作
            }
            else
            {   //存在購物車內，將商品移除
                this._cartItems.Remove(findItem);
            }
            return true;
        }
        #region IEnumerator

        public IEnumerator<CartItem> GetEnumerator()
        {
            return this._cartItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._cartItems.GetEnumerator();
        }
        #endregion
    }
}