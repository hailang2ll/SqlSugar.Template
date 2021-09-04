using Autofac;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SqlSugar.Template
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;
            //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();


            #region 带有接口层的服务注入

            var servicesDllFile = Path.Combine(basePath, "SqlSugar.Template.Service.dll");
            var repositoryDllFile = Path.Combine(basePath, "SqlSugar.Template.Repository.dll");

            if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            {
                var msg = "Repository.dll和service.dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。";
                throw new Exception(msg);
            }


            //var cacheType = new List<Type>();
            //builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();//注册仓储

            //// 获取 Service.dll 程序集服务，并注册
            //var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            //builder.RegisterAssemblyTypes(assemblysServices)
            //          .AsImplementedInterfaces()
            //          .InstancePerDependency()
            //          .PropertiesAutowired()
            //          .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
            //          .InterceptedBy(cacheType.ToArray());//允许将拦截器服务的列表分配给注册。

            //// 获取 Repository.dll 程序集服务，并注册
            //var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            //builder.RegisterAssemblyTypes(assemblysRepository)
            //       .AsImplementedInterfaces()
            //       .PropertiesAutowired()
            //       .InstancePerDependency();

           string serviceName = AppDomain.CurrentDomain.FriendlyName.Replace(".Api", "").Replace("Api", "").Replace(".API", "").Replace("API", "");
            string iserviceName = serviceName;
            if (serviceName.EndsWith("."))
            {
                //iserviceName += "Contracts";
                serviceName += "Service";
            }
            else
            {
                //iserviceName += ".Contracts";
                serviceName += ".Service";
            }

            Assembly assemblysServices = Assembly.Load(serviceName);
            builder.RegisterAssemblyTypes(assemblysServices)
            .Where(t => t.FullName.EndsWith("Service") && !t.IsAbstract) //类名以service结尾，且类型不能是抽象的　
                .InstancePerLifetimeScope() //生命周期
                .AsImplementedInterfaces()
                .PropertiesAutowired(); //属性注入


            Assembly assemblysRepository = Assembly.Load("SqlSugar.Template.Repository");
            builder.RegisterAssemblyTypes(assemblysRepository)
            //.Where(t => t.FullName.EndsWith("Repository") && !t.IsAbstract) //类名以service结尾，且类型不能是抽象的　
                .InstancePerLifetimeScope() //生命周期
                .AsImplementedInterfaces()
                .PropertiesAutowired(); //属性注入

            #endregion

            #region 没有接口层的服务层注入

            //因为没有接口层，所以不能实现解耦，只能用 Load 方法。
            //注意如果使用没有接口的服务，并想对其使用 AOP 拦截，就必须设置为虚方法
            //var assemblysServicesNoInterfaces = Assembly.Load("Blog.Core.Services");
            //builder.RegisterAssemblyTypes(assemblysServicesNoInterfaces);

            #endregion

            #region 没有接口的单独类，启用class代理拦截

            //只能注入该类中的虚方法，且必须是public
            //这里仅仅是一个单独类无接口测试，不用过多追问
            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Love)))
            //    .EnableClassInterceptors()
            //    .InterceptedBy(cacheType.ToArray());
            #endregion

            #region 单独注册一个含有接口的类，启用interface代理拦截

            //不用虚方法
            //builder.RegisterType<AopService>().As<IAopService>()
            //   .AsImplementedInterfaces()
            //   .EnableInterfaceInterceptors()
            //   .InterceptedBy(typeof(BlogCacheAOP));
            #endregion

        }
    }
}
