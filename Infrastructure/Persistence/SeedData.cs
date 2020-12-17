using System;
using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class SeedData
    {
        public static void Initialize(CoffeeShopContext context)
        {
            context.Database.EnsureCreated();
            if (context.Menus.Any()) return;
            if (context.Users.Any()) return;
            if (context.Orders.Any()) return;
            if (context.DetailOrders.Any()) return;
            if (context.Materials.Any()) return;
            context.Users.AddRange(
                new User
                {
                    Username = "admin",
                    Password = "123456",
                    Role = "admin",
                    Status = 1
                },
                new User
                {
                    Username = "luong",
                    Password = "luong123",
                    Role = "staff",
                    Status = 1
                },
                new User
                {
                    Username = "luat",
                    Password = "luat123",
                    Role = "staff",
                    Status = 1
                }
            );
            context.Menus.AddRange(
                new Menu
                {
                    Name = "Cà phê đá",
                    Genre = "Vietnamese Coffee",
                    Price = 1.49M,
                    //Status = "Còn hàng"
                },

                new Menu
                {
                    Name = "Cà phê sữa",
                    Genre = "Vietnamese Coffee",
                    Price = 2.49M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Bạc xỉu",
                    Genre = "Vietnamese Coffee",
                    Price = 2.49M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Cappuchino",
                    Genre = "Espresso",
                    Price = 1.99M,
                    //Status = "Còn hàng"
                },

                new Menu
                {
                    Name = "Latte",
                    Genre = "Espresso",
                    Price = 1.79M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Mocha",
                    Genre = "Espresso",
                    Price = 1.25M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Breve",
                    Genre = "Espresso",
                    Price = 2.00M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Macchiato",
                    Genre = "Espresso",
                    Price = 1.25M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Caramel Macchiato",
                    Genre = "Espresso",
                    Price = 2.45M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Americano",
                    Genre = "Espresso",
                    Price = 1.45M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Black tea",
                    Genre = "Special Tea",
                    Price = 2.45M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Peach Tea",
                    Genre = "Special Tea",
                    Price = 2.45M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Matcha Latte",
                    Genre = "Special Tea",
                    Price = 2.45M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Matcha Ice Blended",
                    Genre = "Special Tea",
                    Price = 2.49M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Mocha Ice Blended",
                    Genre = "Ice Blended Coffee",
                    Price = 2.49M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Caramel Ice Blended",
                    Genre = "Ice Blended Coffee",
                    Price = 2.45M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Hazelnut Ice Blended",
                    Genre = "Ice Blended Coffee",
                    Price = 2.45M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Cookie Ice Blended",
                    Genre = "Ice Blended Coffee",
                    Price = 2.45M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Chocolate Ice Blended",
                    Genre = "Chocolate",
                    Price = 2.45M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Hot Chocolate Toffee Almond",
                    Genre = "Chocolate",
                    Price = 2.45M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Ice Chocolate Mocha Almond",
                    Genre = "Chocolate",
                    Price = 2.45M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Green Apple Soda",
                    Genre = "Soda",
                    Price = 1.99M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Raspberry Soda",
                    Genre = "Soda",
                    Price = 1.99M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Blueberry Soda",
                    Genre = "Soda",
                    Price = 1.99M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Mojito Lemon",
                    Genre = "Soda",
                    Price = 1.99M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Strawberry Smoothie",
                    Genre = "Soda",
                    Price = 1.99M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Donut",
                    Genre = "Dessert",
                    Price = 1.19M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Cheese Cake",
                    Genre = "Dessert",
                    Price = 2.49M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Cookie",
                    Genre = "Dessert",
                    Price = 1.19M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Apple Pie",
                    Genre = "Dessert",
                    Price = 2.19M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Cup-Cake",
                    Genre = "Dessert",
                    Price = 1.49M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Bánh mì thịt",
                    Genre = "Fast Food",
                    Price = 1.19M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Hot Dog",
                    Genre = "Fast Food",
                    Price = 1.19M,
                    //Status = "Còn hàng"
                },
                new Menu
                {
                    Name = "Hamburger",
                    Genre = "Fast Food",
                    Price = 1.19M,
                    //Status = "Còn hàng"
                }
            );
            context.Orders.AddRange(
                new Order
                {
                    UserNv = "luat",
                    NgayLap = DateTime.Parse("2019-2-12"),
                    TongTien = 1.49M
                },
                 new Order
                 {
                     UserNv = "luong",
                     NgayLap = DateTime.Parse("2019-3-12"),
                     TongTien = 1.46M
                 }
                );
            context.DetailOrders.AddRange(
                new DetailOrder
                {
                    OrderId = 1,
                    MenuId = 1,
                    MenuName = "Chocola",
                    Quantity = 3,
                    Price = 120,
                    Total = 360
                }
                );
            context.SaveChanges();
        }
    }
}