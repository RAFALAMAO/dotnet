using System;

namespace ClasesObjs.Models;

public class Cerveza : Bebida
{
  // Los por defecto siempre van al final
  public Cerveza(int CantidadMl, string Nombre = "Cerveza") : base(Nombre, CantidadMl)
  {
  }
}
