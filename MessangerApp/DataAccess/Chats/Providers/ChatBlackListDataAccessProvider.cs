using MessangerApp.Models.Chats;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Chats.Contexts;

namespace MessangerApp.DataAccess.Chats.Providers;

public class ChatBlackListDataAccessProvider : IChatBlackListDataAccessProvider
{
    private readonly ChatBlackListPostgreSqlContext _context;

    public ChatBlackListDataAccessProvider(ChatBlackListPostgreSqlContext context)
    {
        _context = context;
    }

    public void AddChatBlackListRecord(ChatBlackList ChatBlackList)
    {
        _context.ChatBlackLists.Add(ChatBlackList);
        _context.SaveChanges();
    }

    public void AddRange(List<ChatBlackList> ChatBlackLists)
    {
        _context.ChatBlackLists.AddRange(ChatBlackLists);
        _context.SaveChanges();
    }

    public void UpdateChatBlackListRecord(ChatBlackList ChatBlackList)
    {
        _context.ChatBlackLists.Update(ChatBlackList);
        _context.SaveChanges();
    }

    public void DeleteChatBlackListRecord(int id)
    {
        var entity = _context.ChatBlackLists.FirstOrDefault(t => t.Id == id);
        _context.ChatBlackLists.Remove(entity!);
        _context.SaveChanges();
    }

    public ChatBlackList GetChatBlackListSingleRecord(int id)
    {
        return _context.ChatBlackLists.FirstOrDefault(t => t.Id == id);
    }

    public List<ChatBlackList> GetChatBlackListRecords()
    {
        return _context.ChatBlackLists.ToList();
    }
}
