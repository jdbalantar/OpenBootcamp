Console.WriteLine("\t\t\t\t\t\t*****Ejercicio #1*****");
Console.WriteLine("Escribe tu nombre: ");
string nombre = Console.ReadLine();
Console.WriteLine("¡Mucho gusto, " + nombre + "!");
Console.ReadKey();

Console.WriteLine("\t\t\t\t\t\t*****Ejercicio #2*****");
string date = DateTime.Now.ToString("hh:mm:ss tt");
Console.WriteLine("Son las " + date);
Console.ReadKey();