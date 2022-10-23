using MessangerApp.Entities.Chats;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Contexts;

namespace MessangerApp.DataAccess.Chats.Providers;

public class ChatMemberDataAccessProvider : IChatMemberDataAccessProvider
{
    private readonly PostgreSqlContext _context;

    public ChatMemberDataAccessProvider(PostgreSqlContext context)
    {
        _context = context;
    }

    public void AddChatMemberRecord(ChatMember chatMember)
    {
        _context.ChatMembers.Add(chatMember);
        _context.SaveChanges();
    }

    public void AddRange(List<ChatMember> chatMembers)
    {
        _context.ChatMembers.AddRange(chatMembers);
        _context.SaveChanges();
    }

    public void UpdateChatMemberRecord(ChatMember chatMember)
    {
        _context.ChatMembers.Update(chatMember);
        _context.SaveChanges();
    }

    public void DeleteChatMemberRecord(int id)
    {
        var entity = _context.ChatMembers.FirstOrDefault(t => t.Id == id);
        _context.ChatMembers.Remove(entity!);
        _context.SaveChanges();
    }

    public ChatMember GetChatMemberSingleRecord(int id)
    {
        return _context.ChatMembers.FirstOrDefault(t => t.Id == id);
    }

    public List<ChatMember> GetChatMemberRecords()
    {
        return _context.ChatMembers.ToList();
    }
}
