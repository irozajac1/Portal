using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interface;
using WebApplication1.Models;
using WebApplication1.Models.Requests;

namespace WebApplication1.Services
{
    public class LiteratureService : ILiteratureService
    {
        public IHostingEnvironment _env;
        IConfiguration _configuration;
        public IPortalRepository<Literature> repository;

        public LiteratureService(IHostingEnvironment env, IConfiguration configuration, IPortalRepository<Literature> repository)
        {
            _env = env;
            _configuration = configuration;
            this.repository = repository;
        }

        public void DeleteLiterature(Guid id)
        {
            var literature = repository.GetById(id);
            repository.Delete(literature);
        }

        public List<Literature> GetAll()
        {
            return repository.IncludeAll().ToList();
        }

        public List<Literature> GetAllByGroup(string group)
        {
            return repository.FindByCondition(x => x.Group == group);
        }

        public Literature GetById(Guid id)
        {
            return repository.GetById(id);
        }

        public void PostLiterature(Models.Requests.LiteratureRequest literatueRequest)
        {
            var attachment = new Attachment();
            var folderPath = _configuration.GetSection("Paths:Archive").Value + "\\Literature\\";
            var files = literatueRequest.Files;
            if (files != null)
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                foreach (var myFile in files)
                {
                    var fileNameWithGuid = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(myFile.FileName);
                    var fileName = myFile.FileName;
                    var fullPath = Path.Combine(folderPath, fileNameWithGuid);

                    using (FileStream fileStream = System.IO.File.Create(folderPath + fileNameWithGuid))
                    {
                        myFile.CopyTo(fileStream);
                    }

                    var att = new Attachment
                    {
                        AttachmentFileName = fileName,
                        AttachmentFileReference = fileNameWithGuid
                    };
                    attachment = att;
                }

            }
            var literature = new Literature
            {
                Files = attachment,
                Email = literatueRequest.Email,
                IsApproved = false,
                IsDeleted = false,
                Title = literatueRequest.Title,
                Group = literatueRequest.Group,
                Link = literatueRequest.Link
               
            };
            repository.Insert(literature);
        }

        public int GetNotApproved()
        {
            var nummber = repository.GetAll().Where(x => x.IsApproved == false && x.IsDeleted == false).Count();
            return nummber;
        }
    }
}
