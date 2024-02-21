
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UNIπPapers.Data;
using System;
using System.Linq;
using UNIπPapers.Data;

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
                    PaperType = "Cardstock",
                    Color = "Purple",
                    Size = "A4",
                    Thickness = 20,
                    Qty = 2,
                    Price = 12M,
                    Reviews = "Good"
                },
                 new Paper
                 {
                     PaperType = "Bond Paper",
                     Color = "Blue",
                     Size = "A3",
                     Thickness = 20,
                     Qty = 2,
                     Price = 12M,
                     Reviews = "Good"
                 }
            );
            context.SaveChanges();
        }
    }
}
