using DocumentManagement;
using DocumentManagement.Entities;
using DocumentManagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer("data source=localhost;Database=DocManager;integrated security=True;TrustServerCertificate=True;"));

builder.Services.AddTransient(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddTransient(typeof(IGenericService<User>), typeof(UserService));
builder.Services.AddTransient(typeof(IGenericService<Department>), typeof(DepartmentService));
builder.Services.AddTransient(typeof(IGenericService<Document>), typeof(DocumentService));
builder.Services.AddTransient(typeof(IGenericService<DocumentTemplate>), typeof(DocumentTemplateService));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var applicationDbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
await DatabaseSeeder.SeedAsync(applicationDbContext);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(routeBuilder =>
{
    routeBuilder.MapControllers();
});

app.MapControllers();

app.Run();
