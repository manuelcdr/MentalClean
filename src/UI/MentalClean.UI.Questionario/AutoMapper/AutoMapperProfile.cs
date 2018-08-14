using AutoMapper;
using DDD.Infra.Cross.DomainDriver;
using DDD.Infra.Cross.DomainDriver.Extensions;
using System.Linq;

namespace MentalClean.UI.Questionario.AutoMapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
            : base()
        {
            MapearTodos();
            DominioParaViewModel();
            ViewModelParaDominio();
            OutrosMapeamentos();
        }

        private void DominioParaViewModel()
        {
        }

        private void ViewModelParaDominio()
        {
        }

        private void OutrosMapeamentos()
        {
        }

        private void MapearTodos()
        {
            foreach (var model in Driver.GetRefTypes("ViewModel"))
            {
                var domainTypes = model.GetDomainTypes();

                if (domainTypes == null || domainTypes.Count() == 0)
                    continue;

                foreach(var domainType in domainTypes)
                {
                    CreateMap(model, domainType);
                    CreateMap(domainType, model);
                }
            }
        }

        private IMappingExpression CreateMap<TSource>()
        {
            var tFonte = typeof(TSource);

            if (tFonte.Name.EndsWith("VM"))
            {
                var nomeDestino = typeof(TSource).Name.Replace("VM", "");
                var tDestino = Driver.DomainTypes.SingleOrDefault(t => t.Name == nomeDestino);

                if (tDestino != null)
                {
                    return CreateMap(tFonte, tDestino);
                }
            }
            else
            {
                var nomeDestino = typeof(TSource).Name + "VM";
                var tDestino = Driver.GetRefTypes("ViewModel").SingleOrDefault(t => t.Name == nomeDestino);

                if (tDestino != null)
                {
                    return CreateMap(tFonte, tDestino);
                }
            }

            return null;
        }

    }
}
