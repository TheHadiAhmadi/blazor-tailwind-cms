using blazor_tailwind_cms.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => {
    return new ViewState();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

public class ViewState
{
    public Dictionary<string, string> Value { get; set; } = [];
    public Action OnCssChanged { get; set; }


    public void AddCssFile(string name) 
    {
        if(!Value.ContainsKey(name))
        {
            Value.Add(name, $"<link rel=\"stylesheet\" href=\"/{name}.css\">");
            OnCssChanged.Invoke();
        }
    }
    
    public void RemoveCssFile(string name) 
    {
        if(Value.ContainsKey(name))
        {
            Value.Remove(name);
            OnCssChanged.Invoke();
        }
    }
};

// check cmponent library readme, ... 