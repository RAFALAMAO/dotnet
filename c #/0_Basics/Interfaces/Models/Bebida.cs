using System;
using Interfaces.Interfaces;

namespace Interfaces.Models;

public class Bebida : IBebidaAlcoholica
{
  public int Alcohol { get; set; }

  public void MaxRecomendado()
  {
    Console.WriteLine("Max recomendado: 50%");
  }
}
