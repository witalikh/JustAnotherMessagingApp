using MessangerApp.Entities.Chats;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Contexts;

namespace MessangerApp.DataAccess.Chats.Providers;

public class ChatJoinRequestDataAccessProvider : IChatJoinRequestDataAccessProvider
{
    private readonly PostgreSqlContext _context;

    public ChatJoinRequestDataAccessProvider(PostgreSqlContext context)
    {
        _context = context;
    }

    public void AddChatJoinRequestRecord(ChatJoinRequest chatJoinRequest)
    {
        _context.ChatJoinRequests.Add(chatJoinRequest);
        _context.SaveChanges();
    }

    public void AddRange(List<ChatJoinRequest> chatJoinRequests)
    {
        _context.ChatJoinRequests.AddRange(chatJoinRequests);
        _context.SaveChanges();
    }

    public void UpdateChatJoinRequestRecord(ChatJoinRequest chatJoinRequest)
    {
        _context.ChatJoinRequests.Update(chatJoinRequest);
        _context.SaveChanges();
    }

    public void DeleteChatJoinRequestRecord(int id)
    {
        var entity = _context.ChatJoinRequests.FirstOrDefault(t => t.Id == id);
        _context.ChatJoinRequests.Remove(entity!);
        _context.SaveChanges();
    }

    public ChatJoinRequest GetChatJoinRequestSingleRecord(int id)
    {
        return _context.ChatJoinRequests.FirstOrDefault(t => t.Id == id);
    }

    public List<ChatJoinRequest> GetChatJoinRequestRecords()
    {
        return _context.ChatJoinRequests.ToList();
    }
}
