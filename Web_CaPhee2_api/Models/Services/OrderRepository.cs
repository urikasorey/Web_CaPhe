using Web_CaPhee2_api.Data;
using Web_CaPhee2_api.Models.Interface;
namespace Web_CaPhee2_api.Models.Services
{
    public class OrderRepository:IOrderRepository
    {
        private CoffeeshopApiDbContext dbContext;
        private IShoppingCartRepository shopCartRepository;
        public OrderRepository(CoffeeshopApiDbContext dbContext, IShoppingCartRepository shopCartRepository)
        {
            this.dbContext = dbContext;
            this.shopCartRepository = shopCartRepository;
        }
        public void PlaceOrder(Order order)
        {
            var shoppingCartItems = shopCartRepository.GetAllShoppingCartItems();
            order.OrderDetails = new List<OrderDetail>();

            foreach (var item in shoppingCartItems)
            { 
                var orderDetail = new OrderDetail()
                {
                    Quantity = item.Qty,
                    ProductId = item.Product.Id,
                    Price = Convert.ToDecimal(item.Product.Price)
                };


                order.OrderDetails.Add(orderDetail);
            }


            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = shopCartRepository.GetShoppingCartTotal();


            dbContext.Order.Add(order);
           // dbContext.SaveChanges();
        }

    }
}
