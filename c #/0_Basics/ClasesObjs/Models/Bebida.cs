using System;

namespace ClasesObjs.Models;

public class Bebida
{
  // Atributos
  public string Nombre { get; set; }
  public int CantidadMl { get; set; }
  public int id { get; set; }

  // Constructores
  public Bebida(string Nombre, int CantidadMl)
  {
    this.CantidadMl = CantidadMl;
    this.Nombre = Nombre;
  }

  // Métodos
  public void Beberse(int CuantoMl)
  {
    this.CantidadMl -= CuantoMl;
  }
}
