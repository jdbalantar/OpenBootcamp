Console.WriteLine("\t\t\t\t\t\tEjercicio 1");

Console.WriteLine("Escriba su nombre: ");
string nombre = Console.ReadLine();
Console.WriteLine("Escriba su apellido: ");
string apellido = Console.ReadLine();
Console.WriteLine("Escriba su edad: ");
int edad = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("¿Sabe programar?\nSi sabe, escriba 'true'\nSi no sabe, escriba 'false'\nRespuesta: ");
bool programar = Convert.ToBoolean(Console.ReadLine());
string sabe;
if (programar == true)
    sabe = "sabe programar";
else
    sabe = "no sabe programar";
Console.WriteLine(nombre + " " + apellido + " de " + edad + " años y " + sabe);
Console.ReadKey();

Console.WriteLine("\t\t\t\t\t\tEjercicio 2");


Console.WriteLine("\t\t\t\t\t\tAtributos de coche");
int puertas, ruedas;
string marca;
bool itv_vigente;
Console.Write("¿Cuántas puertas tiene?: ");
puertas = Convert.ToInt32(Console.ReadLine());
Console.Write("¿Cuántas ruedas tiene?: ");
ruedas = Convert.ToInt32(Console.ReadLine());
Console.Write("¿De qué marca es?: ");
marca = Console.ReadLine();
Console.Write("¿Tiene el ITV vigente?: ");
Console.WriteLine("Escriba 'true' en caso de que sí, escriba 'false' en caso de que no\n: ");
itv_vigente = Convert.ToBoolean(Console.ReadLine());
Console.ReadKey();

Console.WriteLine("\t\t\t\t\t\tAtributos de mesa");
float peso, largo;
string material, color;
Console.Write("¿Cuánto pesa la mesa?: ");
peso = Convert.ToInt32(Console.ReadLine());
Console.Write("¿Cuánto mide de largo la mesa?: ");
largo = Convert.ToInt32(Console.ReadLine());
Console.Write("¿De qué material está hecha?: ");
material = Console.ReadLine();
Console.Write("¿De qué color es?: ");
color = Console.ReadLine();
Console.ReadKey();

Console.WriteLine("\t\t\t\t\t\tEjercicio 3");
int num = 0;
char car = 'b';
Console.Write(num == 18);
Console.Write(car == 'a');
Console.Write(car == 'a' && num == 0);
Console.Write(car == 'a' || num == 18);
Console.ReadKey();