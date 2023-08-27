using AutoMapper;
using SWQT._576Entity.Entities;
using System.Net;

namespace SWQT._128WebApi.Helper
{
    public class MainAutoMapperProfile : Profile
    {
        public MainAutoMapperProfile()
        {
            //Link hướng dẫn thêm: 
            //https://hanam88.com/kho-tai-lieu/63/107/tim-hieu-ve-automapper-trong-asp-net-core-5-0.html

            CreateMap<TblListPost, TblListPost>().ReverseMap();

            //trường hợp map các thuộc tính khác tên nhau (lưu ý phải 2 thuộc tính phải cùng kiểu)
            //CreateMap<ProductViewModel, Product>()
            //    .ForMember(dest=>dest.ProductName,o=>o.MapFrom(src=>src.Ten))
            //    .ForMember(dest => dest.Price, o => o.MapFrom(src => src.Gia))
            //    .ReverseMap();
        }
    }
}
