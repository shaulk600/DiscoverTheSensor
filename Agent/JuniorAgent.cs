using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiscoverTheSensor.Sensors;
namespace DiscoverTheSensor.Agent
{
    internal class JuniorAgent : AbstractAgent
    {
        public int IdAgent {get;set;}
        public string Name { get; set; } // שם
        public string AgentRank { get; set; } // דרגה

        public RegularSensors[] SensorsToAttack;  //איזה סנסורי תקיפה יש עליו

        public RegularSensors[] SensorsToSurrender;  // איזה סנסורי תקיפה יגרום להכנעה

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

        public abstract void ReturnOfSuccessfulAttack()
        {

        }
    }
}
