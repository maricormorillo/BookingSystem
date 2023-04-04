using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FunGuide.Models;
public class ActivitiesCategoryViewModel
{
    public List<Activities>? Activities { get; set; }
    public SelectList? Category { get; set; }
    public string? ActivitiesCategory { get; set; }
    public string? SearchString { get; set; }
}
