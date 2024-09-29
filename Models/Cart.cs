namespace WebApplication210924_CartProduct.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Product product)
        {
            var item = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                Items.Add(new CartItem { Product = product, Quantity = 1 });
            }
        }

        public decimal TotalPrice => Items.Sum(i => i.Product.Price * i.Quantity);
    }
}
