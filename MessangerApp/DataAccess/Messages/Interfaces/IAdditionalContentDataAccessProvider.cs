using MessangerApp.Entities.Messages;

namespace MessangerApp.DataAccess.Messages.Interfaces;

public interface IAdditionalContentDataAccessProvider
{
    void AddAdditionalContentRecord(AdditionalContent additionalContent);
    void AddRange(List<AdditionalContent> additionalContents);
    void UpdateAdditionalContentRecord(AdditionalContent additionalContent);
    void DeleteAdditionalContentRecord(int id);
    AdditionalContent GetAdditionalContentSingleRecord(int id);
    List<AdditionalContent> GetAdditionalContentRecords();
}
