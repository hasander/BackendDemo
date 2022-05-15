using Autofac;
using Autofac.Extensions.DependencyInjection; 
using BackendDemo.BorsaApi.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Call UseServiceProviderFactory on the Host sub property 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Call ConfigureContainer on the Host sub property 



// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.InstallServices(builder.Configuration);
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterAssemblyTypes(Assembly.Load(("BackendDemo.Business"))).Where(t => t.Namespace?.Contains("Service") == true)
       .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
});



var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.InstallServicesApp();
app.MapControllers();

app.Run();
