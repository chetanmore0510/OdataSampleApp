using Api.Config;
using Application.Users;
using Domain.Data;
using MediatR;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(AutoMapping));

builder.Services.AddDbContext<SamplesContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(SamplesContext));
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    })
    .AddOData(options =>
    {
        options.TimeZone = TimeZoneInfo.Utc;
        options.Count().Filter().Expand().Select().OrderBy().SetMaxTop(200)
            .AddRouteComponents("odata", EdmModelBuilder.GetEdmModel());
    });

builder.Services.AddMediatR(typeof(GetUsersQueryable).GetTypeInfo().Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
