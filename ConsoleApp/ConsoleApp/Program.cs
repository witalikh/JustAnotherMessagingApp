using System;
using System.Data.SqlClient;
using Npgsql;
using Faker;

static class Connection
{
    private const string Server = "db.aq.co";
    private const string Port = "";
    private const string User = "";
    private const string Password = "";
    private const string Database = "";
    
    public static string ConnectionString = $"Server={Server}; Port={Port}; User Id={User}; Password={Password}; Database={Database}";
}


static class Program
{
    public static void CreateUser()
    {
        using NpgsqlConnection npgsqlConnection = new(Connection.ConnectionString);
        npgsqlConnection.Open();



        using var cmd = new NpgsqlCommand("INSERT into users(username, email , password, first_name, last_name, phone_number) VALUES (($1), ($2), ($3), ($4), ($5), ($6))", npgsqlConnection)

        {
            Parameters =
            {
                new() { Value = Faker.Internet.UserName() },
                new() { Value = Faker.Internet.Email() },
                new() { Value = Faker.Internet.DomainWord()+Faker.Internet.DomainName() },
                new() { Value = Faker.Name.First() },
                new() { Value = Faker.Name.Last() },
                new() { Value = ((10000000000) + Faker.RandomNumber.Next(100000000000)).ToString().Remove(10)    }
            }
                };

        cmd.ExecuteNonQuery();
    }


    public static void Main()
    {
        Connect();
    }

    public static void Connect()
    {
        for (int i = 0; i < 5; i++)
        {
            CreateUser();
        }
        using NpgsqlConnection npgsqlConnection = new(Connection.ConnectionString);
        npgsqlConnection.Open();

        using NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM users", npgsqlConnection);
        using var reader = command.ExecuteReader();

        Console.WriteLine();

        while (reader.Read())
        {
            Console.WriteLine("Id: " + reader.GetValue(0));
            Console.WriteLine("Name: " + reader.GetString(1));
            Console.WriteLine("Email: " + reader.GetString(2));
            Console.WriteLine("Password: " + reader.GetString(3));
            Console.WriteLine("First Name: " + reader.GetString(4));
            Console.WriteLine("Last Name: " + reader.GetString(5));
            Console.WriteLine("Phone: " + reader.GetString(6));
            Console.WriteLine("---------------------------------");
        }
    }
}
