using Autofac;
using Customer.Application.Commands.BlobStorageCommands;
using Customer.Application.Commands.QueueStorageFirstCommands;
using Customer.Application.Commands.SellerCommands;
using Customer.Application.Commands.TableStorageCosmosCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Customer.Api.Infraestructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder) 
        {
            builder.RegisterAssemblyTypes(typeof(IMediator)
                .GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(CreateSellerCommand)
                .GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(UploadBlobStorageCommand)
                .GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(InsertUpdateContactCosmosTableStorageCommand)
                .GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(DeleteContactCosmosTableStorageCommand)
                .GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(InsertQueueStorageFirstCommand)
                .GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(ConsumeQueueStorageFirstCommand)
                .GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });
        }
    }
}
