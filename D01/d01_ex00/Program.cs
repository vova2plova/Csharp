using d01_ex00;

var customer1 = new Customer("Petya", 1);
var customer2 = new Customer("Vova", 2);
var customer3 = new Customer("Vanya", 3);
customer1.FillCart(15);
customer2.FillCart(15);
customer3.FillCart(15);

var cash = new CashRegister("1")

Console.WriteLine($"{customer1.ToString()} {customer1.Cart},\n{customer2.ToString()} {customer2.Cart},\n{customer3.ToString()} {customer3.Cart}");