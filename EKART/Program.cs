using System;
using System.Text;
using EKART;
using EKART.Models;
using EKART.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EKARTContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        builder =>
        {
            builder
                .WithOrigins("http://localhost:4200")  // Angular app URL
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddScoped<ISupplier, SupplierRepository>();
builder.Services.AddScoped<ICategory, CategoryRepository>();
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddScoped<IOrder, OrderRepository>();
builder.Services.AddScoped<IOrderDetail, OrderDetailRepository>();
builder.Services.AddScoped<IJwtRepository, JwtRepository>();
builder.Services.AddDbContext<EKARTContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>                 //// Adding swagger generation service
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "enter your JWT token",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme,
        }

    };
    options.AddSecurityDefinition("Bearer",jwtSecurityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {jwtSecurityScheme,Array.Empty<string>() }
    });
}
    
    );

var jwtKey = builder.Configuration["jwt:Key"];
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,           //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ValidateActor = true,            /////////////////////////////////////              ENABLING THE REQUIRED VALIDATIONS              ////////////////////////////
            ValidateLifetime = true,         //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ValidateIssuerSigningKey = true, //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ValidIssuer = builder.Configuration["jwt:Issuer"],
            ValidAudience = builder.Configuration["jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(          ///////////////////////////////////// Symmetric means the key will be used for creating the signature and also for recalculation //////////////
                Encoding.UTF8.GetBytes(jwtKey)),

        };
    });
builder.Services.AddAuthorization();       //// Adding Authorization service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularClient");
app.UseMiddleware<GlobalException>();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


