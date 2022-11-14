# BuggedShopApiForTests

Dokumentacja:

Customer Section:
![image](https://user-images.githubusercontent.com/46795587/201528555-dba9fd6d-3848-4f00-a2db-b49e6d14066a.png)

- /GetCustomers - Returns all added or existing customers
- /GetCustomer/{id} - Returns client with specific ID
- /CreateCustomer - Adds new customer : field dateOfBirth should be in format "YYYY-MM-DD"
- /UpdateCustomer - Updates existing customer
- /DeleteCustomer - Delete customer with specific ID

Item Section:
![image](https://user-images.githubusercontent.com/46795587/201528568-dade3291-4fdd-4e9a-b788-2458fa61b040.png)

- /GetItems - Returns all added or existing items
- /GetItem/{id} - Returns item with specific ID
- /CreateItem - Adds new item: field productGroup should be one of product groups: "Alcohol, Tobbaco, Food, Medicine"
- /UpdateItem - Updates existing item
- /DeleteItem - Delete item with specific ID

Basket Section:
![image](https://user-images.githubusercontent.com/46795587/201528540-53bc0e5f-9f57-491f-a860-faec71c98097.png)

- /GetBasketDetails - Returns actual content of basket (customer, items, payments)
- /AddCustomer - Adds customer to basket content
- /AddItem - Adds item to basket content - possible to add multiple items
- /AddPayment - Adds payment to basket content: field paymentMedium must be one of: "Cash, Card, Voucher". Possible to add multiple payments.
- /ValidateBasket: checks corectness of basket content:
   - Required fields: Customer, Items, Payments
   - If sum of payments is equal to sum of Item prices
   - If item with product group: Alcohol or Tobaaco, checks if customer is 18 years old


# Models
- Basket:
![image](https://user-images.githubusercontent.com/46795587/201528599-35ac4083-ad91-4638-b957-6deae547e380.png)
- Customer:
![image](https://user-images.githubusercontent.com/46795587/201528617-5c989d77-cbd0-4d1f-8b96-e5a177960563.png)
- Item:
![image](https://user-images.githubusercontent.com/46795587/201528636-902c8746-de07-48f9-8127-96ddc9bf5d41.png)
- Payment:
![image](https://user-images.githubusercontent.com/46795587/201528645-0a78df60-f0a0-40d9-95e2-034c38cab128.png)
