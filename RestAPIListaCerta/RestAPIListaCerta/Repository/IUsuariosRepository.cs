

using RestAPIListaCerta.Data.VO;
using RestAPIListaCerta.Models;

namespace RestAPIListaCerta.Repository
{
    public interface IUsuariosRepository
    {
        Usuarios ValidateCredentials(UserVO user);
        Usuarios ValidateCredentials(string userName);
        Usuarios RefreshUserInfo(Usuarios user);

        bool RevokeToken(string userName);
    }
}
