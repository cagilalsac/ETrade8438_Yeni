using AppCore.Results.Bases;

namespace Business.Services
{
    public interface IAccountService
    {
        Result Register(AccountRegisterModel model);
        Result Login(AccountLoginModel model);
    }
}
