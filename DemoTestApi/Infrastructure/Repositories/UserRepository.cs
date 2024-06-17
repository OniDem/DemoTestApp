using Core.Const;
using Core.DTO.User;
using Core.Entity;

namespace DemoTestApi.Infrastructure.Repositories
{ 
    
    public class UserRepository
    {
        private ApplicationContext _applicationContext;
        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public UserEntity Reg(RegUserRequest request)
        {
            UserEntity userEntity = new()
            {
                Username = request.Username,
                Password = request.Password,
                Role = request.Role,
                FIO = request.FIO
            };
             _applicationContext.Users.Add(userEntity);
            _applicationContext.SaveChanges();
            return userEntity;
        }

        public UserEntity? Auth(AuthUserRequest request)
        {
            UserEntity? user = _applicationContext.Users.FirstOrDefault(x =>  x.Username == request.Username);
            if (user != null)
            {
                if (user.Password == request.Password) 
                    return user;
            }
            return null;
        }

        public UserEntity? GetUserById(GetUserByIdRequest request)
        {
            return _applicationContext.Users.FirstOrDefault(x => x.UserId == request.UserId);
        }

        public UserEntity? AddToShift(AddToShiftRequest request)
        {
            UserEntity? userEntity = GetUserById(new() { UserId = request.UserId });
            if (userEntity != null)
            {
                userEntity.ShiftIDs.Add(request.ShiftId);
                _applicationContext.Update(userEntity);
                _applicationContext.SaveChanges();
                return userEntity;
            }
            return null;
        }

        public UserEntity? RefuseUser(RefuseUserRequest request)
        {
            UserEntity? userEntity = GetUserById(new() {  UserId = request.UserId });
            if (userEntity != null)
            {
                userEntity.Status = StatusConst.UserRefused;
                _applicationContext.Update(userEntity);
                _applicationContext.SaveChanges();
                return userEntity;
            }
            return null;
        }
    }
}
