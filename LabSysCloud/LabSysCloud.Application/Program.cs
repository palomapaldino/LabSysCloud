using Microsoft.AspNetCore.Rewrite;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => 
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "LabSysCloud API",
        Version = "v1",
        Description = "API do sistema LabSysCloud, desenvolvido na disciplina de C#",
        Contact = new OpenApiContact () { Name = "ELFUTEC", Email = "coordenacao.elfutec@gmail.com" , Url = new Uri("hppts://www.elfutec")}
    });
});    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "LabSysCloud");
        options.RoutePrefix = string.Empty;
    });
}

var options = new RewriteOptions();
options.AddRedirect("^$", "swagger");

app.UseRewriter(options);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
