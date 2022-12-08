using AdminPanel.EntityLayer.Concrete.Other.AuthenticationKismi;
using AdminPanel.Guvenlik.Token.Objects;

namespace AdminPanel.Guvenlik.Token.Abstract
{
    public interface ITokenIsleyici
    {
        AccessToken CreateAccessToken(TokensMailPassword mailPassword);
        void RemoveRefreshToken(TokensTable token);
    }
}
