using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HamburgerApp.DataAccess.EntityFramework.Concrete;
using HamburgerApp.DataAccess.Abstract;
using HamburgerApp.Business.AutooMapper;
using HamburgerApp.Business.Services.HamburgerMenuService;
using HamburgerApp.Business.Services.ExtraMaterialService;
using HamburgerApp.Business.Services.OrderService;

namespace HamburgerApp.Business.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //repository
            builder.RegisterType<OrderRepo>().As<IOrderRepo>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepo>().As<IProductRepo>().InstancePerLifetimeScope();

            //services burası açılacak
            builder.RegisterType<HamburgerMenuService>().As<IHamburgerMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<ExtraMaterialService>().As<IExtraMaterialService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderServices>().As<IOrderServices>().InstancePerLifetimeScope();

            //automapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                //Mapping dosyamızıda buraya ekliyoruz gidip startup'ta eklemek zorunda kalmayalım zaten burasının görevi oraya sağlamak olacak.
                cfg.AddProfile<Mapping>();
            }
            )).AsSelf().SingleInstance();




            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
