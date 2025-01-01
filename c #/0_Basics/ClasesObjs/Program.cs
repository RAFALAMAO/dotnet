using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using ClasesObjs.Models;
using ClasesObjs.Services;

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
// GetData().Wait();
PostData().Wait();

// ===== Uso de generics ======
var cervezaTest = new Cerveza(200, "Corona");

SendRequest<Cerveza> sendRequest = new SendRequest<Cerveza>();
var respGen = await sendRequest.Send(cervezaTest);
Console.WriteLine(JsonSerializer.Serialize(respGen, new JsonSerializerOptions { WriteIndented = true }));

var postTest = new Post("Esto es un post", "Esto el body");
SendRequest<Post> sendRequestPost = new SendRequest<Post>();
var respGenPost = await sendRequestPost.Send(postTest);
Console.WriteLine(JsonSerializer.Serialize(respGenPost, new JsonSerializerOptions { WriteIndented = true }));


// Functions
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

static async Task PostData() {
  string url = "https://jsonplaceholder.typicode.com/posts";
  HttpClient client = new HttpClient();

  Post post = new Post(){
    userId = 50,
    body = "Esto es una prueba",
    title = "Mi post"
  };

  var data = JsonSerializer.Serialize<Post>(post);
  HttpContent body = new StringContent(data, Encoding.UTF8, "application/json");

  var httpResponse = await client.PostAsync(url,body);

  if (httpResponse.IsSuccessStatusCode) {
    Console.WriteLine("Respuesta exitosa");

    var content = await httpResponse.Content.ReadAsStringAsync();
    var postResult = JsonSerializer.Deserialize<Post>(content);

    Console.WriteLine(JsonSerializer.Serialize(postResult, new JsonSerializerOptions { WriteIndented = true }));
  }
}