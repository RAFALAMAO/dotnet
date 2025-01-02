using System;

namespace ClasesObjs.Models;

public class Beer(string Name, int Alcohol)
{
  public string Name { get; set; } = Name;
  public int Alcohol { get; set; } = Alcohol;
}
