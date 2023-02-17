using AutoMapper;
using Business;
using Business.Utils;
using NEWSHOREAIR.Command;
using NEWSHOREAIR.Mapper;
using RecruitingExternalSource;
using System.ComponentModel;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IJourneyBuilderService, JourneyBuilderService>();
        builder.Services.AddScoped<IBuildJourneyCommand, BuildJourneyCommand>();
        builder.Services.AddScoped<IHttpClient, RecruitingExternalSource.HttpClient>();
        builder.Services.AddScoped<IAppVariables, AppVariables>();
        builder.Services.AddScoped<IAppVariables, AppVariables>();
        builder.Services.AddControllersWithViews();
        
       var mapConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMapperProfile());
        });
        IMapper mapper = mapConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html");

        app.Run();
       
    }
}