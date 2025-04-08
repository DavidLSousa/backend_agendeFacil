using backend_agendeFacil;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Routers
Routers.Map(app);

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
