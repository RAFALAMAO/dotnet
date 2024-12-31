using System;

namespace ArreglosListas.Models;

public class Cerveza
{
  public string? Nombre { get; set; }

  public Cerveza(string? nombre)
  {
    this.Nombre = nombre;
  }
}
