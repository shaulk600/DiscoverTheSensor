using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverTheSensor.Sensors.BuilderSensors
{
    internal static class BuilderSensor
    {
        public static void CreateOBJ()
        {
            //string input;
            //Console.WriteLine("Enter Your Name Sensore");
            //input = Console.ReadLine();
            //RegularSensors objA = new RegularSensors(input, "selolar", 300);
        }

        
        //להפעלת המשחק נצטרך להכניס שתיים רנדומליים
        public static RegularSensors RandomObj()
        {
            RegularSensors[] regularsSensors = new RegularSensors[5];
            
            RegularSensors objA = new RegularSensors("selolarA", "selolar", 300);
            regularsSensors[0] = objA;
            RegularSensors objB = new RegularSensors("selolarB", "selolar", 300);
            regularsSensors[1] = objB;

            regularsSensors[2] = objB;
            regularsSensors[3] = objA;
            regularsSensors[4] = objA;

            System.Random rnd = new System.Random();

            // המהלך הבא יוצר רנדום
            return regularsSensors[ Convert.ToInt32(rnd.Next(1, 4)) ];
             



        }
    }
}
