using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Extensions.Enums
{
    public static class GetEnumValues
    {
        public static List<SelectListItem> GetEnums<T>() where T : Enum
        {

            var values = Enum.GetValues(typeof(T));

            var selectList = new List<SelectListItem>();

            foreach (var item in values)
            {
                selectList.Add(new SelectListItem
                {
                    Text = item.ToString(),
                    Value = item.ToString()
                    
                });
            }

            return selectList;
        }

    }
}
