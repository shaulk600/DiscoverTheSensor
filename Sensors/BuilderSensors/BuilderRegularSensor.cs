using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverTheSensor.Sensors.BuilderSensors
{
    internal class BuilderRegularSensor
    {
        private List<RegularSensors> ListRegularSensors; // אובייקט של סנסורים שקיים בכל אובייקט של סוכן
        private int NumberRegularSensor = 0;

        public BuilderRegularSensor()
        {
            CreateRegularSensors();
        }
        
        //יצירת אובייקטים של סנסורים רגילים
        public void CreateRegularSensors()
        {
            string name = "RegularSensors_" + Convert.ToString(NumberRegularSensor);

            for (int i = 0; i < 5; i++)
            {
                ListRegularSensors.Add(new RegularSensors(name, "selolar", 300));
                NumberRegularSensor++;
            }
        }
        //מתודה למימוש רנדומליות
        public RegularSensors ReturnSensorsRandomaly()
        {
            //יצירת אובייקט רנדום
            System.Random rnd = new System.Random();

            // המהלך הבא יוצר רנדום על האובייקטים
            return ListRegularSensors[ Convert.ToInt32(rnd.Next(1, 5)) ];
        }

        
    }
}
