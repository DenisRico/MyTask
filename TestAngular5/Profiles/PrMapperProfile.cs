using AutoMapper;


namespace TestAngular5.Profiles
{
    /// <summary>
    /// Конфигурация маппинга уровня Presentation
    /// </summary>
    public class PrMapperProfile : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PrMapperProfile()
        {
            MyTask.BusinessLogic.Models.CarModels.Product.CreateMaps(this);
        }
    }
}
