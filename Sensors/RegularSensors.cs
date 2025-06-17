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
    internal class RegularSensors : ISensors
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
        //מתודת הוספה בוולידציה אל BelongsToType
        public virtual void SetBelongsToType(string value)
        {
            if (string.IsNullOrEmpty(value) || value == "Selolar")
            {
                BelongsToType = "Selolar";
            }
        }

        public virtual bool Activate(JuniorAgent a)
        {
            int points = 0;
            //פור - כמספר האובייקטים בתוך a.SensorsToAttack
            for (int i = 0; i < a.SensorsToAttack.Length; i++)
            {
                points += MethodByActivate(a);
            }
            return a.ReturnOfSuccessfulAttack(points); // מחזיר ערך bool;
        }

        private int MethodByActivate(JuniorAgent a)
        {
            //או ליצור copy ולשאול על זה
            // או לקחת ואז להחזיר
            for (int i = 0; i < a.SensorsToSurrenderCopy.Length; i++)
            {
                if ((this.BelongsToType != "" || this.BelongsToType != null) && (this.BelongsToType == a.SensorsToSurrenderCopy[i].BelongsToType) && (this.Name == a.Name)) //האם הערך שיוצא להתקפה דומה לערך שבכוחו לשבור את הסוכן האוייב - בכל הליסט
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


        public override string ToString()
        {
            return $" id: {IdSensors}, name: {Name}, BelongsToType: {BelongsToType}, NumberOfSessions: {NumberOfSessions}, - IsItWithBreakLimit: {IsItWithBreakLimit()} ";
        }
    }
}
