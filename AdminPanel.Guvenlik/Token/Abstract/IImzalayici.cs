using Microsoft.IdentityModel.Tokens;

namespace AdminPanel.Guvenlik.Token.Abstract
{
    public interface IImzalayici
    {
        SecurityKey GetSecurityKey(string SecurityKey);
    }
}
