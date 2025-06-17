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
        public abstract int IdAgent {get; set;}
        public abstract string Name { get; set; } // שם
        public abstract string AgentRank { get; set; } // דרגה

        // למה RegularSensors ? כי זה המחלקה הכי פשוטה - מחלקת האבא
        public abstract RegularSensors[] SensorsToAttack { get; set; } //איזה סנסורי תקיפה יש עליו
        public abstract RegularSensors[] SensorsToSurrender { get; set; } // איזה סנסורי תקיפה יגרום להכנעה


        public abstract bool ReturnOfSuccessfulAttack(int points); //החזרת ערך התקיפה
        public abstract void IntroducingTheSensorsForAttack(); // החזרת הערכים של סנסור בתוך מיכל התקיפה של הסנסורים

    }
}