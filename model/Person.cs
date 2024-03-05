using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan
{

    [Serializable]
    internal class Person
    {
        public string name { get; set; }

        public float saleryPerHour { get; set; }

        public int minWorkHours { get; set; }
        public int maxWorkHours { get; set; }

        public string[] shiftTypes { get; set; }

        public string description { get; set; }

        public List<Workshift> unavailability { get; set; }

        public Person(string name, float saleryPerHour, int minWorkHours, int maxWorkHours, string[] shiftTypes, string description)
        {
            this.name = name;
            this.saleryPerHour = saleryPerHour;
            this.minWorkHours = minWorkHours;
            this.maxWorkHours = maxWorkHours;
            this.shiftTypes = shiftTypes;
            this.description = description;

            unavailability = new List<Workshift>();
        }

        /// <summary>
        /// clones this person with empty unavailability and returns the clone
        /// </summary>
        /// <returns>cloned person</returns>
        public Person clone()
        {
            Person person = new Person(name, saleryPerHour, minWorkHours, maxWorkHours, shiftTypes, description);
            person.unavailability = unavailability;
            return person;
        }

        /// <summary>
        /// puts all data from this person into a string array and returns it
        /// </summary>
        /// <returns>string array with all data from this person</returns>
        public string[] ToStringArray()
        {
            string[] array = new string[7];
            array[0] = name;
            array[1] = "" + saleryPerHour;
            array[2] = "" + minWorkHours;
            array[3] = "" + maxWorkHours;
            array[4] = shiftTypesToString();
            array[5] = description;
            array[6] = "" + unavailability.Count;

            return array;
        }

        /// <summary>
        /// writes all shifttypes into a single string
        /// </summary>
        /// <returns>all shifttypes into as a single string</returns>
        public string shiftTypesToString()
        {
            string shiftTypesAsString = "";

            foreach(string s in shiftTypes)
            {
                shiftTypesAsString +=  "," + s;
            }

            return shiftTypesAsString.Substring(1);
        }
    }
}
