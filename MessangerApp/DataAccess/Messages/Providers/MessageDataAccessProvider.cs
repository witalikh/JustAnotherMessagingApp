using MessangerApp.Entities.Messages;
using MessangerApp.DataAccess.Messages.Interfaces;
using MessangerApp.DataAccess.Contexts;

namespace MessangerApp.DataAccess.Messages.Providers;

public class MessageDataAccessProvider : IMessageDataAccessProvider
{
    private readonly PostgreSqlContext _context;

    public MessageDataAccessProvider(PostgreSqlContext context)
    {
        _context = context;
    }

    public void AddMessageRecord(Message Message)
    {
        _context.Messages.Add(Message);
        _context.SaveChanges();
    }

    public void AddRange(List<Message> Messages)
    {
        _context.Messages.AddRange(Messages);
        _context.SaveChanges();
    }

    public void UpdateMessageRecord(Message Message)
    {
        _context.Messages.Update(Message);
        _context.SaveChanges();
    }

    public void DeleteMessageRecord(int id)
    {
        var entity = _context.Messages.FirstOrDefault(t => t.Id == id);
        _context.Messages.Remove(entity!);
        _context.SaveChanges();
    }

    public Message GetMessageSingleRecord(int id)
    {
        return _context.Messages.FirstOrDefault(t => t.Id == id);
    }

    public List<Message> GetMessageRecords()
    {
        return _context.Messages.ToList();
    }
}
