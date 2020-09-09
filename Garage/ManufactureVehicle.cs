﻿
namespace Ex03.GarageLogic
{
    public class ManufactureVehicle
    {
        // Enums:
        public enum eVehicleType
        {
            ElectricBike = 1,
            Bike,
            ElectricCar,
            Car,
            Truck
        }

        // Constructors:
        public static Vehicle CreateVehicle(string i_LicenseNumber, string i_Model, eVehicleType i_VehicleType)
        {
            Vehicle vehicleToCreate = null; 

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricBike:
                    vehicleToCreate = new Bike(
                        i_Model,
                        i_LicenseNumber,
                        createEngine(Engine.eEngineType.Electric, ElectricEngine.k_BikeBatteryTime));
                    break;
                case eVehicleType.Bike:
                    vehicleToCreate = new Bike(
                        i_Model,
                        i_LicenseNumber,
                        createEngine(Engine.eEngineType.Gas, GasEngine.k_BikeTank, GasEngine.eGasType.Octan95));
                    break;
                case eVehicleType.ElectricCar:
                    vehicleToCreate = new Car(
                        i_Model,
                        i_LicenseNumber,
                        createEngine(Engine.eEngineType.Electric, ElectricEngine.k_CarBatteryTime));
                    break;
                case eVehicleType.Car:
                    vehicleToCreate = new Car(
                        i_Model,
                        i_LicenseNumber,
                        createEngine(Engine.eEngineType.Gas, GasEngine.k_CarTank, GasEngine.eGasType.Octan96));
                    break;
                case eVehicleType.Truck:
                    vehicleToCreate = new Truck(
                        i_Model,
                        i_LicenseNumber,
                        createEngine(Engine.eEngineType.Gas, GasEngine.k_TruckTank, GasEngine.eGasType.Soler));
                    break;
            }

            return vehicleToCreate;
        }

        private static Engine createEngine(
            Engine.eEngineType i_EngineType, 
            float i_MaxCapacity, 
            GasEngine.eGasType i_GasType = GasEngine.eGasType.None)
        {
            Engine engine = null;

            if (i_EngineType == Engine.eEngineType.Electric)
            {
                engine = new ElectricEngine(i_MaxCapacity);
            }
            else
            {
                engine = new GasEngine(i_MaxCapacity, i_GasType);
            }
            
            return engine;
        }
    }
}
