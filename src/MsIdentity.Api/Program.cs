var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

// SOLO PARA PROBAR - ELIMINAR AL DESARROLLAR
app.MapGet("/", () => """
Si usas una estructura de clases tradicional con un método principal (Main), el código se ve así:

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("¡Hola, mundo!");
    }
}

Explicación de los elementos
• Console: Es una clase integrada en C# que representa la ventana de la consola de texto.
• WriteLine: Es el método que imprime una línea de texto en la pantalla y salta a la siguiente línea.
• Comillas "": El texto que deseas mostrar debe ir estrictamente encerrado entre comillas dobles.
• Punto y coma ;: Cada instrucción en C# debe terminar obligatoriamente con un punto y coma.
""");

app.Run();