using app_demo3.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Instanciar la clase Configuración usando la cadena de conexion de appsettings.json
var Configuracion = new Configuracion(builder.Configuration.GetConnectionString("bd_tienda")!);
builder.Services.AddSingleton(Configuracion);

//agregar al contenedor de dependencias la interface y la clase CRUDProducto
builder.Services.AddScoped<IProducto, CRUDProducto>();

//var app = builder.Build();

//agregar al contenedor de dependencias la interface y la clase CRUDCategoria
builder.Services.AddScoped<ICategoria, CRUDCategoria>();

//var app = builder.Build();

//agregar al contenedor de dependencias la interface y la clase CRUDEmpleado
builder.Services.AddScoped<IEmpleado, CRUDEmpleado>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
