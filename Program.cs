using ba_server.Models.Configuration;
using ba_server.Services;
using ba_server.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<BlockchainOptions>(
  builder.Configuration.GetSection(BlockchainOptions.Blockchain)
);
builder.Services.Configure<AzureOptions>(
  builder.Configuration.GetSection(AzureOptions.Azure)
);

builder.Services.AddSingleton<IUpsiContractService, UpsiContractService>();
builder.Services.AddSingleton<ISecretsService, SecretsService>();

builder.Services.AddControllers();
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