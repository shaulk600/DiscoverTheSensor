using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using DiscoverTheSensor.Agent;

namespace DiscoverTheSensor.Sensors.BuilderSensors
{
    internal class BuilderRegularSensor
    {
        private static List<RegularSensors> ListRegularSensors = null; // אובייקט של סנסורים שקיים בכל אובייקט של סוכן
        private static int NumberRegularSensor = 0;

        //singletone
        private  BuilderRegularSensor instance = null;
        private BuilderRegularSensor() { }
        
        public BuilderRegularSensor GetInstance()
        {
            if (instance == null)
            {
                instance = new BuilderRegularSensor();
                CreateRegularSensors();
            }
            return this.instance;
        }


        //יצירת אובייקטים של סנסורים רגילים
        public void CreateRegularSensors()
        {
            if (ListRegularSensors == null)
            {
                List<RegularSensors> listRegularSensors = new List<RegularSensors>();

                string name = "RegularSensors_" + Convert.ToString(NumberRegularSensor);

                for (int i = 0; i < 5; i++)
                {
                    listRegularSensors.Add(new RegularSensors(name, "selolar", 300));
                    BuilderRegularSensor.NumberRegularSensor++;
                }
                ListRegularSensors = listRegularSensors;
            }
        }
        
        //מתודה למימוש רנדומליות
        public static RegularSensors ReturnSensorsRandomaly()
        {

            //יצירת אובייקט רנדום
            System.Random rnd = new System.Random();

            // המהלך הבא יוצר רנדום על האובייקטים
            return ListRegularSensors[ Convert.ToInt32(rnd.Next(1, 5)) ];
        }

        //מחזיר את האובייקט סנסור שעליו ניתן לעשות התקפה במתודה של הסוכן
        public static RegularSensors SelectingSpecificSensorAndReturningTheSensor(JuniorAgent agent)
        {
            //if (ListRegularSensors == null)
            //{
            //    RegularSensors a = SelectingSpecificSensorAndReturningTheSensor(agent); // לא בארמת צריך את a
            //}

            string input = "";
            int indexSensorsToAttack = 0;
            do
            {
                input = SelectionUpdate();
            } while ( (input != null)  && (int.TryParse(input.Split(',')[1], out indexSensorsToAttack)) && 
                        (indexSensorsToAttack <= 2 && indexSensorsToAttack > 0) );
           
            input = input.Split(',')[0]; // לוקח את השם
            int indexList = input.IndexOf("_"); // זה אחד לפני המיקום במערך
            int num = Convert.ToInt32(input[indexList + 1]);
            num--; // מתחיל מאינדקס 0

            indexSensorsToAttack--; //מוריד בחירה של אינדקס ב1 
            agent.SensorsToAttack[indexSensorsToAttack] = ListRegularSensors[num];
            
            return ListRegularSensors[num];
        }

        private static string SelectionUpdate()
        {
            string input = "";
            do
            {
                input = ShowMenuSensors("");

            } while (string.IsNullOrEmpty(input) && (input.Contains("junior_")));

            input = Regex.Replace(input, @"\s+", " ").Trim(); // מסלק רווחים מיותרים גם באמצע וגם בסוף
            return input;
        }

        private static string ShowMenuSensors(string userSelection = "") 
        {
            bool flag = false;
            if(userSelection != "")
            {
                userSelection = "";
                flag = true;
            }
     
            Console.Clear();

            Console.WriteLine($"||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine($"||                                      ||");
            Console.WriteLine($"||              hello user              ||");
            Console.WriteLine($"||          Available sensors           ||");
            Console.WriteLine($"||                                      ||");
            Console.WriteLine($"||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine($"||                                      ||");
            
            if (flag) Console.WriteLine($"   !!!  Invalid selection  !!!    ");
            Console.WriteLine($"||                                      ||");
            
            for (int i = 0; i< ListRegularSensors.Count; i++)
            {
                Console.WriteLine($" - name: {ListRegularSensors[i].Name} , Type Of: {ListRegularSensors[i].BelongsToType} - ");
                Console.WriteLine($"||                                      ||");
                if (ListRegularSensors[i].IsItWithBreakLimit())
                {
                    Console.WriteLine($" -- !!! Attention please: The quantity number     !!! \n        !!! of using this sensor is: {ListRegularSensors[i].NumberOfSessions} !!! ");
                    Console.WriteLine($"||                                      ||");
                    Console.WriteLine($"||                                      ||");
                }
            }
            
            Console.WriteLine($"||                                      ||");
            Console.WriteLine($"||                                      ||");
            Console.WriteLine($"|| Please write the name of the sensor  ||");                               
            Console.WriteLine($"||   you would like to attack with.     ||");                            
            Console.WriteLine($"||                                      ||");
            Console.WriteLine($"||       name , number index (1,2)      ||");
            Console.WriteLine($"||                                      ||");
            Console.WriteLine($"||||||||||||||||||||||||||||||||||||||||||");

            userSelection = Console.ReadLine();
            return userSelection;
        }
    }
}
