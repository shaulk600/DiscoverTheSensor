using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverTheSensor.Sensors.BuilderSensors
{
    internal static class BuilderRegularSensor
    {
        private static List<RegularSensors> RegularSensors; // אובייקט של סנסורים שקיים בכל אובייקט של סוכן
        
        //מתודה היוצרת לי מופע של סנסור רנדומלי
        public static List<RegularSensors> CreateSensorRandomForJuniorAgent()
        {
            //היות שפה צריך 2 בלבד - שלחתי רק 2
            RegularSensors = new List<RegularSensors>();
            RegularSensors.Add(ReturnSensorsRandomaly());
            RegularSensors.Add(ReturnSensorsRandomaly());
            return RegularSensors;
        }
        
        private static RegularSensors ReturnSensorsRandomaly()
        {
            // יצירת מערך ליסט
            List <RegularSensors>  Randomal = new List<RegularSensors>();

            RegularSensors objA = new RegularSensors("selolarA", "selolar", 300);
            RegularSensors objB = new RegularSensors("selolarB", "selolar", 300);

            //הכנסה לליסט 
            Randomal.Add(objA);
            Randomal.Add(objB);
            Randomal.Add(objA);
            Randomal.Add(objB);
            Randomal.Add(objA);
            Randomal.Add(objB);


            //יצירת אובייקט רנדום
            System.Random rnd = new System.Random();

            // המהלך הבא יוצר רנדום
            return Randomal[ Convert.ToInt32(rnd.Next(1, 5)) ];   
        }
    }
}
