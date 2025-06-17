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
            SensorsToSurrenderCopy = new RegularSensors[2];
            //איך הוא אמור לקבל מהדאטה את הערך של הליסט ?
            // תשובה מפורטת בדף- אם יש זמן - תבנה


            //המתודה שבונה רנדומלי
            List<RegularSensors> r = new List<RegularSensors>();
            r.Add(BuilderRegularSensor.ReturnSensorsRandomaly());
            r.Add(BuilderRegularSensor.ReturnSensorsRandomaly());
            r.CopyTo(SensorsToSurrender); // הכנסת הערך אל arr

            //יצירת ערך copy
            Array.Copy(SensorsToSurrender, SensorsToSurrenderCopy, SensorsToSurrender.Length); 
        }
        public JuniorAgent (string name, string agentRank)
        {
            Name = name;
            SetAgentRank(agentRank);
            SensorsToAttack = new RegularSensors[2];
            
            SensorsToSurrender = new RegularSensors[2];
            SensorsToSurrenderCopy = new RegularSensors[2];

            //המתודה שבונה רנדומלי
            List<RegularSensors> r = new List<RegularSensors>();
            r.Add(BuilderRegularSensor.ReturnSensorsRandomaly());
            r.Add(BuilderRegularSensor.ReturnSensorsRandomaly());
            r.CopyTo(SensorsToSurrender); // הכנסת הערך אל arr

            //יצירת ערך copy
            Array.Copy(SensorsToSurrender, SensorsToSurrenderCopy, SensorsToSurrender.Length);
        }


        private void SetAgentRank(string value)
        {
            AgentRank = "junior";
        }
       

        public override bool ReturnOfSuccessfulAttack(int points) // החזרת ערך התקיפה 
        {
            if (points >= SensorsToSurrender.Length)
            {
                Console.WriteLine("The enemy was defeated.");
                //מהלך חיסול אובייקט ...
                return true;

            }
            else if(points == 0)
            {
                Console.WriteLine($"decided: {points} - from {SensorsToSurrender.Length} - try again");
            }
            else
            {
                Console.WriteLine($"decided: {points} - from {SensorsToSurrender.Length} - try again");
            }
            return false;
        }

        ////הצגת הסנסורים הקיימים - זה אמור להיות מוסתר - לצורך טסט נציג אותם
        //public void IntroducingTheSensorsSubmissionTest()
        //{
        //    for (int i = 0; i < SensorsToSurrender.Length; i++)
        //    {
        //        Console.WriteLine($" {i} : Name: {SensorsToSurrender[i].Name} ,BelongsToType: {SensorsToSurrender[i].BelongsToType} ");
        //    }
        //}

        //הצגת הסנסורים הקיימים כעת בשורת התקיפה 
        public override void IntroducingTheSensorsForAttack()
        {
            Console.WriteLine("Introducing The Sensors For Attack : ");
            for (int i = 0; i < SensorsToAttack.Length; i++)
            {
                if(SensorsToAttack[i] == null)
                {
                    Console.WriteLine($"No value has been updated in the box yet -{i + 1} ");
                }
                else if (SensorsToAttack[i].IsItWithBreakLimit()) // אם הסנסור הוא בר שבירה-החזר את כמות השבירות
                {
                    Console.WriteLine($" {i} :  name: {SensorsToAttack[i].Name}, BelongsToType: {SensorsToAttack[i].BelongsToType}, NumberOfSessions: {SensorsToAttack[i].NumberOfSessions}");
                }
                else
                {
                    Console.WriteLine($" {i} :  name: {SensorsToAttack[i].Name}, BelongsToType: {SensorsToAttack[i].BelongsToType}");
                }
            }
        }

        public override string ToString()
        {
            return $" IdAgent: {IdAgent}, NameAgent: {Name}, AgentRank: {AgentRank}, --test-- SensorsToSurrender[0]: {this.SensorsToSurrender[0]} , SensorsToSurrender[1]: {this.SensorsToSurrender[1]}";
        }
        
    }
}
