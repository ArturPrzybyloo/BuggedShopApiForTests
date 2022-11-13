# BuggedShopApiForTests

Dokumentacja:

Sekcja Customer:
![image](https://user-images.githubusercontent.com/46795587/201528555-dba9fd6d-3848-4f00-a2db-b49e6d14066a.png)

- /GetCustomers - służy do pobierania listy dodanych/istniejących klientów
- /GetCustomer/{id} - służy do pobrania klienta o konkretnym id
- /CreateCustomer - Służy do dodawania nowego klienta: pole dateOfBirth powinno być w formacie "YYYY-MM-DD"
- /UpdateCustomer - Służy do aktualizacji danych customera
- /DeleteCustomer - Służy do usuwania klienta o konkretnym id

Sekcja Item:
![image](https://user-images.githubusercontent.com/46795587/201528568-dade3291-4fdd-4e9a-b788-2458fa61b040.png)

- /GetItems - służy do pobierania listy dodanych/istniejących przedmiotów
- /GetItem/{id} - służy do pobrania przedmiotu o konkretnym id
- /CreateItem - Służy do dodawania nowego klienta: pole productGroup powinno do wyboru jedno z grup produktowych: "Alcohol, Tobbaco, Food, Medicine"
- /UpdateItem - Służy do aktualizacji danych przedmiotu
- /DeleteItem - Służy do usuwania przedmiotu o konkretnym id

Sekcja Basket:
![image](https://user-images.githubusercontent.com/46795587/201528540-53bc0e5f-9f57-491f-a860-faec71c98097.png)

- /GetBasketDetails - zwraca aktualną zawartość koszyka (customer,item,payment)
- /AddCustomer - dodaje klienta do koszyka
- /AddItem - dodaje przedmiotu o konkretnym ID do koszyka - można dodać wiele przedmiotów
- /AddPayment - dodaje płatność do koszyka: pole paymentMedium musi być jedną z wartości: "Cash, Card, Voucher". Można dodać wiele płatności.
- /ValidateBasket: sprawdza poprawność zawartości koszyka:
   - wymagane pola: Customer, Items, Payments
   - czy suma płatności odpowiada cenie wszystkich kupowanych przedmiotów
   - w przypadku kupowania produktów z grup: "Alcohol, Tobacco" weryfikowany jest wiek klienta


# Modele
Basket:
![image](https://user-images.githubusercontent.com/46795587/201528599-35ac4083-ad91-4638-b957-6deae547e380.png)
Customer:
![image](https://user-images.githubusercontent.com/46795587/201528617-5c989d77-cbd0-4d1f-8b96-e5a177960563.png)
Item:
![image](https://user-images.githubusercontent.com/46795587/201528636-902c8746-de07-48f9-8127-96ddc9bf5d41.png)
Payment:
![image](https://user-images.githubusercontent.com/46795587/201528645-0a78df60-f0a0-40d9-95e2-034c38cab128.png)
