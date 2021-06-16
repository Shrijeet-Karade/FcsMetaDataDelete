using System;
using System.Threading;
using System.Threading.Tasks;
using Tavisca.DataApis.Sdk;
using Tavisca.DataApis.Sdk.Internal;

namespace FCS_Metadata_Delete
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(" ///----------- Welcome to Delete Metadata App --------------\\\\ ");
            Console.WriteLine("\n");

            var dataApiClientFactory = InitializeDataApiEnvironment();

            StartProcess(dataApiClientFactory);
            
        }

        private static void StartProcess(IDataApiClientFactory dataApiClientFactory)
        {
            var input = "default";
            while (input != "0")
            {
                Console.Clear();
                Console.WriteLine("\n What do you want to delete ? \n 1. Feature \n 2. Flag \n 3. Setting \n 4. Route");
                Console.WriteLine("press the corresponding number (example: 1) or press 0 to exit ");
                input = Console.ReadLine();

                var isValid = ValidateInput(input);

                while (!isValid)
                {
                    Console.Clear();
                    Console.WriteLine("\n Invalid Input Detected");
                    Console.WriteLine("What do you want to delete ? \n 1. Feature \n 2. Flag \n 3. Setting \n 4. Route");
                    Console.WriteLine("press the corresponding number or press 0 to exit ");
                    input = Console.ReadLine();
                    isValid = ValidateInput(input);
                }

                var inputString = Convert.ToInt32(input);
                PerformOperation(inputString, dataApiClientFactory);
                Console.WriteLine("Press Enter to continue");
                Console.ReadKey();
            };
        }

        private static IDataApiClientFactory InitializeDataApiEnvironment()
        {
            ConfigureDataApiClientDefaults();
            var env = Helper.GetEnvironmentInfo();
            var factory = new DataApiClientFactory();
            DataApiClientFactory.activeEnvironment = env;
            return factory;
        }

        private static void ConfigureDataApiClientDefaults()
        {
            var dataApiOptions = new ApiOptions();
            dataApiOptions.Factory.Register<ITraceWriter, DataApiTraceWriter>();
            Tavisca.DataApis.Sdk.AppContext.Initialize(dataApiOptions);
            Tavisca.DataApis.Sdk.AppContext.Debug.ApiLogging.LogFailures();
        }

        private static bool ValidateInput(string input)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(input,"1") ||
                StringComparer.OrdinalIgnoreCase.Equals(input,"2") ||
                StringComparer.OrdinalIgnoreCase.Equals(input,"3") ||
                StringComparer.OrdinalIgnoreCase.Equals(input,"4") ||
                StringComparer.OrdinalIgnoreCase.Equals(input,"0")  )
                return true;

            else
                return false;
        }

        private static void PerformOperation (int input, IDataApiClientFactory dataApiClientFactory)
        {
            switch (input)
            {
                case 1:
                    Console.WriteLine("Operation Delete-Feature Confirmed \n");
                    Thread.Sleep(400);
                    FeatureUtility.InitiateDelete(dataApiClientFactory);
                    break;

                case 2:
                    Console.WriteLine("Operation Delete-Flag Confirmed \n");
                    Thread.Sleep(400);
                    FlagUtility.InitiateDelete(dataApiClientFactory);
                    break;

                case 3:
                    Console.WriteLine("Operation Delete-Setting Confirmed \n");
                    Thread.Sleep(400);
                    SettingUtility.InitiateDelete(dataApiClientFactory);
                    break;

                case 4:
                    Console.WriteLine("Operation Delete-Route Confirmed \n");
                    Thread.Sleep(400);
                    RouteUtility.InitiateDelete(dataApiClientFactory);
                    break;

                case 0:
                    Console.WriteLine("----------------------------------\n Application shutdown initiated \n----------------------------------");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}