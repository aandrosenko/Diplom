using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain;
using Domain.Abstract;
using WebUI.Helpers;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            var unitOfWork = _kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            _kernel.Bind<IUserHelper>().To<UserHelper>().WithConstructorArgument("unitOfWork", unitOfWork);
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}