using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan
{

    [Serializable]
    internal class Workday
    {
        public string weekday { get; set; }
        public int weekdayIndex { get; set; }

        public int day { get; set; }

        public List<Workshift> shifts { get; set; }

        public Workday(string weekday, int weekDayIndex, int day)
        {
            this.weekday = weekday;
            this.weekdayIndex = weekDayIndex;
            this.day = day;
            this.shifts = new List<Workshift>();
        }

        /// <summary>
        /// clones this workday and returns the clone
        /// </summary>
        /// <returns>cloned workday</returns>
        public Workday clone()
        {
            Workday workday = new Workday(weekday, weekdayIndex, day);
            workday.shifts = cloneWorkshifts();
            return workday;
        }

        /// <summary>
        /// clones the workshifts of this workday and returns them
        /// </summary>
        /// <returns>the cloned workshifts</returns>
        public List<Workshift> cloneWorkshifts()
        {
            List<Workshift> workshifts = new List<Workshift>();
            foreach (Workshift workshift in this.shifts)
            {
                workshifts.Add(workshift.clone());
            }
            return workshifts;
        }

        /// <summary>
        /// summarizes this workday into a string
        /// </summary>
        /// <returns>this workday as a string summarized</returns>
        override public string ToString()
        {
            string workdayString = shifts.Count + " (";
            foreach (Workshift workshift in shifts)
            {
                workdayString += workshift.ToString() + "; ";
            }
            if (shifts.Count != 0)
            {
                workdayString = workdayString.Remove(workdayString.Length - 2);
            }
            return workdayString + ")";
        }
    }
}
