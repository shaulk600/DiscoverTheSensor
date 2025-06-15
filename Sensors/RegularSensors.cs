using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiscoverTheSensor.Agent;
namespace DiscoverTheSensor.Sensors
{
    internal class RegularSensors :ISensors
    {
        public int IdSensors {  get; set; } //ID
        public string Name { get; set; } // AO
        public string BelongsToType {  get; set; } // משתייך אל סוג "סלולרי "\ "תרמי"
        public int NumberOfSessions { get; set; } // כמות ההפעלות

        //2 constractors
        public RegularSensors(int idSensors, string name, string belongsToType, int numberOfSessions)
        {
            IdSensors = idSensors;
            Name = name;
            BelongsToType = belongsToType;
            NumberOfSessions = numberOfSessions;
        }
        public RegularSensors(string name, string belongsToType, int numberOfSessions)
        {
            
            Name = name;
            BelongsToType = belongsToType;
            NumberOfSessions = numberOfSessions;
        }

        public void Activate()
        {

        }
        public bool IsItWithBreakLimit() //האם הוא עם הגבלת שבירות
        {
            return false;
        }
        public void InsertRandomSensorsIntoAnObject()// להביא סנסורים אל האובייקטים של agent
        {

        }

    }
}
