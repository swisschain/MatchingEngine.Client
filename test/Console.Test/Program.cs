﻿ 
using System.Text.Json.Serialization;
using Com.Lykke.Matching.Engine.Incoming;
using Com.Lykke.Matching.Engine.Messages.Incoming;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;

namespace ConsoleTest
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = new MatchingEngine.Client.Grpc.MatchingEngine(
                    "http://172.16.0.4:4000",
                    "http://172.16.0.4:4001",
                    "http://172.16.0.4:4002",
                    "http://172.16.0.4:4003");



                var response = client.CashService.CashInOut(new CashInOutOperation()
                {
                    AssetId = "BTC",
                    ClientId = "test-2",
                    Id = "1",
                    Volume = 1.0,
                    MessageId = Guid.NewGuid().ToString("N")
                });
                CheckResponse(response);

                response = client.CashService.CashInOut(new CashInOutOperation()
                {
                    AssetId = "BTC",
                    ClientId = "test-2",
                    Id = "2",
                    Volume = -11.0,
                    MessageId = Guid.NewGuid().ToString("N")
                });
                CheckResponse(response);

                response = client.CashService.CashInOut(new CashInOutOperation()
                {
                    AssetId = "USD",
                    ClientId = "test-2",
                    Id = "3",
                    Volume = 10000,
                    MessageId = Guid.NewGuid().ToString("N")
                });
                CheckResponse(response);

                BalanceResponse balance = client.BalancesService.getBalance(new Com.Lykke.Matching.Engine.Incoming.BalanceRequest()
                {
                    ClientId = "test-2"
                });
                CheckResponse(balance);
                foreach (var asset in balance.Balances)
                {
                    Console.WriteLine($"{balance.ClientId}: {asset.AssetId} = {asset.Balance_}");
                }

                response = client.CashService.CashInOut(new CashInOutOperation()
                {
                    AssetId = "BTC",
                    ClientId = "test-3",
                    Id = "4",
                    Volume = 1,
                    MessageId = Guid.NewGuid().ToString("N")
                });
                CheckResponse(response);

                response = client.CashService.CashInOut(new CashInOutOperation()
                {
                    AssetId = "USD",
                    ClientId = "test-3",
                    Id = "5",
                    Volume = 10000,
                    MessageId = Guid.NewGuid().ToString("N")
                });
                CheckResponse(response);

                balance = client.BalancesService.getBalance(new Com.Lykke.Matching.Engine.Incoming.BalanceRequest()
                {
                    ClientId = "test-3"
                });
                CheckResponse(balance);
                foreach (var asset in balance.Balances)
                {
                    Console.WriteLine($"{balance.ClientId}: {asset.AssetId} = {asset.Balance_}");
                }


                response = client.TradingService.LimitOrder(new LimitOrder()
                {
                    ClientId = "test-2",
                    AssetPairId = "BTCUSD",
                    Price = 6000,
                    Volume = 1,
                    MessageId = Guid.NewGuid().ToString("N"),
                    Uid = "111"
                });
                CheckResponse(response);



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void CheckResponse(BalanceResponse response)
        {
        }

        private static void CheckResponse(Response response)
        {
            if (response.Status != 0)
            {
                Console.WriteLine($"Error: {response.Status}: {response.StatusReason}. Id: {response.Id}");
            }
        }
    }
}
