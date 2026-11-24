var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Nuestra "base de datos" por ahora: una lista en memoria.
var productos = new List<Producto>
{
    new(1, "Teclado", 10),
    new(2, "Mouse", 25),
};

// Una ruta (endpoint) = un método HTTP + una dirección.
app.MapGet("/", () => "Mi primera API en C#");

app.MapGet("/productos", () => productos);

app.MapGet("/productos/{id:int}", (int id) =>
{
    var producto = productos.FirstOrDefault(p => p.Id == id);
    return producto is null ? Results.NotFound() : Results.Ok(producto);
});

app.MapPost("/productos", (NuevoProducto nuevo) =>
{
    var id = productos.Count == 0 ? 1 : productos.Max(p => p.Id) + 1;
    var producto = new Producto(id, nuevo.Nombre, nuevo.Stock);
    productos.Add(producto);
    return Results.Created($"/productos/{id}", producto);
});

app.Run();

record NuevoProducto(string Nombre, int Stock);
record Producto(int Id, string Nombre, int Stock);
