using Autofac;
using Microsoft.Extensions.Configuration;
using StockData.Worker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker
{
    public class WorkerModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IConfiguration _configuration;

        public WorkerModule(string connectionStringName, string migrationAssemblyName,
            IConfiguration configuration)
        {
            _connectionString = connectionStringName;
            _migrationAssemblyName = migrationAssemblyName;
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateStockModel>().As<ICreateStockModel>();
            builder.RegisterType<ExtractTableModel>().As<IExtractTableModel>();
            builder.RegisterType<CreateStockModel>().AsSelf();
            builder.RegisterType<ExtractTableModel>().AsSelf();
            base.Load(builder);
        }
    }
}
