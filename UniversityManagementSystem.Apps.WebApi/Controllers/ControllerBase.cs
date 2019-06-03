using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Data.Entities;
using UniversityManagementSystem.Exceptions;
using UniversityManagementSystem.Services;

namespace UniversityManagementSystem.Apps.WebApi.Controllers
{
    public abstract class ControllerBase<TEntity, TModel> : ControllerBase, IController<TEntity, TModel>
        where TEntity : IEntity
    {
        protected ControllerBase(IService<TEntity> service)
        {
            Service = service;
        }

        private IService<TEntity> Service { get; }

        protected abstract IMapper Mapper { get; }

        public virtual async Task<ActionResult<IEnumerable<TModel>>> GetAsync()
        {
            var entities = await Service.GetAsync();

            var viewModels = Mapper.Map<IEnumerable<TModel>>(entities);

            return Ok(viewModels);
        }

        public virtual async Task<ActionResult<TModel>> GetAsync(int id)
        {
            var entity = await Service.GetAsync(id);

            if (entity == null) return NotFound();

            var model = Mapper.Map<TModel>(entity);

            return Ok(model);
        }

        public virtual async Task<ActionResult> PostAsync(TModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<TEntity>(model);

            await Service.AddAsync(entity);

            return NoContent();
        }

        public virtual async Task<ActionResult> PutAsync(int id, TModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<TEntity>(model);

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