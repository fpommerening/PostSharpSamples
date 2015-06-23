using FP.PostSharpSamples.DAL;

namespace FP.PostSharpSamples.BL
{
    public class UserMappings
    {
        public void CreateMapping()
        {
            AutoMapper.Mapper.CreateMap<DOUser, UserViewModel>();
            AutoMapper.Mapper.CreateMap<UserViewModel, DOUser>();
        }
    }
}
