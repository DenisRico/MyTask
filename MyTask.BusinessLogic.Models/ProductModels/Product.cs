using AutoMapper;

namespace MyTask.BusinessLogic.Models.CarModels
{
    /// <summary>
    /// Model Car
    /// </summary>
    public class Product
    {
        public int Id { get; set; }   //id
        public string Name { get; set; }    // name 
        public int Price { get; set; }  // price


        /// <summary>
		/// Мапка автомапера
		/// </summary>
		/// <param name="profile"></param>
		public static void CreateMaps(Profile profile)
        {
            profile.CreateMap<MyTask.DataAccess.Models.Models.Product, Product>()
                .ForMember(item => item.Id, exp => exp.MapFrom(item => item.Id))
                .ForMember(item => item.Name, exp => exp.MapFrom(item => item.Name))
                .ForMember(item => item.Price, exp => exp.MapFrom(item => item.Price))

                .ReverseMap();
        }
    }
}
