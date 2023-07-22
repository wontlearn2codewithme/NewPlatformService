using System;
using System.Runtime.InteropServices;
using NewPlatformService.Models;

namespace NewPlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder appBuilder)
        {
            using var serviceScope = appBuilder.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());

        }

        public static void SeedData(AppDbContext? context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
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

