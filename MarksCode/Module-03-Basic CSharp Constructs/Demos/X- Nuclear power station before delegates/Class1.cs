using System;
using System.Collections;
using System.Text;

namespace P41__Nuclear_power_station_before_delegates
{

    public class ExampleOfUse
    {
        public static void Main()
        {
            CoreTempMonitor ctm = new CoreTempMonitor();
            ElectricPumpDriver ed1 = new ElectricPumpDriver();
            ctm.Add(ed1);
            PneumaticPumpDriver pd1 = new PneumaticPumpDriver();
            ctm.Add(pd1);
            ctm.SwitchOnAllPumps();
            Console.WriteLine("Press any key to continue"); Console.ReadLine();
        }
    }


    public class CoreTempMonitor
    {
        public void Add(object pump)
        {
            pumps.Add(pump);
        }

        /**************************************
         * The issue with the following code is that it
         * would constantly have to change if we wanted to add 
         * new kinds of pumps. we need a design that requires minimum
         * change if we're adding new kinds of pumps.
         * *************************/
        public void SwitchOnAllPumps()
        {
            foreach (object pump in pumps)
            {
                if (pump is ElectricPumpDriver)
                {
                    ((ElectricPumpDriver)pump).StartElectricPumpRunning();
                }
                if (pump is PneumaticPumpDriver)
                {
                    ((PneumaticPumpDriver)pump).SwitchOn();
                }

            }
        }

        private ArrayList pumps = new ArrayList();
    }
    


    public class ElectricPumpDriver
    {
        public void StartElectricPumpRunning()
        {
            Console.WriteLine("ElectricPumpDriver StartElectricPumpRunning");
        }
    }

    public class PneumaticPumpDriver
    {
        public void SwitchOn()
        {
            Console.WriteLine("PneumaticPumpDriver SwitchOn"); 
        }
    }
}
