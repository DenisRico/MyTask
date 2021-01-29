using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTask.DataAccess.Context;
using MyTask.DataAccess.Models.Models;
using MyTask.Interfaces.Services;
using Microsoft.AspNetCore.Http;


namespace MyTask.Controllers
{
    /// <summary>
    /// definition
    /// </summary>
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        //service
        IProductService _productService;
        //DataBase context
        DatabaseContext db;
        public ProductController(DatabaseContext context, IProductService productService)
        {
            db = context;
            _productService = productService;

        }

        ///// <summary>
        ///// Получаем список Car
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _productService.GetAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

       

        /// <summary>
        /// Получаем объект car по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        /// <summary>
        /// post
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(MyTask.BusinessLogic.Models.CarModels.Product product)
        {
            try
            {
                if (product == null) return BadRequest("product is required");

                await _productService.AddAsync(product);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

    


        /// <summary>
        /// Обновление product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(MyTask.BusinessLogic.Models.CarModels.Product product)
        {
            try
            {
                if(product == null) return BadRequest("product is required");

                await _productService.UpdateAsync(product);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }


   


        /// <summary>
        /// Удаление product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

      

    }
}
