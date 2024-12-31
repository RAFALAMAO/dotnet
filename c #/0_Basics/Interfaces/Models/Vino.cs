using System;
using Interfaces.Interfaces;

namespace Interfaces.Models;

public class Vino : IBebidaAlcoholica
{
  public int Alcohol { get ; set ; }

  public void MaxRecomendado()
  {
    System.Console.WriteLine("Max recomendado: 3 copas");
  }
}
