

using Web.API;
using Infrastructure;
using Application;
using Web.API.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de CORS
builder.Services.AddCorsPolicy();



builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();


var app = builder.Build();

// Usar la política de CORS
app.UseCors("AllowAll");

app.UseAuthentication();  // Primero autenticación
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();

}


app.UseExceptionHandler("/error");
app.UseHttpsRedirection();




app.MapControllers();


app.Run();

