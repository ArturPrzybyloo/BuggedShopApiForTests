using Microsoft.AspNetCore.Mvc;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : Controller
    {
        CustomerController customers = new CustomerController();
        ItemController items = new ItemController();
        public static List<ItemDto> itemList = new List<ItemDto>();
        public static List<PaymentDto> paymentsList = new List<PaymentDto>();
        public static BasketDto basket = new BasketDto();

        [HttpGet("GetBasketDetails")]
        public ActionResult<BasketDto> GetBasketDetails()
        {
            return Ok(basket);
        }


        [HttpPost("AddCustomer")]
        public ActionResult<BasketDto> AddCustomer(int customerId)
        {
            var customer = customers.GetById(customerId).Value;
            basket.Customer = customer;
            return Ok(basket);
        }

        // BUG RETURNS ERROR AFTER ADDING 4 ITEMS
        [HttpPost("AddItem")]
        public  ActionResult<BasketDto> AddItem(int itemId)
        {
            var item = items.GetById(itemId).Value;
            itemList.Add(item);
            basket.Items = itemList;
            if (basket.Items.Count > 4)
            {
                return NotFound("Items list cannot be found");
            }
            return Ok(basket);

        }

        [HttpPost("AddPayment")]
        public ActionResult<BasketDto> AddPayment(string paymentMedium, int amount)
        {
            var payment = new PaymentDto
            {
                PaymentMedium = paymentMedium,
                Amount = amount
            };
            paymentsList.Add(payment);
            if(payment.PaymentMedium != "Cash" ^ payment.PaymentMedium != "Card" ^ payment.PaymentMedium != "Voucher")
            {
                return BadRequest("Payment medium must be one of: Cash, Card, Voucher");
            }
            basket.Payments = paymentsList;
            return Ok(basket);
        }

        // BUG NOT CLEANING UP LISTS WITH ITEMS/PAYMENTS
        [HttpDelete("ClearBasket")]
        public ActionResult<BasketDto> ClearBasket()
        {
            basket = new BasketDto();
            return Ok(basket);
        }

        [HttpPost("ValidateBasket")]
        public ActionResult<BasketDto> ValidateBasket()
        {
            // Validate fields
            if (basket.Customer == null)
            {
                return BadRequest("Please provide customer data");
            }

            if (basket.Items == null)
            {
                return BadRequest("Please add at least one item to basket");
            }

            if (basket.Payments == null)
            {
                return BadRequest("Please provide payments data");
            }

            // Validate payment
            int totalPrice = 0;
            int totalPayment = 0;
            foreach(var item in basket.Items)
            {
                totalPrice += item.Price * item.Quantity;
            }
            foreach(var payment in basket.Payments)
            {
                totalPayment += payment.Amount;
            }

            if (totalPrice > totalPayment)
            {
                return BadRequest($"Payment is not regulated. Total items price is {totalPrice} and {totalPayment} have been paid. Difference: {totalPrice - totalPayment}");
            } 
            else if (totalPrice < totalPayment)
            {
                return BadRequest($"Payment is overpaid. Total items price is {totalPrice} and {totalPayment} have been paid. Difference: {totalPayment - totalPrice}");
            }

            // Validate customer age
            // BUG CUSTOMER WITH AGE 17 CAN BUY ALCOHOL AND TOBBACO
            if (basket.Items.Any(i => i.ProductGroup == "Alcohol" ^ i.ProductGroup == "Tobbaco"))
            {
                var dateOfBirth = DateTime.Parse(basket.Customer.DateOfBirth);
                int age = DateTime.Now.Year - dateOfBirth.Year;
                if (age < 17)
                {
                    return BadRequest("Customer too young to buy articles: Alcohol, Tobbaco");
                }
            }

            return Ok(basket);
        }
    }
}
