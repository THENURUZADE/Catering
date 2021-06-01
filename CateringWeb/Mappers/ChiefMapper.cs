using Catering.Core.Domain.Entities;
using Catering.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Mappers
{
    public class ChiefMapper : BaseMapper<ChiefModel, Chief>
    {
        public override ChiefModel Map(Chief entity)
        {
            return new ChiefModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Note = entity.Note
            };
        }

        public override Chief Map(ChiefModel model)
        {
            return new Chief()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Note = model.Note
            };
        }
    }
}
