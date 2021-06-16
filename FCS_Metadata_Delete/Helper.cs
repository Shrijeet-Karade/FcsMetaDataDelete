using FCS_Metadata_Delete.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FCS_Metadata_Delete
{
    public static class Helper
    {
        public static string GetApplicationInfo(IDataApiClientFactory dataApiClientFactory)
        {
            Application application = null;
            do
            {
               Console.WriteLine("Enter valid application name");
               var applicationName = Console.ReadLine();
               application = ApplicationUtility.GetApplication(dataApiClientFactory, applicationName);
                
            } while (application == null);

            return application.Id;
        }
        public static string GetApplicationInstanceInfo(IDataApiClientFactory dataApiClientFactory)
        {
            ApplicationInstance appInstance = null;
            do
            {
                Console.WriteLine("\n Enter valid application-instance name");
                var applicationInstanceName = Console.ReadLine();
                appInstance = AppInstanceUtility.GetApplicationInstance(dataApiClientFactory, applicationInstanceName);

            } while (appInstance == null);

            return appInstance.Id;
        }

        public static string GetEnvironmentInfo()
        {
            Console.WriteLine("Enter environment where you want to perform these operations");
            Console.WriteLine("enter one of the following \n qa \n stage");
            var env = Console.ReadLine();
            var isInvalidEnv = true;
            do
            {
                if(StringComparer.OrdinalIgnoreCase.Equals(env, Constants.Environment.Qa))
                {
                    isInvalidEnv = false;
                    return Constants.Environment.Qa;
                }
                else if(StringComparer.OrdinalIgnoreCase.Equals(env, Constants.Environment.Stage))
                {
                    isInvalidEnv = false;
                    return Constants.Environment.Stage;
                }
                else
                {
                    Console.WriteLine("\nInvalid Input");
                    Console.WriteLine("enter one of the following \n qa \n stage \n");
                    env = Console.ReadLine();
                    isInvalidEnv = true;
                }
            } while (isInvalidEnv);

            //default which will never be called
            return Constants.Environment.Qa;
        }

        public static bool IsAppInstanceLevelData()
        {
            Console.WriteLine("\n Does the entity exists on appinstance level ?");
            Console.WriteLine(" Enter Y for yes and any other key to skip");
            var input = Console.ReadLine();
            return StringComparer.OrdinalIgnoreCase.Equals(input ,"Y");
        }
    }
}
