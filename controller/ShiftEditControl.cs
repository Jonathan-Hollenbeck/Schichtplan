using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan.controller
{
    public class ShiftEditControl : ViewControl
    {
        /// <summary>
        /// the workday which is currently in the shiftEdit in the shiftTab
        /// </summary>
        public Workday currentWorkdayInShiftEdit { get; set; }

        public ShiftEditControl(ModelControl modelControl) : base(modelControl)
        {
        }

        /// <summary>
        /// sets the currentDayInShiftEdit from the weektemplate with the index of the weekday given as parameter
        /// </summary>
        /// <param name="weekdayIndex">the index of the weekday</param>
        public void setCurrentDayInShiftEditFromWeekTemplate(int weekdayIndex)
        {
            currentWorkdayInShiftEdit = modelControl.currentWorkmonth.weekTemplate[weekdayIndex];
        }

        /// <summary>
        /// sets the currentDayInShiftEdit from the currentMonth.workdays with the index of the workday given as parameter
        /// </summary>
        /// <param name="workdayIndex">the index of the workday</param>
        public void setCurrentDayInShiftEditFromWorkdays(int workdayIndex)
        {
            currentWorkdayInShiftEdit = modelControl.currentWorkmonth.workdays[workdayIndex];
        }

        /// <summary>
        /// saves the workshifts into the currentDayInShiftEdit with a double string array
        /// </summary>
        /// <param name="data">data of the workshifts</param>
        public void saveWorkshiftsIntoCurrentDayInShiftEdit(string[,] data)
        {
            //fill with new shifts
            for (int r = 0; r < data.GetLength(0); r++)
            {
                int[] startHoursMinutes = modelControl.getHourMinutesFromString(data[r, 0]);
                if (startHoursMinutes == null)
                {
                    return;
                }
                int[] endHoursMinutes = modelControl.getHourMinutesFromString(data[r, 1]);
                if (endHoursMinutes == null)
                {
                    return;
                }
                if (r >= currentWorkdayInShiftEdit.shifts.Count)
                {
                    currentWorkdayInShiftEdit.shifts.Add(new Workshift(startHoursMinutes[0], startHoursMinutes[1],
                    endHoursMinutes[0], endHoursMinutes[1], data[r, 2], data[r, 3]));
                }
                else
                {
                    currentWorkdayInShiftEdit.shifts[r].startHour = startHoursMinutes[0];
                    currentWorkdayInShiftEdit.shifts[r].startMinute = startHoursMinutes[1];
                    currentWorkdayInShiftEdit.shifts[r].endHour = endHoursMinutes[0];
                    currentWorkdayInShiftEdit.shifts[r].endMinute = endHoursMinutes[1];
                    currentWorkdayInShiftEdit.shifts[r].shiftType = data[r, 2];
                    currentWorkdayInShiftEdit.shifts[r].description = data[r, 3];
                }
            }

            //delete workshifts that are not in the data anymore
            if (data.GetLength(0) < currentWorkdayInShiftEdit.shifts.Count)
            {
                for (int i = 0; i < currentWorkdayInShiftEdit.shifts.Count - data.GetLength(0); i++)
                {
                    currentWorkdayInShiftEdit.shifts.Remove(currentWorkdayInShiftEdit.shifts[currentWorkdayInShiftEdit.shifts.Count - i - 1]);
                }
            }

            setShiftTypesInShiftTypeColorSettings();

            currentWorkdayInShiftEdit.shifts = modelControl.getSortedWorkshiftsInWorkday(currentWorkdayInShiftEdit);
        }

        /// <summary>
        /// sets the shifttypes in the shifttypecolor setting
        /// </summary>
        public void setShiftTypesInShiftTypeColorSettings()
        {
            //look if the workshifts in the month have changed and put data in the shifttypecolors accordingly
            string[] shiftTypes = modelControl.getShiftTypesInWorkdays(modelControl.currentWorkmonth.workdays);
            //add all shiftTypes in the currentMonth, who are not in the dict yet
            foreach (string shiftType in shiftTypes)
            {
                if (!modelControl.currentWorkmonth.settings.shiftTypeColors.ContainsKey(shiftType))
                {
                    modelControl.currentWorkmonth.settings.shiftTypeColors.Add(shiftType, window.transparent);
                }
            }
            //remove any shiftTypes who are not in the currentMonth anymore
            List<string> shiftTypesToBeRemoved = new List<string>();
            foreach (string shiftType in modelControl.currentWorkmonth.settings.shiftTypeColors.Keys)
            {
                if (!Util.stringArrayContains(shiftTypes, shiftType))
                {
                    shiftTypesToBeRemoved.Add(shiftType);
                }
            }
            foreach (string shiftType in shiftTypesToBeRemoved)
            {
                modelControl.currentWorkmonth.settings.shiftTypeColors.Remove(shiftType);
            }
        }

        /// <summary>
        /// clones the weektemplate workshifts into the workshifts of all currentMonth.workdays with the corresponding weekdayindex
        /// </summary>
        public void setWeekTemplateOnMonth()
        {
            foreach (Workday workday in modelControl.currentWorkmonth.workdays)
            {
                workday.shifts = modelControl.currentWorkmonth.weekTemplate[workday.weekdayIndex].cloneWorkshifts();
            }

            setShiftTypesInShiftTypeColorSettings();
        }
    }
}
