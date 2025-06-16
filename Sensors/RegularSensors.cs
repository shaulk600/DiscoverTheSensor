using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiscoverTheSensor.Agent;
using DiscoverTheSensor.Sensors.BuilderSensors;
namespace DiscoverTheSensor.Sensors
{
    internal class RegularSensors :ISensors
    {
        public int IdSensors {  get; set; } //ID
        public string Name { get; set; } // שם
        public string BelongsToType {  get; set; } // משתייך אל סוג "סלולרי "\ "תרמי"
        public int NumberOfSessions { get; set; } // כמות ההפעלות- לבדוק אם זה חיוני לנו בשלב הנוכחי

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

       public virtual void SetBelongsToType(string value)
        {
            if (string.IsNullOrEmpty(value) || value == "Selolar")
            {
                BelongsToType = "Selolar";
            }
            //else if(value == "" || value == "")
            //{

            //}
        }

        public virtual void Activate(JuniorAgent a)
        {
            //מה הוא באמת יחזיר 
            int points;
            points = MethodByActivate(a);

        }

        private int MethodByActivate(JuniorAgent a)
        {
            //או ליצור copy ולשאול על זה
            // או לקחת ואז להחזיר
            for (int i = 0; i < a.SensorsToSurrender.Length; i++)
            {
                if (this.BelongsToType == a.SensorsToSurrenderCopy[i].BelongsToType) //האם הערך שיוצא להתקפה דומה לערך שבכוחו לשבור את הסוכן האוייב - בכל הליסט
                {
                    a.SensorsToSurrenderCopy[i].BelongsToType = "";
                    return 1;
                }               
            }
            return 0 ;
        }

        public virtual bool IsItWithBreakLimit() //האם הוא עם הגבלת שבירות
        {
            return false;
        }
        public virtual void InsertRandomSensorsIntoAnObject()// להביא סנסורים אל האובייקטים של agent
        {
            //אולי פה זה סנסור רגיל - לא רנדום - לבדוק אם צריך - אם לא לבטל
        }

    }
}
