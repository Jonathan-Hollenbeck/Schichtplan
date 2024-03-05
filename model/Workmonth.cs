using Schichtplan.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan
{

    [Serializable]
    internal class Workmonth
    {
        public Settings settings { get; set; }

        public string monthName { get; set; }

        public int month { get; set; }

        public int year { get; set; }

        public List<Workday> workdays { get; set; }

        public List<Person> persons { get; set; }

        public Dictionary<int, Workday> weekTemplate { get; set; }

        public Dictionary<Workshift, Person> shiftplan { get; set; }

        public Dictionary<Person, float> hourCarryOverLastMonth { get; set; }
        public Dictionary<Person, float> hourCarryOverThisMonth { get; set; }

        public float turnoverMonth;
        public Dictionary<int, float> turnoverWeeks;
        public Dictionary<Workday, float> turnoverWorkdays;

        public List<Cost> fixCosts;
        public List<Cost> variableCosts;

        public Workmonth(string monthName, int month, int year)
        {
            this.monthName = monthName;
            this.month = month;
            this.year = year;
            workdays = new List<Workday>();
            persons = new List<Person>();
            weekTemplate = new Dictionary<int, Workday>();
            shiftplan = new Dictionary<Workshift, Person>();

            hourCarryOverLastMonth = new Dictionary<Person, float>();
            hourCarryOverThisMonth = new Dictionary<Person, float>();

            settings = new model.Settings();

            turnoverMonth = 0.0f;
            turnoverWeeks = new Dictionary<int, float>();
            turnoverWorkdays = new Dictionary<Workday, float>();

            fixCosts = new List<Cost>();
            variableCosts = new List<Cost>();
        }

        /// <summary>
        /// creates a empty weektemplate for this workmonth
        /// </summary>
        public void createEmptyWeekTemplate()
        {
            weekTemplate.Clear();
            weekTemplate.Add(0, new Workday("Montag", 0, 0));
            weekTemplate.Add(1, new Workday("Dienstag", 1, 0));
            weekTemplate.Add(2, new Workday("Mittwoch", 2, 0));
            weekTemplate.Add(3, new Workday("Donnerstag", 3, 0));
            weekTemplate.Add(4, new Workday("Freitag", 4, 0));
            weekTemplate.Add(5, new Workday("Samstag", 5, 0));
            weekTemplate.Add(6, new Workday("Sonntag", 6, 0));
        }
    }
}
