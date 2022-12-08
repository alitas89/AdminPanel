using AdminPanel.EntityLayer.Concrete.Other.AuthenticationKismi;
using AdminPanel.Guvenlik.Token.Objects;
using AdminPanle.BusinessLayer.Other.Response;

namespace AdminPanel.Guvenlik.AuthenticationKismi
{
    public interface IAuthentication
    {
        Task<ObjectResponse<TokensMailPassword>> CreateEmailPassword(string email, string password);

        Task<ObjectResponse<TokensMailPassword>> UpdatePassword(string email, string password, int emailID);

        Task<ObjectResponse<AccessToken>> CreateAccessToken(string email, string password);

        Task<ObjectResponse<AccessToken>> CreateAccessTokenByRefreshToken(string email, string refreshToken);

        Task<ObjectResponse<TokensTable>> RemoveRefreshToken(string email, string refreshToken);


    }
}
