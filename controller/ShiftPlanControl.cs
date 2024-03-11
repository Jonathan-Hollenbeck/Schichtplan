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

        #region my functions

        /// <summary>
        /// creates the shiftplan
        /// </summary>
        public void createShiftPlan(int algorithmIndex)
        {
            modelControl.currentWorkmonth.shiftplan.Clear();

            switch (algorithmIndex)
            {
                case 0:
                    modelControl.currentWorkmonth.shiftplan = getSimpleShiftPlan(modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.persons, modelControl.currentWorkmonth.hourCarryOverLastMonth);
                    break;
                case 1:
                    modelControl.currentWorkmonth.shiftplan = getEvenlyDistributedShiftPlan(modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.persons, modelControl.currentWorkmonth.hourCarryOverLastMonth);
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

        #endregion

        #region create shiftPlan

        /// <summary>
        /// creates the shiftplan by iteratively for every workshift first trying fulfill the minWorkHour of every person
        /// and then to not to get over their maxWorkHour
        /// also not inserts person, if it is working at the day before or after
        /// </summary>
        public Dictionary<Workshift, Person> getSimpleShiftPlan(List<Workday> workdays, List<Person> persons, Dictionary<Person, float> carryOver)
        {
            Dictionary<Workshift, Person> shiftplan = new Dictionary<Workshift, Person>();

            shiftplan = setWorkshiftsToOnlyAvailablePerson(shiftplan, workdays, persons, carryOver);

            shiftplan = setWorkshiftsToPersonWithMostDistanceToMinWorktime(shiftplan, workdays, persons, carryOver);

            shiftplan = setWorkshiftsToPersonWithMostDistanceToMaxWorktime(shiftplan, workdays, persons, carryOver);

            return shiftplan;
        }

        /// <summary>
        /// creates the shiftplan and tries to distribute their workhours evenly over the month
        /// </summary>
        public Dictionary<Workshift, Person> getEvenlyDistributedShiftPlan(List<Workday> workdays, List<Person> persons, Dictionary<Person, float> carryOver)
        {
            Dictionary<Workshift, Person> shiftplan = new Dictionary<Workshift, Person>();

            shiftplan = setWorkshiftsToOnlyAvailablePerson(shiftplan, workdays, persons, carryOver);

            shiftplan = setWorkshiftsEvenlyDistributed(shiftplan, workdays, persons, carryOver);

            shiftplan = setWorkshiftsAndNotLetPersonsWorkTwoDaysInARow(shiftplan, workdays, persons, carryOver);
            
            shiftplan = setWorkshiftBasedOnPersonWithLeastDaysWorking(shiftplan, workdays, persons, carryOver);

            return shiftplan;
        }

        /// <summary>
        /// sets the person, who is the only one available for that workshift into that workshift
        /// </summary>
        /// <param name="currentShiftplan">the current shiftplan</param>
        /// <param name="workdays">the workdays with the workshifts</param>
        /// <param name="persons">the persons to set</param>
        /// <param name="carryOver">the carryOver for the persons</param>
        /// <returns>a shiftplan with all workshifts, where only one person can work set to that person</returns>
        public Dictionary<Workshift, Person> setWorkshiftsToOnlyAvailablePerson(Dictionary<Workshift, Person> currentShiftplan, List<Workday> workdays, List<Person> persons, Dictionary<Person, float> carryOver)
        {
            Dictionary<Workshift, Person> shiftplan = currentShiftplan;

            //workshifts where only one person can work. set this person to work
            foreach (Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    if (!shiftplan.ContainsKey(workshift))
                    {
                        foreach (Person person in persons)
                        {
                            if (modelControl.isPersonOnlyOneAvailableForWorkshift(person, persons, workshift, workdays))
                            {
                                shiftplan.Add(workshift, person);
                            }
                        }
                    }
                }
            }

            return shiftplan;
        }
        
        /// <summary>
        /// sets the workshifts and tries to evenly distribute the persons based on their minworktime
        /// </summary>
        /// <param name="currentShiftplan">the current shiftplan</param>
        /// <param name="workdays">the workdays with the workshifts</param>
        /// <param name="persons">the persons to set</param>
        /// <param name="carryOver">the carryOver for the persons</param>
        /// <returns>a shiftplan with all workshifts, where only one person can work set to that person</returns>
        public Dictionary<Workshift, Person> setWorkshiftsEvenlyDistributed(Dictionary<Workshift, Person> currentShiftplan, List<Workday> workdays, List<Person> persons, Dictionary<Person, float> carryOver)
        {
            Dictionary<Workshift, Person> shiftplan = currentShiftplan;

            //loop persons
            foreach (Person person in persons)
            {
                //list with all workdays a person could work
                List<Workday> availableWorkdays = modelControl.getWorkdaysWithAvailableEmtpyWorkshiftsForPersonInWorkdays(person, workdays, shiftplan);

                //distribute workshifts based on persons average time, minworkhours and available workdays
                float averageWorktime = 0.0f;
                Dictionary<string, float> shiftTypesWorktimes = modelControl.getWorktimesForShiftTypesInWorkdays(availableWorkdays);
                Dictionary<string, int> shiftTypesCount = modelControl.getShiftCountByShiftTypesInWorkdays(shiftTypesWorktimes.Keys.ToArray(), availableWorkdays);
                foreach (KeyValuePair<string, float> shiftTypeWorktime in shiftTypesWorktimes)
                {
                    if (Util.stringArrayContains(person.shiftTypes, shiftTypeWorktime.Key))
                    {
                        averageWorktime += (shiftTypeWorktime.Value / shiftTypesCount[shiftTypeWorktime.Key]) / person.shiftTypes.Length;
                    }
                }

                float distributionDistance = availableWorkdays.Count / (person.minWorkHours / averageWorktime);
                //distribution distance is a little to high so here its brought down a bit
                distributionDistance -= 1 - (5 / person.minWorkHours);
                float currentDistributionDistance = 0;
                //loop weeks
                List<List<Workday>> weeksPerson = modelControl.getWeeksInWorkdays(availableWorkdays);
                for (int weekCounter = 0; weekCounter < weeksPerson.Count; weekCounter++)
                {
                    //workdays sorted by day
                    List<Workday> week = modelControl.getSortedWorkdays(weeksPerson[weekCounter]);
                    //loop week
                    foreach (Workday workday in week)
                    {
                        List<Workshift> emptyWorkshifts = modelControl.getEmptyWorkshiftsByShiftTypesFromWorkday(person.shiftTypes, workday, shiftplan);
                        if (emptyWorkshifts.Count != 0 && currentDistributionDistance <= 0.0f)
                        {
                            //distribution distance reached. set person to workshift
                            foreach (Workshift workshift in emptyWorkshifts)
                            {
                                if (!modelControl.isPersonWorkingAtDay(person, workday, shiftplan)
                                && modelControl.isPersonAvailableInWorkshift(person, workshift))
                                {
                                    shiftplan.Add(workshift, person);
                                    currentDistributionDistance += distributionDistance;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            currentDistributionDistance--;
                        }
                    }
                }
            }

            return shiftplan;
        }

        /// <summary>
        /// sets the workshifts and only sets the person, if it didnt work the day before or after
        /// </summary>
        /// <param name="currentShiftplan">the current shiftplan</param>
        /// <param name="workdays">the workdays with the workshifts</param>
        /// <param name="persons">the persons to set</param>
        /// <param name="carryOver">the carryOver for the persons</param>
        /// <returns>a shiftplan with all workshifts, where only one person can work set to that person</returns>
        public Dictionary<Workshift, Person> setWorkshiftsAndNotLetPersonsWorkTwoDaysInARow(Dictionary<Workshift, Person> currentShiftplan, List<Workday> workdays, List<Person> persons, Dictionary<Person, float> carryOver)
        {
            Dictionary<Workshift, Person> shiftplan = currentShiftplan;

            //loop throu weeks, workdays, workshifts
            List<List<Workday>> weeks = modelControl.getWeeksInWorkdays(workdays);
            for (int weekCounter = 0; weekCounter < weeks.Count; weekCounter++)
            {
                //workdays sort by day
                List<Workday> week = modelControl.getSortedWorkdays(weeks[weekCounter]);
                foreach (Workday workday in week)
                {
                    foreach (Workshift workshift in workday.shifts)
                    {
                        if (!shiftplan.ContainsKey(workshift))
                        {
                            float worktime = modelControl.getWorktimeInWorkshift(workshift);

                            //look for persons who can work this workshifts
                            //take person, which isnt working that day and has the least worktime
                            Person currentPerson = null;
                            float currentMinWorktime = float.MaxValue;
                            foreach (Person person in modelControl.getAvailablePersonsInWorkshift(workshift, persons))
                            {
                                //calculate effictive worktime
                                float effictiveWorktimeInMonth = modelControl.getWorktimeForPersonInWorkdays(person, workdays, shiftplan);
                                effictiveWorktimeInMonth += modelControl.getPersonCarryOver(person, carryOver);

                                if (!modelControl.isPersonWorkingAtDayBeforeOrAfter(person, workday, week, shiftplan)
                                    && !modelControl.isPersonWorkingAtDay(person, workday, shiftplan)
                                && effictiveWorktimeInMonth < currentMinWorktime
                                    && effictiveWorktimeInMonth + worktime <= person.maxWorkHours)
                                {
                                    currentPerson = person;
                                    currentMinWorktime = effictiveWorktimeInMonth;
                                }
                            }
                            if (currentPerson != null)
                            {
                                shiftplan.Add(workshift, currentPerson);
                            }
                        }
                    }
                }
            }

            return shiftplan;
        }

        /// <summary>
        /// sets the workshifts to the person with the least days working
        /// </summary>
        /// <param name="currentShiftplan">the current shiftplan</param>
        /// <param name="workdays">the workdays with the workshifts</param>
        /// <param name="persons">the persons to set</param>
        /// <param name="carryOver">the carryOver for the persons</param>
        /// <returns>a shiftplan with all workshifts, where only one person can work set to that person</returns>
        public Dictionary<Workshift, Person> setWorkshiftBasedOnPersonWithLeastDaysWorking(Dictionary<Workshift, Person> currentShiftplan, List<Workday> workdays, List<Person> persons, Dictionary<Person, float> carryOver)
        {
            Dictionary<Workshift, Person> shiftplan = currentShiftplan;

            foreach (Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    if (!shiftplan.ContainsKey(workshift))
                    {
                        float worktime = modelControl.getWorktimeInWorkshift(workshift);

                        Person currentPerson = null;
                        int currentDaysNotWorking = int.MinValue;
                        foreach (Person person in modelControl.getAvailablePersonsInWorkshift(workshift, persons))
                        {
                            //calculate effictive worktime
                            float effictiveWorktimeInMonth = modelControl.getWorktimeForPersonInWorkdays(person, workdays, shiftplan);
                            effictiveWorktimeInMonth += modelControl.getPersonCarryOver(person, carryOver);

                            int daysNotWorking = modelControl.getDaysNotWorkingForPersonInWorkdaysCount(person, workdays, shiftplan);
                            if (!modelControl.isPersonWorkingAtDay(person, workday, shiftplan)
                                && daysNotWorking > currentDaysNotWorking
                                && effictiveWorktimeInMonth + worktime <= person.maxWorkHours)
                            {
                                currentPerson = person;
                                currentDaysNotWorking = daysNotWorking;
                            }
                        }
                        if (currentPerson != null)
                        {
                            shiftplan.Add(workshift, currentPerson);
                        }
                    }
                }
            }

            return shiftplan;
        }

        /// <summary>
        /// sets the workshifts to the person with the least worktime
        /// </summary>
        /// <param name="currentShiftplan">the current shiftplan</param>
        /// <param name="workdays">the workdays with the workshifts</param>
        /// <param name="persons">the persons to set</param>
        /// <param name="carryOver">the carryOver for the persons</param>
        /// <returns>a shiftplan with all workshifts, where only one person can work set to that person</returns>
        public Dictionary<Workshift, Person> setWorkshiftsBasedOnPersonWithLeastWorktime(Dictionary<Workshift, Person> currentShiftplan, List<Workday> workdays, List<Person> persons, Dictionary<Person, float> carryOver)
        {
            Dictionary<Workshift, Person> shiftplan = currentShiftplan;

            foreach (Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    if (!shiftplan.ContainsKey(workshift))
                    {
                        float worktime = modelControl.getWorktimeInWorkshift(workshift);

                        Person currentPerson = null;
                        float currentLeastWorktime = float.MaxValue;
                        foreach (Person person in modelControl.getAvailablePersonsInWorkshift(workshift, persons))
                        {
                            //calculate effictive worktime
                            float effictiveWorktimeInMonth = modelControl.getWorktimeForPersonInWorkdays(person, workdays, shiftplan);
                            effictiveWorktimeInMonth += modelControl.getPersonCarryOver(person, carryOver);

                            if (!modelControl.isPersonWorkingAtDay(person, workday, shiftplan)
                                && effictiveWorktimeInMonth < currentLeastWorktime
                                && effictiveWorktimeInMonth + worktime <= person.maxWorkHours)
                            {
                                currentPerson = person;
                                currentLeastWorktime = effictiveWorktimeInMonth;
                            }
                        }
                        if (currentPerson != null)
                        {
                            shiftplan.Add(workshift, currentPerson);
                        }
                    }
                }
            }

            return shiftplan;
        }

        /// <summary>
        /// sets the workshifts to the person with most distance to the minworktime 
        /// and only sets persons if they have not reached their minworktime
        /// </summary>
        /// <param name="currentShiftplan">the current shiftplan</param>
        /// <param name="workdays">the workdays with the workshifts</param>
        /// <param name="persons">the persons to set</param>
        /// <param name="carryOver">the carryOver for the persons</param>
        /// <returns>a shiftplan with all workshifts, where only one person can work set to that person</returns>
        public Dictionary<Workshift, Person> setWorkshiftsToPersonWithMostDistanceToMinWorktime(Dictionary<Workshift, Person> currentShiftplan, List<Workday> workdays, List<Person> persons, Dictionary<Person, float> carryOver)
        {
            Dictionary<Workshift, Person> shiftplan = currentShiftplan;

            foreach (Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    if (!shiftplan.ContainsKey(workshift))
                    {
                        float worktime = modelControl.getWorktimeInWorkshift(workshift);

                        Person currentPerson = null;
                        float currentDistToMinWorktime = float.MinValue;
                        foreach (Person person in modelControl.getAvailablePersonsInWorkshift(workshift, persons))
                        {
                            //calculate effictive worktime
                            float effictiveWorktimeInMonth = modelControl.getWorktimeForPersonInWorkdays(person, workdays, shiftplan);
                            effictiveWorktimeInMonth += modelControl.getPersonCarryOver(person, carryOver);

                            float distanceToMinWorktime = person.minWorkHours - effictiveWorktimeInMonth;

                            if (!modelControl.isPersonWorkingAtDay(person, workday, shiftplan)
                                && distanceToMinWorktime > currentDistToMinWorktime
                                && distanceToMinWorktime > 0
                                && effictiveWorktimeInMonth + worktime <= person.maxWorkHours)
                            {
                                currentPerson = person;
                                currentDistToMinWorktime = distanceToMinWorktime;
                            }
                        }
                        if (currentPerson != null)
                        {
                            shiftplan.Add(workshift, currentPerson);
                        }
                    }
                }
            }

            return shiftplan;
        }

        /// <summary>
        /// sets the workshifts to the person with most distance to the maxworktime
        /// </summary>
        /// <param name="currentShiftplan">the current shiftplan</param>
        /// <param name="workdays">the workdays with the workshifts</param>
        /// <param name="persons">the persons to set</param>
        /// <param name="carryOver">the carryOver for the persons</param>
        /// <returns>a shiftplan with all workshifts, where only one person can work set to that person</returns>
        public Dictionary<Workshift, Person> setWorkshiftsToPersonWithMostDistanceToMaxWorktime(Dictionary<Workshift, Person> currentShiftplan, List<Workday> workdays, List<Person> persons, Dictionary<Person, float> carryOver)
        {
            Dictionary<Workshift, Person> shiftplan = currentShiftplan;

            foreach (Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    if (!shiftplan.ContainsKey(workshift))
                    {
                        float worktime = modelControl.getWorktimeInWorkshift(workshift);

                        Person currentPerson = null;
                        float currentDistToMaxWorktime = float.MinValue;
                        foreach (Person person in modelControl.getAvailablePersonsInWorkshift(workshift, persons))
                        {
                            //calculate effictive worktime
                            float effictiveWorktimeInMonth = modelControl.getWorktimeForPersonInWorkdays(person, workdays, shiftplan);
                            effictiveWorktimeInMonth += modelControl.getPersonCarryOver(person, carryOver);

                            float distanceToMaxWorktime = person.maxWorkHours - effictiveWorktimeInMonth;

                            if (!modelControl.isPersonWorkingAtDay(person, workday, shiftplan)
                                && distanceToMaxWorktime > currentDistToMaxWorktime
                                && effictiveWorktimeInMonth + worktime <= person.maxWorkHours)
                            {
                                currentPerson = person;
                                currentDistToMaxWorktime = distanceToMaxWorktime;
                            }
                        }
                        if (currentPerson != null)
                        {
                            shiftplan.Add(workshift, currentPerson);
                        }
                    }
                }
            }

            return shiftplan;
        }
        #endregion
    }
}
