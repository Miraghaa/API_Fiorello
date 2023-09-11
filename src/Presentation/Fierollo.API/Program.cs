using Fiorello.Application.Validators.CategoryValidator;
using Fiorello.Persistence.Contexts;
using Fiorello.Persistence.Helpers.Mappers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Fluent Validation
builder.Services.AddValidatorsFromAssemblyContaining<CategoryCreateDtoValidator>();
//Automapper paketini dependec yuklemelisen eger basqa yerden dependes edirsense oda boyu ehtimal
builder.Services.AddAutoMapper(typeof(CategoryProfile).Assembly);
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
