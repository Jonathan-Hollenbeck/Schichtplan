using Schichtplan.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan
{
    public class ModelControl
    {
        /// <summary>
        /// the currentMonth
        /// </summary>
        public Workmonth currentWorkmonth { get; set; }

        /// <summary>
        /// creates a new workmonth and sets it as the currentMonth
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public void createYearMonth(int year, int month)
        {
            currentWorkmonth = new Workmonth(getMonthNameFromMonthNumber(month), month, year);
            currentWorkmonth.createEmptyWeekTemplate();
            currentWorkmonth.workdays = getWorkdaysFromDatetimes(getDates(year, month));
        }

        #region Util


        #region return List

        #region Workday List


        /// <summary>
        /// creates a new workday for a given list of datetimes and returns them in a list
        /// </summary>
        /// <param name="dateTimes">list of datetimes to create workdays from</param>
        /// <returns>list of workdays created from the given list of datetimes</returns>
        private List<Workday> getWorkdaysFromDatetimes(List<DateTime> dateTimes)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("de-DE");

            List<Workday> workdays = new List<Workday>();
            foreach (DateTime date in dateTimes)
            {
                string weekdayName = culture.DateTimeFormat.GetDayName(date.DayOfWeek).ToString();
                workdays.Add(new Workday(weekdayName, getWeekdayIndexFromWeekdayName(weekdayName), date.Day));
            }
            return workdays;
        }

        /// <summary>
        /// creates a list for all weeks in a given list of workdays
        /// each entry of this list contains a list with all workdays corresponding to that week
        /// </summary>
        /// <param name="workdays">list of workdays</param>
        /// <returns>list with weeks, which all have a list of workdays</returns>
        public List<List<Workday>> getWeeksInWorkdays(List<Workday> workdays)
        {
            List<List<Workday>> weekdays = new List<List<Workday>>();
            if (workdays.Count > 0)
            {
                int weekCounter = 0;
                Workday firstDayOfWeek = workdays[0];
                foreach (Workday workday in workdays)
                {
                    if (!isSameWeek(firstDayOfWeek, workday))
                    {
                        firstDayOfWeek = workday;
                        weekCounter++;
                    }
                    if (weekdays.Count < weekCounter + 1)
                    {
                        weekdays.Add(new List<Workday>());
                    }
                    weekdays[weekCounter].Add(workday);
                }
            }

            return weekdays;
        }

        /// <summary>
        /// gets a list of workdays, where a given person is available to work a emtpy shift at
        /// </summary>
        /// <param name="person">person to look for</param>
        /// <param name="workdays">list of workdays</param>
        /// <param name="shiftplan">shiftplan to look if workshift is occupied</param>
        /// <returns>a list of workdays, where a given person is available to work a emtpy shift at</returns>
        public List<Workday> getWorkdaysWithAvailableEmtpyWorkshiftsForPersonInWorkdays(Person person, List<Workday> workdays, Dictionary<Workshift, Person> shiftplan)
        {
            List<Workday> availableWorkdays = new List<Workday>();
            foreach(Workday workday in workdays)
            {
                if(isAvailableEmptyWorkshiftForPersonInWorkday(person, workday, shiftplan)){
                    availableWorkdays.Add(workday);
                }
            }
            return availableWorkdays;
        }

        /// <summary>
        /// returns the sorted workday list by their date day
        /// </summary>
        /// <param name="workdays">list of workdays</param>
        /// <returns>sorted workday list by date day</returns>
        public List<Workday> getSortedWorkdays(List<Workday> workdays)
        {
            workdays.Sort((workday1, workday2) => workday1.day.CompareTo(workday2.day));
            return workdays;
        }

        #endregion

        #region Workshift List

        /// <summary>
        /// checks which workshifts a person could work in a given list of workdays and returns them as a list
        /// </summary>
        /// <param name="person">person to check for</param>
        /// <param name="workdays">list of workdays</param>
        /// <returns></returns>
        public List<Workshift> getPossibleWorkshiftsForPersonInWorkdays(Person person, List<Workday> workdays)
        {
            List<Workshift> workshifts = new List<Workshift>();
            foreach (Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    if (isPossibleWorkshiftForPerson(person, workshift))
                    {
                        workshifts.Add(workshift);
                    }
                }
            }
            return workshifts;
        }

        /// <summary>
        /// sorts the workshifts in a given workday by shiftType first and startHour second
        /// </summary>
        /// <param name="workday">workday from which to sort the workshifts</param>
        /// <returns>the workshifts in a given workday by shiftType first and startHour second as a workshift list</returns>
        public List<Workshift> getSortedWorkshiftsInWorkday(Workday workday)
        {
            
            List<List<Workshift>> temp = new List<List<Workshift>>();

            //get all shifttypes for the workday
            string[] shiftTypes = getShiftTypesInWorkday(workday);
            List<string> shiftTypesList = shiftTypes.ToList();


            //sort for shifttype
            shiftTypesList.Sort((shiftType1, shiftType2) => shiftType2.CompareTo(shiftType1));
            foreach(string shifttype in shiftTypesList)
            {
                List<Workshift> workshifts = getWorkshiftsInWorkdayByShiftType(shifttype, workday);
                //sort for startHour
                workshifts.Sort((workshift1, workshift2) => workshift1.startHour.CompareTo(workshift2.startHour));
                temp.Add(workshifts);
            }
            List<Workshift> sorted = new List<Workshift>();
            foreach(List<Workshift> workshifts in temp)
            {
                sorted.AddRange(workshifts);
            }
            
            return sorted;
        }

        /// <summary>
        /// gets all workshifts from a given workday with a given workshift
        /// </summary>
        /// <param name="shiftType">shifttype to search for</param>
        /// <param name="workday">workday to search in</param>
        /// <returns>all workshifts from a given workday with a given workshift as a workshift list</returns>
        public List<Workshift> getWorkshiftsInWorkdayByShiftType(string shiftType, Workday workday)
        {
            List<Workshift> workshifts = new List<Workshift>();
            foreach(Workshift workshift in workday.shifts)
            {
                if(workshift.shiftType == shiftType)
                {
                    workshifts.Add(workshift);
                }
            }
            return workshifts;
        }

        /// <summary>
        /// gets all workshifts in a given workday which do not have a designated person and are one of a given shifttype
        /// </summary>
        /// <param name="shiftTypes">shifttypes to check for</param>
        /// <param name="workday">workday to check in</param>
        /// <param name="shiftplan">shiftplan to look if workshift is occupied</param>
        /// <returns>all workshifts in a given workshift list which do not have a designated person and are one of a given shifttype</returns>
        public List<Workshift> getEmptyWorkshiftsByShiftTypesFromWorkday(string[] shiftTypes, Workday workday, Dictionary<Workshift, Person> shiftplan)
        {
            List<Workshift> emptyWorkshifts = new List<Workshift>();

            foreach(Workshift workshift in workday.shifts)
            {
                if (!shiftplan.ContainsKey(workshift) && Util.stringArrayContains(shiftTypes, workshift.shiftType))
                {
                    emptyWorkshifts.Add(workshift);
                }
            }

            return emptyWorkshifts;
        }

        /// <summary>
        /// gets all workshifts in a given list of workdays which do not have a designated person
        /// </summary>
        /// <param name="workdays">list of workdays</param>
        /// <param name="shiftplan">shiftplan to look if workshift is occupied</param>
        /// <returns>all workshifts in a given list of workdays which do not have a designated person</returns>
        public List<Workshift> getEmtpyWorkshiftsInWorkdays(List<Workday> workdays, Dictionary<Workshift, Person> shiftplan)
        {
            List<Workshift> emptyWorkshifts = new List<Workshift>();

            foreach(Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    if (!shiftplan.ContainsKey(workshift))
                    {
                        emptyWorkshifts.Add(workshift);
                    }
                }
            }

            return emptyWorkshifts;
        }

        #endregion

        #region Person List

        /// <summary>
        /// checks which persons do not reach their minHours in a list of workdays with a given shiftplan and returns them
        /// </summary>
        /// <param name="persons">list of persons</param>
        /// <param name="workdays">list of workdays</param>
        /// <param name="shiftplan">shiftplan to check in</param>
        /// <returns>the persons, which do not reach their minHours</returns>
        public List<Person> getPersonsWithLessThanMinWorkhours(List<Person> persons, List<Workday> workdays, Dictionary<Workshift, Person> shiftplan, Dictionary<Person, float> carryOver)
        {
            List<Person> unsatisfiedPersons = new List<Person>();

            foreach (Person person in persons)
            {
                float worktime = getWorktimeForPersonInWorkdays(person, workdays, shiftplan);
                if (carryOver.ContainsKey(person))
                {
                    worktime += carryOver[person];
                }
                if (worktime < person.minWorkHours)
                {
                    unsatisfiedPersons.Add(person);
                }
            }

            return unsatisfiedPersons;
        }

        /// <summary>
        /// checks which persons surpass their maxHours in a list of workdays with a given shiftplan and returns them
        /// </summary>
        /// <param name="persons">list of persons</param>
        /// <param name="workdays">list of workdays</param>
        /// <param name="shiftplan">shiftplan to check in</param>
        /// <returns>the persons, which surpass their maxHours</returns>
        public List<Person> getPersonsWithMoreThanMaxWorkhours(List<Person> persons, List<Workday> workdays, Dictionary<Workshift, Person> shiftplan, Dictionary<Person, float> carryOver)
        {
            List<Person> unsatisfiedPersons = new List<Person>();

            foreach (Person person in persons)
            {
                float worktime = getWorktimeForPersonInWorkdays(person, workdays, shiftplan);
                if (carryOver.ContainsKey(person))
                {
                    worktime += carryOver[person];
                }
                if (worktime > person.maxWorkHours)
                {
                    unsatisfiedPersons.Add(person);
                }
            }

            return unsatisfiedPersons;
        }

        /// <summary>
        /// gets the available persons for a workshift in a given list of persons
        /// </summary>
        /// <param name="workshift">workshift to check for</param>
        /// <param name="persons">list of persons</param>
        /// <returns>list of available persons for the workshift</returns>
        public List<Person> getAvailablePersonsInWorkshift(Workshift workshift, List<Person> persons)
        {
            List<Person> availablePersons = new List<Person>();
            foreach (Person person in persons)
            {
                if (isPersonAvailableInWorkshift(person, workshift))
                {
                    availablePersons.Add(person);
                }
            }
            return availablePersons;
        }

        /// <summary>
        /// sorts the given person list for the given sort key
        /// </summary>
        /// <param name="sort">sort key</param>
        /// <param name="persons">list of persons</param>
        /// <returns>list of sorted persons by the sort key</returns>
        public List<Person> getPersonsSortedBy(string sort, List<Person> persons)
        {
            switch (sort)
            {
                case "name":
                    persons.Sort((person1, person2) => person1.name.CompareTo(person2.name));
                    break;
                case "saleryPerHour":
                    persons.Sort((person1, person2) => person1.saleryPerHour.CompareTo(person2.saleryPerHour));
                    break;
                case "minWorkHours":
                    persons.Sort((person1, person2) => person1.minWorkHours.CompareTo(person2.minWorkHours));
                    break;
                case "maxWorkHours":
                    persons.Sort((person1, person2) => person1.maxWorkHours.CompareTo(person2.maxWorkHours));
                    break;
                case "shiftTypes":
                    persons.Sort((person1, person2) => person1.shiftTypesToString().CompareTo(person2.shiftTypesToString()));
                    break;
                case "description":
                    persons.Sort((person1, person2) => person1.description.CompareTo(person2.description));
                    break;
                default:
                    break;
            }

            return persons;
        }

        #endregion

        #region DateTime List

        /// <summary>
        /// gets a list of all days as datetimes for a given year and month
        /// </summary>
        /// <param name="year">year to get the days from</param>
        /// <param name="month">month to get the days from</param>
        /// <returns>list with all datetimes for all days of the given year and month</returns>
        public List<DateTime> getDates(int year, int month)
        {
            List<DateTime> dates = new List<DateTime>();

            for (DateTime date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                dates.Add(date);
            }

            return dates;
        }

        #endregion

        #region int List

        /// <summary>
        /// gets all workshifts from a given workdayindex in a list of workdays, in which a given person could work
        /// </summary>
        /// <param name="day">workdayindex with the workshifts</param>
        /// <param name="person">person who needs to be able to work in the workshifts</param>
        /// <param name="workdays">list of workdays</param>
        /// <returns>all workshifts from a given workdayindex in a list of workdays, in which a given person could work</returns>
        public List<int> getWorkshiftIndexesForWorkdayIndexForPersonInWorkdays(int day, Person person, List<Workday> workdays)
        {
            List<int> workshiftIndexes = new List<int>();

            foreach (Workday workday in workdays)
            {
                if (workday.day == day)
                {
                    foreach (Workshift workshift in workday.shifts)
                    {
                        int index = getWorkshiftIndexForWorkshiftForPersonInWorkdays(workshift, person, workdays);
                        if (index != -1)
                        {
                            workshiftIndexes.Add(index);
                        }
                    }
                    return workshiftIndexes;
                }
            }
            return workshiftIndexes;
        }

        #endregion

        #endregion

        #region return Dicts

        #region Person, float Dicts

        /// <summary>
        /// calculates, if any person in a given person list works more in a given workday list, then its maxWorkHours and saves them into a dict
        /// </summary>
        /// <param name="persons">person list</param>
        /// <param name="workdays">workday list</param>
        /// <param name="shiftplan">shiftplan to search in</param>
        /// <returns>carryover hours for all persons in a given peron list</returns>
        public Dictionary<Person, float> getCarryOverHoursForWorkdaysForPersonsInShiftplan(List<Person> persons, List<Workday> workdays, Dictionary<Workshift, Person> shiftplan, Dictionary<Person, float> carryOver)
        {
            Dictionary<Person, float> carryOverHours = new Dictionary<Person, float>();

            foreach(Person person in persons)
            {
                float worktime = getWorktimeForPersonInWorkdays(person, workdays, shiftplan);
                if (carryOver.ContainsKey(person))
                {
                    worktime += carryOver[person];
                }
                if(worktime != 0 && worktime > person.maxWorkHours)
                {
                    if (!carryOverHours.ContainsKey(person))
                    {
                        carryOverHours.Add(person, worktime - person.maxWorkHours);
                    }
                }
            }

            return carryOverHours;
        }

        #endregion

        #region Workshift, Person Dicts

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
                workTimeMonth.Add(person, getPersonCarryOver(person, carryOver));
            }

            //fill dict with available persons
            Dictionary<Workshift, List<Person>> availablePersons = new Dictionary<Workshift, List<Person>>();
            foreach (Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    //check what kind of shift it is and fill List with corresponding persons
                    availablePersons.Add(workshift, getAvailablePersonsInWorkshift(workshift, persons));
                }
            }

            //set Person per shift in shiftplan
            for (int wd = 0; wd < workdays.Count; wd++)
            {
                Workday workday = workdays[wd];
                foreach (Workshift workshift in workday.shifts)
                {
                    float shiftWorkTime = getWorktimeInWorkshift(workshift);
                    //take the available person, who has the most distance to its minWorkhours.
                    bool noPersonFound = true;
                    Person currentPerson = null;
                    float currentDistance = 0.0f;
                    foreach (Person person in availablePersons[workshift])
                    {
                        float distance = person.minWorkHours - workTimeMonth[person];
                        if (distance > currentDistance && !isPersonWorkingAtDayBeforeOrAfter(person, workday, workdays, shiftplan))
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
                            if (workTimeMonth[person] < currentDistance && person.maxWorkHours >= (workTimeMonth[person] + shiftWorkTime) && !isPersonWorkingAtDayBeforeOrAfter(person, workday, workdays, shiftplan))
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
                workTimeMonth.Add(person, getPersonCarryOver(person, carryOver));
            }

            //workshifts where only one person can work. set this person to work
            foreach(Workday workday in workdays)
            {
                foreach(Workshift workshift in workday.shifts)
                {
                    foreach(Person person in persons)
                    {
                        if(isPersonOnlyOneAvailableForWorkshift(person, persons, workshift, workdays))
                        {
                            shiftplan.Add(workshift, person);
                            workTimeMonth[person] += getWorktimeInWorkshift(workshift);
                        }
                    }
                }
            }

            //first try to distribute the workshifts evenly
            //loop persons
            foreach(Person person in persons)
            {
                //list with all workdays a person could work
                List<Workday> availableWorkdays = getWorkdaysWithAvailableEmtpyWorkshiftsForPersonInWorkdays(person, workdays, shiftplan);

                //distribute workshifts based on persons average time, minworkhours and available workdays
                float averageWorktime = 0.0f;
                Dictionary<string, float> shiftTypesWorktimes = getWorktimesForShiftTypesInWorkdays(availableWorkdays);
                Dictionary<string, int> shiftTypesCount = getShiftCountByShiftTypesInWorkdays(shiftTypesWorktimes.Keys.ToArray(), availableWorkdays);
                foreach (KeyValuePair<string, float> shiftTypeWorktime in shiftTypesWorktimes)
                {
                    if(Util.stringArrayContains(person.shiftTypes, shiftTypeWorktime.Key))
                    {
                        averageWorktime += (shiftTypeWorktime.Value / shiftTypesCount[shiftTypeWorktime.Key]) / person.shiftTypes.Length;
                    }
                }

                float distributionDistance = availableWorkdays.Count / (person.minWorkHours / averageWorktime);
                //distribution distance is a little to high so here its brought down a bit
                distributionDistance -= 1 - (5 / person.minWorkHours);
                float currentDistributionDistance = 0;
                //loop weeks
                List<List<Workday>> weeksPerson = getWeeksInWorkdays(availableWorkdays);
                for(int weekCounter = 0; weekCounter < weeksPerson.Count; weekCounter++)
                {
                    //workdays sorted by day
                    List<Workday> week = getSortedWorkdays(weeksPerson[weekCounter]);
                    //loop week
                    foreach (Workday workday in week)
                    {
                        List<Workshift> emptyWorkshifts = getEmptyWorkshiftsByShiftTypesFromWorkday(person.shiftTypes, workday, shiftplan);
                        if (emptyWorkshifts.Count != 0 && currentDistributionDistance <= 0.0f)
                        {
                            //distribution distance reached. set person to workshift
                            foreach (Workshift workshift in emptyWorkshifts)
                            {
                                if (!isPersonWorkingAtDay(person, workday, shiftplan)
                                && isPersonAvailableInWorkshift(person, workshift))
                                {
                                    shiftplan.Add(workshift, person);
                                    workTimeMonth[person] += getWorktimeInWorkshift(workshift);
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
            List<List<Workday>> weeks = getWeeksInWorkdays(workdays);
            for (int weekCounter = 0; weekCounter < weeks.Count; weekCounter++)
            {
                //workdays sort by day
                List<Workday> week = getSortedWorkdays(weeks[weekCounter]);
                foreach(Workday workday in week)
                {
                    foreach(Workshift workshift in workday.shifts)
                    {
                        if (!shiftplan.ContainsKey(workshift))
                        {
                            float worktime = getWorktimeInWorkshift(workshift);

                            //look for persons who can work this workshifts
                            //take person, which isnt working that day and has the least worktime
                            Person currentPerson = null;
                            float currentMinWorktime = float.MaxValue;
                            foreach (Person person in getAvailablePersonsInWorkshift(workshift, persons))
                            {
                                if (!isPersonWorkingAtDayBeforeOrAfter(person, workday, week, shiftplan)
                                    && !isPersonWorkingAtDay(person, workday, shiftplan)
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
            foreach(Workday workday in workdays)
            {
                foreach(Workshift workshift in workday.shifts)
                {
                    if (!shiftplan.ContainsKey(workshift))
                    {
                        float worktime = getWorktimeInWorkshift(workshift);

                        Person currentPerson = null;
                        int currentDaysNotWorking = 0;
                        foreach (Person person in getAvailablePersonsInWorkshift(workshift, persons))
                        {
                            int daysNotWorking = getDaysNotWorkingForPersonInWorkdaysCount(person, workdays, shiftplan);
                            if (!isPersonWorkingAtDay(person, workday, shiftplan)
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

        #endregion

        #region string, float dicts

        /// <summary>
        /// gets a dict, which has all the different shifttypes of the workshifts in the given workdays list and as keys their worktimes
        /// </summary>
        /// <param name="workdays">list of workdays</param>
        /// <returns>dict, which has all the different shifttypes of the workshifts in the given workdays list and as keys their worktimes</returns>
        public Dictionary<string, float> getWorktimesForShiftTypesInWorkdays(List<Workday> workdays)
        {
            Dictionary<string, float> counter = new Dictionary<string, float>();

            foreach (Workday workday in workdays)
            {
                Dictionary<string, float> workTimesDay = getWorktimesForShiftTypesInWorkday(workday);

                foreach (KeyValuePair<string, float> kvp in workTimesDay)
                {
                    if (!counter.ContainsKey(kvp.Key))
                    {
                        counter.Add(kvp.Key, 0);
                    }
                    counter[kvp.Key] += kvp.Value;
                }
            }
            return counter;
        }

        /// <summary>
        /// gets a dict, which has all the different shifttypes of the workshifts in a given workday and as keys their worktimes
        /// </summary>
        /// <param name="workday"></param>
        /// <returns></returns>
        public Dictionary<string, float> getWorktimesForShiftTypesInWorkday(Workday workday)
        {
            Dictionary<string, float> counter = new Dictionary<string, float>();

            foreach (Workshift workshift in workday.shifts)
            {
                if (!counter.ContainsKey(workshift.shiftType))
                {
                    counter.Add(workshift.shiftType, 0);
                }
                counter[workshift.shiftType] += getWorktimeInWorkshift(workshift);
            }
            return counter;
        }

        #endregion

        #region string, int Dicts

        /// <summary>
        /// counts the amount of shifts in a list of workdays by shifttype
        /// </summary>
        /// <param name="workdays">list of workdays</param>
        /// <returns>dict with all the shifttypes as key and the amount of shifts as value</returns>
        public Dictionary<string, int> getShiftCountInWorkdaysByShiftType(List<Workday> workdays)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();

            foreach (Workday workday in workdays)
            {
                Dictionary<string, int> workshiftPerWorkday = getShiftCountInWorkdayByShiftType(workday);

                foreach (KeyValuePair<string, int> kvp in workshiftPerWorkday)
                {
                    if (!counter.ContainsKey(kvp.Key))
                    {
                        counter.Add(kvp.Key, 0);
                    }
                    counter[kvp.Key] += kvp.Value;
                }
            }
            return counter;
        }

        /// <summary>
        /// counts the amount of shifts in a workday by shifttype
        /// </summary>
        /// <param name="workdays">list of workdays</param>
        /// <returns>dict with all the shifttypes as key and the amount of shifts as value</returns>
        public Dictionary<string, int> getShiftCountInWorkdayByShiftType(Workday workday)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();

            foreach (Workshift workshift in workday.shifts)
            {
                if (!counter.ContainsKey(workshift.shiftType))
                {
                    counter.Add(workshift.shiftType, 0);
                }
                counter[workshift.shiftType]++;
            }
            return counter;
        }

        /// <summary>
        /// counts the amount of shifts for a given array of shifttypes in a list of workdays
        /// </summary>
        /// <param name="shiftTypes">array of shifttypes to count for</param>
        /// <param name="workdays">list of workdays</param>
        /// <returns> dict with the given shifttypes as key and the amount of shifts in the list of workdays as value</returns>
        public Dictionary<string, int> getShiftCountByShiftTypesInWorkdays(string[] shiftTypes, List<Workday> workdays)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();

            foreach (Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    if (Util.stringArrayContains(shiftTypes, workshift.shiftType))
                    {
                        if (!counter.ContainsKey(workshift.shiftType))
                        {
                            counter.Add(workshift.shiftType, 0);
                        }
                        counter[workshift.shiftType]++;
                    }
                }
            }
            return counter;
        }

        /// <summary>
        /// counts how many shifts a person has worked in a list of workdays in a specific shifttype
        /// </summary>
        /// <param name="person">person for which to count for</param>
        /// <param name="workdays">list of workdays</param>
        /// <param name="shiftplan">shiftplan to look for the worked shifts of the given person</param>
        /// <returns>dict with the shifttype as key and the amount of shifts the person has worked in a workshift with that shifttype</returns>
        public Dictionary<string, int> getWorkedShiftsForPersonInWorkdaysByShiftTypeCount(Person person, List<Workday> workdays, Dictionary<Workshift, Person> shiftplan)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();

            foreach (Workday workday in workdays)
            {
                foreach (Workshift workshift in workday.shifts)
                {
                    if (shiftplan.ContainsKey(workshift))
                    {
                        if (shiftplan[workshift] == person)
                        {
                            if (Util.stringArrayContains(person.shiftTypes, workshift.shiftType))
                            {
                                if (!counter.ContainsKey(workshift.shiftType))
                                {
                                    counter.Add(workshift.shiftType, 0);
                                }
                                counter[workshift.shiftType]++;
                            }
                        }
                    }
                }
            }

            return counter;
        }

        #endregion

        #endregion

        #region return Workday

        /// <summary>
        /// gets the workday of a given workshift in a given list of workdays
        /// </summary>
        /// <param name="workshift">workshifts for which to search</param>
        /// <param name="workdays">list of workdays</param>
        /// <returns>the workday of the given workshift or null if not found</returns>
        public Workday getWorkdayFromWorkshiftInWorkdays(Workshift workshift, List<Workday> workdays)
        {
            foreach (Workday workday in workdays)
            {
                foreach (Workshift w in workday.shifts)
                {
                    if (workshift == w)
                    {
                        return workday;
                    }
                }
            }
            return null;
        }

        #endregion

        #region return string

        /// <summary>
        /// gets all shifttypes from a given workday and saves them in a string array
        /// </summary>
        /// <param name="workshifts">list of workshifts</param>
        /// <returns>string array with all shifttypes from the workday</returns>
        public string[] getShiftTypesInWorkday(Workday workday)
        {
            List<string> shiftTypes = new List<string>();
            foreach (Workshift workshift in workday.shifts)
            {
                if (!shiftTypes.Contains(workshift.shiftType))
                {
                    shiftTypes.Add(workshift.shiftType);
                }
            }
            return shiftTypes.ToArray();
        }

        /// <summary>
        /// gets all shifttypes from a given list of workdays and saves them in a string array
        /// </summary>
        /// <param name="workshifts">list of workshifts</param>
        /// <returns>string array with all shifttypes from the workday list</returns>
        public string[] getShiftTypesInWorkdays(List<Workday> workdays)
        {
            List<string> shiftTypes = new List<string>();
            foreach (Workday workday in workdays)
            {
                string[] workdayShiftTypes = getShiftTypesInWorkday(workday);
                foreach(string shiftType in workdayShiftTypes)
                {
                    if (!shiftTypes.Contains(shiftType))
                    {
                        shiftTypes.Add(shiftType);
                    }
                }
            }
            return shiftTypes.ToArray();
        }

        /// <summary>
        /// puts the year of the currentMonth and its month and monthname together in a string and returns it
        /// </summary>
        /// <returns>the year of the currentMonth and its month and monthname together in a string</returns>
        public string getYearMonthString()
        {
            return currentWorkmonth.year + "_" + currentWorkmonth.month + "-" + currentWorkmonth.monthName;
        }

        /// <summary>
        /// converts the starttime of a given workshift and workday into a format for an ics file
        /// </summary>
        /// <param name="workday">workday to convert the time from</param>
        /// <param name="workshift">workshift to convert the time from</param>
        /// <returns>the converted starttime of a given workshift and workday into a format for an ics file</returns>
        public string getWorkshiftStartTimeToIcsFormat(Workday workday, Workshift workshift)
        {
            string year = "" + currentWorkmonth.year;
            string month = "" + currentWorkmonth.month;
            month = month.Length == 1 ? "0" + month : month;
            string day = "" + workday.day;
            day = day.Length == 1 ? "0" + day : day;

            string hour = "" + workshift.startHour;
            hour = hour.Length == 1 ? "0" + hour : hour;
            string minute = "" + workshift.startMinute;
            minute = minute.Length == 1 ? "0" + minute : minute;

            return year + month + day + "T" + hour + minute + "00";
        }

        /// <summary>
        /// converts the endtime of a given workshift and workday into a format for an ics file
        /// </summary>
        /// <param name="workday">workday to convert the time from</param>
        /// <param name="workshift">workshift to convert the time from</param>
        /// <returns>the converted endtime of a given workshift and workday into a format for an ics file</returns>
        public string getWorkshiftEndTimeToIcsFormat(Workday workday, Workshift workshift)
        {
            string year = "" + currentWorkmonth.year;
            string month = "" + currentWorkmonth.month;
            month = month.Length == 1 ? "0" + month : month;
            string day = "" + workday.day;
            day = day.Length == 1 ? "0" + day : day;

            string hour = "" + workshift.endHour;
            hour = hour.Length == 1 ? "0" + hour : hour;
            string minute = "" + workshift.endMinute;
            minute = minute.Length == 1 ? "0" + minute : minute;

            return year + month + day + "T" + hour + minute + "00";
        }

        /// <summary>
        /// gets the monthName for a month index
        /// </summary>
        /// <param name="month">month index</param>
        /// <returns>the monthname for a month index or "" if not found</returns>
        public string getMonthNameFromMonthNumber(int month)
        {
            if (month == 1)
            {
                return "Januar";
            }
            else if (month == 2)
            {
                return "Februar";
            }
            else if (month == 3)
            {
                return "Maerz";
            }
            else if (month == 4)
            {
                return "April";
            }
            else if (month == 5)
            {
                return "Mai";
            }
            else if (month == 6)
            {
                return "Juni";
            }
            else if (month == 7)
            {
                return "Juli";
            }
            else if (month == 8)
            {
                return "August";
            }
            else if (month == 9)
            {
                return "September";
            }
            else if (month == 10)
            {
                return "Oktober";
            }
            else if (month == 11)
            {
                return "November";
            }
            else if (month == 12)
            {
                return "Dezember";
            }
            return "";
        }

        /// <summary>
        /// puts together the day index of the first and last day in a list of workdays in a string and returns it
        /// </summary>
        /// <param name="workdays">list of workdays</param>
        /// <returns>the day index of the first and last day in a list of workdays put together in a string</returns>
        public string getFirstAndLastDayInWorkdaysAsString(List<Workday> workdays)
        {
            int first = 1000;
            int last = 0;

            foreach (Workday workday in workdays)
            {
                if (workday.day < first)
                {
                    first = workday.day;
                }
                if (workday.day > last)
                {
                    last = workday.day;
                }
            }

            return first + " " + currentWorkmonth.monthName + " - " + last + " " + currentWorkmonth.monthName;
        }

        #endregion

        #region return int

        /// <summary>
        /// seperates the hours and minutes of a string with the format hh:mm and puts them into an int array
        /// </summary>
        /// <param name="dateTimeString">string of minuted and hours</param>
        /// <returns>the hours and minutes of a string with the format hh:mm seperated and put into an int array</returns>
        public int[] getHourMinutesFromString(string dateTimeString)
        {
            string[] split = dateTimeString.Split(':');
            int[] output = new int[2];

            int minute = 0;
            if (split.Length > 1)
            {
                minute = Util.parseInt(split[1], "Bitte nur Zahlen bei den Uhrzeiten verwenden.\n" +
                "Entweder nur eine Zahl fuer die Stunde, oder im Format hh:mm fuer Minuten und Stunden.");
            }

            output[0] = Util.parseInt(split[0], "Bitte nur Zahlen bei den Uhrzeiten verwenden.\n" +
                "Entweder nur eine Zahl fuer die Stunde, oder im Format hh:mm fuer Minuten und Stunden.");
            if (output[0] == -1)
            {
                return null;
            }
            output[1] = minute;
            return output;
        }

        /// <summary>
        /// gets the weekday index from the weekday name
        /// </summary>
        /// <param name="weekdayName">the weekday name</param>
        /// <returns>the weekday index from the weekday name</returns>
        public int getWeekdayIndexFromWeekdayName(string weekdayName)
        {
            if (weekdayName == "Montag")
            {
                return 0;
            }
            else if (weekdayName == "Dienstag")
            {
                return 1;
            }
            else if (weekdayName == "Mittwoch")
            {
                return 2;
            }
            else if (weekdayName == "Donnerstag")
            {
                return 3;
            }
            else if (weekdayName == "Freitag")
            {
                return 4;
            }
            else if (weekdayName == "Samstag")
            {
                return 5;
            }
            else if (weekdayName == "Sonntag")
            {
                return 6;
            }
            return -1;
        }

        /// <summary>
        /// sums the amount of workshifts for a given list of workdays
        /// </summary>
        /// <param name="workdays">list of workdays</param>
        /// <returns>the amount of workshifts for a given list of workdays</returns>
        public int getWorkShiftsCountInWorkdays(List<Workday> workdays)
        {
            int counter = 0;

            foreach (Workday workday in workdays)
            {
                counter += workday.shifts.Count;
            }
            return counter;
        }

        /// <summary>
        /// counts the amount of working days for a person in a list of workdays
        /// </summary>
        /// <param name="person">person to count for</param>
        /// <param name="workdays">list of workdays</param>
        /// <param name="shiftplan">shiftplan to look up if person is working workshift</param>
        /// <returns>the amount of working days for a person in a list of workdays</returns>
        public int getWorkingDaysForPersonInWorkdaysCount(Person person, List<Workday> workdays, Dictionary<Workshift, Person> shiftplan)
        {
            int sum = 0;
            foreach (Workday workday in workdays)
            {
                if (isPersonWorkingAtDay(person, workday, shiftplan))
                {
                    sum++;
                }
            }
            return sum;
        }

        /// <summary>
        /// counts the amount of days a person is not working in a list of workdays
        /// </summary>
        /// <param name="person">person to count for</param>
        /// <param name="workdays">list of workdays</param>
        /// <param name="shiftplan">shiftplan to look up if person is working workshift</param>
        /// <returns>the amount of days a person is not working in a list of workdays</returns>
        public int getDaysNotWorkingForPersonInWorkdaysCount(Person person, List<Workday> workdays, Dictionary<Workshift, Person> shiftplan)
        {
            return getWorkingDaysCounter(workdays) - getWorkingDaysForPersonInWorkdaysCount(person, workdays, shiftplan);
        }

        /// <summary>
        /// counts the amount of days on which there are workshifts in a given list of workdays
        /// </summary>
        /// <param name="workdays">list of workdays</param>
        /// <returns>the amount of days on which there are workshifts in a given list of workdays</returns>
        public int getWorkingDaysCounter(List<Workday> workdays)
        {
            int counter = 0;
            foreach (Workday workday in workdays)
            {
                counter += workday.shifts.Count > 0 ? 1 : 0;
            }
            return counter;
        }

        /// <summary>
        /// gets the index of the given workshift in the given list of workdays,
        /// but only ups the index if the person could work the current workshift
        /// </summary>
        /// <param name="workshift">workshift to search for</param>
        /// <param name="person">person for which to check if the workshifts are possible to work</param>
        /// <param name="workdays">list of workdays</param>
        /// <returns>the index of the given workshift in the given list of workdays,
        /// but only ups the index if the person could work the current workshift</returns>
        public int getWorkshiftIndexForWorkshiftForPersonInWorkdays(Workshift workshift, Person person, List<Workday> workdays)
        {
            List<Workshift> posibleWorkshifts = getPossibleWorkshiftsForPersonInWorkdays(person, workdays);

            int index = 0;

            foreach (Workday workday in workdays)
            {
                foreach (Workshift w in workday.shifts)
                {
                    if (w == workshift && posibleWorkshifts.Contains(w))
                    {
                        return index;
                    }
                    index += posibleWorkshifts.Contains(w) ? 1 : 0;
                }
            }

            return -1;
        }

        #endregion

        #region return float

        /// <summary>
        /// returns a potential carryOver for a person
        /// </summary>
        /// <param name="person">person to look for a carryover</param>
        /// <param name="carryOver">dict woth the potential carryover inside</param>
        /// <returns></returns>
        public float getPersonCarryOver(Person person, Dictionary<Person, float> carryOver)
        {
            if (carryOver.ContainsKey(person))
            {
                return carryOver[person];
            }
            return 0.0f;
        }

        /// <summary>
        /// gets the worktime for a given workshift
        /// </summary>
        /// <param name="workshift">the workshift for which the worktime is needed</param>
        /// <returns>the worktime for a given workshift</returns>
        public float getWorktimeInWorkshift(Workshift workshift)
        {
            return getWorktime(workshift.startHour, workshift.startMinute, workshift.endHour, workshift.endMinute);
        }

        /// <summary>
        /// gets the sum of worktime for all workshifts worked by a person in a given list of workdays
        /// </summary>
        /// <param name="person">person to calculate the worktime for</param>
        /// <param name="workdays">list of workdays</param>
        /// <param name="shiftplan">shiftplan to look up if person is working workshift</param>
        /// <returns>the sum of all workshifts worked by a person in a given list of workdays</returns>
        public float getWorktimeForPersonInWorkdays(Person person, List<Workday> workdays, Dictionary<Workshift, Person> shiftplan)
        {
            float result = 0;

            foreach (Workday workday in workdays)
            {
                result += getWorktimeForPersonInWorkday(person, workday, shiftplan);
            }
            return result;
        }

        /// <summary>
        /// gets the sum of worktime for all workshifts worked by a person in a given workday
        /// </summary>
        /// <param name="person">person to calculate the worktime for</param>
        /// <param name="workday">workday to calculate worktime for</param>
        /// <param name="shiftplan">shiftplan to look up if person is working workshift</param>
        /// <returns>the sum of all workshifts worked by a person in a given list of workdays</returns>
        public float getWorktimeForPersonInWorkday(Person person, Workday workday, Dictionary<Workshift, Person> shiftplan)
        {
            float result = 0.0f;

            foreach (Workshift workshift in workday.shifts)
            {
                if (shiftplan.ContainsKey(workshift))
                {
                    if (shiftplan[workshift] == person)
                    {
                        result += getWorktimeInWorkshift(workshift);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// calculates the worktime for a given time
        /// </summary>
        /// <param name="startHour">start hour</param>
        /// <param name="startMinute">start minute</param>
        /// <param name="endHour">end hour</param>
        /// <param name="endMinute">end minute</param>
        /// <returns>the worktime for a given time</returns>
        public float getWorktime(int startHour, int startMinute, int endHour, int endMinute)
        {
            //if endHour < startHour, the endTime is past midnight.
            if (endHour < startHour)
            {
                endHour += 24;
            }
            float worktime = endHour - startHour;
            float worktimeMinute = endMinute - startMinute;
            if (worktimeMinute < 0)
            {
                worktime -= 1;
                worktimeMinute *= -1;
            }
            return worktime + Util.mapFloat(0, 60, 0, 1, worktimeMinute);
        }

        /// <summary>
        /// calculates the sum of worktime for all workshifts in a given list of workdays
        /// </summary>
        /// <param name="workdays">list of workdays</param>
        /// <returns>the sum of worktime for all workshifts in a given list of workdays</returns>
        public float getWorktimeInWorkdays(List<Workday> workdays)
        {
            float counter = 0;

            foreach (Workday workday in workdays)
            {
                counter += getWorktimeInWorkday(workday);
            }
            return counter;
        }

        /// <summary>
        /// calculates the worktime for all workshifts of a given workday
        /// </summary>
        /// <param name="workday">workday to calculate the worktime for</param>
        /// <returns>the worktime for all workshifts of a given day</returns>
        public float getWorktimeInWorkday(Workday workday)
        {
            float counter = 0;

            foreach (Workshift workshift in workday.shifts)
            {
                counter += getWorktimeInWorkshift(workshift);
            }

            return counter;
        }

        #endregion

        #region return bool

        /// <summary>
        /// checks if two given workdays are in the same week
        /// </summary>
        /// <param name="workday1">first workday</param>
        /// <param name="workday2">second workday</param>
        /// <returns>if two given workdays are in the same week</returns>
        public bool isSameWeek(Workday workday1, Workday workday2)
        {
            if((workday2.weekdayIndex - workday1.weekdayIndex) == (workday2.day - workday1.day))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// checks if a given person is available for a given workshift
        /// checks the shifttype and the unavailability
        /// </summary>
        /// <param name="person">person to check for</param>
        /// <param name="workshift">workshift to check</param>
        /// <returns>if a given person is available for a given workshift</returns>
        public bool isPersonAvailableInWorkshift(Person person, Workshift workshift)
        {
            if (Util.stringArrayContains(person.shiftTypes, workshift.shiftType))
            {
                if (!person.unavailability.Contains(workshift))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// checks if a given person is available for a given workshift
        /// checks the shifttype
        /// </summary>
        /// <param name="person">person to check for</param>
        /// <param name="workshift">workshift to check</param>
        /// <returns>if a given person is available for a given workshift</returns>
        public bool isPossibleWorkshiftForPerson(Person person, Workshift workshift)
        {
            if (person != null && workshift != null)
            {
                if (Util.stringArrayContains(person.shiftTypes, workshift.shiftType))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// checks if a given person is working at a given workday
        /// </summary>
        /// <param name="person">person to check for</param>
        /// <param name="workday">workday to check</param>
        /// <param name="shiftplan">shiftplan to look up if person is working workshift</param>
        /// <returns>if a given person is working at a given workday</returns>
        public bool isPersonWorkingAtDay(Person person, Workday workday, Dictionary<Workshift, Person> shiftplan)
        {
            foreach (Workshift workshift in workday.shifts)
            {
                if (shiftplan.ContainsKey(workshift))
                {
                    if (shiftplan[workshift] == person)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// checks if given person is the only one available for a given workshift out of a list of persons
        /// </summary>
        /// <param name="person">person to check for</param>
        /// <param name="persons">list of persons</param>
        /// <param name="workshift">workshift to check</param>
        /// <returns>if given person is the only one available for a given workshift out of a list of persons</returns>
        public bool isPersonOnlyOneAvailableForWorkshift(Person person, List<Person> persons, Workshift workshift, List<Workday> workdays)
        {
            if (person.unavailability.Contains(workshift))
            {
                return false;
            }
            foreach(Person p in persons)
            {
                List<Workshift> personPossibleWorkshifts = getPossibleWorkshiftsForPersonInWorkdays(p, workdays);
                if(p != person && personPossibleWorkshifts.Contains(workshift) && !p.unavailability.Contains(workshift))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// checks if in the given workday, a given person is available to work a emtpy shift at
        /// </summary>
        /// <param name="person">person to check for</param>
        /// <param name="workday">workday to check in</param>
        /// <param name="shiftplan">shiftplan to check occupied workshifts</param>
        /// <returns>if a person can work any workshift at a given workday</returns>
        public bool isAvailableEmptyWorkshiftForPersonInWorkday(Person person, Workday workday, Dictionary<Workshift, Person> shiftplan)
        {
            foreach(Workshift workshift in workday.shifts)
            {
                if(isPersonAvailableInWorkshift(person, workshift) && !shiftplan.ContainsKey(workshift))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// checks if a person is working at a workday around a given workday
        /// The list of workdays to check in is expected to be sorted by date
        /// </summary>
        /// <param name="person">person to check for</param>
        /// <param name="workday">workday to check</param>
        /// <param name="workdays">list of workdays</param>
        /// <returns>if a person is working at a workday around a given workday</returns>
        public bool isPersonWorkingAtDayBeforeOrAfter(Person person, Workday workday, List<Workday> workdays, Dictionary<Workshift, Person> shiftplan)
        {
            if(workdays.Count > 1)
            {
                if (workdays[0].day == workday.day)
                {
                    return isPersonWorkingAtDay(person, workdays[1], shiftplan);
                }
                else if (workdays[workdays.Count - 1].day == workday.day)
                {
                    return isPersonWorkingAtDay(person, workdays[workdays.Count - 2], shiftplan);
                }
                else
                {
                    int workdayIndex = -1;
                    for(int i = 0; i < workdays.Count; i++)
                    {
                        if (workdays[i].day == workday.day)
                        {
                            workdayIndex = i;
                        }
                    }
                    if(workdayIndex > -1)
                    {
                        bool isPersonWorkingAtDayBefore = isPersonWorkingAtDay(person, workdays[workdayIndex - 1], shiftplan);
                        bool isPersonWorkingAtDayAfter = isPersonWorkingAtDay(person, workdays[workdayIndex + 1], shiftplan);
                        return isPersonWorkingAtDayBefore || isPersonWorkingAtDayAfter;
                    }
                }
            }
            return false;
        }
        #endregion


        #endregion
    }
}
