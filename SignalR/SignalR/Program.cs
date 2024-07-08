using Microsoft.AspNetCore.Mvc;
using SignalR.Business;
using SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyHeader()
            .AllowAnyHeader()
                .AllowCredentials()
                    .SetIsOriginAllowed(org => true);
    });
});
builder.Services.AddTransient<MyBusiness>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.MapGet("/", async () =>
{
    return "Hello World!";
});


app.MapHub<MyHub>("/myhub");
app.MapHub<MessageHub>("/messagehub");


app.Run();
