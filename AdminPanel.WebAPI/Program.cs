using AdminPanel.WebAPI.Extension;
using AdminPanel.AppSettings;

var builder = WebApplication.CreateBuilder(args);

builder.AppSettingsConfigure();
// Add services to the container.
builder.Services.AddConnectionString();
builder.Services.AddConnectionStringPostgre();
builder.Services.AddCrosAyari();
//builder.Services.AddJwt();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwagerAuthorization();

var app = builder.Build();

//

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.VeriTabaniniKaydet();
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

app.Run();
