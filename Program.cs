using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuração da chave secreta para JWT
var key = Encoding.ASCII.GetBytes("sua_chave_secreta_super_segura");

// Configuração da autenticação JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Adiciona suporte a controladores para trabalhar com APIs
builder.Services.AddControllers();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Adiciona autenticação e autorização ao pipeline
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // Mapeia os controllers de API
app.MapRazorPages();   // Mantém suporte ao Razor Pages

app.Run();
