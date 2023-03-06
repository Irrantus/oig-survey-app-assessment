using Auth0.AspNetCore.Authentication;
using QuestionnaireUI.Data;
using QuestionnaireUI.Data.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration.GetSection("Auth0Settings").GetValue<string>("Domain");
        options.ClientId = builder.Configuration.GetSection("Auth0Settings").GetValue<string>("ClientId");
    });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5000") });
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddTransient<IQuestionnaireService, QuestionnaireService>();



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
