using System;
using System.Collections;
using System.Text;

namespace P41__Nuclear_power_station_before_delegates
{

    public class ExampleOfUse
    {
        public static void Main()
        {
            CoreTempMonitor.PumpStartDelegate ptrStart;


            CoreTempMonitor ctm = new CoreTempMonitor();

            //Add electric pump
            ElectricPumpDriver ed1 = new ElectricPumpDriver();
            ptrStart = ed1.StartElectricPumpRunning;
            ctm.Add(ptrStart);

            //Add Pneumatic pump
            PneumaticPumpDriver pd1 = new PneumaticPumpDriver();
            ptrStart = pd1.SwitchOn;
            ctm.Add(ptrStart);

            ctm.SwitchOnAllPumps();

            Console.WriteLine("Press any key to continue"); Console.ReadLine();
        }
    }


    public class CoreTempMonitor
    {
        public delegate void PumpStartDelegate();

        public void Add(PumpStartDelegate pumpDelegate)
        {
            pumpDelegates.Add(pumpDelegate);
        }
        public void SwitchOnAllPumps()
        {
            //The following code does not need to change 
            //when new kinds of pumps are installed.
            foreach (object pumpDelegate in pumpDelegates)
            {
                PumpStartDelegate ptrToStartFunction = pumpDelegate as PumpStartDelegate;
                if (ptrToStartFunction != null)
                    ptrToStartFunction.Invoke();

            }
        }

        private ArrayList pumpDelegates = new ArrayList();
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
