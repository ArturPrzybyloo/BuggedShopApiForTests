namespace ShopApi
{
    public class BasketDto
    {
        public DateTime TransactionDate = DateTime.Now;
        public CustomerDto Customer { get; set; }
        public List<ItemDto> Items { get; set; }
        public List<PaymentDto> Payments { get; set; }
    }
}
