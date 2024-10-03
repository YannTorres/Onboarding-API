using Onboarding.Infrastructure;
using Onboarding.API.Filters;
using Onboarding.Application;
using Onboarding.Domain.Entities;
using Onboarding.Infrastructure.DataAcess;
using Onboarding.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorizationBuilder();
builder.Services.AddIdentityApiEndpoints<PortalUser>().AddEntityFrameworkStores<PortalAuthDbContext>();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("/auth").MapIdentityApi<PortalUser>();

app.UseAuthorization();

app.MapControllers();

await MigrateDataBase();

app.Run();

async System.Threading.Tasks.Task MigrateDataBase()
{
    await using var scoped = app.Services.CreateAsyncScope();
    await DataBaseMigration.MigrateDataBase(scoped.ServiceProvider);
}