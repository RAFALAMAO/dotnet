using System.Net;
using Newtonsoft.Json;

string API_URL = "https://jsonplaceholder.typicode.com/posts?_limit=5";

var client = new WebClient();
var json = client.DownloadString(new Uri(API_URL));

dynamic posts = JsonConvert.DeserializeObject(json);

foreach (var post in posts)
{
  Console.WriteLine($"{post.id} - {post.title}");
}


