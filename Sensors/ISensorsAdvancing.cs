using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverTheSensor.Sensors
{
    internal interface ISensorsAdvancing
    {
        int NumberOfSessions { get; set; } // כמות ההפעלות
        void AttackAndTakedownInOne(); // במידה ויש לנו את  מספר האובייקטים שאנחנו צריכים להוריד - אז לרדת ב1 כל פעם - אולי לחלק את זה לשתי InterFace
    }
}
