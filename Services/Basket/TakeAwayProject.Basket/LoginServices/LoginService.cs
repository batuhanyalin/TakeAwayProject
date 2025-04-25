namespace TakeAwayProject.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor; //HttpContextAccessor 
        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value; //buradaki sub bilgisi jwt den gelen Identityserver üzerindeng giriş yapan kullanıcıya ait token değerindeki payload kısmındaki sub değerini yani kullanıcının id değerini buluyoruz.
    }
}
