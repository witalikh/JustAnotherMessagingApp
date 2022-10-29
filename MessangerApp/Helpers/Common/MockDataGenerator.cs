using MessangerApp.Entities.Users;
using MessangerApp.Entities.Chats;
using MessangerApp.Entities.Messages;
using MessangerApp.Models.Users;
using MessangerApp.Models.Chats;
using MessangerApp.Models.Messages;
using MessangerApp.DataAccess.Users.Interfaces;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Messages.Interfaces;

namespace MessangerApp.Helpers.Common;

public class FakeDataGenerator
{
	private IServiceScope _scope;
	private IUserDataAccessProvider _userService;
	private IUserBlacklistDataAccessProvider _userBlacklistService;
	private IChatDataAccessProvider _chatService;
	private IChatMemberDataAccessProvider _chatMemberService;
	private IChatInvitationDataAccessProvider _chatInvitationService;
	private IChatJoinRequestDataAccessProvider _chatJoinRequestService;
	private IChatRoleDataAccessProvider _chatRoleService;
	private IChatBlacklistDataAccessProvider _chatBlacklistService;
	private IMessageDataAccessProvider _messageService;
	private IAdditionalContentDataAccessProvider _additionalContentService;
	private Random _rand;

	public FakeDataGenerator(IServiceScope scope)
	{
		_scope = scope;
		_userService = scope.ServiceProvider.GetRequiredService<IUserDataAccessProvider>();
		_userBlacklistService = scope.ServiceProvider.GetRequiredService<IUserBlacklistDataAccessProvider>();
		_chatService = scope.ServiceProvider.GetRequiredService<IChatDataAccessProvider>();
		_chatMemberService = scope.ServiceProvider.GetRequiredService<IChatMemberDataAccessProvider>();
		_chatInvitationService = scope.ServiceProvider.GetRequiredService<IChatInvitationDataAccessProvider>();
		_chatJoinRequestService = scope.ServiceProvider.GetRequiredService<IChatJoinRequestDataAccessProvider>();
		_chatRoleService = scope.ServiceProvider.GetRequiredService<IChatRoleDataAccessProvider>();
		_chatBlacklistService = scope.ServiceProvider.GetRequiredService<IChatBlacklistDataAccessProvider>();
		_messageService = scope.ServiceProvider.GetRequiredService<IMessageDataAccessProvider>();
		_additionalContentService = scope.ServiceProvider.GetRequiredService<IAdditionalContentDataAccessProvider>();
		_rand = new Random();
	}

	public void GenerateFakeData(int generateNum)
	{
		CreateUsers(generateNum);
		CreateUserBlacklists(generateNum);

		CreateChats(generateNum);
		CreateChatMembersAndRoles(generateNum);
		CreateChatInvitations(generateNum);
		CreateChatJoinRequest(generateNum);
		CreateChatBlacklists(generateNum);

		CreateMessages(generateNum);
		CreateAdditionalContents(generateNum);
	}

	public void CreateUsers(int num)
	{
		for (int i = 0; i < num; i++)
		{
			try
			{
				var registerRequest = new RegisterRequest{
					Username = Faker.Internet.UserName(),
					FirstName = Faker.Name.First(),
					LastName = Faker.Name.Last(),
					Password = Faker.Lorem.GetFirstWord(),
					PhoneNumber = Faker.Phone.Number(),
				};
				_userService.Register(registerRequest);
			}
			catch (Exception)
			{
				continue;
			}
		}
	}

	public void CreateUserBlacklists(int num)
	{
		for (int i = 0; i < num; i++)
		{
			var users = _userService.GetAll().ToArray();

			if (users.Length <= 0)
				return;

			User randUser = users[_rand.Next(0, users.Length)];
			User randBlacklistedUser = users[_rand.Next(0, users.Length)];

			while (randBlacklistedUser.Id == randUser.Id)
			{
				randBlacklistedUser = users[_rand.Next(0, users.Length)];
			}

			var userBlacklist = new UserBlacklist{
				UserId = randUser.Id,
				BlacklistedUserId = randBlacklistedUser.Id,
				User = randUser,
				BlacklistedUser = randBlacklistedUser,
			};

			_userBlacklistService.AddUserBlacklistRecord(userBlacklist);
		}
	}

