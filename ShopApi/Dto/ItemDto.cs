using ShopApi.Common;

namespace ShopApi
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string ProductGroup { get; set; }

    }
}
