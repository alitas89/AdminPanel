using AdminPanel.EntityLayer.Concrete.Other.AuthenticationKismi;
using AdminPanle.BusinessLayer.Abstract.Base;
using AdminPanle.BusinessLayer.Other.Response;

namespace AdminPanle.BusinessLayer.Abstract.Other.AuthenticationKismi
{
    public interface IBusTokensTable : IEntityBusBase<TokensTable>
    {
        Task<ObjectResponse<List<TokensTable>>> GetByMailPassword(TokensMailPassword mailPassword);

        Task<ObjectResponse<List<TokensTable>>> GetByEmail(string email);

        /// <summary>
        /// Refresh token ın süresi bitmemiş ise gelir
        /// </summary>
        /// <returns></returns>
        Task<ObjectResponse<List<TokensTable>>> GetByGecerli();

        Task<ObjectResponse<TokensTable>> GetByRefreshToken(string refreshToken);
    }
}
