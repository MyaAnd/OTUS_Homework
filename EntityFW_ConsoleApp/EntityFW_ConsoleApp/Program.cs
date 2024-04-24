// See https://aka.ms/new-console-template for more information
using EntityFW_ConsoleApp;
using EntityFW_ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");
ClearTables();
FillTables();
AddNewProduct(new Product() { ProductName = "Elden Ring", Description = "VideoGame", Price = 3000, QuantityInStock = 5 });
UpdatePrice(1, 777);
GetAllOrdersForUser(1);
GetAllOrdersForUserByName("Ibragim");
GetAllOrdersForUserByName("NetTakih");
GetOrderPrice(1);
GetRemainingProductCount(1);
GetTop5PricyProducts();
GetExpiringProducts();

static void ClearTables()
{
    using (var db = new DBDataContext())
    {
        db.Products.RemoveRange(db.Products);
        db.Users.RemoveRange(db.Users);
        db.Orders.RemoveRange(db.Orders);
        db.OrderDetails.RemoveRange(db.OrderDetails);

        db.SaveChanges();
    }
}

static void AddProductToDB(DBDataContext db, Product product)
{
    db.Products.Add(product);
    db.SaveChanges();
}

static void AddUserToDB(DBDataContext db, User user)
{
    db.Users.Add(user);
    db.SaveChanges();
}

static void AddOrderToDB(DBDataContext db, Order order)
{
    db.Orders.Add(order);
    db.SaveChanges();
}

static void AddOrderDetails(DBDataContext db, OrderInfo orderInfo)
{
    if (orderInfo.TotalCost == 0)
    {
        var product = db.Products.First(el => el.ProductID == orderInfo.ProductID);
        orderInfo.TotalCost = orderInfo.Quantity * product.Price;
    }

    db.OrderDetails.Add(orderInfo);
    db.SaveChanges();
}

static void FillTables()
{
    using (var db = new DBDataContext())
    {
        AddProductToDB(db, new Product()
        { ProductID = 1, ProductName = "Apple", Description = "Fruit", Price = 10, QuantityInStock = 50 });

        AddProductToDB(db, new Product()
        { ProductID = 2, ProductName = "Potato", Description = "Vegetable", Price = 3, QuantityInStock = 200 });

        AddProductToDB(db, new Product()
        { ProductID = 3, ProductName = "Chicken", Description = "Meat", Price = 100, QuantityInStock = 10 });

        AddProductToDB(db, new Product()
        { ProductID = 4, ProductName = "Tomato", Description = "Vegetable", Price = 5, QuantityInStock = 30 });

        AddProductToDB(db, new Product()
        { ProductID = 5, ProductName = "Table", Description = "Furniture", Price = 500, QuantityInStock = 20 });

        AddProductToDB(db, new Product()
        { ProductID = 6, ProductName = "Chair", Description = "Furniture", Price = 250, QuantityInStock = 3 });

        AddProductToDB(db, new Product()
        { ProductID = 7, ProductName = "Uno", Description = "TableTop Game", Price = 40, QuantityInStock = 2 });

        AddUserToDB(db, new User() { UserID = 1, UserName = "Vasya", Email = "", RegistrationDate = DateTime.Now });
        AddUserToDB(db, new User() { UserID = 2, UserName = "Ibragim", Email = "mail@mail.ru", RegistrationDate = DateTime.Now.AddDays(-1) });

        AddOrderToDB(db, new Order() { OrderID = 1, OrderDate = DateTime.Now, Status = OrderStatus.Created, UserID = 1 });
        AddOrderDetails(db, new OrderInfo() { OrderDetailID = 1, OrderID = 1, ProductID = 2, Quantity = 10});

        AddOrderToDB(db, new Order() { OrderID = 2, OrderDate = DateTime.Now, Status = OrderStatus.Created, UserID = 2 });
        AddOrderDetails(db, new OrderInfo() { OrderDetailID = 2, OrderID = 2, ProductID = 1, Quantity = 46 });

        AddOrderToDB(db, new Order() { OrderID = 3, OrderDate = DateTime.Now, Status = OrderStatus.Delivered, UserID = 1 });
        AddOrderDetails(db, new OrderInfo() { OrderDetailID = 3, OrderID = 3, ProductID = 3, Quantity = 10 });


        db.SaveChanges();


    }
}

static void AddNewProduct(Product product)
{
    using (var db = new DBDataContext())
    {
        db.Products.Add(product);
        db.SaveChanges();
    }
}

static void UpdatePrice(int prodId, double newPrice)
{
    using (var db = new DBDataContext())
    {
        var productToUpdate = db.Products.First(el => el.ProductID == prodId);
        productToUpdate.Price = newPrice;
        var query = db.OrderDetails.Where(el => el.ProductID == prodId);

        foreach(var orderDetails in query)
        {
            orderDetails.TotalCost = orderDetails.Quantity * newPrice;
        }

        db.SaveChanges();
    }
}

static List<Order> GetAllOrdersForUser(int userID)
{
    using (var db = new DBDataContext())
    {
        //db.Orders.ToList();
        //var result = db.Users.First(el => el.UserID == userID).Orders.ToList
        db.OrderDetails.ToList();

        var result = db.Orders.Where(el => el.UserID == userID).ToList();

        return result;
    }
}

static List<Order> GetAllOrdersForUserByName(string userName)
{
    using (var db = new DBDataContext())
    {
        db.OrderDetails.ToList();

        var result = db.Orders.Where(el => el.UserData.UserName == userName).ToList();

        return result;
    }
}

static double GetOrderPrice(int orderID)
{
    using (var db = new DBDataContext())
    {
        var order = db.Orders.Find(orderID);
        var price = db.OrderDetails.First(el => el.OrderID == order.OrderID).TotalCost;
        return price;
    }
}

static int GetRemainingProductCount(int productID)
{
    using (var db = new DBDataContext())
    {
        int originalQuantity = db.Products.Find(productID).QuantityInStock;
        var orderWithProd = db.OrderDetails.Where(el => (el.ProductID == productID)).Include(el => el.OrderData);
        var orderQuantity = orderWithProd.Where(el => el.OrderData.Status == OrderStatus.Created).Select(el => el.Quantity).Sum();

        return originalQuantity - orderQuantity;
    }
}

static List<Product> GetTop5PricyProducts()
{
    using (var db = new DBDataContext())
    {
        var result = db.Products.OrderByDescending(el => el.Price).Take(5).ToList();
        return result;
    }
}

static List<Product> GetExpiringProducts()
{
    using (var db = new DBDataContext())
    {
        var result = db.Products.Where(el => (el.QuantityInStock - db.OrderDetails.Where(od => od.ProductID == el.ProductID).Select(od => od.Quantity).Sum())
            < 5).ToList();
        //var products = db.Products.ToList();
        //List<Product> result = new List<Product>();
        //foreach (var product in products)
        //{
        //    if (GetRemainingProductCount(product.ProductID) < 5)
        //    {
        //        result.Add(product);
        //    }
        //}

        return result;
    }
}