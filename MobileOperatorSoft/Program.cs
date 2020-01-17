using System;
using System.Collections.Generic;
using MobileOperatorSoft.DB;
using MobileOperatorSoft.Services;

namespace MobileOperatorSoft
{
    class Program
    {
        private static Dictionary<string, Action<Fasade>> commands;

        private static Fasade fasade;

        private static Storage storage;

        private static bool stopWork;

        static void Main(string[] args)
        {
            InitRepository();

            InitFasade();
            InitCommands();

            RunApp();
        }

        private static void InitRepository()
        {
            storage = new Storage();

            Number number1 = new Number(1234560);
            Number number2 = new Number(1234561);
            Number number3 = new Number(1234562);
            Number number4 = new Number(1234563);
            Number number5 = new Number(1234564);
            Number number6 = new Number(1234565);

            storage.PutEntity(number1);
            storage.PutEntity(number2);
            storage.PutEntity(number3);
            storage.PutEntity(number4);
            storage.PutEntity(number5);
            storage.PutEntity(number6);

            Tarif tarif1 = new Tarif(1, "junior", 50, 100, 1, 0.5);
            Tarif tarif2 = new Tarif(2, "midle", 100, 1000, 1, 0.5);
            Tarif tarif3 = new Tarif(3, "senior", 200, 10000, 1, 0.5);

            storage.PutEntity(tarif1);
            storage.PutEntity(tarif2);
            storage.PutEntity(tarif3);

            Client client = new Client(number1, tarif1);
            storage.PutEntity(client);
        }

        private static void RunApp()
        {
            while (!stopWork)
            {

                Console.WriteLine("Please choose action: \n");
                Console.WriteLine("1 - Show all availible numbers");
                Console.WriteLine("2 - Show all availible tarifs");
                Console.WriteLine("3 - Register client");
                Console.WriteLine("4 - Change client tarif");
                Console.WriteLine("5 - Show client information");
                Console.WriteLine("6 - Fill client balance");
                Console.WriteLine("0 - exit");

                string command = Console.ReadLine();

                if (!commands.ContainsKey(command))
                {
                    Console.WriteLine("Please chose correct number");
                }
                else
                {
                    commands[command].Invoke(fasade);
                }
            }
        }

        private static void InitFasade()
        {
            fasade = new Fasade(new NumberService(new NumberDao(storage)), 
                new ClientService(new ClientDao(storage)), 
                new TarifService(new TarifDao(storage)));
        }

        private static void InitCommands()
        {
            commands = new Dictionary<string, Action<Fasade>>();
            commands["1"] = (fasade) => fasade.GetAllAvailibleNumbers().ForEach(entity => Console.WriteLine(entity));
            commands["2"] = (fasade) => fasade.GetAllTarifs().ForEach(entity => Console.WriteLine(entity));
            commands["3"] = (fasade) =>
            {
                Console.WriteLine("Write a number");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Write a tarif id");
                int tarifId = int.Parse(Console.ReadLine());
                Console.WriteLine(
                    fasade.RegisterClient(number, tarifId)
                    ? "Client was registered"
                    : "Client was not registered, please check number and tarif id");
            };
            commands["4"] = (fasade) =>
            {
                Console.WriteLine("Write a number");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Write a tarif id");
                int tarifId = int.Parse(Console.ReadLine());
                Console.WriteLine(
                    fasade.ChangeClientTarif(number, tarifId)
                    ? "Tarif was changed"
                    : "Tarif was not changed, please check number and tarif id");
            };
            commands["5"] = (fasade) =>
            {
                Console.WriteLine("Write client number please");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(fasade.ShowClientInformation(number));
            };
            commands["6"] = (fasade) =>
            {
                Console.WriteLine("Write client number please");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Please input money ammount");
                int money = int.Parse(Console.ReadLine());
                Console.WriteLine(
                    fasade.PutMoneyOnClientBalanse(number, money)
                    ? "Client balanse was updated"
                    : "Client balanse was not updated, please check number and money ammount");
            };
            commands["0"] = (fasade) => stopWork = true;
        }
    }
}
