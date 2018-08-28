using System;
using Microsoft.Extensions.DependencyInjection;
using Networker.Client;
using Networker.Common;
using Networker.Common.Abstractions;

namespace Forza7DataClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var clientBuilder = new ClientBuilder()
                .UseLogger<ConsoleLogger>()
                .SetLogLevel(LogLevel.Info)
                .UseIp("127.0.0.1")
                .UseUdp(1)
                .RegisterPacketHandler<DataOutPacket, DataOutPacketHandler>();

            var services = clientBuilder.GetServiceCollection();
            services.AddSingleton<IPacketSerialiser, ForzaPacketSerialiser>();

            var client = clientBuilder.Build();
            client.Connect();

            Console.ReadLine();
        }
    }
}