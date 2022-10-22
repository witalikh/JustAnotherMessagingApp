using MessangerApp.Models.Chats;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Chats.Contexts;

namespace MessangerApp.DataAccess.Chats.Providers;

public class ChatJoinRequestDataAccessProvider : IChatJoinRequestDataAccessProvider
{
    private readonly ChatJoinRequestPostgreSqlContext _context;

    public ChatJoinRequestDataAccessProvider(ChatJoinRequestPostgreSqlContext context)
    {
        _context = context;
    }

    public void AddChatJoinRequestRecord(ChatJoinRequest ChatJoinRequest)
    {
        _context.ChatJoinRequests.Add(ChatJoinRequest);
        _context.SaveChanges();
    }

    public void AddRange(List<ChatJoinRequest> ChatJoinRequests)
    {
        _context.ChatJoinRequests.AddRange(ChatJoinRequests);
        _context.SaveChanges();
    }

    public void UpdateChatJoinRequestRecord(ChatJoinRequest ChatJoinRequest)
    {
        _context.ChatJoinRequests.Update(ChatJoinRequest);
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
