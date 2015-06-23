using System.Collections.Generic;
using System.Linq;
using FP.PostSharpSamples.DAL;

namespace FP.PostSharpSamples.BL
{
    public class BusinessLayer
    {
        private UserRepository _userRepository;
        public BusinessLayer(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public List<UserViewModel> GetAllUser()
        {
            try
            {
                var doUsers = _userRepository.GetAllUsers();
                return doUsers.Select(AutoMapper.Mapper.Map<UserViewModel>).ToList();
            }
            catch
            {
                return new List<UserViewModel>();
            }    
        }

        public UserViewModel GetUserById(int userId)
        {
            try
            {
                var doUser = _userRepository.GetUserById(userId);
                return AutoMapper.Mapper.Map<UserViewModel>(doUser);
            }
            catch
            {
                return null;
            }
        }

        public void CreateUser(UserViewModel viewModel)
        {
            var doUser = AutoMapper.Mapper.Map<DOUser>(viewModel);
            _userRepository.SaveUser(doUser);
        }
    }
}
