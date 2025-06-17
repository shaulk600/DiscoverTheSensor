using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiscoverTheSensor.Agent;
namespace DiscoverTheSensor.Sensors
{
    internal interface ISensors
    {
       
        bool Activate(JuniorAgent a);
        bool IsItWithBreakLimit(); //האם הוא עם הגבלת שבירות

        //void InsertRandomSensorsIntoAnObject(); // להביא סנסורים אל האובייקטים של agent באופן רנדומלי

        
    }
}
