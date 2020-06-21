using System;
using System.Linq;

namespace LinqToEntitiesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindEntities())
            {
                var numberOfOrders = (
                    from o in context.Orders
                    select o
                    ).Count();

                Console.WriteLine($"Number of orders: {numberOfOrders}");

                var orderDetails = (
                    from o in context.Orders
                    join od in context.Order_Details on o.OrderID equals od.OrderID
                    where o.OrderID == 10248
                    select new { Order = o, OrderDetail = od }
                    ).ToArray();

                foreach (var orderDetail in orderDetails)
                {
                    Console.WriteLine($"OrderID: {orderDetail.Order.OrderID}, ProductID: {orderDetail.OrderDetail.ProductID}");
                }
            }

            Console.ReadLine();
        }
    }
}
