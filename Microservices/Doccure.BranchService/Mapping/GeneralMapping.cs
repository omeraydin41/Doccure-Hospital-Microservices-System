using AutoMapper;
using Doccure.BranchService.Dtos.BranchDtos;
using Doccure.BranchService.Entities;

namespace Doccure.BranchService.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<Branch, ResultBranchDto>().ReverseMap();//branchı resultbranchdto ile ve tam tersi şekilde mapla 
            CreateMap<Branch, CreateBranchDto>().ReverseMap();
            CreateMap<Branch, UpdateBranchDto>().ReverseMap();
            CreateMap<Branch, GetBranchByIdDto>().ReverseMap();
        }
    }
}
