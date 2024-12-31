// Interface: contrato para respetar las caracteristicas de un objeto
// Clase: es una implementacion de una interface
// Objeto: es una instancia de una clase
using Interfaces.Interfaces;
using Interfaces.Models;

Bebida bebida = new();
Vino vino = new();

MostrarRecomendacion(vino);
MostrarRecomendacion(bebida);

static void MostrarRecomendacion(IBebidaAlcoholica bebida) {
  bebida.MaxRecomendado();
}