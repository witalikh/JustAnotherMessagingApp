using System;
using Npgsql;

namespace VeryBadOrm
{
	public class AwfulOrm
	{
		public static void CreateUser()
		{
			var connection = new Connection();
			using NpgsqlConnection npgsqlConnection = new(connection.ConnectionString);
			npgsqlConnection.Open();

			using var cmd = new NpgsqlCommand(
				"INSERT into users(username, email , password, first_name, last_name, phone_number)" +
				"VALUES (($1), ($2), ($3), ($4), ($5), ($6))",
				npgsqlConnection)
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

		public static void CreateChat()
		{
			var connection = new Connection();
			using NpgsqlConnection npgsqlConnection = new(connection.ConnectionString);
			npgsqlConnection.Open();

			var rand = new Random();
			string[] chatVisibilityChoices = {"pub", "pub+", "prvt", "dialog"};

			using var cmd = new NpgsqlCommand(
				"INSERT into chats(" +
				"name, description, owner_id, " +
				"visibility, default_write_messages, default_invite_persons, " +
				"default_send_files, join_link) " +
				"VALUES (($1), ($2), ($3), ($4)::chat_visibility, ($5), ($6), ($7), ($8))",
				npgsqlConnection)
			{
				Parameters = {
					new () { Value = Faker.Company.Name() },
					new () { Value = Faker.Lorem.Paragraph() },
					new () { Value = rand.Next(1, 10) },
					new () { Value = chatVisibilityChoices[rand.Next(0, chatVisibilityChoices.Length)] },
					new () { Value = rand.Next(0, 2) != 0 },
					new () { Value = rand.Next(0, 2) != 0 },
					new () { Value = rand.Next(0, 2) != 0 },
					new () { Value = Faker.Internet.Url() }
				}
			};

			cmd.ExecuteNonQuery();
		}

		public static void CreateRole()
		{
			var connection = new Connection();
			using NpgsqlConnection npgsqlConnection = new(connection.ConnectionString);
			npgsqlConnection.Open();

			var rand = new Random();
			string[] roleNames = {"admin", "user", "stuff", "spectator"};

			using var cmd = new NpgsqlCommand(
				"INSERT into roles(" +
				"name, chat_id, can_write_messages, " +
				"can_invite_people, can_send_files, can_approve_join_requests)" +
				"VALUES (($1), ($2), ($3), ($4), ($5), ($6))",
				npgsqlConnection)
			{
				Parameters = {
					new () { Value =  roleNames[rand.Next(0, 4)]},
					new () { Value = rand.Next(1, 10) },
					new () { Value = rand.Next(0, 2) != 0 },
					new () { Value = rand.Next(0, 2) != 0 },
					new () { Value = rand.Next(0, 2) != 0 },
					new () { Value = rand.Next(0, 2) != 0 }
				}
			};

			cmd.ExecuteNonQuery();
		}

		public static void CreateUserBlackList()
		{
			var connection = new Connection();
			using NpgsqlConnection npgsqlConnection = new(connection.ConnectionString);
			npgsqlConnection.Open();

			var rand = new Random();

			using var cmd = new NpgsqlCommand(
				"INSERT into user_blacklists(" +
				"user_id, user_blacklisted_id)" +
				"VALUES (($1), ($2))",
				npgsqlConnection)
			{
				Parameters = {
					new () { Value = rand.Next(1, 10) },
					new () { Value = rand.Next(1, 10) },
				}
			};

			cmd.ExecuteNonQuery();
		}

		public static void CreateChatBlackList()
		{
			var connection = new Connection();
			using NpgsqlConnection npgsqlConnection = new(connection.ConnectionString);
			npgsqlConnection.Open();

			var rand = new Random();

			using var cmd = new NpgsqlCommand(
				"INSERT into chat_blacklists(" +
				"chat_id, user_id)" +
				"VALUES (($1), ($2))",
				npgsqlConnection)
			{
				Parameters = {
					new () { Value = rand.Next(1, 10) },
					new () { Value = rand.Next(1, 10) },
				}
			};

			cmd.ExecuteNonQuery();
		}

		public static void CreateChatInvitation()
		{
			var connection = new Connection();
			using NpgsqlConnection npgsqlConnection = new(connection.ConnectionString);
			npgsqlConnection.Open();

			var rand = new Random();
			string[] statuses = {"approved", "pending", "declined"};

			using var cmd = new NpgsqlCommand(
				"INSERT into chat_invitations(" +
				"chat_id, user_id, status, invited_by)" +
				"VALUES (($1), ($2), ($3)::join_status, ($4))",
				npgsqlConnection)
			{
				Parameters = {
					new () { Value = rand.Next(1, 10) },
					new () { Value = rand.Next(1, 10) },
					new () { Value = statuses[rand.Next(0, 3)] },
					new () { Value = rand.Next(1, 10) }
				}
			};

			cmd.ExecuteNonQuery();
		}

		public static void CreateChatJoinRequest()
		{
			var connection = new Connection();
			using NpgsqlConnection npgsqlConnection = new(connection.ConnectionString);
			npgsqlConnection.Open();

			var rand = new Random();
			string[] statuses = {"approved", "pending", "declined"};

			using var cmd = new NpgsqlCommand(
				"INSERT into chat_join_requests(" +
				"chat_id, user_id, status, approved_by)" +
				"VALUES (($1), ($2), ($3)::join_status, ($4))",
				npgsqlConnection)
			{
				Parameters = {
					new () { Value = rand.Next(1, 10) },
					new () { Value = rand.Next(1, 10) },
					new () { Value = statuses[rand.Next(0, 3)] },
					new () { Value = rand.Next(1, 10) },
				}
			};

			cmd.ExecuteNonQuery();
		}

		public static void CreateChatMember()
		{
			var connection = new Connection();
			using NpgsqlConnection npgsqlConnection = new(connection.ConnectionString);
			npgsqlConnection.Open();

			var rand = new Random();

			using var cmd = new NpgsqlCommand(
				"INSERT into chat_members(" +
				"chat_id, user_id, role_id) " +
				"VALUES (($1), ($2), ($3))",
				npgsqlConnection)
			{
				Parameters = {
					new () { Value = rand.Next(1, 10) },
					new () { Value = rand.Next(1, 10) },
					new () { Value = rand.Next(1, 10) },
				}
			};

			cmd.ExecuteNonQuery();
		}

		public static void CreateMessages()
		{
			var connection = new Connection();
			using NpgsqlConnection npgsqlConnection = new(connection.ConnectionString);
			npgsqlConnection.Open();

			var rand = new Random();

			using var cmd = new NpgsqlCommand(
				"INSERT into messages(" +
				"chat_id, member_id, status, payload, has_additional_context)" +
				"VALUES (($1), ($2), ($3)::\"messageStatus\", ($4), ($5))",
				npgsqlConnection)
			{
				Parameters = {
					new () { Value = rand.Next(1, 10) },
					new () { Value = rand.Next(1, 10) },
					new () { Value = rand.Next(0, 2) != 0 ? "0": "1"},
					new () { Value = Faker.Lorem.Paragraph() },
					new () { Value = rand.Next(0, 2) != 0 },
				}
			};

			cmd.ExecuteNonQuery();
		}

		public static void CreateAdditionalContext()
		{
			var connection = new Connection();
			using NpgsqlConnection npgsqlConnection = new(connection.ConnectionString);
			npgsqlConnection.Open();

			var rand = new Random();

			using var cmd = new NpgsqlCommand(
				"INSERT into additional_context(" +
				"message_id, type, payload)" +
				"VALUES (($1), ($2), ($3))",
				npgsqlConnection)
			{
				Parameters = {
					new () { Value = rand.Next(1, 5) },
					new () { Value = Faker.Lorem.GetFirstWord() },
					new () { Value = Faker.Internet.Url() },
				}
			};

			cmd.ExecuteNonQuery();
		}

		public static void CreateRandomData()
		{
			for (int i = 0; i < 10; i++)
			{
				/* AwfulOrm.CreateUser(); */
				/* AwfulOrm.CreateChat(); */
				/* AwfulOrm.CreateRole(); */
				/* AwfulOrm.CreateChatBlackList(); */
				/* AwfulOrm.CreateChatMember(); */
				/* AwfulOrm.CreateChatInvitation(); */
				/* AwfulOrm.CreateChatJoinRequest(); */
				/* AwfulOrm.CreateMessages(); */
				/* AwfulOrm.CreateAdditionalContext(); */
			}
		}

		public static void ReadData(string tableName)
		{
			var connection = new Connection();
			using NpgsqlConnection npgsqlConnection = new(connection.ConnectionString);
			npgsqlConnection.Open();

			using NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM {tableName}", npgsqlConnection);
			using var reader = command.ExecuteReader();

			Console.WriteLine();

			while (reader.Read())
			{
				for (int i = 0; i < reader.FieldCount; i++)
				{
					Console.WriteLine(reader.GetValue(i).ToString());
				}
				Console.WriteLine("------------------------------");
			}
		}
	}
}
