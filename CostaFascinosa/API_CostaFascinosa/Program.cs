using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Implementacion;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using CostaFascinosa.Repositorio.Implementacion;
using CostaFascinosa.Repositorio.Interfaz;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//INYECCIÓN DBCONTEXT
builder.Services.AddDbContext<COSTA_FASCINOSAContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));


//CORS
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("*")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


//INYECCIONES REPOSITORIOS
builder.Services.AddScoped<ICategoria_repository, Categoria_repository>();
builder.Services.AddScoped<ICodVestimenta_repository, CodVestimenta_repository>();
builder.Services.AddScoped<IZona_repository, Zona_repository>();
builder.Services.AddScoped<ITurno_repository, Turno_repository>();
builder.Services.AddScoped<IDestinatario_repository, Destinatario_repository>();
builder.Services.AddScoped<ICordinadore_repository, Cordinadore_repository>();
builder.Services.AddScoped<IPreferenciaAlimenticia, PreferenciasAlimenticias_repository>();
builder.Services.AddScoped<ITematica_repository, Tematica_repository>();
builder.Services.AddScoped<ITiposProducto_repository, TiposProducto_repository>();
builder.Services.AddScoped<ITiposServicio_repository, TiposServicio_repository>();
builder.Services.AddScoped<IPasajero_repository, Pasajero_repository>();
builder.Services.AddScoped<IActividade_repository, Actividade_repository>();
builder.Services.AddScoped<IAmenity_repository, Amenity_repository>();
builder.Services.AddScoped<IUsuario_repository, Usuario_repository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IServicioGastronomico_repository, ServiciosGastronomico_repository>();
builder.Services.AddScoped<IReservasActividade_repository, ReservasActividade_repository>();
builder.Services.AddScoped<IConsumosGastronomico_repository, ConsumosGastronomico_repository>();
builder.Services.AddScoped<IConsumosHabitacione_repository, ConsumosHabitacione_repository>();
builder.Services.AddScoped<IProductosGastronomico_repository, ProductosGastronomico_repository>();
builder.Services.AddScoped<IResenasActividade_repository, ResenasActividade_repository>();
builder.Services.AddScoped<IResenasAmenity_repository, ResenasAmenity_repository>();
builder.Services.AddScoped<IResenasServicio_repository, ResenasServicio_repository>();
builder.Services.AddScoped<IReservasServicio_repository, ReservasServicio_repository>();





//INYECCIONES SERVICIOS
builder.Services.AddScoped<ICategoria_service, Categoria_service>();
builder.Services.AddScoped<ICodVestimenta_service, CodVestimenta_service>();
builder.Services.AddScoped<IZona_service, Zona_service>();
builder.Services.AddScoped<ITurno_service, Turnos_serivce>();
builder.Services.AddScoped<IDestinatario_service, Destinatario_service>();
builder.Services.AddScoped<ICordinadore_service, Cordinadore_service>();
builder.Services.AddScoped<IPreferenciaAlimenticia_service, PreferenciaAlimenticia_service>();
builder.Services.AddScoped<ITematica_service, Tematica_service>();
builder.Services.AddScoped<ITiposProducto_service, TiposProducto_service>();
builder.Services.AddScoped<ITiposServicio_service, TiposServicio_service>();
builder.Services.AddScoped<IPasajero_service, Pasajero_service>();
builder.Services.AddScoped<IUsuario_service, Usuario_Service>();
builder.Services.AddScoped<IActividade_service, Actividade_service>();
builder.Services.AddScoped<IAmenity_service, Amenity_service>();
builder.Services.AddScoped<IServicioGastronomico_service, ServicioGastronomico_service>();
builder.Services.AddScoped<IReservasActividade_service, ReservasActividade_service>();
builder.Services.AddScoped<IReservasServicio_service, ReservasServicio_service>();
builder.Services.AddScoped<IResenasActividade_service, ResenasActividade_service>();
builder.Services.AddScoped<IResenasAmenity_service, ResenasAmenity_service>();
builder.Services.AddScoped<IResenasServicio_service, ResenasServicio_service>();
builder.Services.AddScoped<IConsumosGastronomico_service, ConsumosGastronomico_service>();
builder.Services.AddScoped<IConsumosHabitacione_service, ConsumosHabitacione_service>();
builder.Services.AddScoped<IProductosGastronomico_service, ProductosGastronomico_service>();






builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var jwtSettings = builder.Configuration.GetSection("Jwt");



//JWT
var issuer = jwtSettings.GetValue<string>("Issuer");
var audience = jwtSettings.GetValue<string>("Audience");
var key = jwtSettings.GetValue<string>("Key");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // Cambia a true en producción
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // Usa la clave secreta desde appsettings.json
        };
    });

//Swagger con JWT Bearer
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });

    
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Description = "Ingrese 'Bearer' seguido de un espacio y el token JWT."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
