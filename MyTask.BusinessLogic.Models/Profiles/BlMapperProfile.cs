using AutoMapper;

namespace MyTask.BusinessLogic.Models.Profiles
{
    /// <summary>
    /// Профиль моделей BL
    /// </summary>
    public class BlMapperProfile : Profile
    {
        /// <inheritdoc />
        
        public BlMapperProfile()
        {
            CarModels.Product.CreateMaps(this);
        }
    }
}
