using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Core.Data.Entities;

namespace UniversityManagementSystem.Core.WebApi.Controllers
{
    public interface IController<TEntity, TViewModel> where TEntity : IEntity
    {
        Task<ActionResult<IEnumerable<TViewModel>>> GetAsync();

        Task<ActionResult<TViewModel>> GetAsync(int id);

        Task<ActionResult> PostAsync(TViewModel viewModel);

        Task<ActionResult> PutAsync(int id, TViewModel viewModel);

        Task<ActionResult> DeleteAsync(int id);
    }
}