﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_Model;
        protected readonly string r_LisenceNumber;
        protected float m_PrecentageOfEnergyLeft;
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine;

        protected Vehicle(string i_Model, string i_LicenseNumber, Engine i_Engine)
        {
            m_Wheels = new List<Wheel>();
            r_Model = i_Model;
            r_LisenceNumber = i_LicenseNumber;
            m_PrecentageOfEnergyLeft = 0;
            m_Engine = i_Engine;
        }

        // Properties
        public string Model
        {
            get
            {
                return r_Model;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LisenceNumber;
            }
        }

        virtual public float PrecentageOfEnergyLeft
        {
            get
            {
                return m_PrecentageOfEnergyLeft;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }

            set
            {
                Engine = value;
            }
        }

        public abstract void UpdateProperties(object i_Obj, object i_SecObj);

        public abstract void AddWheels();
        public abstract List<string> GetMessagesAndParams();

        public void UpdatManufactererOfWheels(string i_NameOfManufacterer)
        {
            Wheel wheel;
            for (int i = 0; i < this.Wheels.Count; i++)
            {
                wheel = m_Wheels[i];
                wheel.Manufacturer = i_NameOfManufacterer;
                m_Wheels[i] = wheel;
            }
        }

        public abstract bool CheckValidProperties(int i_IndexOFInput, string i_InputsFromUser);

        //public static bool Is<T>(this string input)
        //{
        //    try
        //    {
        //        TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(input);
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //    return true;
        //}

 

        public void checkekIfValidProperty<T>(T i_Param, string i_Input)
        {
            var typeKind = typeof(T);
            Type ty = typeof(T);

            object[] args = { i_Input, typeKind.MakeByRefType() };
            Type type = i_Param.GetType();
            MethodInfo tryParse = type.GetMethod("TryParse");
            if (tryParse != null)
            {
                if (!(bool)tryParse.Invoke(null, args))
                {
                    throw new ArgumentException("not a valid formated type");
                }
                else
                {
                    i_Param = (T)args[1];
                }
            }
            else
            {
                throw new ArgumentException("not a valid formated type");
            }
        }

        public override string ToString()
        {
            return string.Format(@"
Model:{0}
license number:{1}
Wheels:", r_Model, r_LisenceNumber) + m_Wheels[0].ToString() + m_Engine.ToString();
        }
    }
}



