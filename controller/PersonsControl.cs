using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan.controller
{
    public class PersonsControl : ViewControl
    {
        /// <summary>
        /// the person, which is currently in the person edit in the personTab
        /// </summary>
        public Person currentPersonInEdit { get; set; }

        public PersonsControl(ModelControl modelControl) : base(modelControl)
        {
        }

        /// <summary>
        /// sets the currentPerson to the given personIndex in the currentMonth.persons
        /// </summary>
        /// <param name="personIndex">the personIndex in the currentMonth.persons</param>
        public void setCurrentPersonInEdit(int personIndex)
        {
            currentPersonInEdit = modelControl.currentWorkmonth.persons[personIndex];
        }

        /// <summary>
        /// adds a person to the currentMonth.perons list with the given data and unavailabilities
        /// and sets it as currentPerson
        /// </summary>
        /// <param name="data">person data</param>
        public void addPerson(string[] data, Color personColor)
        {
            float saleryPerHour = Util.parseFloat(data[1], "Bitte nur Zahlen im Gehalt pro Stunde Textfeld benutzen.");
            int minWorkHours = Util.parseInt(data[2], "Bitte nur Zahlen im min Arbeitsstunden Textfeld benutzen.");
            int maxWorkHours = Util.parseInt(data[3], "Bitte nur Zahlen im max Arbeitsstunden Textfeld benutzen.");
            if (minWorkHours == -1 || maxWorkHours == -1 || saleryPerHour == -1)
            {
                return;
            }
            Person person = new Person(data[0], saleryPerHour, minWorkHours, maxWorkHours, data[4].Split(','), data[5]);
            modelControl.currentWorkmonth.persons.Add(person);
            modelControl.currentWorkmonth.settings.personColors.Add(person, personColor);
            currentPersonInEdit = person;
        }

        /// <summary>
        /// deletes the currentPerson
        /// </summary>
        public void deleteCurrentPerson()
        {
            modelControl.currentWorkmonth.persons.Remove(currentPersonInEdit);
            modelControl.currentWorkmonth.settings.personColors.Remove(currentPersonInEdit);
            currentPersonInEdit = null;
        }

        /// <summary>
        /// edits the currentPerson with the data and unavailabilities
        /// </summary>
        /// <param name="data">person data</param>
        /// <param name="unavailability">person unavailabilities</param>
        public void editCurrentPerson(string[] data, bool[] unavailability, bool[] onlyOneAble, Color personColor)
        {
            float saleryPerHour = Util.parseFloat(data[1], "Bitte nur Zahlen im Gehalt pro Stunde Textfeld benutzen.");
            int minWorkHours = Util.parseInt(data[2], "Bitte nur Zahlen im min Arbeitsstunden Textfeld benutzen.");
            int maxWorkHours = Util.parseInt(data[3], "Bitte nur Zahlen im max Arbeitsstunden Textfeld benutzen.");
            float carryOver = Util.parseFloat(data[6], "Bitte nur Zahlen Übertrag vom letzten Monat Textfeld benutzen.");
            if (minWorkHours == -1 || maxWorkHours == -1 || saleryPerHour == -1 || carryOver == -1)
            {
                return;
            }

            setUnavailabilitiesInCurrentPerson(unavailability);
            setUnavailabilitiesInOtherPersons(onlyOneAble);

            currentPersonInEdit.name = data[0];
            currentPersonInEdit.saleryPerHour = saleryPerHour;
            currentPersonInEdit.minWorkHours = minWorkHours;
            currentPersonInEdit.maxWorkHours = maxWorkHours;
            currentPersonInEdit.shiftTypes = data[4].Split(',');
            currentPersonInEdit.description = data[5];

            if (!modelControl.currentWorkmonth.hourCarryOverLastMonth.ContainsKey(currentPersonInEdit))
            {
                modelControl.currentWorkmonth.hourCarryOverLastMonth.Add(currentPersonInEdit, 0.0f);
            }
            modelControl.currentWorkmonth.hourCarryOverLastMonth[currentPersonInEdit] = carryOver;

            modelControl.currentWorkmonth.settings.personColors[currentPersonInEdit] = personColor;
        }

        /// <summary>
        /// sets the unavailabilities in the currentPerson
        /// </summary>
        /// <param name="unavailability">person unavailabilities</param>
        public void setUnavailabilitiesInCurrentPerson(bool[] unavailability)
        {
            currentPersonInEdit.unavailability.Clear();
            int index = 0;
            List<Workshift> possibleWorkshifts = modelControl.getPossibleWorkshiftsForPersonInWorkdays(currentPersonInEdit, modelControl.currentWorkmonth.workdays);
            foreach (Workshift workshift in possibleWorkshifts)
            {
                if (unavailability[index] == true)
                {
                    currentPersonInEdit.unavailability.Add(workshift);
                }
                index++;
            }
        }

        /// <summary>
        /// sets the unavailabilities in all other persons then the currentPerson
        /// </summary>
        /// <param name="unavailability">unavailabilities for all other persons</param>
        public void setUnavailabilitiesInOtherPersons(bool[] unavailability)
        {
            int index = 0;
            foreach (Workshift workshift in modelControl.getPossibleWorkshiftsForPersonInWorkdays(currentPersonInEdit, modelControl.currentWorkmonth.workdays))
            {
                if (unavailability[index] == true)
                {
                    foreach (Person person in modelControl.currentWorkmonth.persons)
                    {
                        if (person != currentPersonInEdit)
                        {
                            List<Workshift> possibleWorkdaysForPerson = modelControl.getPossibleWorkshiftsForPersonInWorkdays(person, modelControl.currentWorkmonth.workdays);
                            if (!person.unavailability.Contains(workshift) && possibleWorkdaysForPerson.Contains(workshift))
                            {
                                person.unavailability.Add(workshift);
                            }
                        }
                    }
                }
                index++;
            }
        }

        /// <summary>
        /// deletes all unavailibilities from a given list of persons
        /// </summary>
        /// <param name="persons">list of persons to delete the unavailabilities from</param>
        public void resetUnavailabilities(List<Person> persons)
        {
            foreach (Person person in persons)
            {
                person.unavailability.Clear();
            }
        }
    }
}
