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
                            printFilter();
                            break;
                        case 3:
                            ChangeVehicleStatus();
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
                            printByLicenseNumber();
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

                System.Threading.Thread.Sleep(4000);
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
        public void printFilter()
        {
            bool watchInRapir, watchIsFixed, watchIsPaid;
            Console.WriteLine("Do you want to see all vehicle (without filter) (Y/N)?");
            askYesOrNo(out bool watchAllAnswer);

            if (!watchAllAnswer)
            {
                Console.WriteLine("By rapir status ? [Y/N}");
                askYesOrNo(out watchInRapir);

                Console.WriteLine("By fixed status ? [Y/N}");
                askYesOrNo(out watchIsFixed);

                Console.WriteLine("By paid status ? [Y/N}");
                askYesOrNo(out watchIsPaid);
            }
            else
            {
                watchInRapir = true;
                watchIsFixed = true;
                watchIsPaid = true;
            }
            Console.Write(r_MyGarage.GarageVehcileFilter(watchInRapir, watchIsFixed, watchIsPaid));
        }
        public void printByLicenseNumber()
        {
            getLicenseNumber(out string io_LicenseNumber);

            if (r_MyGarage.VehcileInformation(io_LicenseNumber, out string io_VehicleInformation))
            {
                Console.WriteLine($"{io_VehicleInformation}{Environment.NewLine}" +
                    $"Press any key to go back to the menu");
            }
            else
            {
                Console.WriteLine("Vehicle is not found");
            }
        }
        public void addNewVehicleInput()
        {
            getPhoneNumberAndNmae(out string io_Name,out string io_PhoneNumber);
            getVehcile(out int io_VehcileChoice);
            getLicenseNumber(out string io_LicensenseNumber);

            if (r_MyGarage.addNewVehicle(io_Name, io_PhoneNumber, io_LicensenseNumber, io_VehcileChoice))
            {
                getExtraInformation(io_VehcileChoice, io_LicensenseNumber);
                Console.WriteLine("Added new vehcile to garage");
            }
            else
            {
                Console.WriteLine("This vehicle is already in");
            }


        }
        public void inflateToMax()
        {
            getLicenseNumber(out string io_LicenseNumber);

            if (r_MyGarage.InflateWheels(io_LicenseNumber))
            {
                Console.WriteLine("Wheels are now at full");
            }
            else
            {
                Console.WriteLine("License does not exist in our garage");
            }
        }
        public void fillGas()
        {
            int gasType = -1;
            float amountToadd = -1f;

            getLicenseNumber(out string licenseNumber);

            Console.WriteLine("Which type of gas do you want to add?");
            Console.Write(r_MyGarage.ShowFuelTypes());

            while (!int.TryParse(Console.ReadLine(), out gasType) || gasType < 1 || gasType > r_MyGarage.NumOfFuelTypes())
            {
                Console.WriteLine(r_ErrorMsg);
            }

            Console.WriteLine("How much do you want to add?");

            while (!float.TryParse(Console.ReadLine(), out amountToadd) || amountToadd < 0f)
            {
                Console.WriteLine("{0}{1}Please enter positive amount", r_ErrorMsg, Environment.NewLine);
            }

            if (r_MyGarage.fuelGas(licenseNumber, gasType, amountToadd))
            {
                Console.WriteLine("Tank Filled");
            }
            else
            {
                Console.WriteLine("Vehicle did not found.");
            }
        }
        public void chargeBattery()
        {
            string licenseNumber;
            float toAdd = -1f;

            getLicenseNumber(out licenseNumber);
            Console.WriteLine("Number of minutes to add:");
            float.TryParse(Console.ReadLine(), out toAdd);

            while (toAdd <= 0)
            {
                Console.WriteLine($"{r_ErrorMsg}{Environment.NewLine}" +
                    $"Please,{Environment.NewLine}" +
                    $"Enter a positive number");
            }

            if (r_MyGarage.chargeEnergey(licenseNumber, toAdd))
            {
                Console.WriteLine("Battery charged");
            }
            else
            {
                Console.WriteLine($"Viehclie not found in our garage{Environment.NewLine}");
            }

        }
        public void ChangeVehicleStatus()
        {
            int choice = 0;
            getLicenseNumber(out string licenseInput);

            Console.Write("Choose new status:{0}{1}", Environment.NewLine, r_MyGarage.ShowServiceStatus());

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > r_MyGarage.numOfSupportedVehciles())
            {
                Console.WriteLine(r_ErrorMsg);
            }

            if (r_MyGarage.ChangeServiceStatus(licenseInput, choice))
            {
                Console.WriteLine("Status Updated!");
            }
            else
            {
                Console.WriteLine("License does not exists in our garage");
            }
        }
        public void getPhoneNumberAndNmae(out string io_PhoneNumber, out string io_Name)
        {
            Console.WriteLine("Enter customer name:");
            io_Name = Console.ReadLine();

            if (io_Name.Length <= 1)
            {
                Console.WriteLine($"{r_ErrorMsg}{Environment.NewLine} Name should be at least 2 char's");
                io_Name = Console.ReadLine();
            }

            Console.WriteLine("Enter customer phone number:");
            io_PhoneNumber = Console.ReadLine();

            while (!int.TryParse(io_PhoneNumber, out int phoneNumberResult) || io_PhoneNumber.Length > 10 || io_PhoneNumber[0] != '0' ||io_PhoneNumber[1] != '5')
            {
                Console.WriteLine($"{r_ErrorMsg}{Environment.NewLine} Celephone number should be at least 10 digits" +
                    $"in form of 05x-xxx-xxxx ");
                io_PhoneNumber = Console.ReadLine();
            }
        }
        public void getVehcile(out int io_VehcileChoice)
        {
            int maxVehcileChoice = r_MyGarage.numOfSupportedVehciles();
            io_VehcileChoice = 0;

            Console.WriteLine("Please enter customer's vehcile :");
            Console.WriteLine(@"Options:
1. Regular Motorcycle
2. Electric Motorcycle
3. Regular Car
4. Electric Car
5. Truck");
            int.TryParse(Console.ReadLine(), out io_VehcileChoice);

            while(io_VehcileChoice < 1 || io_VehcileChoice > maxVehcileChoice)
            {
                Console.Write($"{r_ErrorMsg}{Environment.NewLine}" +
                    $"Must choose one of the following: 1-{maxVehcileChoice}{Environment.NewLine}");
                int.TryParse(Console.ReadLine(), out io_VehcileChoice);
            }
        }
        public void getLicenseNumber(out string io_LicenseNumber)
        {
            Console.WriteLine("Enter vehcile license number: ");
            io_LicenseNumber = Console.ReadLine();

            if(io_LicenseNumber.Length > k_LicenseLength)
            {
                Console.WriteLine($"{r_ErrorMsg}{Environment.NewLine}" +
                    $"Vehcile license number can not be larger than {k_LicenseLength}");
                io_LicenseNumber = Console.ReadLine();
            }
        }
        public void getExtraInformation(int io_VehcileChoice, string io_LicenseNumber)
        {
            Dictionary<ePossibleValues, object> extraInformationToFill = new Dictionary<ePossibleValues, object>();
            bool inputCheck = true;

            while (inputCheck)
            {
                if (extraInformationToFill.ContainsKey(ePossibleValues.ModelName))
                {
                    Console.WriteLine("Enter vehcile model name :");
                    extraInformationToFill[ePossibleValues.ModelName] = Console.ReadLine();
                }
                if (extraInformationToFill.ContainsKey((ePossibleValues)ePossibleValues.CurentWheelAirPressure))
                {
                    Console.WriteLine("Enter wheel's pressure: ");
                    extraInformationToFill[ePossibleValues.CurentWheelAirPressure] = Console.ReadLine();
                }
                if (extraInformationToFill.ContainsKey((ePossibleValues)ePossibleValues.CurrentFuel))
                {
                    Console.WriteLine("Enter amount of fuel left in your vehicle:");
                    extraInformationToFill[ePossibleValues.CurrentFuel] = Console.ReadLine();
                }
                if (extraInformationToFill.ContainsKey((ePossibleValues)ePossibleValues.CurrentHours))
                {
                    Console.WriteLine("Enter amount of hours left in your vehicle:");
                    extraInformationToFill[ePossibleValues.CurrentHours] = Console.ReadLine();
                }
                if (extraInformationToFill.ContainsKey((ePossibleValues)ePossibleValues.WheelManufacturer))
                {
                    Console.WriteLine("Enter wheels manufactuer: ");
                    extraInformationToFill[ePossibleValues.WheelManufacturer] = Console.ReadLine();
                }
                if (extraInformationToFill.ContainsKey((ePossibleValues)ePossibleValues.Color))
                {
                    string printMessage = string.Format($"Select cars color: {Environment.NewLine}" +
                        $"{r_MyGarage.ShowCarsColor()}");
                    Console.WriteLine(printMessage);
                    extraInformationToFill[ePossibleValues.Color] = Console.ReadLine();
                }
                if (extraInformationToFill.ContainsKey((ePossibleValues)ePossibleValues.Doors))
                {
                    string printMessage = string.Format($"Select car number of doors{Environment.NewLine}" +
                        $"{r_MyGarage.ShowCarsDoors()}");
                    Console.WriteLine(printMessage);
                    extraInformationToFill[ePossibleValues.Doors] = Console.ReadLine();
                }
                if (extraInformationToFill.ContainsKey((ePossibleValues)ePossibleValues.LicenseType))
                {
                    string printMessage = string.Format($"Select motorcycle license type:{Environment.NewLine}" +
                        $"{r_MyGarage.ShowMotorcycleLicense()}");
                    Console.WriteLine(printMessage);
                    extraInformationToFill[ePossibleValues.LicenseType] = Console.ReadLine();
                }
                if (extraInformationToFill.ContainsKey(ePossibleValues.EngineCapacity))
                {
                    Console.WriteLine("Enter vehcile engine capacity:");
                    extraInformationToFill[ePossibleValues.EngineCapacity] = Console.ReadLine();
                }
                if (extraInformationToFill.ContainsKey(ePossibleValues.CargoCpacity))
                {
                    Console.WriteLine("Enter truck cargo capacity:");
                    extraInformationToFill[ePossibleValues.CargoCpacity] = Console.ReadLine();
                }
                if (extraInformationToFill.ContainsKey(ePossibleValues.DangerousChemicals))
                {
                    Console.WriteLine("Does the truck contains dangerous chemicals ? [Y/N]");
                    askYesOrNo(out bool theAnswer);
                    extraInformationToFill[ePossibleValues.DangerousChemicals] = theAnswer;
                }
                try
                {
                    r_MyGarage.InsertInfo(extraInformationToFill, io_LicenseNumber);
                    inputCheck = false;
                }
                catch (Exception ex)
                {
                    if (ex is ValueOutOfRangeException)
                    {
                        Console.WriteLine((ex as ValueOutOfRangeException).InnerException.Message);
                    }

                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("Please fill missing information");
                }
            }
        }
        private void askYesOrNo(out bool io_theAnswer)
        {
            io_theAnswer = false;
            string userInput = Console.ReadLine();
            while (userInput != "Y" && userInput != "N")
            {
                Console.WriteLine($"{r_ErrorMsg}{Environment.NewLine}Please enter [Y/N]");
            }

            if (userInput == "N")
            {
                io_theAnswer = false;
            }
            else if (userInput == "Y")
            {
                io_theAnswer = true;
            }
        }
    }
}
