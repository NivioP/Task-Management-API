using Amazon.DynamoDBv2;
using TaskManagementAPI.Data;
using TaskManagementAPI.Repositories;
using TaskManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer(); // Enables endpoint exploration
builder.Services.AddSwaggerGen();

// Add AWS configuration from appsettings.json
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions("AWS"));
builder.Services.AddAWSService<IAmazonDynamoDB>(); // Register DynamoDB client

// Add controllers
builder.Services.AddControllers();

// Add other services
builder.Services.AddScoped<DynamoDbContext>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
}

app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint
app.UseSwaggerUI(c => // Enable middleware to serve swagger-ui
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); // Specify the Swagger JSON endpoint
    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
});

app.MapControllers(); // Map controller routes

app.Run();
