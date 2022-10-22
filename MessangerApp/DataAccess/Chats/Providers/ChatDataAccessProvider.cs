using MessangerApp.Models.Chats;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Chats.Contexts;

namespace MessangerApp.DataAccess.Chats.Providers;

public class ChatDataAccessProvider : IChatDataAccessProvider
{
    private readonly ChatPostgreSqlContext _context;

    public ChatDataAccessProvider(ChatPostgreSqlContext context)
    {
        _context = context;
    }

    public void AddChatRecord(Chat Chat)
    {
        _context.Chats.Add(Chat);
        _context.SaveChanges();
    }

    public void AddRange(List<Chat> Chats)
    {
        _context.Chats.AddRange(Chats);
        _context.SaveChanges();
    }

    public void UpdateChatRecord(Chat Chat)
    {
        _context.Chats.Update(Chat);
        _context.SaveChanges();
    }

    public void DeleteChatRecord(int id)
    {
        var entity = _context.Chats.FirstOrDefault(t => t.Id == id);
        _context.Chats.Remove(entity!);
        _context.SaveChanges();
    }

    public Chat GetChatSingleRecord(int id)
    {
        return _context.Chats.FirstOrDefault(t => t.Id == id);
    }

    public List<Chat> GetChatRecords()
    {
        return _context.Chats.ToList();
    }
}
