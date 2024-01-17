using ExamPre3.Business.CustomExceptions.ServiceExceptions;
using ExamPre3.Business.Service.Interfaces;
using ExamPre3.Core.Models;
using ExamPre3.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre3.Business.Service.Implementations
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IWebHostEnvironment _env;

        public ServicesService(IServiceRepository serviceRepository,IWebHostEnvironment env)
        {
            _serviceRepository = serviceRepository;
            _env = env;
        }
        public async Task CreateAsync(Services entity)
        {
            if(entity.FormFile !=null)
            {
                if(entity.FormFile.ContentType != "image/png" && entity.FormFile.ContentType != "image/jpeg")
                {
                    throw new ContentTypeException("FormFile", "png or jpeg file");
                }
                if (entity.FormFile.Length > 2097600)
                {
                    throw new FileLengthException("FormFile", " file must be less than 2 mb ");
                }

                entity.ImageUrl = Helper.Helper.SaveFile(_env.WebRootPath, "Uploads/Services", entity.FormFile);
            }

            await _serviceRepository.CreateAsync(entity);
            await _serviceRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var trainer =await _serviceRepository.GetByIdAsync(x => x.Id == id);
            if (trainer == null) throw new TrainerNullException();
            
                 _serviceRepository.DeleteAsync(trainer);
                await _serviceRepository.CommitAsync();
            
        }

        public  async Task<List<Services>> GetAllAsync()
        {
            return await _serviceRepository.GetAllAsync();


        }

        public async Task<Services> GetByIdAsync(int id)
        {
            return await _serviceRepository.GetByIdAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var trainer = await _serviceRepository.GetByIdAsync(x => x.Id == id);
            if (trainer == null) throw new TrainerNullException();

            trainer.IsDeleted = !trainer.IsDeleted;
            await _serviceRepository.CommitAsync();
        }

        public async Task UpdateAsync(Services entity)
        {
            var existTrainer = await _serviceRepository.GetByIdAsync(x => x.Id == entity.Id);
            if (existTrainer == null) throw new TrainerNullException();

            if(entity.FormFile != null)
            {
                if (entity.FormFile.ContentType != "image/png" && entity.FormFile.ContentType != "image/jpeg")
                {
                    throw new ContentTypeException("FormFile", "png or jpeg file");
                }
                if (entity.FormFile.Length > 2097600)
                {
                    throw new ContentTypeException("FormFile", " file must be less than 2 mb ");
                }

                string oldpatch = Path.Combine(_env.WebRootPath, "Uploads/Services", existTrainer.ImageUrl);
                if (File.Exists(oldpatch))
                {
                    File.Delete(oldpatch);
                }

                existTrainer.ImageUrl = Helper.Helper.SaveFile(_env.WebRootPath, "Uploads/Services", entity.FormFile);

            }

            existTrainer.Name = entity.Name;
            existTrainer.InstaUrl = entity.InstaUrl;
            existTrainer.TwutUrl = entity.TwutUrl;
            existTrainer.FaceUrl = entity.FaceUrl;

            await _serviceRepository.CommitAsync();
        }
    }
}
