using Microsoft.EntityFrameworkCore;
using TeamWater.Data;
using TeamWater.Services.Token;
using TeamWater.Services.User;
using TeamWater.Services.Episode;
using TeamWater.Services.EpisodeReview;
using TeamWater.Services.TvShow;
using TeamWater.Services.TvShowReview;
using TeamWater.Services.StreamingPlatform;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ITvShowService, TvShowService>();
builder.Services.AddScoped<ITvShowReviewService, TvShowReviewService>();
builder.Services.AddScoped<IEpisodeService, EpisodeService>();
builder.Services.AddScoped<IEpisodeReviewService, EpisodeReviewService>();
builder.Services.AddScoped<IStreamingPlatformService, StreamingPlatformService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "TeamWater.WebAPI",
            Version = "v1"
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
