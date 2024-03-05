using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan
{

    [Serializable]
    internal class Workshift
    {

        public int startHour { get; set; }
        public int startMinute { get; set; }
        public int endHour { get; set; }
        public int endMinute { get; set; }

        public string shiftType { get; set; }

        public string description { get; set; }

        public Workshift(int startHour, int startMinute, int endHour, int endMinute, string shiftType, string description)
        {
            this.startHour = startHour;
            this.startMinute = startMinute;
            this.endHour = endHour;
            this.endMinute = endMinute;
            this.shiftType = shiftType;
            this.description = description;
        }

        /// <summary>
        /// clones this workshift and returns the clone
        /// </summary>
        /// <returns>cloned workshift</returns>
        public Workshift clone()
        {
            return new Workshift(startHour, startMinute, endHour, endMinute, shiftType, description);
        }

        /// <summary>
        /// summarizes this workshift into a string
        /// </summary>
        /// <returns>this workshift as a string summarized</returns>
        override public string ToString()
        {
            return startHour + ":" + startMinute + "-" + endHour + ":" + endMinute + ", " + shiftType;
        }

        /// <summary>
        /// puts all the data of this workshift into a string array
        /// </summary>
        /// <returns></returns>
        public string[] ToStringArray()
        {
            string[] array = new string[4];
            array[0] = getStartTimeAsString();
            array[1] = getEndTimeAsString();
            array[2] = shiftType;
            array[3] = description;

            return array;
        }

        /// <summary>
        /// writes the startHours and startMinutes after each other in a string and returns it
        /// </summary>
        /// <returns>the startHours and startMinutes after each other as a string</returns>
        public string getStartTimeAsString()
        {
            return startHour + ":" + startMinute;
        }

        /// <summary>
        /// writes the endHour and endMinute after each other in a string and returns it
        /// </summary>
        /// <returns>the endHour and endMinute after each other as a string</returns>
        public string getEndTimeAsString()
        {
            return endHour + ":" + endMinute;
        }
    }
}
