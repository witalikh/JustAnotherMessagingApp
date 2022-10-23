using MessangerApp.Application;

namespace MessangerApp;

public class Program
{
	static void Main(string[] args)
	{
		var app = new App(args);
		app.Run();
	}
}
