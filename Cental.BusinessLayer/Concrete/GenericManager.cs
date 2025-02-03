using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.BaseDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{

    public class GenericManager<Entity, ToListDto, CreateDto, UpdateDto> : IGenericService<Entity, ToListDto, CreateDto, UpdateDto> where Entity : class, new() where ToListDto : class, new() where CreateDto : class, new() where UpdateDto : class
        

    {   
        private readonly IMapper _mapper;
        private readonly IGenericDal<Entity> _genericDal;
        public GenericManager(IMapper mapper, IGenericDal<Entity> genericDal)
        {
            _mapper = mapper;
            _genericDal = genericDal;
        }

       

        public void TCreate(Entity entity)
        {
          _genericDal.Create(entity);
        }



        public void TDelete(int id)
        {
            _genericDal.Delete(id);
        }

        public List<Entity> TGetAll()
        {
          return _genericDal.GetAll();
        }
        public void TUpdate(Entity entity)
        {
            _genericDal.Update(entity);
        }
        public Entity TGetById(int id)
        {
           return _genericDal.GetById(id);
        }

        public void TCreateN(CreateDto createDto)
        {
           
            _genericDal.Create(_mapper.Map<Entity>(createDto));
        }
        public List<ToListDto> TListN()
        {
            
            return _mapper.Map<List<ToListDto>>(_genericDal.GetAll());

        }



        public UpdateDto TUpdate_GetN(int id)
        {

            return _mapper.Map<UpdateDto>(_genericDal.GetById(id));
        }

        public void T_Update_PostN(UpdateDto updateDto)
        {

            _genericDal.Update(_mapper.Map<Entity>(updateDto));

        }
    }
}
