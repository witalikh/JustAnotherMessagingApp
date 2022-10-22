namespace MessangerApp.DataAccess.BlackListedTokens;

using MessangerApp.Models.BlackListedTokens;

public interface IBlackListedTokenService
{
    List<BlackListedToken> GetBlackListedTokens();
    void InvalidateToken(BlackListedToken token);
}