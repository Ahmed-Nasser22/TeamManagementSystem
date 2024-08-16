using Application.Events;
using Application.Mapping;
using Application.Services;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WebUI.EventHandlers;
using WebUI.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

// Configure in-memory database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("TeamManagementDB"));

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

//Mapping
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register the event handlers
builder.Services.AddScoped<IEventHandler<TaskAssignedEvent>, TaskAssignedEventHandler>();
builder.Services.AddScoped<IEventHandler<TaskStatusUpdatedEvent>, TaskStatusUpdatedEventHandler>();

// Register your services
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<IActivityService, ActivityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<TaskHub>("/taskHub");

app.Run();
