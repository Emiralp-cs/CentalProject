using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.BaseDtos;
using Cental.DTOLayer.FeatureDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class FeatureManager : GenericManager<Feature, ToListFeatureDTO, CreateFeatureDTO, UpdateFeatureDTO>,IFeatureService
    {
        public FeatureManager(IMapper mapper, IGenericDal<Feature> genericDal) : base(mapper, genericDal)
        {
        }
    }
}
