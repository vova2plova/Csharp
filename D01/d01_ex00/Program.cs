using d01_ex00;

var customer1 = new Customer("Petya", 1);
var customer2 = new Customer("Vova", 2);
var customer3 = new Customer("Vanya", 3);
List<Customer> list = new List<Customer>();
list.Add(customer1);
list.Add(customer2);
list.Add(customer3);

Store store = new Store(5, 40);
store.Working(list);