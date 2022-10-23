using MessangerApp.Entities.Chats;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Contexts;

namespace MessangerApp.DataAccess.Chats.Providers;

public class ChatDataAccessProvider : IChatDataAccessProvider
{
    private readonly PostgreSqlContext _context;

    public ChatDataAccessProvider(PostgreSqlContext context)
    {
        _context = context;
    }

    public void AddChatRecord(Chat chat)
    {
        _context.Chats.Add(chat);
        _context.SaveChanges();
    }

    public void AddRange(List<Chat> chats)
    {
        _context.Chats.AddRange(chats);
        _context.SaveChanges();
    }

    public void UpdateChatRecord(Chat chat)
    {
        _context.Chats.Update(chat);
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
