using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DiscoverTheSensor.Agent;
using DiscoverTheSensor.Sensors;
using DiscoverTheSensor.Sensors.BuilderSensors;

namespace DiscoverTheSensor.Menu
{
    internal class MenuRegular
    {
        public static int ValueOfVariableObj = 1;
        //ליסט של הסנסורים בעלי אפשרויות תקיפה
        List<JuniorAgent> JuniorAgents; // אובייקט של סוכנים - במידה ויש משחק גדול
        List<RegularSensors> RegularSensors; // אובייקט של סנסורים שקיים בכל אובייקט של סוכן

        public MenuRegular()
        {
            PrintMainMenu();
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

        //המתודות הבאות מייצרות אובייקטים של סוכן ושל סנסורים - לשקול העברה לקלאס נפרד כל אחד
        public void CreateAgentForGame()
        {
            //string name = "NameObject_" + Convert.ToString(_NameObj); // return : 'NameObject_1'
            JuniorAgents = new List<JuniorAgent>();

            JuniorAgents.Add(CreateAgentForGameByOne());
            //JuniorAgents.Add(CreateAgentForGameOne());
            
        }
        private JuniorAgent CreateAgentForGameByOne()
        {
            //יצירת אובייקט סוכן איראני
            string name= "Agent_" + Convert.ToString(ValueOfVariableObj); // return : 'Agent_1'.
            MenuRegular.ValueOfVariableObj++;
            JuniorAgent a = new JuniorAgent(name, "junior");
            return a;
        }



        public List<RegularSensors> CreateSensorsForGame()
        {
            RegularSensors = new List<RegularSensors>();
            RegularSensors.Add(CreateSensoreForGameByOne());
            RegularSensors.Add(CreateSensoreForGameByOne());
            return RegularSensors;
        }
        private RegularSensors CreateSensoreForGameByOne()
        {
            RegularSensors a = BuilderSensor.RandomObj();
            return a;
            
            //זה יופעל אם אני רוצה אובייקט ספציפי
            //string name = "Sensore_" + Convert.ToString(ValueOfVariableObj); // return : 'Sensore__1'.
            //MenuRegular.ValueOfVariableObj++;
            //RegularSensors a = new RegularSensors(name, "Selolar", 300);
        }

        public void DisplayingPossibleSensorsForAttack()
        {
            for(int i = 0; i < JuniorAgents.Count; i++)
            {
                Console.WriteLine($" the {JuniorAgents[i].Name} of the kind of {JuniorAgents[i].AgentRank}"); 
            }
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
