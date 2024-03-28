using WebAPINET6;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
    app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
}

//NET Minimal API example of Get
app.MapGet("/Test", (string firstName, string lastName) => 
    new List<DataSent> { new DataSent { Id = 1, Name = $"{firstName} {lastName}", Description = "Test Data" } });

app.UseAuthorization();

app.MapControllers();

app.Run();
