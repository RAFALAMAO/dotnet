using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using ClasesObjs.Errors;
using ClasesObjs.Models;
using ClasesObjs.Services;

Cerveza cerveza = new(200, "Corona");
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
// PostData().Wait();

// ===== Uso de generics ======
var cervezaTest = new Cerveza(200, "Corona");

SendRequest<Cerveza> sendRequest = new SendRequest<Cerveza>();
var respGen = await sendRequest.Send(cervezaTest);
Console.WriteLine(JsonSerializer.Serialize(respGen, new JsonSerializerOptions { WriteIndented = true }));

var postTest = new Post("Esto es un post", "Esto el body");
SendRequest<Post> sendRequestPost = new SendRequest<Post>();
var respGenPost = await sendRequestPost.Send(postTest);
Console.WriteLine(JsonSerializer.Serialize(respGenPost, new JsonSerializerOptions { WriteIndented = true }));

// ===== Uso de LINQ ======
// Where
Console.WriteLine("***** Uso de LINQ *****");
List<Cerveza> cervezas2 = new List<Cerveza>() {
  new Cerveza(100, "Corona"),
  new Cerveza(200, "Heineken"),
  new Cerveza(200, "Alare")
};

var numero7 = cervezas2.Where(cerveza => cerveza.Nombre.ToLower().Contains("co")).FirstOrDefault();
Console.WriteLine(JsonSerializer.Serialize(numero7, new JsonSerializerOptions { WriteIndented = true }));

// Ordenar por nombre
var cervezasOrdenadasPorNombre = from c in cervezas2
                                 where c.CantidadMl > 100
                                 orderby c.Nombre
                                 select c;
Console.WriteLine(JsonSerializer.Serialize(cervezasOrdenadasPorNombre, new JsonSerializerOptions { WriteIndented = true }));

// Ordenar datos
List<int> randomNumbers = new List<int>() { 4, 5, 6, 1, 2, 3 };
var ordenados = randomNumbers.OrderBy(x => x).ToList();
Console.WriteLine(JsonSerializer.Serialize(ordenados, new JsonSerializerOptions { WriteIndented = true }));

// Sumar datos
var sum = randomNumbers.Sum(x => x);
Console.WriteLine(sum);

// ===== Objetos complejos =====
List<Bar> bares = new List<Bar>() {
  new Bar("Bar Aaron", new List<Cerveza>(){
    new Cerveza(100, "Corona"),
    new Cerveza(300, "Heineken"),
    new Cerveza(300, "Alare")
  }),
  new Bar("Bar Locos", new List<Cerveza>(){
    new Cerveza(100, "Corona"),
    new Cerveza(200, "Carta Blanca"),
  }),
  new Bar("Bar Carakas", new List<Cerveza>(){
    new Cerveza(100, "Smirnoff"),
    new Cerveza(400, "Sky"),
  })
};
Console.WriteLine(JsonSerializer.Serialize(bares, new JsonSerializerOptions { WriteIndented = true }));

// Obtner los bares por diferentes filtros
var barConSky = bares.Where(bar => bar.Cervezas.Any(cerveza => cerveza.Nombre == "Corona")).ToList();
Console.WriteLine(JsonSerializer.Serialize(barConSky, new JsonSerializerOptions { WriteIndented = true }));

// ===== Uso de Excepciones ======
try
{
  // throw new InvalidOperationException("Esto es una prueba");
  throw new BeerNotFoundException("Esto es una prueba de beer exception");
}
catch (InvalidOperationException)
{
  Console.WriteLine("Ha caido una operación invalida");
}
catch (BeerNotFoundException ex)
{
  // Se utiliza una excepcion personalizada para poder tratar el error
  Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
  Console.WriteLine(ex.Message);
}
finally
{
  Console.WriteLine("Se ejecuta siempre");
}

// ===== Uso de delegado, funciones y actions ======
Mostrar mostrar = Show;
HacerAlgoDelegado(mostrar);

MostrarUpper mostrarUpper = ShowUpper;
HacerAlgoDelegadoUpper(mostrarUpper);

