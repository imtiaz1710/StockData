using Autofac;
using StockData.DataService.Contexts;
using StockData.DataService.Repositories;
using StockData.DataService.Services;
using StockData.DataService.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Training
{
    public class DataServiceModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public DataServiceModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataServiceContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<DataServiceContext>().As<IDataServiceContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<StockPriceRepository>().As<IStockPriceRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<DataServiceUnitOfWork>().As<IDataServiceUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<StockService>().As<IStockService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
