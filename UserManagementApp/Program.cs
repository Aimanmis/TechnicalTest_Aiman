var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages(); // Keep this line

// Set default route to /UserManagement
app.MapGet("/", context =>
{
    context.Response.Redirect("/UserManagement");
    return Task.CompletedTask;
});

app.Run();