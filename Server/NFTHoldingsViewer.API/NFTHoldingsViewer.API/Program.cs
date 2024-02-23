using NFTHoldingsViewer.Application.Services.NFTs;
using NFTHoldingsViewer.Infrastructure.Alchemy;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.local.json");


// Add services to the container.

builder.Services.AddHttpClient<IAlchemyApiClient, AlchemyApiClient>("AlchemyApi", client =>
{
    var baseUrl = builder.Configuration["Alchemy:BaseUrl"]!;
    
    client.BaseAddress = new Uri(baseUrl);  
});

builder.Services.AddScoped<IAlchemyApiClient, AlchemyApiClient>();

builder.Services.AddScoped<INFTService, NFTService>();

builder.Services.AddCors(options =>
{
    var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
    options.AddPolicy("DefaultCors", policy =>
    {
        policy.WithOrigins(allowedOrigin!)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
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

app.UseCors("DefaultCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();