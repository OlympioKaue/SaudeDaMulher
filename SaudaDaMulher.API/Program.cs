using SaudeDaMulher.Infrastrutura.ExtensaoDeDependencia;
using SaudedaMulher.Aplicacao.ExtensaoDeDependencia;
using SaudedaMulher.Aplicacao.Mapster;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Adicionar_Programa();
builder.Services.AdicionarDados(builder.Configuration);

MapsterConfig.RegistrarMapeamento(); // mapeamento de objetos entre DTO e entidade


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
