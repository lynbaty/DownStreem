using AutoMapper;
using downstreem.Dtos;
using downstreem.Models;
using downstreem.Repositories;
using downstreem.Services;
using Microsoft.AspNetCore.Mvc;

namespace downstreem.Controllers
{
    public class EntityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageUpload _imageUpload;

        public EntityController(IUnitOfWork unitOfWork, IMapper mapper, IImageUpload imageUpload)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageUpload = imageUpload;
        }
        public async Task<IActionResult> Index()
        {
            var entities =await _unitOfWork.Repository<Entity>().GetAll();

            return View(entities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntityCreateDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var entity = _mapper.Map<Entity>(model);
            if(model.Image!=null)
            {
                entity.Image =await _imageUpload.UpImageAsync(model.Image);
            }    
            entity.DateFirst = DateTime.Now.ToShortDateString();

            _unitOfWork.Repository<Entity>().Add(entity);
            await _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity =await _unitOfWork.Repository<Entity>().GetbyId(id);
            return View(_mapper.Map<EntityEditDTO>(entity));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EntityEditDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var entity = _mapper.Map<Entity>(model);

            if (model.UpdateImage != null)
            {
                entity.Image = await _imageUpload.UpImageAsync(model.UpdateImage);
            }  

            _unitOfWork.Repository<Entity>().Update(entity);
            await _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditImage(int id)
        {
           return View(new EntityEditImageDTO { Id = id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditImage(EntityEditImageDTO model)
        {
           
            var entity = await _unitOfWork.Repository<Entity>().GetbyId(model.Id);
            
            if (model.UpdateImage != null)
            {
                entity.Image = await _imageUpload.UpImageAsync(model.UpdateImage);
            }

            _unitOfWork.Repository<Entity>().Update(entity);
            await _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}
