using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class ConsoleUI
    {
        private const int k_LicenseLength = 9;
        private const int k_NumberOfOptions = 8;

        private readonly string r_ErrorMsg = "Ivalid input, please try again.";
        private readonly Garage r_MyGarage = new Garage();

        internal ConsoleUI()
        {
            //// Run garage menu
            int userChoice = 0;

            printOptions(out userChoice);

            while (userChoice != k_NumberOfOptions)
            {
                try
                {
                    switch (userChoice)
                    {
                        case 1:
                            addNewVehicleInput();
                            break;
                        case 2:
                            printByFilter();
                            break;
                        case 3:
                            changeVehicleStatus();
                            break;
                        case 4:
                            inflateToMax();
                            break;
                        case 5:
                            fillGas();
                            break;
                        case 6:
                            chargeBattery();
                            break;
                        case 7:
                            printByLicense();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is ValueOutOfRangeException)
                    {
                        Console.WriteLine((ex as ValueOutOfRangeException).InnerException.Message);
                    }

                    Console.WriteLine(ex.Message);
                }

                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                printOptions(out userChoice);
            }
        }
        public void printOptions(out int io_UserChoice)
        {
            io_UserChoice = 0;
            string showError = string.Format($"{this.r_ErrorMsg}{Environment.NewLine} the input is invalid !{Environment.NewLine}" +
                $"Try 1-8{Environment.NewLine}");
            string garageMenu = string.Format(
                @"Welcome to our garage {0}
                Options:
                1. Enter new vehicle to the garage.
                2. Show license number of vehicles by filter.
                3. Change status of vehicle.
                4. Inflating air in wheels.
                5. Fill gas tank.
                6. Charge battery.
                7. Show vehicle details.
                8. Exit {0}", Environment.NewLine);
            Console.Write(garageMenu);

            while(!int.TryParse(Console.ReadLine(), out io_UserChoice) || io_UserChoice < 1 || io_UserChoice > k_NumberOfOptions)
            {
                Console.WriteLine(showError);
            }
        }
        public void addNewVehicleInput()
        {
            ///...
        }

    }
}
