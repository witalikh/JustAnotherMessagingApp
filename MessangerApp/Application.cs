using System.Linq;
using Microsoft.EntityFrameworkCore;

using MessangerApp.Helpers.Authorization;
using MessangerApp.Helpers.Common;
using MessangerApp.Middleware.Common;
using MessangerApp.Middleware.Authorization;
using MessangerApp.Entities.Users;

using DA = MessangerApp.DataAccess;
using BCryptNet = BCrypt.Net;

namespace MessangerApp.Application;

public class App
{
	private WebApplicationBuilder _builder;
	private WebApplication _app;

	public App(string[] args)
	{
		_builder = WebApplication.CreateBuilder(args);
		SetUpBuilder();
		ConfigureApp();
		ParseArgs(args);
	}

	private void ParseArgs(string[] args)
	{
		if (args.Any(s => "migrate".Contains(s)))
			MigrateDB();
		if (args.Any(s => "createfakedata".Contains(s)))
			CreateFakeData();
	}

	public void Run()
	{
		_app.Run();
	}

	public void SetUpBuilder()
	{
		_builder.Services.AddCors();
		_builder.Services.AddControllers();

		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		_builder.Services.AddEndpointsApiExplorer();
		_builder.Services.AddSwaggerGen();
		_builder.Services.AddAutoMapper(typeof(Program));
		_builder.Services.Configure<AppSettings>(_builder.Configuration.GetSection("AppSettings"));

		AddServices();
	}

	public void ConfigureApp()
	{
		_app = _builder.Build();

		// Configure the HTTP request pipeline.
		if (_app.Environment.IsDevelopment())
		{
			_app.UseSwagger();
			_app.UseSwaggerUI();
		}

		_app.UseHttpsRedirection();
		_app.UseAuthorization();
		_app.MapControllers();

		// configure HTTP request pipeline
		// global cors policy
		_app.UseCors(x => x
			.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader());

		// global error handler
		_app.UseMiddleware<ErrorHandlerMiddleware>();

		// custom jwt auth middleware
		_app.UseMiddleware<JwtMiddleware>();
		_app.MapControllers();

		var webSocketOptions = new WebSocketOptions {
			KeepAliveInterval = TimeSpan.FromSeconds(10)
		};
		_app.UseWebSockets(webSocketOptions);

		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
	}

	public void AddServices()
	{
		_builder.Services.AddDbContext<DA.Contexts.PostgreSqlContext>(
			options => options.UseNpgsql(_builder.Configuration.GetConnectionString("DefaultConnection")));

		_builder.Services.AddScoped<IJwtUtils, JwtUtils>();

		// User providers
		_builder.Services.AddScoped<
			DA.Users.Interfaces.IUserDataAccessProvider,
			DA.Users.Providers.UserDataAccessProvider>();

		_builder.Services.AddScoped<
			DA.Users.Interfaces.IUserBlacklistDataAccessProvider,
			DA.Users.Providers.UserBlacklistDataAccessProvider>();

		// Message providers
		_builder.Services.AddScoped<
			DA.Messages.Interfaces.IMessageDataAccessProvider,
			DA.Messages.Providers.MessageDataAccessProvider>();

		_builder.Services.AddScoped<
			DA.Messages.Interfaces.IAdditionalContentDataAccessProvider,
			DA.Messages.Providers.AdditionalContentDataAccessProvider>();

		// Chat contexts
		_builder.Services.AddScoped<
			DA.Chats.Interfaces.IChatDataAccessProvider,
			DA.Chats.Providers.ChatDataAccessProvider>();

		_builder.Services.AddScoped<
			DA.Chats.Interfaces.IChatMemberDataAccessProvider,
			DA.Chats.Providers.ChatMemberDataAccessProvider>();

		_builder.Services.AddScoped<
			DA.Chats.Interfaces.IChatInvitationDataAccessProvider,
			DA.Chats.Providers.ChatInvitationDataAccessProvider>();

		_builder.Services.AddScoped<
			DA.Chats.Interfaces.IChatJoinRequestDataAccessProvider,
			DA.Chats.Providers.ChatJoinRequestDataAccessProvider>();

		_builder.Services.AddScoped<
			DA.Chats.Interfaces.IChatRoleDataAccessProvider,
			DA.Chats.Providers.ChatRoleDataAccessProvider>();

		_builder.Services.AddScoped<
			DA.Chats.Interfaces.IChatBlacklistDataAccessProvider,
			DA.Chats.Providers.ChatBlacklistDataAccessProvider>();
	}

	public void MigrateDB()
	{
		// migrate any database changes on startup (includes initial db creation)
		using (var localScope = _app.Services.CreateScope())
		{
			var postgreSqlContext = localScope.ServiceProvider.GetRequiredService<DA.Contexts.PostgreSqlContext>();
			postgreSqlContext.Database.Migrate();
		}
	}

	public void CreateFakeData()
	{
		var localScope = _app.Services.CreateScope();
		var faker = new FakeDataGenerator(localScope);
		faker.GenerateFakeData(50);
	}
}
