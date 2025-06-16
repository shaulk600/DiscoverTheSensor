using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiscoverTheSensor.Sensors;
using DiscoverTheSensor.Sensors.BuilderSensors;
namespace DiscoverTheSensor.Agent
{
    internal class JuniorAgent : AbstractAgent
    {
        public int IdAgent {get;set;}
        public string Name { get; set; } // שם
        public string AgentRank { get; set; } // דרגה

        public RegularSensors[] SensorsToAttack;  //איזה סנסורי תקיפה יש עליו

        public RegularSensors[] SensorsToSurrender;  // איזה סנסורי תקיפה יגרום להכנעה - זה צריך להיות רנדומךלי
        public RegularSensors[] SensorsToSurrenderCopy; // ערך Copy.

        // 2 constractors
        public JuniorAgent(int idAgent, string name, string agentRank)
        {
            IdAgent = idAgent;
            Name = name;
            AgentRank = agentRank;
            SensorsToAttack = new RegularSensors[2];
            SensorsToSurrender = new RegularSensors[2];
            
        }
        public JuniorAgent (string name, string agentRank)
        {
            Name = name;
            AgentRank = agentRank;
            SensorsToAttack = new RegularSensors[2];
            SensorsToSurrender = new RegularSensors[2];
        }
        public virtual void RandomalAndCopyValueToSensorsToSurrender()
        {
            for (int i = 0; i< SensorsToSurrender.Length; i++)
            {
                SensorsToSurrender[i] = BuilderSensor.RandomObj();
            }
            
            Array.Copy(SensorsToSurrender, 0, SensorsToSurrenderCopy, 0, SensorsToSurrender.Length); // מתודה שאומרת העתק ממקום באינדקס מסוים - אל מקום - התחל באינדקס-עד איפה שתגיד-לאורך כמה

        }
        public abstract void ReturnOfSuccessfulAttack()
        {

        }
    }
}
