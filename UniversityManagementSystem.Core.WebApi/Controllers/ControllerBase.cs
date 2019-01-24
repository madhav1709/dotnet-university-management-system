using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Core.Data.Entities;
using UniversityManagementSystem.Core.Services;
using UniversityManagementSystem.Exceptions;

namespace UniversityManagementSystem.Core.WebApi.Controllers
{
    public abstract class ControllerBase<TEntity, TViewModel> : ControllerBase, IController<TEntity, TViewModel>
        where TEntity : IEntity
    {
        protected ControllerBase(IService<TEntity> service)
        {
            Service = service;
        }

        private IService<TEntity> Service { get; }

        protected abstract IMapper Mapper { get; }

        public virtual async Task<ActionResult<IEnumerable<TViewModel>>> GetAsync()
        {
            var entities = await Service.GetAsync();

            var viewModels = Mapper.Map<IEnumerable<TViewModel>>(entities);

            return Ok(viewModels);
        }

        public virtual async Task<ActionResult<TViewModel>> GetAsync(int id)
        {
            var entity = await Service.GetAsync(id);

            if (entity == null) return NotFound();

            var viewModel = Mapper.Map<TViewModel>(entity);

            return Ok(viewModel);
        }

        public virtual async Task<ActionResult> PostAsync(TViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<TEntity>(viewModel);

            await Service.AddAsync(entity);

            return NoContent();
        }

        public virtual async Task<ActionResult> PutAsync(int id, TViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<TEntity>(viewModel);

            await Service.UpdateAsync(entity);

            return NoContent();
        }

        public virtual async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await Service.DeleteAsync(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}