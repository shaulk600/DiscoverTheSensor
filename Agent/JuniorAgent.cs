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
        public int IdAgent { get; set; }
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
            SetAgentRank(agentRank); // כרגע מחזיר תמיד 'זוטר'
            //אם נקצה לקבל מדאטה יתכן ונעשה פה שינוי
            
            //לקבל מהדאטה את הסנסורס
            SensorsToAttack = new RegularSensors[2];
            SensorsToSurrender = new RegularSensors[2];
            SensorsToSurrenderCopy = null;
        }
        public JuniorAgent (string name, string agentRank)
        {
            Name = name;
            SetAgentRank(agentRank);

            //ליצור אוטומאטית את הסנסורס
            SensorsToAttack = new RegularSensors[2];
            SensorsToSurrender = new RegularSensors[2];
            SensorsToSurrenderCopy = null;
        }

        private void SetAgentRank(string value)
        {
            AgentRank = "junior";
        }
        public override void RandomalAndCopyValueToSensorsToSurrender()
        {
            for (int i = 0; i< SensorsToSurrender.Length; i++)
            {
                SensorsToSurrender[i] = BuilderSensor.RandomObj();
            }
            
            Array.Copy(SensorsToSurrender, 0, SensorsToSurrenderCopy, 0, SensorsToSurrender.Length); // מתודה שאומרת העתק ממקום באינדקס מסוים - אל מקום - התחל באינדקס-עד איפה שתגיד-לאורך כמה

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
