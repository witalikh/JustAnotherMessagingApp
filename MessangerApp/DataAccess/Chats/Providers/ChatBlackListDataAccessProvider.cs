using MessangerApp.Entities.Chats;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Contexts;

namespace MessangerApp.DataAccess.Chats.Providers;

public class ChatBlacklistDataAccessProvider : IChatBlacklistDataAccessProvider
{
    private readonly PostgreSqlContext _context;

    public ChatBlacklistDataAccessProvider(PostgreSqlContext context)
    {
        _context = context;
    }

    public void AddChatBlacklistRecord(ChatBlacklist chatBlackList)
    {
        _context.ChatBlacklists.Add(chatBlackList);
        _context.SaveChanges();
    }

    public void AddRange(List<ChatBlacklist> chatBlackLists)
    {
        _context.ChatBlacklists.AddRange(chatBlackLists);
        _context.SaveChanges();
    }

    public void UpdateChatBlacklistRecord(ChatBlacklist chatBlackList)
    {
        _context.ChatBlacklists.Update(chatBlackList);
        _context.SaveChanges();
    }

    public void DeleteChatBlacklistRecord(int id)
    {
        var entity = _context.ChatBlacklists.FirstOrDefault(t => t.Id == id);
        _context.ChatBlacklists.Remove(entity!);
        _context.SaveChanges();
    }

    public ChatBlacklist GetChatBlacklistSingleRecord(int id)
    {
        return _context.ChatBlacklists.FirstOrDefault(t => t.Id == id);
    }

    public List<ChatBlacklist> GetChatBlacklistRecords()
    {
        return _context.ChatBlacklists.ToList();
    }
}
