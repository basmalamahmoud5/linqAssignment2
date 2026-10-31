
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Product> ProductList = new List<Product>
    {
        new Product { ProductID = 1, ProductName = "Chai", UnitPrice = 18, UnitsInStock = 39, Category = new Category { CategoryName = "Beverages" } },
        new Product { ProductID = 2, ProductName = "Chang", UnitPrice = 19, UnitsInStock = 17, Category = new Category { CategoryName = "Beverages" } },
        new Product { ProductID = 3, ProductName = "Aniseed Syrup", UnitPrice = 10, UnitsInStock = 13, Category = new Category { CategoryName = "Condiments" } },
        new Product { ProductID = 4, ProductName = "Chef Anton", UnitPrice = 22, UnitsInStock = 53, Category = new Category { CategoryName = "Condiments" } },
        new Product { ProductID = 5, ProductName = "Grandma Boysenberry", UnitPrice = 25, UnitsInStock = 120, Category = new Category { CategoryName = "Condiments" } },
        new Product { ProductID = 6, ProductName = "Uncle Bob", UnitPrice = 30, UnitsInStock = 15, Category = new Category { CategoryName = "Condiments" } },
        new Product { ProductID = 7, ProductName = "Mishi Kobe Beef", UnitPrice = 97, UnitsInStock = 29, Category = new Category { CategoryName = "Meat" } },
        new Product { ProductID = 8, ProductName = "Ikura", UnitPrice = 31, UnitsInStock = 24, Category = new Category { CategoryName = "Seafood" } },
        new Product { ProductID = 9, ProductName = "Queso Cabrales", UnitPrice = 21, UnitsInStock = 22, Category = new Category { CategoryName = "Dairy" } },
        new Product { ProductID = 10, ProductName = "Carnarvon Tigers", UnitPrice = 62, UnitsInStock = 42, Category = new Category { CategoryName = "Seafood" } },
        new Product { ProductID = 11, ProductName = "Boston Crab Meat", UnitPrice = 18, UnitsInStock = 20, Category = new Category { CategoryName = "Seafood" } },
        new Product { ProductID = 12, ProductName = "Rogede sild", UnitPrice = 9, UnitsInStock = 5, Category = new Category { CategoryName = "Seafood" } },
        new Product { ProductID = 13, ProductName = "Thuringer Sausage", UnitPrice = 123, UnitsInStock = 0, Category = new Category { CategoryName = "Meat" } },
        new Product { ProductID = 14, ProductName = "Ravioli", UnitPrice = 35, UnitsInStock = 26, Category = new Category { CategoryName = "Grains" } },
        new Product { ProductID = 15, ProductName = "Perth Pasties", UnitPrice = 45, UnitsInStock = 8, Category = new Category { CategoryName = "Grains" } },
        new Product { ProductID = 16, ProductName = "Cote de Blaye", UnitPrice = 263, UnitsInStock = 17, Category = new Category { CategoryName = "Beverages" } },
        new Product { ProductID = 17, ProductName = "Alice Mutton", UnitPrice = 39, UnitsInStock = 0, Category = new Category { CategoryName = "Meat" } },
        new Product { ProductID = 18, ProductName = "Ipoh Coffee", UnitPrice = 46, UnitsInStock = 25, Category = new Category { CategoryName = "Beverages" } }
    };

    static List<Customer> CustomerList = new List<Customer>
    {
        new Customer
        {
            CompanyName = "Alfreds Futterkiste",
            Country = "Germany",
            Orders = new List<Order>
            {
                new Order
                {
                    OrderDetails = new List<OrderDetail>
                    {
                        new OrderDetail { UnitPrice = 18, Quantity = 10 },
                        new OrderDetail { UnitPrice = 30, Quantity = 5 }
                    }
                }
            }
        },
        new Customer
        {
            CompanyName = "Ana Trujillo",
            Country = "Mexico",
            Orders = new List<Order>
            {
                new Order
                {
                    OrderDetails = new List<OrderDetail>
                    {
                        new OrderDetail { UnitPrice = 25, Quantity = 4 }
                    }
                }
            }
        },
        new Customer
        {
            CompanyName = "Antonio Moreno",
            Country = "Mexico",
            Orders = new List<Order>
            {
                new Order
                {
                    OrderDetails = new List<OrderDetail>
                    {
                        new OrderDetail { UnitPrice = 40, Quantity = 3 }
                    }
                }
            }
        },
        new Customer
        {
            CompanyName = "Around the Horn",
            Country = "UK",
            Orders = new List<Order>
            {
                new Order
                {
                    OrderDetails = new List<OrderDetail>
                    {
                        new OrderDetail { UnitPrice = 50, Quantity = 2 }
                    }
                }
            }
        },
        new Customer
        {
            CompanyName = "Berglunds snabbkop",
            Country = "Sweden",
            Orders = new List<Order>()
        }
    };

    static void Main()
    {
        // Question 1
        Console.WriteLine("\nQuestion 1");
        var q1 = ProductList.OrderByDescending(p => p.UnitPrice).Take(3);
        foreach (var p in q1)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        // Question 2
        Console.WriteLine("\nQuestion 2");
        var q2 = ProductList.Skip(5).Take(5);
        foreach (var p in q2)
            Console.WriteLine(p.ProductName);

        // Question 3
        Console.WriteLine("\nQuestion 3");
        var q3 = ProductList.OrderBy(p => p.UnitPrice).TakeWhile(p => p.UnitPrice < 25);
        foreach (var p in q3)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        // Question 4
        Console.WriteLine("\nQuestion 4");
        bool q4 = ProductList
            .Where(p => p.Category.CategoryName == "Seafood")
            .All(p => p.UnitsInStock > 0);
        Console.WriteLine(q4);

        // Question 5
        Console.WriteLine("\nQuestion 5");
        int[] ids = { 3, 9, 13, 18 };
        bool q5 = ids.Contains(9);
        Console.WriteLine(q5);

        // Question 6
        Console.WriteLine("\nQuestion 6");
        var q6 = ProductList.GroupBy(p => p.Category.CategoryName);
        foreach (var group in q6)
            Console.WriteLine($"{group.Key} - {group.Count()}");

        // Question 7
        Console.WriteLine("\nQuestion 7");
        var q7 = ProductList
            .GroupBy(p => p.Category.CategoryName)
            .Select(g => new
            {
                Category = g.Key,
                Products = g.Select(p => p.ProductName)
            });

        foreach (var group in q7)
        {
            Console.WriteLine(group.Category);
            foreach (var name in group.Products)
                Console.WriteLine(name);
        }

        // Question 8
        Console.WriteLine("\nQuestion 8");
        var q8 = ProductList
            .GroupBy(p => p.Category.CategoryName)
            .Where(g => g.Count() > 3);

        foreach (var group in q8)
            Console.WriteLine(group.Key);

        // Question 9
        Console.WriteLine("\nQuestion 9");
        var q9 =
            from c in CustomerList
            group c by c.Country into g
            select new
            {
                Country = g.Key,
                Count = g.Count(),
                TotalOrderValue = g.Sum(c => c.Orders.Sum(o =>
                    o.OrderDetails.Sum(d => d.UnitPrice * d.Quantity)))
            };

        foreach (var item in q9)
            Console.WriteLine($"{item.Country} - {item.Count} - {item.TotalOrderValue}");

        // Question 10
        Console.WriteLine("\nQuestion 10");
        var q10 = ProductList.Sum(p => p.UnitsInStock);
        Console.WriteLine(q10);

        // Question 11
        Console.WriteLine("\nQuestion 11");
        var q11Min = ProductList.Min(p => p.UnitPrice);
        var q11Max = ProductList.Max(p => p.UnitPrice);
        Console.WriteLine($"Cheapest: {q11Min}");
        Console.WriteLine($"Most Expensive: {q11Max}");

        // Question 12
        Console.WriteLine("\nQuestion 12");
        var q12 = ProductList
            .Select(p => p.Category.CategoryName)
            .Distinct();

        foreach (var category in q12)
            Console.WriteLine(category);

        // Question 13
        Console.WriteLine("\nQuestion 13");
        int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
        int[] setB = { 3, 6, 9, 12, 15, 13 };

        var q13 = setA.Except(setB);
        foreach (var id in q13)
            Console.WriteLine(id);

        // Question 14
        Console.WriteLine("\nQuestion 14");
        string[] list1 = { "Germany", "France", "UK", "Spain" };
        string[] list2 = { "france", "SPAIN", "Italy" };

        var q14 = list1.Except(list2, StringComparer.OrdinalIgnoreCase);
        foreach (var country in q14)
            Console.WriteLine(country);

        // Question 15
        Console.WriteLine("\nQuestion 15");
        var q15 = ProductList.ToDictionary(p => p.ProductID);
        var product = q15[18];
        Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");

        // Question 16
        Console.WriteLine("\nQuestion 16");
        var q16 = ProductList.First(p => p.UnitPrice > 50);
        Console.WriteLine(q16.ProductName);

        // Question 17
        Console.WriteLine("\nQuestion 17");
        var q17 = ProductList.FirstOrDefault(p => p.UnitPrice > 500);
        Console.WriteLine(q17?.ProductName ?? "null");

        // Question 18
        Console.WriteLine("\nQuestion 18");
        var q18 = Enumerable.Range(1, 10).Select(i => 7 * i);
        foreach (var number in q18)
            Console.WriteLine(number);

        // Question 19
        Console.WriteLine("\nQuestion 19");
        var q19 = Enumerable.Range(1, 30).Where(n => n % 2 == 0);
        foreach (var number in q19)
            Console.WriteLine(number);

        // Question 20
        Console.WriteLine("\nQuestion 20");
        var q20 = ProductList
            .Take(3)
            .Select(p => p.ProductName)
            .Concat(CustomerList.Take(3).Select(c => c.CompanyName));

        foreach (var name in q20)
            Console.WriteLine(name);

        // Question 21
        Console.WriteLine("\nQuestion 21");
        var q21 = ProductList
            .Zip(CustomerList, (p, c) => $"{p.ProductName} sold to {c.CompanyName}");

        foreach (var item in q21)
            Console.WriteLine(item);
    }
}

class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public Category Category { get; set; }
}

class Category
{
    public string CategoryName { get; set; }
}

class Customer
{
    public string CompanyName { get; set; }
    public string Country { get; set; }
    public List<Order> Orders { get; set; }
}

class Order
{
    public List<OrderDetail> OrderDetails { get; set; }
}

class OrderDetail
{
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}
