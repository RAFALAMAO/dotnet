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

// ===== Peticiones http ======
// GET
GetData().Wait();

static async Task GetData() {
  string url = "https://jsonplaceholder.typicode.com/posts";
  HttpClient client = new HttpClient();

  var httpResponse = client.GetAsync(url);

  if (httpResponse.Result.IsSuccessStatusCode) {
    Console.WriteLine("Respuesta exitosa");

    var content = await httpResponse.Result.Content.ReadAsStringAsync();
    List<Post> posts = JsonSerializer.Deserialize<List<Post>>(content);

    Console.WriteLine(JsonSerializer.Serialize(posts, new JsonSerializerOptions { WriteIndented = true }));

    foreach (var post in posts)
    {
      Console.WriteLine(post.id);
    }
  }
}
