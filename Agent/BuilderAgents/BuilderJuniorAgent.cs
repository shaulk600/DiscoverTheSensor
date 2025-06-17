using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoverTheSensor.Menu;

namespace DiscoverTheSensor.Agent.BuilderAgents
{
    internal static class BuilderJuniorAgent
    {
        private static int ValueOfVariableObj = 1;

        //יצירת Agent
        public static JuniorAgent CreateRegularAgent()
        {
            string name = "Agent_" + Convert.ToString(ValueOfVariableObj); // return : 'Agent_1'.
            BuilderJuniorAgent.ValueOfVariableObj++;
            JuniorAgent a = new JuniorAgent(name, "junior");
            return a;
        }
        
        ////מתודה ליצירת List של סוכנים 
        //public
        //לרשום

        ////מתודה להדפסת שמותיהם מתוך הליסט 
        //public static void DisplayingPossibleSensorsForAttack()
        //{
        //    for (int i = 0; i < JuniorAgents.Count; i++)
        //    {
        //        Console.WriteLine($" the {JuniorAgents[i].Name} of the kind of {JuniorAgents[i].AgentRank}");
        //    }
        //}
    }
}
