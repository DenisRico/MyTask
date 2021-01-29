using System.Collections.Generic;
using MyTask.Interfaces.Services;
using MyTask.DataAccess.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTask.BusinessLogic.Models;
using AutoMapper;


namespace MyTask.BusinessLogic.Services.Car
{
    public class ProductService : IProductService 
    {
        private readonly DatabaseContext _contextFactory;
        private readonly IMapper _mapper;

        public ProductService(DatabaseContext contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task AddAsync(MyTask.BusinessLogic.Models.CarModels.Product product)
        {
            var entity = _mapper.Map<MyTask.DataAccess.Models.Models.Product>(product);

            using var context = _contextFactory;

            await context.Products.AddAsync(entity).ConfigureAwait(false);
            
            await context.SaveChangesAsync().ConfigureAwait(false);


        }

        public async Task DeleteAsync(int id)
        {
            var context = _contextFactory;

            var entity = await context.Products.FirstOrDefaultAsync(item => item.Id.Equals(id))
                .ConfigureAwait(false);

            if (entity == null) return;

            context.Products.Remove(entity);

            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<MyTask.BusinessLogic.Models.CarModels.Product>> GetAsync()
        {
            var context = _contextFactory.Products;

            await context.ToListAsync().ConfigureAwait(false);

            var Items = _mapper.Map<IEnumerable<MyTask.BusinessLogic.Models.CarModels.Product>>(context);
            
            return Items;
        }

        public async Task UpdateAsync(MyTask.BusinessLogic.Models.CarModels.Product product)
        {
            var context = _contextFactory;

            var entity = await context.Products.FirstOrDefaultAsync(item => item.Id.Equals(product.Id))
                .ConfigureAwait(false);

            if (entity == null) return;
            
            entity.Name = product.Name;
            entity.Price = product.Price;


            context.Products.Update(entity);

            await context.SaveChangesAsync().ConfigureAwait(false);
            
        }
    }
}
