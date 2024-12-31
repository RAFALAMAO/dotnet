using System.Text.Json;
using ClasesObjs.Models;

Cerveza cerveza = new (200, "Corona");
cerveza.Beberse(300);

Console.WriteLine($"{cerveza.CantidadMl} {cerveza.Nombre}");

// Serializacion
System.Console.WriteLine("Serializacion");
string cervezaJson = JsonSerializer.Serialize(cerveza);
Console.WriteLine(cervezaJson);

File.WriteAllText("cerveza.json", cervezaJson);

// Deserializacion
Console.WriteLine("Deserializacion");
try
{
  string myJson = File.ReadAllText("cerveza.json");
  Cerveza? cerveza2 = JsonSerializer.Deserialize<Cerveza>(myJson);
  Console.WriteLine(cerveza2?.Nombre);
}
catch (Exception)
{
  Console.WriteLine("El archivo no existe");
}
