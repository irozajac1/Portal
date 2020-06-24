using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Requests;

namespace WebApplication1.Interface
{
    public interface IPortalService
    {
        List<About> GetAllText();
        About GetTextByID(Guid id);
        void SetAboutText(About a);
        void PostFile(IFormFile myfile);
        void deleteTextAbout(About a);
        void deleteFile(Attachment myfile);
        List<Documentation> GetAllDocumentation();
        Documentation getById(Guid id);
        List<Documentation> getByGroupName(string group);
        void addDocumentation(Documentation documentation);
        void deleteDocumentation(Documentation documentation);
        void deleteAllGroup(string group);
        List<News> GetAllNews();
        List<Attachment> getAllFiles();
        Attachment getFileById(Guid id);
        Meetings GetMeeting(Guid id);
        void PostLink(Meetings meeting);
        void DeleteLink(Guid id);

    }
}
