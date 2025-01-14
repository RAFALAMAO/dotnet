using System;
using System.ComponentModel.DataAnnotations;

namespace TutorialPagina.Models.ViewModels;

public class BeerViewModel
{
  [Required]
  [Display(Name = "Nombre")]
  public required string Name { get; set; }

  [Required]
  [Display(Name = "Marca")]
  public required string IdBrand { get; set; }
}
