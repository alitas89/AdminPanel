using AdminPanel.EntityLayer.Abctract;
using AdminPanel.EntityLayer.Concrete.Other.AuthenticationKismi;
using AdminPanel.Guvenlik.Other;
using AdminPanel.Guvenlik.Token.Objects;
using AdminPanel.Guvenlik.Token.Abstract;
using AdminPanle.BusinessLayer.Abstract.Other.AuthenticationKismi;
using AdminPanle.BusinessLayer.Other;
using AdminPanle.BusinessLayer.Other.Extensions;
using AdminPanle.BusinessLayer.Other.Response;

namespace AdminPanel.Guvenlik.AuthenticationKismi
{
    public class Authentication : IAuthentication
    {
        ITokenIsleyici _tokenIsleyici;
        IBusTokensMailPassword _mailPassword;
        IBusTokensTable _refreshTokentable;
        ITokenOpsiyonlari _tokenOpsiyonlari;

        public Authentication()
        {
            _mailPassword = BusOlusturucu.Olustur().TokensMailPassword;
            _refreshTokentable = BusOlusturucu.Olustur().TokensTable;

            _tokenIsleyici = GuvenlikOlusturucu.Olustur().TokenIsleyici;
            _tokenOpsiyonlari = GuvenlikOlusturucu.Olustur().TokenOpsiyonlari;
        }

        public async Task<ObjectResponse<AccessToken>> CreateAccessToken(string email, string password)
        {
            ObjectResponse<AccessToken> result;
            try
            {
                if (email.isEmail())
                {
                    var mailPasswordResponse = await _mailPassword.GetByEmailAndPassword(email, password);
                    if (mailPasswordResponse.Success)
                    {
                        if (!mailPasswordResponse.Data.silinmisMi())
                        {
                            var token = _tokenIsleyici.CreateAccessToken(mailPasswordResponse.Data);
                            if (token != null)
                            {
                                var refresAddResult = await _refreshTokentable.AddAsync(new TokensTable
                                {
                                    mailPassword = mailPasswordResponse.Data,
                                    refreshToken = token.RefreshToken,
                                    refreshTokenDate = DateTime.Now.AddMinutes(_tokenOpsiyonlari.RefreshTokenSonKullanim)
                                });

                                if (refresAddResult.Success)
                                {
                                    result = new ObjectResponse<AccessToken>(token);
                                }
                                else
                                    result = new ObjectResponse<AccessToken>("Refresh Token kaydedilirken hata oluştu");
                            }
                            else
                            {
                                result = new ObjectResponse<AccessToken>("Token üretilemedi");
                            }
                        }
                        else
                            result = new ObjectResponse<AccessToken>("Bu mail password silimiştir. Yetkisiz işlem yapmaya çalışıyorsunuz.");
                    }
                    else
                        result = new ObjectResponse<AccessToken>(mailPasswordResponse.Message);
                }
                else
                    result = new ObjectResponse<AccessToken>("Geçersiz email");

            }
            catch (Exception ex)
            {
                result = new ObjectResponse<AccessToken>("Access token üretilirken hata oluştu. : " + ex.Message);
            }
            return result;
        }

        public async Task<ObjectResponse<AccessToken>> CreateAccessTokenByRefreshToken(string email, string refreshToken)
        {
            ObjectResponse<AccessToken> result;
            try
            {
                if (email.isEmail())
                {
                    var refresTableResponse = await _refreshTokentable.GetByRefreshToken(refreshToken);


                    if (refresTableResponse.Success)
                    {
                        if (!refresTableResponse.Data.silinmisMi() && refresTableResponse.Data.gecerlilikDurumu)
                        {
                            if (refresTableResponse.Data.refreshTokenDate >= DateTime.Now)
                            {
                                if (refresTableResponse.Data.mailPassword.mail.Equals(email))
                                {
                                    var emailPaswordResource = await _mailPassword.GetByEmailAndPassword(
                                        email, refresTableResponse.Data.mailPassword.password);

                                    if (emailPaswordResource.Success)
                                    {
                                        /* Süresi dolmadan işlem yapıldığı için geçerliliği devre dışı bırakılıyor*/
                                        _tokenIsleyici.RemoveRefreshToken(refresTableResponse.Data);
                                        await _refreshTokentable.UpdateAsync(refresTableResponse.Data);
                                        result = await this.CreateAccessToken
                                            (emailPaswordResource.Data.mail, emailPaswordResource.Data.password);
                                    }
                                    else
                                    {
                                        result = new ObjectResponse<AccessToken>(emailPaswordResource.Message);
                                    }

                                }
                                else
                                    result = new ObjectResponse<AccessToken>("Yanlış email");
                            }
                            else
                            {
                                await _refreshTokentable.DeleteAsync(refresTableResponse.Data); // süresi dolduğu için siliyoruz. Emaile bakmak sızın
                                result = new ObjectResponse<AccessToken>("Refresh tokenın süresi dolmuştur.");
                            }
                        }
                        else
                            result = new ObjectResponse<AccessToken>("Bu refresh token silimiştir veya geçersizdir.");
                    }
                    else
                        result = new ObjectResponse<AccessToken>(refresTableResponse.Message);
                }
                else
                    result = new ObjectResponse<AccessToken>("Lütfen bir email giriniz.");
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<AccessToken>("Refresh token a göre access toke nüretilirken hata oluştu");
            }

            return result;
        }

