using System;

namespace ClasesObjs.Models;

public class Post(string title = "", string body = "") : IGeneric
{
  public int userId { get; set; }
  public int id { get; set; }
  public string title { get; set; } = title ?? string.Empty;
  public string body { get; set; } = body ?? string.Empty;
}
