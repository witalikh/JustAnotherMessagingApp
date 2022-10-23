using MessangerApp.Entities.Chats;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Contexts;

namespace MessangerApp.DataAccess.Chats.Providers;

public class ChatRoleDataAccessProvider : IChatRoleDataAccessProvider
{
    private readonly PostgreSqlContext _context;

    public ChatRoleDataAccessProvider(PostgreSqlContext context)
    {
        _context = context;
    }

    public void AddChatRoleRecord(ChatRole chatRole)
    {
        _context.ChatRoles.Add(chatRole);
        _context.SaveChanges();
    }

    public void AddRange(List<ChatRole> chatRoles)
    {
        _context.ChatRoles.AddRange(chatRoles);
        _context.SaveChanges();
    }

    public void UpdateChatRoleRecord(ChatRole chatRole)
    {
        _context.ChatRoles.Update(chatRole);
        _context.SaveChanges();
    }

    public void DeleteChatRoleRecord(int id)
    {
        var entity = _context.ChatRoles.FirstOrDefault(t => t.Id == id);
        _context.ChatRoles.Remove(entity!);
        _context.SaveChanges();
    }

    public ChatRole GetChatRoleSingleRecord(int id)
    {
        return _context.ChatRoles.FirstOrDefault(t => t.Id == id);
    }

    public List<ChatRole> GetChatRoleRecords()
    {
        return _context.ChatRoles.ToList();
    }
}
