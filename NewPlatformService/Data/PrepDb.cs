using System;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using NewPlatformService.Models;

namespace NewPlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder appBuilder, bool isProd)
        {
            using var serviceScope = appBuilder.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);

        }

        public static void ProdMigrations(AppDbContext? context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

        }

        public static void SeedData(AppDbContext? context, bool isProd)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if(isProd)
            {
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"COuld not run migrations! Error: {ex}");
                    throw;
                }
            }

            if (!context.Platforms.Any())
            {
                Console.WriteLine("Insertando datos");
                context.Platforms.AddRange(
                    new Platform
                    {
                        Cost = "Free",
                        Name = "Hola",
                        Publisher = "Yo"
                    },
                    new Platform
                    {
                        Cost = "10,50",
                        Name = "medio",
                        Publisher = "Les Jackson"
                    },
                    new Platform
                    {
                        Cost = "8347",
                        Name = "carisimo",
                        Publisher = "El rey don juan carlos"
                    });
                context.SaveChanges();
            }
        }
    }
}

