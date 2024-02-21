using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace UNIπPapers.Models;
public class PaperColorViewModel
{
    public List<Paper>? Papers { get; set; }
    public SelectList? Colors { get; set; }
    public string? PaperColor { get; set; }
    public string? SearchString { get; set; }
}