using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan.controller
{
    public class ShiftPlanControl : ViewControl
    {
        /// <summary>
        /// the workshift, which is currently in the shiftedit in the shiftPlanTab
        /// </summary>
        public Workshift currentWorkshiftInShiftPlanEdit { get; set; }

        public ShiftPlanControl(ModelControl modelControl) : base(modelControl)
        {
        }

        /// <summary>
        /// creates the shiftplan
        /// </summary>
        public void createShiftPlan(int algorithmIndex)
        {
            modelControl.currentWorkmonth.shiftplan.Clear();

            switch (algorithmIndex)
            {
                case 0:
                    modelControl.currentWorkmonth.shiftplan = modelControl.getSimpleShiftPlan(modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.persons, modelControl.currentWorkmonth.hourCarryOverLastMonth);
                    break;
                case 1:
                    modelControl.currentWorkmonth.shiftplan = modelControl.getEvenlyDistributedShiftPlan(modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.persons, modelControl.currentWorkmonth.hourCarryOverLastMonth);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// sets currentWorkshiftInShiftPlanEdit to a given workshift
        /// </summary>
        /// <param name="workshift">the workshift to set as the current one</param>
        public void setCurrentWorkshiftInShiftPlanEdit(Workshift workshift)
        {
            currentWorkshiftInShiftPlanEdit = workshift;
        }

        /// <summary>
        /// edit the currentWorkshiftInShiftPlanEdit with the given shiftInfo
        /// set the person for this workshift in the shiftplan as the given person
        /// </summary>
        /// <param name="person">person for this workshift</param>
        /// <param name="shiftInfo">info for this workshift</param>
        public void editWorkshiftInWorkshiftEdit(Person person, string[] shiftInfo)
        {
            //set person
            modelControl.currentWorkmonth.shiftplan[currentWorkshiftInShiftPlanEdit] = person;

            //set other data
            int[] startHoursMinutes = modelControl.getHourMinutesFromString(shiftInfo[0]);
            if (startHoursMinutes == null)
            {
                return;
            }
            int[] endHoursMinutes = modelControl.getHourMinutesFromString(shiftInfo[1]);
            if (endHoursMinutes == null)
            {
                return;
            }
            currentWorkshiftInShiftPlanEdit.startHour = startHoursMinutes[0];
            currentWorkshiftInShiftPlanEdit.startMinute = startHoursMinutes[1];
            currentWorkshiftInShiftPlanEdit.endHour = endHoursMinutes[0];
            currentWorkshiftInShiftPlanEdit.endMinute = endHoursMinutes[1];
            currentWorkshiftInShiftPlanEdit.shiftType = shiftInfo[2];
            currentWorkshiftInShiftPlanEdit.description = shiftInfo[3];
        }

        /// <summary>
        /// add a new workshift int the day of the currentWorkshiftInShiftPlanEdit with the given shiftInfo
        /// set the person for this workshift in the shiftplan as the given person
        /// </summary>
        /// <param name="person">person for this workshift</param>
        /// <param name="shiftInfo">info for this workshift</param>
        public void addWorkshift(Person person, string[] shiftInfo)
        {
            Workday workday = modelControl.getWorkdayFromWorkshiftInWorkdays(currentWorkshiftInShiftPlanEdit, modelControl.currentWorkmonth.workdays);

            //set other data
            int[] startHoursMinutes = modelControl.getHourMinutesFromString(shiftInfo[0]);
            if (startHoursMinutes == null)
            {
                return;
            }
            int[] endHoursMinutes = modelControl.getHourMinutesFromString(shiftInfo[1]);
            if (endHoursMinutes == null)
            {
                return;
            }

            //create new Workshift
            Workshift workshift = new Workshift(startHoursMinutes[0], startHoursMinutes[1],
                endHoursMinutes[0], endHoursMinutes[1], shiftInfo[2], shiftInfo[3]);

            //add new Workshift to workday
            workday.shifts.Add(workshift);

            workday.shifts = modelControl.getSortedWorkshiftsInWorkday(workday);

            currentWorkshiftInShiftPlanEdit = workshift;

            //set person
            modelControl.currentWorkmonth.shiftplan.Add(currentWorkshiftInShiftPlanEdit, person);
        }

        /// <summary>
        /// deletes the currentWorkshiftInShiftPlanEdit
        /// </summary>
        public void deleteCurrentWorkshiftInShiftEdit()
        {
            modelControl.currentWorkmonth.shiftplan.Remove(currentWorkshiftInShiftPlanEdit);
            foreach (Workday workday in modelControl.currentWorkmonth.workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    if (workshift == currentWorkshiftInShiftPlanEdit)
                    {
                        workday.shifts.Remove(workshift);
                        break;
                    }
                }
            }
            foreach (Person person in modelControl.currentWorkmonth.persons)
            {
                if (person.unavailability.Contains(currentWorkshiftInShiftPlanEdit))
                {
                    person.unavailability.Remove(currentWorkshiftInShiftPlanEdit);
                }
            }
            currentWorkshiftInShiftPlanEdit = null;
        }

        /// <summary>
        /// swaps the Persons in the 2 given workshifts
        /// </summary>
        /// <param name="workshift1">first workshift to swap</param>
        /// <param name="workshift2">first workshift to swap</param>
        public void swapPersonsInWorkshifts(Workshift workshift1, Workshift workshift2)
        {
            if (modelControl.currentWorkmonth.shiftplan.ContainsKey(workshift1) && modelControl.currentWorkmonth.shiftplan.ContainsKey(workshift2))
            {
                Person tempPerson = modelControl.currentWorkmonth.shiftplan[workshift1];
                modelControl.currentWorkmonth.shiftplan[workshift1] = modelControl.currentWorkmonth.shiftplan[workshift2];
                modelControl.currentWorkmonth.shiftplan[workshift2] = tempPerson;
            }
        }
    }
}
