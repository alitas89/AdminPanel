using AdminPanel.EntityLayer.Concrete.Other.AuthenticationKismi;
using AdminPanel.Guvenlik.Token.Abstract;
using AdminPanel.Guvenlik.Token.Objects;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AdminPanel.Guvenlik.Token.Concrete
{
    public class TokenIsleyici : ITokenIsleyici
    {
        private ITokenOpsiyonlari _tokenOpsiyonlari;
        private readonly IImzalayici _imzalayici;
        private SigningCredentials _kimlikImzalayici;
        private JwtSecurityToken _jwtGuvenliToken;
        private JwtSecurityTokenHandler _jwtGuvenliTokenIsleyici;
        private string _guvenlikAlgoritmasi;

        public TokenIsleyici(ITokenOpsiyonlari tokenOpsiyonlari, IImzalayici imzalayici)
        {
            _tokenOpsiyonlari = tokenOpsiyonlari;
            _imzalayici = imzalayici;
            _guvenlikAlgoritmasi = SecurityAlgorithms.HmacSha256Signature;
            _jwtGuvenliTokenIsleyici = new JwtSecurityTokenHandler();
        }

        public AccessToken CreateAccessToken(TokensMailPassword mailPassword)
        {
            AccessToken result = new AccessToken();

            var accsessTokenSonKullanmaTarihi =
                DateTime.Now.AddMinutes(_tokenOpsiyonlari.AccessTokenSonKulanim);
            var guvenlikAnahtari =
                _imzalayici.GetSecurityKey(_tokenOpsiyonlari.GuvenlikAnahtari);
            var tarihtenitibarenGecerli =
                DateTime.Now.AddMinutes(_tokenOpsiyonlari.GecerlilikBaslamasi);

            _kimlikImzalayici = new SigningCredentials(guvenlikAnahtari, _guvenlikAlgoritmasi);

            _jwtGuvenliToken = new JwtSecurityToken(
                audience: _tokenOpsiyonlari.Dinleyici,
                issuer: _tokenOpsiyonlari.Yayinci,
                expires: accsessTokenSonKullanmaTarihi,
                notBefore: tarihtenitibarenGecerli,
                signingCredentials: _kimlikImzalayici,
                claims: TalepGetir(mailPassword)
                );



            var token = _jwtGuvenliTokenIsleyici.WriteToken(_jwtGuvenliToken);

            result.Token = token;
            result.SonKullanımTarihi = accsessTokenSonKullanmaTarihi;
            result.RefreshToken = RefresTokenOlustur();

            return result;

        }
        #region temeller
        private string RefresTokenOlustur()
        {
            var ByteNumaralar = new Byte[64];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(ByteNumaralar);

                return Convert.ToBase64String(ByteNumaralar);
            }
        }

        private IEnumerable<Claim> TalepGetir(TokensMailPassword mailPassword)
        {
            List<Claim> result = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,mailPassword.id.ToString()),
                new Claim(ClaimTypes.Email,mailPassword.mail),
                new Claim(ClaimTypes.Name,"Bekir ;)"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            return result;
        }
        #endregion

        /// <summary>
        ///  TokenTable referansı geldiği için bu gelen referans içerisindeki
        ///  geçerlilik durumunu değiştirir Geçersiz ise false olur
        /// </summary>
        /// <param name="token"></param>
        public void RemoveRefreshToken(TokensTable token)
        {
            token.gecerlilikDurumu = false;
        }
    }
}
