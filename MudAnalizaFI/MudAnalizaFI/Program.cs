using Microsoft.EntityFrameworkCore;
using MudAnalizaFI.Components;
using MudAnalizaFI.Context;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Dodavanje MudBlazor servisa
builder.Services.AddMudServices();
builder.Services.AddHttpClient();

// Dodavanje DbContext-a
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Dodaj kontrolere (API)
builder.Services.AddControllers();

// 🔹 Dodaj CORS – da frontend može da zove API
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:5001") // frontend adresa
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Swagger (dokumentacija API-ja)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Razor + WebAssembly renderovanje
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Dev okruženje
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

// Omogući HTTPS redirekciju
app.UseHttpsRedirection();

// 🔹 Aktiviraj CORS
app.UseCors();

// Antiforgery zaštita (koristi se u Blazoru)
app.UseAntiforgery();

// 🔹 Mapiraj kontrolere
app.MapControllers();

// Statički fajlovi + Blazor server/wasm komponente
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MudAnalizaFI.Client._Imports).Assembly);

// Pokreni aplikaciju
app.Run();
