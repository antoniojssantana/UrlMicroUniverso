using AutoMapper;
using System.Security.Claims;
using url.api.ViewModels;
using url.business.Models;

namespace url.api.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserBaseModel, UserBaseViewModel>().ReverseMap();
            CreateMap<UserBaseModel, UserBaseReduceViewModel>().ReverseMap();
            CreateMap<Claim, ClaimViewModel>().ReverseMap();
        }
    }
}