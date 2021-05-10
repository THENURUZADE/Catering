using Catering.Core.Domain.Entities;
using Catering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Mappers
{
    public class ChiefMapper : BaseMapper<ChiefControlModel, Chief>
    {
        public override ChiefControlModel Map(Chief t)
        {
            ChiefControlModel chief = new ChiefControlModel();
            chief.Id = t.Id;
            chief.Email = t.Email;
            chief.Name = t.Name;
            chief.Phone = t.Phone;
            chief.Note = t.Note;

            return chief;
        }

        public override Chief Map(ChiefControlModel t)
        {
            Chief chief = new Chief();
            chief.Id = t.Id;
            chief.Email = t.Email;
            chief.Name = t.Name;
            chief.Phone = t.Phone;
            chief.Note = t.Note;
            return chief;
        }

        
    }
}
