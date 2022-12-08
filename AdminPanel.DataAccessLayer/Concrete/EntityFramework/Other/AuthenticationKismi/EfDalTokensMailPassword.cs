using AdminPanel.DataAccessLayer.Abstract.Other.Genel.AuthenticationKismi;
using AdminPanel.DataAccessLayer.Concrete.EntityFramework.Base;
using AdminPanel.EntityLayer.Concrete.Other.AuthenticationKismi;

namespace AdminPanel.DataAccessLayer.Concrete.EntityFramework.Other.AuthenticationKismi
{
    public class EfDalTokensMailPassword : EntityEfDal<TokensMailPassword, EFContextOracle>, IDalTokensMailPassword
    {
    }
}
