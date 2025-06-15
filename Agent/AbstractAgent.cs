using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiscoverTheSensor.Sensors;
namespace DiscoverTheSensor.Agent
{
    internal abstract class AbstractAgent
    {
        public abstract int IdAgent {get;set;}
        public abstract string Name { get; set; } // שם
        public abstract string AgentRank { get; set; } // דרגה
        
        // 2 הבאים חייבים להיות זהים באיבריהם
        public abstract RegularSensors[] SensorsToAttack { get; set; } //איזה סנסורי תקיפה יש עליו
        
        public abstract RegularSensors[] SensorsToSurrender { get; set; } // איזה סנסורי תקיפה יגרום להכנעה
        public abstract void ReturnOfSuccessfulAttack();
     

    }
}
