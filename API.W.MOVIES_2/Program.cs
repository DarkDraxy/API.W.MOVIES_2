using API.W.MOVIES_2.DAL;
using API.W.MOVIES_2.MoviesMapper;
using API.W.MOVIES_2.Services;
using API.W.MOVIES_2.Services.IServices;
using API.W.MOVIES_2.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using API.W.MOVIES_2.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(ctg => ctg.AddProfile<Mappers>());

//dependency Injection for services
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
//dependency injection for repository
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