// Ultimo parametro es lo que regresa
Func<string, int> mostrarLength = ShowLength;
HacerAlgoFunc(mostrarLength);

// Uso de Action, este no regresa nada
Action<string, string> mostrarAction = ShowAction;
HacerAlgoAction(mostrarAction);

// Se puede hacer lo mismo con una funcion anonima
Action<string, string> mostrarActionAnon = (string a, string b) =>
{
  Console.WriteLine("Soy una funcion anonima: " + a + " " + b);
};
HacerAlgoAction(mostrarActionAnon);

// ===== Predicados ======
// Sentencia solo true o false
// Reutilizar condiciones
var numbers = new List<int>() { 1, 2, 3, 4, 5 };

var predicado = new Predicate<int>(IsDivider2);
var dividers2 = numbers.FindAll(predicado);

Console.WriteLine(JsonSerializer.Serialize(dividers2, new JsonSerializerOptions { WriteIndented = true }));

Predicate<int> negativePredicade = x => !predicado(x);
var negativeDividers2 = numbers.FindAll(negativePredicade);
Console.WriteLine(JsonSerializer.Serialize(negativeDividers2, new JsonSerializerOptions { WriteIndented = true }));

List<Beer> beers = new List<Beer>()
{
  new("Corona", 100),
  new("Heineken", 300),
  new("Sky Blue", 250),
};

ShowBeerThatIGetDrunk(beers, x => x.Alcohol > 200);

// * Predicados
static bool IsDivider2(int x) => x % 2 == 0;

// * Functions
static void ShowBeerThatIGetDrunk(List<Beer> beers, Predicate <Beer> condition) {
  List<Beer> evilBeers = beers.FindAll(condition);

  Console.WriteLine(JsonSerializer.Serialize(evilBeers, new JsonSerializerOptions { WriteIndented = true }));
}

static async Task GetData()
{
  string url = "https://jsonplaceholder.typicode.com/posts";
  HttpClient client = new HttpClient();

  var httpResponse = client.GetAsync(url);

  if (httpResponse.Result.IsSuccessStatusCode)
  {
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

static async Task PostData()
{
  string url = "https://jsonplaceholder.typicode.com/posts";
  HttpClient client = new HttpClient();

  Post post = new Post()
  {
    userId = 50,
    body = "Esto es una prueba",
    title = "Mi post"
  };

  var data = JsonSerializer.Serialize<Post>(post);
  HttpContent body = new StringContent(data, Encoding.UTF8, "application/json");

  var httpResponse = await client.PostAsync(url, body);

  if (httpResponse.IsSuccessStatusCode)
  {
    Console.WriteLine("Respuesta exitosa");

    var content = await httpResponse.Content.ReadAsStringAsync();
    var postResult = JsonSerializer.Deserialize<Post>(content);

    Console.WriteLine(JsonSerializer.Serialize(postResult, new JsonSerializerOptions { WriteIndented = true }));
  }
}

static void Show(string cad)
{
  Console.WriteLine("Soy un delegado con data: " + cad);
}

static string ShowUpper(string cad)
{
  return cad.ToUpper();
}

static int ShowLength(string cad)
{
  return cad.Length;
}

static void HacerAlgoDelegado(Mostrar mostrarFcn)
{
  mostrarFcn("Esto es una prueba");
}

static void HacerAlgoDelegadoUpper(MostrarUpper mostrarFcn)
{
  var result = mostrarFcn("Esto es una prueba");
  Console.WriteLine(result);
}

static void HacerAlgoFunc(Func<string, int> mostrarFcn)
{
  var result = mostrarFcn("Esto es una prueba");
  Console.WriteLine(result);
}

static void HacerAlgoAction(Action<string, string> mostrarFcn)
{
  mostrarFcn("Esto es una prueba", "del action");
}

// Action no regresa nada
static void ShowAction(string cad, string cad2)
{
  Console.WriteLine("Soy un delegado con data: " + cad + " " + cad2);
}

// * Delegados
delegate void Mostrar(string cadena);
delegate string MostrarUpper(string cadena);