using MessangerApp.Models.Chats;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Chats.Contexts;

namespace MessangerApp.DataAccess.Chats.Providers;

public class ChatRoleDataAccessProvider : IChatRoleDataAccessProvider
{
    private readonly ChatRolePostgreSqlContext _context;

    public ChatRoleDataAccessProvider(ChatRolePostgreSqlContext context)
    {
        _context = context;
    }

    public void AddChatRoleRecord(ChatRole ChatRole)
    {
        _context.ChatRoles.Add(ChatRole);
        _context.SaveChanges();
    }

    public void AddRange(List<ChatRole> ChatRoles)
    {
        _context.ChatRoles.AddRange(ChatRoles);
        _context.SaveChanges();
    }

    public void UpdateChatRoleRecord(ChatRole ChatRole)
    {
        _context.ChatRoles.Update(ChatRole);
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
