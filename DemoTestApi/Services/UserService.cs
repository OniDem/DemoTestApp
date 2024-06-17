using Core.DTO.User;
using Core.Entity;
using DemoTestApi.Infrastructure;
using DemoTestApi.Infrastructure.Repositories;

namespace DemoTestApi.Services
{
    public class UserService
    {
        UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserEntity?> Reg(RegUserRequest request)
        {
            return _repository.Reg(request);
        }

        public async Task<UserEntity?> Auth(AuthUserRequest request)
        {
            return _repository.Auth(request);
        }

        public async Task<UserEntity?> AddToShift(AddToShiftRequest request)
        {
            return _repository.AddToShift(request);
        }

        public async Task<UserEntity?> Refuse(RefuseUserRequest request)
        {
            return _repository.RefuseUser(request);
        }
    }
}
