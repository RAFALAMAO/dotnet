using System;

namespace ClasesObjs.Models;

public class Bar(string Nombre, List<Cerveza> Cervezas)
{
  public string Nombre { get; set; } = Nombre;
  public List<Cerveza> Cervezas { get; set; } = Cervezas;
}
