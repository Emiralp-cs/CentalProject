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
    public class FeatureManager : IFeatureService
    {

        private readonly IFeatureDal _featureDal;

        private readonly IMapper _mapper;

        public FeatureManager(IFeatureDal featureDal, IMapper mapper)
        {
            _featureDal = featureDal;
            _mapper = mapper;
        }

        public void TCreate(Feature entity)
        {
            _featureDal.Create(entity);
        }

      

        public void TDelete(int id)
        {
            _featureDal.Delete(id);
        }

        public List<Feature> TGetAll()
        {
            return _featureDal.GetAll();
        }

        public Feature TGetById(int id)
        {

            return _featureDal.GetById(id);
        }

        public void TUpdate(Feature entity)
        {

            _featureDal.Update(entity);
        }


        public void TCreateN(Feature entity)
        {
            _featureDal.Create(_mapper.Map<Feature>(entity));
        }

        public List<BaseDto> TListN(BaseEntity entity)
        {
            
            return 
        }

       

        public BaseDto TUpdate_GetN(Feature entity)
        {
            
        }

        public Feature T_Update_PostN(Feature entity)
        {
           
        }
    }
}
