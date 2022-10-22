using MessangerApp.Models.Chats;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Chats.Contexts;

namespace MessangerApp.DataAccess.Chats.Providers;

public class ChatMemberDataAccessProvider : IChatMemberDataAccessProvider
{
    private readonly ChatMemberPostgreSqlContext _context;

    public ChatMemberDataAccessProvider(ChatMemberPostgreSqlContext context)
    {
        _context = context;
    }

    public void AddChatMemberRecord(ChatMember ChatMember)
    {
        _context.ChatMembers.Add(ChatMember);
        _context.SaveChanges();
    }

    public void AddRange(List<ChatMember> ChatMembers)
    {
        _context.ChatMembers.AddRange(ChatMembers);
        _context.SaveChanges();
    }

    public void UpdateChatMemberRecord(ChatMember ChatMember)
    {
        _context.ChatMembers.Update(ChatMember);
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
