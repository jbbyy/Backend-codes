using LayeredApp.Model;
using LayeredApp.REPO;
using LayeredApp.Services;
using Microsoft.EntityFrameworkCore;
using LayeredApp.Middlewares;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Consul;
using LayeredAppDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
{
    consulConfig.Address = new System.Uri(builder.Configuration["ConsulConfig:ConsulAddress"]);
}));

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
builder.Services.AddScoped<ICustomer, CustomerRep>();
builder.Services.AddScoped<ICustService, CustomerService>();



// Add services to the container.

//To perform authentication
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This_is_secret_key"));
//key from 1st mircoservice which generates the token 
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //to validate based on eg: issue key
}).AddJwtBearer(x => x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
{

    //validate key against key at microservice 1
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = key,
    //validate issuer
    ValidateIssuer = true,
    ValidIssuer = "authapi",
    //validate by audience
    ValidateAudience =true,
    ValidAudience = "productapi",


});

//WithOrigins("http://localhost:4200") -> allow specific origins/URL to access. Able to allow multiple 
//any header : HTTP
//any method : Get post put delete
builder.Services.AddCors(options => options.AddPolicy("MyCorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin())); 
//.AllowAnyOrigin() this will allow access to anyone 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseConsul(builder.Configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyCorsPolicy");
//use a middle ware to check your cors policy
app.UseHandleExceptionMiddleware();
app.UseAuthorization().UseAuthorization();
//need to add in use authorization to check authorization

app.MapControllers();

app.Run();
