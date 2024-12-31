// ==== Tipos de datos =====
// Numericos
byte b = 255; // 0 a 255
sbyte sb = 127; // -128 a 127
short s = 32767; // -32768 a 32767
ushort us = 65535; // 0 a 65535
int i = 2147483647; // -2147483648 a 2147483647
uint ui = 4294967295; // 0 a 4294967295
long l = 9223372036854775807; // -9223372036854775808 a 9223372036854775807
ulong ul = 18446744073709551615; // 0 a 18446744073709551615

// Decimales
float f = 3.1415f; // 3.1415
double d = 3.1415d; // 3.1415
decimal de = 3.1415m; // 3.1415
Console.WriteLine($"{b} {sb} {s} {us} {i} {ui} {l} {ul} {f} {d} {de}");

// Caracteres
char c = 'a';
string s1 = "texto";
string s2 = @"texto";
Console.WriteLine($"{c} {s1} {s2}");

// Fecha y hora
DateTime dt = DateTime.Now;
Console.WriteLine(dt);

// Booleanos
bool b1 = true;
Console.WriteLine($"{b1}");

// ==== Informacion por default =====
int i1 = new int();
int? i2 = null;
i2 = 10;
Console.WriteLine($"{i1} {i2}");

// ==== Variables =====
var nombre = "Sergio";
var numero = 0;
// numero = "a";
Console.WriteLine(nombre, numero);

// ==== Objetos =====
object persona = new {
  nombre = "Sergio",
  apellido = "Fernandez"
  };
Console.WriteLine(persona.ToString());
