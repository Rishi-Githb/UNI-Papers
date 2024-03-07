
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UNIπPapers.Data;
using System;
using System.Linq;
using System.Drawing;

namespace UNIπPapers.Models;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new UNIπPapersContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<UNIπPapersContext>>()))
        {
            // Look for any movies.
            if (context.Paper.Any())

            {
                return;   // DB has been seeded
            }
            context.Paper.AddRange(
                new Paper
                {
                    PaperType = "Bond Paper",
                    Color = "Blue",
                    Size = "A3",
                    Thickness = 20,
                    Qty = 2,
                    Price = 12M,
                    Reviews = "Good"
                },
                new Paper
                {
                    PaperType = "Book Paper",
                    Color = "White",
                    Size = "A5",
                    Thickness = 22,
                    Qty = 5,
                    Price = 8M,
                    Reviews = "Excellent"
                },
                 new Paper
                 {
                     PaperType = "Inkjet Paper",
                     Color = "Bright White",
                     Size = "A4",
                     Thickness = 32,
                     Qty = 100,
                     Price = 25M,
                     Reviews = "Excellent"
                 },
                new Paper
                {
                    PaperType = "Cardstock",
                    Color = "Purple",
                    Size = "A4",
                    Thickness = 110,
                    Qty = 50,
                    Price = 20M,
                    Reviews = "Good"
                },
                 new Paper
                 {
                     PaperType = "Tissue Paper",
                     Color = "White",
                     Size = "A3",
                     Thickness = 17,
                     Qty = 100,
                     Price = 10M,
                     Reviews = "Versatile"
                 },
                 new Paper
                 {
                PaperType = "Fish Paper",
                     Color = "White",
                     Size = "A4",
                     Thickness = 22,
                     Qty = 5,
                     Price = 8M,
                     Reviews = "Good"
                 },
                  new Paper
                  {
                      PaperType = "Blotting Paper",
                      Color = "White",
                      Size = "A3",
                      Thickness = 30,
                      Qty = 100,
                      Price = 55M,
                      Reviews = "Excellent"
                  },
                   new Paper
                   {
                       PaperType = "Art Paper",
                       Color = "Pink",
                       Size = "A3",
                       Thickness = 26,
                       Qty = 50,
                       Price = 25M,
                       Reviews = "Nice"
                   },
                    new Paper
                    {
                        PaperType = "Chart",
                        Color = "Yellow",
                        Size = "A1",
                        Thickness = 20,
                        Qty = 50,
                        Price = 30M,
                        Reviews = "Awosome"
                    },
                     new Paper
                     {
                         PaperType = "Leather Paper",
                         Color = "Any",
                         Size = "A2",
                         Thickness = 25,
                         Qty = 150,
                         Price = 70M,
                         Reviews = "Good"
                     }


            );
            context.SaveChanges();
        }
    }
}
