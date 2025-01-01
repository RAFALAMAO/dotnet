using System;
using System.Text;
using System.Text.Json;

namespace ClasesObjs.Services;

// Uso de generics
public class SendRequest<T> where T : IGeneric
{
  private HttpClient _client = new HttpClient();

  public async Task<T> Send(T model) {
    string url = "https://jsonplaceholder.typicode.com/posts";

    var data = JsonSerializer.Serialize<T>(model);
    HttpContent body = new StringContent(data, Encoding.UTF8, "application/json");
    var httpResponse = await _client.PostAsync(url, body);

    if (httpResponse.IsSuccessStatusCode) {
      var content = await httpResponse.Content.ReadAsStringAsync();
      return JsonSerializer.Deserialize<T>(content);
    } else {
      return default(T);
    }
  }
}