	public void CreateChats(int num)
	{
		for (int i = 0; i < num; i++)
		{
			var users = _userService.GetAll().ToArray();

			if (users.Length <= 0)
				return;

			User randUser = users[_rand.Next(0, users.Length)];

			Chat chat = new Chat{
				Name = Faker.Lorem.GetFirstWord(),
				Description = Faker.Lorem.Paragraph(),
				IsMessagingOnByDefault = _rand.Next(0, 2) > 0 ? true : false,
				IsInvitesSendingOnByDefault = _rand.Next(0, 2) > 0 ? true : false,
				IsFilesSendingOnByDefault = _rand.Next(0, 2) > 0 ? true : false,
				JoinLink = Faker.Internet.Url(),
				Visibility = (Visibility)_rand.Next(0, Enum.GetNames(typeof(Visibility)).Length),
				OwnerId = randUser.Id,
				Owner = randUser,
			};

			_chatService.AddChatRecord(chat);
		}
	}

	public void CreateChatRoles(int num)
	{
		for (int i = 0; i < num; i++)
		{
			var chats = _chatService.GetChatRecords().ToArray();

			if (chats.Length <= 0)
				return;

			Chat randChat = chats[_rand.Next(0, chats.Length)];

			ChatRole chatRole = new ChatRole{
				Name = Faker.Lorem.GetFirstWord(),
				CanMessage = _rand.Next(0, 2) > 0 ? true : false,
				CanInvitePeople = _rand.Next(0, 2) > 0 ? true : false,
				CanSendFiles = _rand.Next(0, 2) > 0 ? true : false,
				CanApproveJoinRequests = _rand.Next(0, 2) > 0 ? true : false,
				ChatId = randChat.Id,
				Chat = randChat,
			};

			_chatRoleService.AddChatRoleRecord(chatRole);
		}
	}

	public void CreateChatMembersAndRoles(int num)
	{
		for (int i = 0; i < num; i++)
		{
			var chats = _chatService.GetChatRecords().ToArray();
			var users = _userService.GetAll().ToArray();

			if (chats.Length <= 0 || users.Length <= 0)
				return;

			Chat randChat = chats[_rand.Next(0, chats.Length)];
			User randUser = users[_rand.Next(0, users.Length)];


			ChatRole randRole = new ChatRole{
				Name = Faker.Lorem.GetFirstWord(),
				CanMessage = _rand.Next(0, 2) > 0 ? true : false,
				CanInvitePeople = _rand.Next(0, 2) > 0 ? true : false,
				CanSendFiles = _rand.Next(0, 2) > 0 ? true : false,
				CanApproveJoinRequests = _rand.Next(0, 2) > 0 ? true : false,
				ChatId = randChat.Id,
				Chat = randChat,
			};

			_chatRoleService.AddChatRoleRecord(randRole);

			ChatMember chatMember = new ChatMember{
				UserId = randUser.Id,
				ChatId = randChat.Id,
				RoleId = randRole.Id,
				User = randUser,
				Chat = randChat,
				Role = randRole,
			};

			_chatMemberService.AddChatMemberRecord(chatMember);
		}
	}

	public void CreateChatInvitations(int num)
	{
		for (int i = 0; i < num; i++)
		{
			var chats = _chatService.GetChatRecords().ToArray();
			var users = _userService.GetAll().ToArray();
			var chatMembers = _chatMemberService.GetChatMemberRecords().ToArray();

			if (chats.Length <= 0 || users.Length <= 0 || chatMembers.Length <= 0)
				return;

			User randUser = users[_rand.Next(0, users.Length)];
			Chat randChat = chats[_rand.Next(0, chats.Length)];
			ChatMember randMember = chatMembers[_rand.Next(0, chatMembers.Length)];;

			ChatInvitation chatInvitation = new ChatInvitation{
				Status = (JoinStatus)_rand.Next(0, Enum.GetNames(typeof(JoinStatus)).Length),
				UserId = randUser.Id,
				ChatId = randChat.Id,
				InvitedById = randMember.Id,
				User = randUser,
				Chat = randChat,
				InvitedBy = randMember,
			};

			_chatInvitationService.AddChatInvitationRecord(chatInvitation);
		}
	}

