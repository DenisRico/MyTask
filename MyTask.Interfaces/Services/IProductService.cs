using System.Collections.Generic;
using MyTask.BusinessLogic.Models;
using System.Threading.Tasks;

namespace MyTask.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<MyTask.BusinessLogic.Models.CarModels.Product>> GetAsync();
        
        Task AddAsync(MyTask.BusinessLogic.Models.CarModels.Product product);

        Task UpdateAsync(MyTask.BusinessLogic.Models.CarModels.Product product);

        Task DeleteAsync(int id);
    }
}
