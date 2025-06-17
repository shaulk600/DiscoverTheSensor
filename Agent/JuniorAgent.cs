using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using DiscoverTheSensor.Sensors;
using DiscoverTheSensor.Sensors.BuilderSensors;
namespace DiscoverTheSensor.Agent
{
    internal class JuniorAgent : AbstractAgent
    {
        public override int IdAgent { get; set; }
        public override string Name { get; set; } // שם
        public override string AgentRank { get; set; } // דרגה

        public override RegularSensors[] SensorsToAttack { get; set; } //איזה סנסורי תקיפה יש עליו
        public override RegularSensors[] SensorsToSurrender { get; set; } // איזה סנסורי תקיפה יגרום להכנעה

        public RegularSensors[] SensorsToSurrenderCopy { get; set; }// ערך Copy.



        // 2 constractors
        public JuniorAgent(int idAgent, string name, string agentRank) 
        {
            IdAgent = idAgent;
            Name = name;
            SetAgentRank(agentRank); // כרגע מחזיר תמיד 'זוטר' - אם נקצה לקבל מדאטה יתכן ונעשה פה שינוי
            SensorsToAttack = new RegularSensors[2];
            SensorsToSurrender = new RegularSensors[2];
            //איך הוא אמור לקבל מהדאטה את הערך של הליסט ?
            // תשובה מפורטת בדף- אם יש זמן - תבנה


            //המתודה שבונה רנדומלי
            List<RegularSensors> r = new List<RegularSensors>();
            r.Add(BuilderRegularSensor.ReturnSensorsRandomaly());
            r.Add(BuilderRegularSensor.ReturnSensorsRandomaly());
            r.CopyTo(SensorsToSurrender); // הכנסת הערך אל arr

            //יצירת ערך copy
            r.CopyTo(SensorsToSurrenderCopy); // הכנסת הערך אל arr
            
        }
        public JuniorAgent (string name, string agentRank)
        {
            Name = name;
            SetAgentRank(agentRank);
            SensorsToAttack = new RegularSensors[2];
            SensorsToSurrender = new RegularSensors[2];

            //המתודה שבונה רנדומלי
            List<RegularSensors> r = new List<RegularSensors>();
            r.Add(BuilderRegularSensor.ReturnSensorsRandomaly());
            r.Add(BuilderRegularSensor.ReturnSensorsRandomaly());
            r.CopyTo(SensorsToSurrender); // הכנסת הערך אל arr

            //יצירת ערך copy
            r.CopyTo(SensorsToSurrenderCopy); // הכנסת הערך אל arr
        }


        private void SetAgentRank(string value)
        {
            AgentRank = "junior";
        }
       

        public override void ReturnOfSuccessfulAttack(int points) // החזרת ערך התקיפה 
        {
            if (points >= SensorsToSurrender.Length)
            {
                Console.WriteLine("The enemy was defeated.");
                //מהלך חיסול אובייקט ...

            }
            else if(points == 0)
            {
                Console.WriteLine($"decided: {points} - from {SensorsToSurrender.Length} - try again");
            }
            else
            {
                Console.WriteLine($"decided: {points} - from {SensorsToSurrender.Length} - try again");
            }            
        }

        //הצגת הסנסורים הקיימים - זה אמור להיות מוסתר - לצורך טסט נציג אותם
        private void IntroducingTheSensorsSubmissionTest()
        {
            for (int i = 0; i < SensorsToSurrender.Length; i++)
            {
                Console.WriteLine($" {i} : Name: {SensorsToSurrender[i].Name} ,BelongsToType: {SensorsToSurrender[i].BelongsToType} ");
            }
        }
        
        //הצגת הסנסורים הקיימים כעת בשורת התקיפה 
        public void IntroducingTheSensorsForAttack()
        {
            Console.WriteLine("Introducing The Sensors For Attack : ");
            for (int i =0; i < SensorsToAttack.Length; i++)
            {
                if (SensorsToAttack[i].IsItWithBreakLimit()) // אם הסנסור הוא בר שבירה-החזר את כמות השבירות
                {
                    Console.WriteLine($" {i} :  name: {SensorsToAttack[i].Name}, BelongsToType: {SensorsToAttack[i].BelongsToType}, NumberOfSessions: {SensorsToAttack[i].NumberOfSessions}");
                }
                else
                {
                    Console.WriteLine($" {i} :  name: {SensorsToAttack[i].Name}, BelongsToType: {SensorsToAttack[i].BelongsToType}");
                }
            }
        }
    }
}
