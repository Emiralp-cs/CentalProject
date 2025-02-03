using Cental.DTOLayer;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IGenericService<Entity, ToListDto, CreateDto, UpdateDto> where Entity : class, new()
        where ToListDto : class, new()
        where CreateDto : class, new()
        where UpdateDto : class
    {
        List<Entity> TGetAll();
        Entity TGetById(int id);
        void TDelete(int id);
        void TCreate(Entity entity);
        void TUpdate(Entity entity);
        List<ToListDto> TListN();

        void TCreateN(CreateDto createDto);

        UpdateDto TUpdate_GetN(int id);

        void T_Update_PostN(UpdateDto updateDto);








    }
}
