using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Apps.WebApi.Controllers
{
    public interface IController<TEntity, TModel> where TEntity : IEntity
    {
        Task<ActionResult<IEnumerable<TModel>>> GetAsync();

        Task<ActionResult<TModel>> GetAsync(int id);

        Task<ActionResult> PostAsync(TModel model);

        Task<ActionResult> PutAsync(int id, TModel model);

        Task<ActionResult> DeleteAsync(int id);
    }
}