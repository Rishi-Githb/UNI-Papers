using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNIπPapers.Models;

public class Paper
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    [Display(Name = "Paper Type")]
    public string? PaperType { get; set; }


    [StringLength(60, MinimumLength = 3)]
    [Required] 
    public string? Color { get; set; }
    public string? Size { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Thickness { get; set; }

    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Qty { get; set; }

    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    public string? Reviews { get; set; }
}