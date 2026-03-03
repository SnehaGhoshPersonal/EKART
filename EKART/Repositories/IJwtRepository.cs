using EKART.Models;

namespace EKART.Repositories
{
    public interface IJwtRepository
    {
        public Task<LoginResponse> Authenticate(LoginRequest request);
    }
}
