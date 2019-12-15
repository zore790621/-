using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DotrA_Lab.InternalDataService
{
    public class DataModelToViewModel
    {
        /// <summary>
        /// 自動轉換List
        /// </summary>
        /// <typeparam name="Tin">要轉</typeparam>
        /// <typeparam name="Tout">轉出</typeparam>
        /// <param name="source">要轉資料</param>
        /// <returns>轉出資料</returns>
        public static IEnumerable<Tout> GenericIEnumberableMapper<Tin, Tout>(IEnumerable<Tin> source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Tin, Tout>();
            });

            IMapper mapper = config.CreateMapper();

            IEnumerable<Tout> result = mapper.Map<IEnumerable<Tin>, IEnumerable<Tout>>(source);

            return result;
        }

        /// <summary>
        /// 自動轉換List
        /// </summary>
        /// <typeparam name="Tin">要轉</typeparam>
        /// <typeparam name="Tout">轉出</typeparam>
        /// <param name="source">要轉資料</param>
        /// <returns>轉出資料</returns>
        public static List<Tout> GenericListMapper<Tin, Tout>(IEnumerable<Tin> source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Tin, Tout>();
            });

            IMapper mapper = config.CreateMapper();

            List<Tout> result = mapper.Map<IEnumerable<Tin>, List<Tout>>(source);

            return result;
        }

        /// <summary>
        /// 自動轉換
        /// </summary>
        /// <typeparam name="Tin">要轉</typeparam>
        /// <typeparam name="Tout">轉出</typeparam>
        /// <param name="source">要轉資料</param>
        /// <returns>轉出資料</returns>
        public static Tout GenericMapper<Tin, Tout>(Tin source)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<Tin, Tout>()
                );
            IMapper mapper = config.CreateMapper();

            Tout result = mapper.Map<Tin, Tout>(source);

            return result;
        }
    }
}