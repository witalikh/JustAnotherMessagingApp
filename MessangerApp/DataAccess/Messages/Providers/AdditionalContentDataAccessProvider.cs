using MessangerApp.Entities.Messages;
using MessangerApp.DataAccess.Messages.Interfaces;
using MessangerApp.DataAccess.Contexts;

namespace MessangerApp.DataAccess.Messages.Providers;

public class AdditionalContentDataAccessProvider : IAdditionalContentDataAccessProvider
{
    private readonly PostgreSqlContext _context;

    public AdditionalContentDataAccessProvider(PostgreSqlContext context)
    {
        _context = context;
    }

    public void AddAdditionalContentRecord(AdditionalContent AdditionalContent)
    {
        _context.AdditionalContents.Add(AdditionalContent);
        _context.SaveChanges();
    }

    public void AddRange(List<AdditionalContent> AdditionalContents)
    {
        _context.AdditionalContents.AddRange(AdditionalContents);
        _context.SaveChanges();
    }

    public void UpdateAdditionalContentRecord(AdditionalContent AdditionalContent)
    {
        _context.AdditionalContents.Update(AdditionalContent);
        _context.SaveChanges();
    }

    public void DeleteAdditionalContentRecord(int id)
    {
        var entity = _context.AdditionalContents.FirstOrDefault(t => t.Id == id);
        _context.AdditionalContents.Remove(entity!);
        _context.SaveChanges();
    }

    public AdditionalContent GetAdditionalContentSingleRecord(int id)
    {
        return _context.AdditionalContents.FirstOrDefault(t => t.Id == id);
    }

    public List<AdditionalContent> GetAdditionalContentRecords()
    {
        return _context.AdditionalContents.ToList();
    }
}
