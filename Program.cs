var builder = WebApplication.CreateBuilder(args);

// Agregar servicios
builder.Services.AddRazorPages();

var app = builder.Build();

// Configurar el pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// --- ESTO ES LO VITAL ---
// Esto permite que wwwroot funcione normal, sin "magia" rara de .NET 9
app.UseStaticFiles(); 
// ------------------------

app.UseRouting();

app.UseAuthorization();

// --- Ruteo Clásico ---
app.MapRazorPages(); 
// (Nota: Quitamos el .WithStaticAssets() y el MapStaticAssets() que causaban el error)

app.Run();