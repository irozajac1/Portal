using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Requests;

namespace WebApplication1.Interface
{
    public interface ILiteratureService
    {
        List<Literature> GetAll();
        Literature GetById(Guid id);
        List<Literature> GetAllByGroup(string group);
        void PostLiterature(Models.Requests.LiteratureRequest messageRequest);
        void DeleteLiterature(Guid id);
        int GetNotApproved();
    }
}
