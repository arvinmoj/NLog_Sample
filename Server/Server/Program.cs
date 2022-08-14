var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

// Note:

//services.AddTransient<Logging.ILogger, Logging.NLogAdapter>(); // Compile Error!

//services.AddTransient<Logging.ILogger<>, Logging.NLogAdapter<>>(); // Compile Error!

//services.AddSingleton

//	(serviceType: typeof(Logging.ILogger<>),

//	implementationType: typeof(Logging.NLogAdapter<>)); // Runtime Error!



builder.Services.AddTransient
    (serviceType: typeof(Logging.ILogger<>),
    implementationType: typeof(Logging.NLogAdapter<>));

//services.AddTransient

//	(serviceType: typeof(Logging.ILogger<>),

//	implementationType: typeof(Logging.Log4NetAdapter<>));

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