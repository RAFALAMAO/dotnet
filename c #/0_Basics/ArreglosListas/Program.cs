// ==== Arreglos Listas ====
// Arreglo de numeros
// ! Es mas eficiente que una lista
using System.Text.Json;
using ArreglosListas.Models;

System.Console.WriteLine("******************* Arreglos");
int[] numeros = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

Console.WriteLine(numeros[2]);

for (int i = 0; i < numeros.Length; i++)
{
  Console.WriteLine("Iteración:" + i + " - " + numeros[i]);
}

foreach (var numero in numeros)
{
  Console.WriteLine(numero);
}

// Listas
System.Console.WriteLine("******************* Listas");
List<int> lista = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
lista.Add(9);
lista.Add(0);
lista.Remove(2);

foreach (var item in lista)
{
  Console.WriteLine(item);
}

List<Cerveza> cervezas = new List<Cerveza>() { new Cerveza("Corona") };
cervezas.Add(new Cerveza("Pilsen"));

Cerveza cervezaStella = new Cerveza("Stella");
cervezas.Add(cervezaStella);

foreach (var cerveza in cervezas)
{
  // Print complete object like json
  Console.WriteLine(JsonSerializer.Serialize(cerveza));
}