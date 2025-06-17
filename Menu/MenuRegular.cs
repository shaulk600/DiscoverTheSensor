using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DiscoverTheSensor.Agent;
using DiscoverTheSensor.Agent.BuilderAgents;
using DiscoverTheSensor.Sensors;
using DiscoverTheSensor.Sensors.BuilderSensors;


namespace DiscoverTheSensor.Menu
{
    internal class MenuRegular
    {
        private  readonly BuilderRegularSensor sens;

        public MenuRegular()
        {
            bool ifSeccess = false;
            PrintMainMenu();

            sens = new BuilderRegularSensor.GetInstance();
            //sens.CreateRegularSensors();

            JuniorAgent iranyAgent = BuilderJuniorAgent.CreateRegularAgent();
            
            while (! ifSeccess)
            {
                iranyAgent.IntroducingTheSensorsForAttack();
                RegularSensors SensorToActive = BuilderRegularSensor.SelectingSpecificSensorAndReturningTheSensor(iranyAgent);

                ifSeccess = SensorToActive.Activate(iranyAgent);
            }
            Console.WriteLine("finish");
        }
        public  void PrintMainMenu()
        {
            Console.Clear();
            
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||           WELCOME TO GAME            ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||   Your task is:                      ||");             
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||      Obtaining the information       ||");                          
            Console.WriteLine("|| that the person in front of you has  ||");                               
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||     There are two interrogation      ||");
            Console.WriteLine("||       rooms in front of you.         ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||    Wait for further instructions...  ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||");
            
            Thread.Sleep(5000);  
        }

        


        public  string EnterAValue()
        {
            string userSelection = "";

            Console.Clear();

            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||           WELCOME TO GAME            ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||                                      ||");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||");

            userSelection = Console.ReadLine();
            return userSelection;
        }
    }
}
