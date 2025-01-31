using AutoMapper;
using Cental.DTOLayer.FeatureDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, ToListFeatureDTO>().ReverseMap();
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
        }
    }
}