	public void CreateChatJoinRequest(int num)
	{
		for (int i = 0; i < num; i++)
		{
			var chats = _chatService.GetChatRecords().ToArray();
			var users = _userService.GetAll().ToArray();
			var chatMembers = _chatMemberService.GetChatMemberRecords().ToArray();

			if (chats.Length <= 0 || users.Length <= 0 || chatMembers.Length <= 0)
				return;

			User randUser = users[_rand.Next(0, users.Length)];
			Chat randChat = chats[_rand.Next(0, chats.Length)];
			ChatMember randMember = chatMembers[_rand.Next(0, chatMembers.Length)];

			ChatJoinRequest chatJoinRequest = new ChatJoinRequest{
				Status = (JoinStatus)_rand.Next(0, Enum.GetNames(typeof(JoinStatus)).Length),
				UserId = randUser.Id,
				ChatId = randChat.Id,
				ApprovedById = randMember.Id,
				User = randUser,
				Chat = randChat,
				ApprovedBy = randMember,
			};

			_chatJoinRequestService.AddChatJoinRequestRecord(chatJoinRequest);
		}
	}

	public void CreateChatBlacklists(int num)
	{
		for (int i = 0; i < num; i++)
		{
			var chats = _chatService.GetChatRecords().ToArray();
			var users = _userService.GetAll().ToArray();

			if (chats.Length <= 0 || users.Length <= 0)
				return;

			User randUser = users[_rand.Next(0, users.Length)];
			Chat randChat = chats[_rand.Next(0, chats.Length)];

			ChatBlacklist chatBlacklist = new ChatBlacklist{
				UserId = randUser.Id,
				ChatId = randChat.Id,
				User = randUser,
				Chat = randChat,
			};

			_chatBlacklistService.AddChatBlacklistRecord(chatBlacklist);
		}
	}

	public void CreateMessages(int num)
	{
		for (int i = 0; i < num; i++)
		{
			var chats = _chatService.GetChatRecords().ToArray();
			var chatMembers = _chatMemberService.GetChatMemberRecords().ToArray();

			if (chats.Length <= 0 || chatMembers.Length <= 0)
				return;

			Chat randChat = chats[_rand.Next(0, chats.Length)];
			ChatMember randMember = chatMembers[_rand.Next(0, chatMembers.Length)];

			Message message = new Message{
				Status = (MessageStatus)_rand.Next(0, Enum.GetNames(typeof(MessageStatus)).Length),
				Payload = Faker.Lorem.Paragraph(),
				HasAdditionalContext = false,
				CreatedAt = DateTime.Now,
				ChatId = randChat.Id,
				MemberId = randMember.Id,
				Chat = randChat,
				ChatMember = randMember,
			};

			_messageService.AddMessageRecord(message);
		}
	}

	public void CreateAdditionalContents(int num)
	{
		for (int i = 0; i < num; i++)
		{
			var messages = _messageService.GetMessageRecords().ToArray();

			if (messages.Length <= 0)
				return;

			Message message = messages[_rand.Next(0, messages.Length)];
			message.HasAdditionalContext = true;

			AdditionalContent additionalContent = new AdditionalContent{
				Type = Faker.Lorem.GetFirstWord(),
				Payload = Faker.Lorem.Paragraph(),
				MessageId = message.Id,
				Message = message,
			};

			_messageService.UpdateMessageRecord(message);
			_additionalContentService.AddAdditionalContentRecord(additionalContent);
		}
	}
}
