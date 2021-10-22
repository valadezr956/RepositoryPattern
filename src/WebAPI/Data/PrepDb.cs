using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            Console.WriteLine("--> Attempting to apply migrations...");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not run migrations: {ex.Message}");
            }

            if (!context.Orders.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                List<OrderDET> details = new List<OrderDET>() { new OrderDET() { OrderId = 1, Cost = 1.25, Description = "Bolt", PartNum = "T1245" },
                                                                new OrderDET() { OrderId = 1, Cost = 3.25, Description = "Bolt 2 1/2", PartNum = "U1245" }};

                context.Orders.AddRange(
                    new Order() { Id = 1, SalesOrderID = "11111", Invoice = "Paper", Total = 12.75, Date = DateTime.Now.AddDays(1), 
                        Details = details
                                },
                    new Order() { Id = 2, SalesOrderID = "22222", Invoice = "PDF", Total = 1.25, Date = DateTime.Now.AddDays(2),
                        Details = new List<OrderDET>() { new OrderDET() {OrderId = 2, Cost = 2.25, Description = "Screw", PartNum = "S1445" } }
                                },
                    new Order() { Id = 3, SalesOrderID = "33333", Invoice = "Email", Total = 3.50, Date = DateTime.Now.AddDays(3),
                        Details = new List<OrderDET>() { new OrderDET() {OrderId = 3, Cost = 12.25, Description = "2 X 4 X 1 Stud", PartNum = "S1004" } }
                                }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
