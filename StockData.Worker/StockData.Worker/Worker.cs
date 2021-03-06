using Autofac;
using HtmlAgilityPack;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockData.DataService.Services;
using StockData.Worker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockData.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public static ILifetimeScope AutofacContainer { get; private set; }

        public Worker(ILogger<Worker> logger, ILifetimeScope autofacContainer)
        {
            _logger = logger;
            AutofacContainer = autofacContainer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var createStockModel = new CreateStockModel();
                createStockModel.LoadTableData();
                createStockModel.Create();

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}
