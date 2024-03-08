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


        /// <summary>
        /// creates the shiftplan by iteratively for every workshift first trying fulfill the minWorkHour of every person
        /// and then to not to get over their maxWorkHour
        /// also not inserts person, if it is working at the day before or after
        /// </summary>
        public Dictionary<Workshift, Person> getSimpleShiftPlan(List<Workday> workdays, List<Person> persons, Dictionary<Person, float> carryOver)
        {
            Dictionary<Workshift, Person> shiftplan = new Dictionary<Workshift, Person>();

            Dictionary<Person, float> workTimeMonth = new Dictionary<Person, float>();
            //fill dict with 0
            foreach (Person person in persons)
            {
                workTimeMonth.Add(person, modelControl.getPersonCarryOver(person, carryOver));
            }

            //fill dict with available persons
            Dictionary<Workshift, List<Person>> availablePersons = new Dictionary<Workshift, List<Person>>();
            foreach (Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    //check what kind of shift it is and fill List with corresponding persons
                    availablePersons.Add(workshift, modelControl.getAvailablePersonsInWorkshift(workshift, persons));
                }
            }

            //set Person per shift in shiftplan
            for (int wd = 0; wd < workdays.Count; wd++)
            {
                Workday workday = workdays[wd];
                foreach (Workshift workshift in workday.shifts)
                {
                    float shiftWorkTime = modelControl.getWorktimeInWorkshift(workshift);
                    //take the available person, who has the most distance to its minWorkhours.
                    bool noPersonFound = true;
                    Person currentPerson = null;
                    float currentDistance = 0.0f;
                    foreach (Person person in availablePersons[workshift])
                    {
                        float distance = person.minWorkHours - workTimeMonth[person];
                        if (distance > currentDistance && !modelControl.isPersonWorkingAtDayBeforeOrAfter(person, workday, workdays, shiftplan))
                        {
                            noPersonFound = false;
                            currentPerson = person;
                            currentDistance = distance;
                        }
                    }
                    //all minWorkhours were satisfied. Now look for persons, who can work this shift without getting over their maxWorkhours
                    if (noPersonFound == true)
                    {
                        currentDistance = float.MaxValue;
                        foreach (Person person in availablePersons[workshift])
                        {
                            if (workTimeMonth[person] < currentDistance
                                && person.maxWorkHours >= (workTimeMonth[person] + shiftWorkTime)
                                && !modelControl.isPersonWorkingAtDayBeforeOrAfter(person, workday, workdays, shiftplan))
                            {
                                noPersonFound = false;
                                currentPerson = person;
                                currentDistance = workTimeMonth[person];
                            }
                        }
                    }
                    if (noPersonFound == false)
                    {
                        //add the worktime to its counter
                        workTimeMonth[currentPerson] += shiftWorkTime;
                        //remove the person from all shifts of the day
                        foreach (Workshift shift in workday.shifts)
                        {
                            availablePersons[shift].Remove(currentPerson);
                        }

                        //set current Person as the one to get this shift
                        shiftplan.Add(workshift, currentPerson);
                    }
                }
            }

            return shiftplan;
        }

        /// <summary>
        /// creates the shiftplan and tries to distribute their workhours evenly over the month
        /// </summary>
        public Dictionary<Workshift, Person> getEvenlyDistributedShiftPlan(List<Workday> workdays, List<Person> persons, Dictionary<Person, float> carryOver)
        {
            Dictionary<Workshift, Person> shiftplan = new Dictionary<Workshift, Person>();

            Dictionary<Person, float> workTimeMonth = new Dictionary<Person, float>();
            //fill dict with 0
            foreach (Person person in persons)
            {
                workTimeMonth.Add(person, modelControl.getPersonCarryOver(person, carryOver));
            }

            //workshifts where only one person can work. set this person to work
            foreach (Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    foreach (Person person in persons)
                    {
                        if (modelControl.isPersonOnlyOneAvailableForWorkshift(person, persons, workshift, workdays))
                        {
                            shiftplan.Add(workshift, person);
                            workTimeMonth[person] += modelControl.getWorktimeInWorkshift(workshift);
                        }
                    }
                }
            }

            //first try to distribute the workshifts evenly
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
                                    workTimeMonth[person] += modelControl.getWorktimeInWorkshift(workshift);
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


            //now try to set the other workshifts and not let persons work two days in a row.
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
                                if (!modelControl.isPersonWorkingAtDayBeforeOrAfter(person, workday, week, shiftplan)
                                    && !modelControl.isPersonWorkingAtDay(person, workday, shiftplan)
                                && workTimeMonth[person] < currentMinWorktime
                                    && workTimeMonth[person] + worktime <= person.maxWorkHours)
                                {
                                    currentPerson = person;
                                    currentMinWorktime = workTimeMonth[person];
                                }
                            }
                            if (currentPerson != null)
                            {
                                shiftplan.Add(workshift, currentPerson);
                                workTimeMonth[currentPerson] += worktime;
                            }
                        }
                    }
                }
            }

            //lastly set workshifts based on the person with the most days not working in the workdays
            foreach (Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    if (!shiftplan.ContainsKey(workshift))
                    {
                        float worktime = modelControl.getWorktimeInWorkshift(workshift);

                        Person currentPerson = null;
                        int currentDaysNotWorking = 0;
                        foreach (Person person in modelControl.getAvailablePersonsInWorkshift(workshift, persons))
                        {
                            int daysNotWorking = modelControl.getDaysNotWorkingForPersonInWorkdaysCount(person, workdays, shiftplan);
                            if (!modelControl.isPersonWorkingAtDay(person, workday, shiftplan)
                                && daysNotWorking > currentDaysNotWorking
                                && workTimeMonth[person] + worktime <= person.maxWorkHours)
                            {
                                currentPerson = person;
                                currentDaysNotWorking = daysNotWorking;
                            }
                        }
                        if (currentPerson != null)
                        {
                            shiftplan.Add(workshift, currentPerson);
                            workTimeMonth[currentPerson] += worktime;
                        }
                    }
                }
            }

            return shiftplan;
        }

    }
}
