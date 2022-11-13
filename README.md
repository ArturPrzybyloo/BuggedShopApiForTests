# BuggedShopApiForTests

Dokumentacja:

Sekcja Customer:
- /GetCustomers - służy do pobierania listy dodanych/istniejących klientów
- /GetCustomer/{id} - służy do pobrania klienta o konkretnym id
- /CreateCustomer - Służy do dodawania nowego klienta: pole dateOfBirth powinno być w formacie "YYYY-MM-DD"
- /UpdateCustomer - Służy do aktualizacji danych customera
- /DeleteCustomer - Służy do usuwania klienta o konkretnym id

Sekcja Item:
- /GetItems - służy do pobierania listy dodanych/istniejących przedmiotów
- /GetItem/{id} - służy do pobrania przedmiotu o konkretnym id
- /CreateItem - Służy do dodawania nowego klienta: pole productGroup powinno do wyboru jedno z grup produktowych: "Alcohol, Tobbaco, Food, Medicine"
- /UpdateItem - Służy do aktualizacji danych przedmiotu
- /DeleteItem - Służy do usuwania przedmiotu o konkretnym id

Sekcja Basket:
- /GetBasketDetails - zwraca aktualną zawartość koszyka (customer,item,payment)
- /AddCustomer - dodaje klienta do koszyka
- /AddItem - dodaje przedmiotu o konkretnym ID do koszyka - można dodać wiele przedmiotów
- /AddPayment - dodaje płatność do koszyka: pole paymentMedium musi być jedną z wartości: "Cash, Card, Voucher". Można dodać wiele płatności.
- /ValidateBasket: sprawdza poprawność zawartości koszyka:
   - wymagane pola: Customer, Items, Payments
   - czy suma płatności odpowiada cenie wszystkich kupowanych przedmiotów
   - w przypadku kupowania produktów z grup: "Alcohol, Tobacco" weryfikowany jest wiek klienta
