using System;
using System.Data.SqlClient;
using Npgsql;
using Faker;
using VeryBadOrm;

class Connection
{
	public string ConnectionString { get; set; }

	public Connection()
	{
		string Server = Environment.GetEnvironmentVariable("DB_HOST");
		string Port = Environment.GetEnvironmentVariable("DB_PORT");
		string User = Environment.GetEnvironmentVariable("DB_USER");
		string Password = Environment.GetEnvironmentVariable("DB_PASSWORD");
		string Database = Environment.GetEnvironmentVariable("DB_NAME");

		this.ConnectionString = String.Format(
			"Server={0}; Port={1}; User Id={2}; Password={3}; Database={4}",
			Server,
			Port,
			User,
			Password,
			Database);
		}
}

static class Program
{
    public static void Main(string[] args)
    {
        Connect(args[0]);
    }


    public static void Connect(string tableName)
    {
		AwfulOrm.CreateRandomData();
		AwfulOrm.ReadData(tableName);
    }
}
