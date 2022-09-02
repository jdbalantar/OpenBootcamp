Cliente cliente = new Cliente("Juan David", 3005241436, "Mi dirección en COLOMBIA", "correo@gmail.com", true);
Console.WriteLine($"Información del cliente: {cliente}");
Console.ReadKey();  

public struct Cliente
{
    public Cliente(string nombre, long telefono, string direccion, string email, bool isNew)
    {
        Nombre = nombre;
        Telefono = telefono;
        Direccion = direccion;
        Email = email;
        IsNew = isNew;

    }

    public string Nombre { get; set; }
    public long Telefono { get; set; }
    public string Direccion { get; set; }
    public  string Email { get; set; }
    public bool IsNew { get; set; }

    public override string ToString() => $"{Nombre}, {Telefono}, {Direccion}, {Email}, {IsNew}";
}