        public async Task<ObjectResponse<TokensMailPassword>> CreateEmailPassword(string email, string password)
        {
            ObjectResponse<TokensMailPassword> result;

            try
            {
                var mailPasswordResource = await _mailPassword.GetByEmail(email);
                // message tanımları tek bir merkeze alınacak
                if (!mailPasswordResource.Success && mailPasswordResource.Message.Equals("Sistemde kayıtlı değildir."))
                {
                    var addResult = await _mailPassword.AddByAsync(new TokensMailPassword { mail = email, password = password });
                    if (addResult.Data.isIdNotEmpty())
                    {
                        result = new ObjectResponse<TokensMailPassword>(addResult.Data);
                    }
                    else
                        result = new ObjectResponse<TokensMailPassword>("Obje oluşturulamadı");
                }
                else
                {
                    if (mailPasswordResource.Message.isNotEmpty())
                        result = mailPasswordResource;
                    else
                        result = new ObjectResponse<TokensMailPassword>("Bu emailde sistemde bir kayıt mevcuttur.");
                }
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<TokensMailPassword>("Mail ve Password kadedilirken hata oluştu. :" + ex.Message);
            }

            return result;
        }

        public async Task<ObjectResponse<TokensTable>> RemoveRefreshToken(string email, string refreshToken)
        {
            ObjectResponse<TokensTable> result;
            try
            {
                var refrehTokenResource = await _refreshTokentable.GetByRefreshToken(refreshToken);

                if (refrehTokenResource.Success)
                {
                    if (email.isEmail() && refrehTokenResource.Data.mailPassword.mail.Equals(email))
                    {
                        if (refrehTokenResource.Data.silinmisMi())
                        {
                            // silindiği için direkt yolluyoruz
                            result = new ObjectResponse<TokensTable>(refrehTokenResource.Data);
                        }
                        else
                        {
                            if (refrehTokenResource.Data.gecerlilikDurumu)
                            {
                                _tokenIsleyici.RemoveRefreshToken(refrehTokenResource.Data);
                                var islemResult = await _refreshTokentable.UpdateAsync(refrehTokenResource.Data);
                                if (islemResult.Success)
                                {
                                    result = new ObjectResponse<TokensTable>(refrehTokenResource.Data);
                                }
                                else
                                    result = new ObjectResponse<TokensTable>("Refresh tokenı geçersiz kılmada" +
                                        "bilinmeyen bir hata oluştu");

                            }
                            else
                            {
                                // geçerliliği devre dışı kaldığı için direkt yolluyoruz
                                result = new ObjectResponse<TokensTable>(refrehTokenResource.Data);
                            }
                        }
                    }
                    else
                        result = new ObjectResponse<TokensTable>("Email geçersiz veya kayıtlarla uyuşmuyor");
                }
                else
                    result = new ObjectResponse<TokensTable>("Kaldırmak istediğiniz refres token getirilemedi. \nDetay: " +
                        refrehTokenResource.Message);
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<TokensTable>("Refresh token kaldırılırken hata oluştu. : " + ex.Message);
            }

            return result;
        }

        public async Task<ObjectResponse<TokensMailPassword>> UpdatePassword(string email, string password,int emailID)
        {
            ObjectResponse<TokensMailPassword> result;
            try
            {
                if (email.isEmail() && password.isNotEmpty())
                {
                    var emailResource = await _mailPassword.GetByEmail(email);

                    if (emailResource.Success)
                    {
                        if (emailResource.Data.id == emailID)
                        {
                            emailResource.Data.password = password;

                            await _mailPassword.UpdateAsync(emailResource.Data);

                            result = emailResource;
                        }
                        else
                            result = new ObjectResponse<TokensMailPassword>("Kendinizden başka birinin şifresini değiştirme hakkınız yoktur.");
                    }
                    else
                        result = new ObjectResponse<TokensMailPassword>($"İlgili \"{email}\" emaile ait veri bulunamadı.");
                }
                else
                    result = new ObjectResponse<TokensMailPassword>("Geçersiz email veya password");
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<TokensMailPassword>("Şifre güncelleme esnasında hata oluştu");
            }
            return result;
        }
    }
}
