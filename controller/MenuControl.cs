using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.IO;
using Google.Apis.Services;
using Schichtplan.model;
using Google.Apis.Auth.OAuth2;

namespace Schichtplan.controller
{
    public class MenuControl : ViewControl
    {
        public MenuControl(ModelControl modelControl) : base(modelControl)
        {
        }

        /// <summary>
        /// saves the currentMonth into a saveFile in the SAVE_FOLDER
        /// </summary>
        public void save()
        {
            Workmonth workmonth = modelControl.currentWorkmonth;
            workmonth.hourCarryOverThisMonth = modelControl.getCarryOverHoursForWorkdaysForPersonsInShiftplan(workmonth.persons, workmonth.workdays, workmonth.shiftplan, workmonth.hourCarryOverLastMonth);
            Serializer.Instance().saveObject(Serializer.Instance().BASE_DICT + "" + Serializer.SAVE_DIRECTORY + "" + modelControl.getYearMonthString() + ".save", workmonth);
        }

        /// <summary>
        /// loads a month from the file given in the fileName parameter and sets this month as the currentMonth
        /// </summary>
        /// <param name="fileName">file from which to load the month</param>
        public void open(string fileName)
        {
            modelControl.currentWorkmonth = (Workmonth)Serializer.Instance().loadObject(fileName);
        }

        /// <summary>
        /// creates csv files for all shifts for each person in the currentMonth and a csv file for all shifts in general
        /// </summary>
        public void exportCSVFiles()
        {
            Workmonth workmonth = modelControl.currentWorkmonth;

            Serializer.Instance().createDir(Serializer.Instance().BASE_DICT + "" + Serializer.CSV_DIRECTORY + "" + modelControl.getYearMonthString() + "/");

            // Files for the persons
            foreach (Person person in workmonth.persons)
            {
                string fileContentPerson = "";

                //string füllen
                foreach (Workday workday in workmonth.workdays)
                {
                    if (modelControl.isPersonWorkingAtDay(person, workday, workmonth.shiftplan))
                    {
                        fileContentPerson += workday.weekday + ", " + workday.day + " " + workmonth.monthName + ";;\n\n";

                        foreach (Workshift workshift in workday.shifts)
                        {
                            string personName = "KEINE PERSON GEFUNDEN";
                            if (workmonth.shiftplan.ContainsKey(workshift))
                            {
                                personName = workmonth.shiftplan[workshift].name;
                            }
                            fileContentPerson += personName + ";" + workshift.ToString() + ";" + workshift.description + "\n";
                        }

                        fileContentPerson += "\n\n";
                    }
                }

                Serializer.Instance().writeToFile(Serializer.Instance().BASE_DICT + "" + Serializer.CSV_DIRECTORY + modelControl.getYearMonthString() + "/" + person.name + ".csv", fileContentPerson);
            }

            //File for all Shifts

            string fileContentShifts = "";
            foreach (Workday workday in workmonth.workdays)
            {
                if (workday.shifts.Count > 0)
                {
                    fileContentShifts += workday.weekday + ", " + workday.day + " " + workmonth.monthName + ";;\n\n";

                    foreach (Workshift workshift in workday.shifts)
                    {
                        string personName = "KEINE PERSON GEFUNDEN";
                        if (workmonth.shiftplan.ContainsKey(workshift))
                        {
                            personName = workmonth.shiftplan[workshift].name;
                        }
                        fileContentShifts += personName + ";" + workshift.ToString() + ";" + workshift.description + "\n";
                    }

                    fileContentShifts += "\n\n";
                }
            }

            Serializer.Instance().writeToFile(Serializer.Instance().BASE_DICT + "" + Serializer.CSV_DIRECTORY + modelControl.getYearMonthString() + "/Schichten.csv", fileContentShifts);

            //File with general info
            //Info for every Person
            string fileContentGeneral = "Name;" +
                "Gehalt pro Stunde;" +
                "Stunden gearbeitet diesen Monat;" +
                "Monatsgehalt (davon vom letzten Monat);" +
                "Tage nicht gearbeitet;" +
                "Anzahl Schichten" +
                "\n";
            int workingDays = modelControl.getWorkingDaysCounter(workmonth.workdays);

            foreach (Person person in modelControl.getPersonsSortedBy("name", workmonth.persons))
            {
                float worktime = modelControl.getWorktimeForPersonInWorkdays(person, workmonth.workdays, workmonth.shiftplan);
                int daysNotWorking = modelControl.getDaysNotWorkingForPersonInWorkdaysCount(person, workmonth.workdays, workmonth.shiftplan);
                float carryOver = modelControl.getPersonCarryOver(person, workmonth.hourCarryOverLastMonth);

                Dictionary<string, int> workshiftAmounts = modelControl.getWorkedShiftsForPersonInWorkdaysByShiftTypeCount(person, workmonth.workdays, workmonth.shiftplan);
                string workshiftAmountsString = "";
                foreach (KeyValuePair<string, int> kvp in workshiftAmounts)
                {
                    workshiftAmountsString += kvp.Key + ": " + kvp.Value + ", ";
                }
                if (workshiftAmountsString.Length > 1)
                {
                    workshiftAmountsString = workshiftAmountsString.Substring(0, workshiftAmountsString.Length - 2);
                }

                fileContentGeneral += person.name
                    + ";" + person.saleryPerHour
                    + ";" + worktime + "h (" + person.minWorkHours + "h, " + person.maxWorkHours + "h)"
                    + ";" + Util.clampToDecimalpoints(((carryOver + worktime) * person.saleryPerHour) + 0.5f, 2) + " (" + (carryOver * person.saleryPerHour) + ")"
                    + ";" + daysNotWorking + "/" + workingDays
                    + ";" + workshiftAmountsString
                    + "\n";
            }

            fileContentGeneral += "\n\n";

            //Other info
            float carryOverSalerySum = 0.0f;
            float salarySum = 0.0f;
            foreach (Person person in workmonth.persons)
            {
                carryOverSalerySum += modelControl.getPersonCarryOver(person, workmonth.hourCarryOverLastMonth) * person.saleryPerHour;
                salarySum += modelControl.getWorktimeForPersonInWorkdays(person, workmonth.workdays, workmonth.shiftplan) * person.saleryPerHour;
                salarySum += carryOverSalerySum;
            }
            fileContentGeneral += "Gehaelter Sum:;" + Util.clampToDecimalpoints(salarySum, 2) + " (" + carryOverSalerySum + ")\n";

            Dictionary<string, int> workshiftsByShiftType = modelControl.getShiftCountInWorkdaysByShiftType(workmonth.workdays);
            int workshiftSum = 0;
            string workshiftsByShiftTypeString = "";
            foreach (KeyValuePair<string, int> kvp in workshiftsByShiftType)
            {
                workshiftsByShiftTypeString += kvp.Key + ": " + kvp.Value + ", ";
                workshiftSum += kvp.Value;
            }
            fileContentGeneral += "Summe Schichten:;";
            fileContentGeneral += workshiftsByShiftTypeString.Length > 1 ?
                workshiftSum + " (" + workshiftsByShiftTypeString.Substring(0, workshiftsByShiftTypeString.Length - 2) + ")\n"
                : "";

            fileContentGeneral += "Summe Stunden:;" + modelControl.getWorktimeInWorkdays(workmonth.workdays) + "h";

            Serializer.Instance().writeToFile(Serializer.Instance().BASE_DICT + "" + Serializer.CSV_DIRECTORY + modelControl.getYearMonthString() + "/Generelle_Infos.csv", fileContentGeneral);
        }

        /// <summary>
        /// creates html files for all shifts for each person in the currentMonth and a html file for all shifts in general
        /// </summary>
        public void exportHTMLFiles()
        {
            Workmonth workmonth = modelControl.currentWorkmonth;

            List<List<Workday>> weeks = modelControl.getWeeksInWorkdays(workmonth.workdays);

            Serializer.Instance().createDir(Serializer.Instance().BASE_DICT + "" + Serializer.HTML_DIRECTORY + "" + modelControl.getYearMonthString() + "/");

            // Files for the persons
            foreach (Person person in workmonth.persons)
            {
                string fileContentPerson = "<html>\n";
                //string füllen
                for (int weekCounter = 0; weekCounter < weeks.Count; weekCounter++)
                {
                    List<Workday> week = weeks[weekCounter];

                    fileContentPerson += "<h1 style=\"" +
                        "background-color:black;" +
                        "color:" + window.getHTMLColor(window.weekFontColor) + ";" +
                        "width:100%;" +
                        "padding: 10px;" +
                        "text-align: center;" +
                        "\">Woche " + weekCounter + ", " + modelControl.getFirstAndLastDayInWorkdaysAsString(week) + "</h1>";

                    foreach (Workday workday in week)
                    {
                        if (modelControl.isPersonWorkingAtDay(person, workday, workmonth.shiftplan))
                        {
                            fileContentPerson += "<table style=\"" +
                                "border:1px solid;" +
                                "text-align:left;" +
                                "border-collapse:collapse;" +
                                "width:100%" +
                                "\">\n";

                            fileContentPerson += "<tr style=\"background-color:" + window.getHTMLColor(window.dayColor) + ";\">" +
                                "<th style=\"width:33%\">" + workday.weekday + ", " + workday.day + " " + workmonth.monthName + "</th>" +
                                "<th style=\"width:33%\"></th>" +
                                "<th style=\"width:33%\"></th>" +
                                "</tr>\n";

                            foreach (Workshift workshift in workday.shifts)
                            {
                                string personName = "KEINE PERSON GEFUNDEN";
                                string backColor = window.getHTMLColor(window.transparent);
                                if (workmonth.settings.shiftTypeColors.ContainsKey(workshift.shiftType))
                                {
                                    backColor = window.getHTMLColor(workmonth.settings.shiftTypeColors[workshift.shiftType]);
                                }
                                if (workmonth.shiftplan.ContainsKey(workshift))
                                {
                                    personName = workmonth.shiftplan[workshift].name;
                                    if (person == workmonth.shiftplan[workshift])
                                    {
                                        backColor = window.getHTMLColor(window.saturdayColor);
                                    }
                                }

                                fileContentPerson += "<tr style=\"background-color:" + backColor + ";\">" +
                                    "<td style=\"width:33%\">" + personName + "</td>" +
                                    "<td style=\"width:33%\">" + workshift.ToString() + "</td>" +
                                    "<td style=\"width:33%\">" + workshift.description + "</td>" +
                                    "</tr>\n";
                            }

                            fileContentPerson += "</table>\n</br>";
                        }
                    }
                }
                fileContentPerson += "</html>";

                Serializer.Instance().writeToFile(Serializer.Instance().BASE_DICT + "" + Serializer.HTML_DIRECTORY + modelControl.getYearMonthString() + "/" + person.name + ".html", fileContentPerson);
            }

            string fileContentShift = "<html>\n";

            //File for all Shifts
            for (int weekCounter = 0; weekCounter < weeks.Count; weekCounter++)
            {
                List<Workday> week = weeks[weekCounter];

                fileContentShift += "<h1 style=\"" +
                    "background-color:black;" +
                    "color:" + window.getHTMLColor(window.weekFontColor) + ";" +
                    "width:100%;" +
                    "padding: 10px;" +
                    "text-align: center;" +
                    "\">Woche " + weekCounter + ", " + modelControl.getFirstAndLastDayInWorkdaysAsString(week) + "</h1>";

                foreach (Workday workday in week)
                {
                    if (workday.shifts.Count > 0)
                    {
                        fileContentShift += "<table style=\"" +
                                "border:1px solid;" +
                                "text-align:left;" +
                                "border-collapse:collapse;" +
                                "width:100%" +
                                "\">\n";

                        fileContentShift += "<tr style=\"background-color:" + window.getHTMLColor(window.dayColor) + ";\">" +
                            "<th style=\"width:33%\">" + workday.weekday + ", " + workday.day + " " + workmonth.monthName + "</th>" +
                            "<th style=\"width:33%\"></th>" +
                            "<th style=\"width:33%\"></th>" +
                            "</tr>\n";

                        foreach (Workshift workshift in workday.shifts)
                        {
                            string backColorShift = window.getHTMLColor(window.transparent);
                            if (workmonth.settings.shiftTypeColors.ContainsKey(workshift.shiftType))
                            {
                                backColorShift = window.getHTMLColor(workmonth.settings.shiftTypeColors[workshift.shiftType]);
                            }
                            string backColorPerson = window.getHTMLColor(window.transparent);

                            string personName = "KEINE PERSON GEFUNDEN";
                            if (workmonth.shiftplan.ContainsKey(workshift))
                            {
                                Person person = workmonth.shiftplan[workshift];
                                personName = person.name;

                                if (workmonth.settings.personColors.ContainsKey(person))
                                {
                                    backColorPerson = window.getHTMLColor(workmonth.settings.personColors[person]);
                                }
                            }
                            fileContentShift += "<tr>" +
                                "<td style=\"width:33%;background-color:" + backColorPerson + ";\">" + personName + "</td>" +
                                "<td style=\"width:33%;background-color:" + backColorShift + ";\">" + workshift.ToString() + "</td>" +
                                "<td style=\"width:33%;background-color:" + window.getHTMLColor(window.transparent) + ";\">" + workshift.description + "</td>" +
                                "</tr>\n";
                        }

                        fileContentShift += "</table>\n</br>";
                    }
                }
            }

            fileContentShift += "</html>";

            Serializer.Instance().writeToFile(Serializer.Instance().BASE_DICT + "" + Serializer.HTML_DIRECTORY + modelControl.getYearMonthString() + "/Schichten.html", fileContentShift);
        }

        /// <summary>
        /// creates ics files for all shifts for each person in the currentMonth and a ics file for all shifts in general
        /// </summary>
        public void exportCalenderFiles()
        {
            Workmonth workmonth = modelControl.currentWorkmonth;

            Serializer.Instance().createDir(Serializer.Instance().BASE_DICT + "" + Serializer.ICS_DIRECTORY + "" + modelControl.getYearMonthString() + "/");

            // Files for the persons
            foreach (Person person in workmonth.persons)
            {
                string fileContentPerson = "";

                fileContentPerson += "BEGIN:VCALENDAR\nVERSION: 2.0\nCALSCALE: GREGORIAN\n";

                //string füllen
                foreach (Workday workday in workmonth.workdays)
                {
                    foreach (Workshift workshift in workday.shifts)
                    {
                        if (workmonth.shiftplan.ContainsKey(workshift))
                        {
                            if (workmonth.shiftplan[workshift] == person)
                            {
                                fileContentPerson += "BEGIN:VEVENT\n";
                                fileContentPerson += "SUMMARY:Los Amigos arbeiten\n";
                                fileContentPerson += "DESCRIPTION:Du bist für " + workshift.shiftType + " eingeteilt.\n";
                                fileContentPerson += "DTSTART:" + modelControl.getWorkshiftStartTimeToIcsFormat(workday, workshift) + "\n";
                                fileContentPerson += "DTEND:" + modelControl.getWorkshiftEndTimeToIcsFormat(workday, workshift) + "\n";
                                fileContentPerson += "LOCATION:Wolbecker Straße 128, 48155 Münster\n";
                                fileContentPerson += "STATUS:CONFIRMED\n";
                                fileContentPerson += "SEQUENCE:0\n";
                                fileContentPerson += "END:VEVENT\n";
                            }
                        }
                    }
                }

                fileContentPerson += "END:VCALENDAR";

                Serializer.Instance().writeToFile(Serializer.Instance().BASE_DICT + "" + Serializer.ICS_DIRECTORY + modelControl.getYearMonthString() + "/" + person.name + ".ics", fileContentPerson);
            }

            // Files for all shifts of the day

            string fileContentShifts = "";

            fileContentShifts += "BEGIN:VCALENDAR\nVERSION: 2.0\nCALSCALE: GREGORIAN\n";

            foreach (Workday workday in workmonth.workdays)
            {
                if (workday.shifts.Count > 0)
                {
                    string description = "";
                    foreach (Workshift workshift in workday.shifts)
                    {
                        if (workmonth.shiftplan.ContainsKey(workshift))
                        {
                            description += workmonth.shiftplan[workshift].name + ": " + workshift.ToString() + "\\n";
                        }
                        else
                        {
                            description += "KEINE PERSON GEFUNDEN: " + workshift.ToString() + "\\n";
                        }
                    }
                    string month = "" + workmonth.month;
                    month = month.Length == 1 ? "0" + month : month;
                    string day = "" + workday.day;
                    day = day.Length == 1 ? "0" + day : day;

                    fileContentShifts += "BEGIN:VEVENT\n";
                    fileContentShifts += "SUMMARY:Los Amigos heute: " + workday.shifts.Count + " Schichten.\n";
                    fileContentShifts += "DESCRIPTION:" + description + "\n";
                    fileContentShifts += "DTSTART:" + workmonth.year + "" + month + "" + day + "T070000\n";
                    fileContentShifts += "DTEND:" + workmonth.year + "" + month + "" + day + "T071500\n";
                    fileContentShifts += "LOCATION:Wolbecker Straße 128, 48155 Münster\n";
                    fileContentShifts += "STATUS:CONFIRMED\n";
                    fileContentShifts += "SEQUENCE:0\n";
                    fileContentShifts += "END:VEVENT\n";
                }
            }

            fileContentShifts += "END:VCALENDAR";

            Serializer.Instance().writeToFile(Serializer.Instance().BASE_DICT + "" + Serializer.ICS_DIRECTORY + modelControl.getYearMonthString() + "/Schichten.ics", fileContentShifts);
        }

        /// <summary>
        /// uploads the shiftplan to google table
        /// </summary>
        public async Task uploadToGoogleTableAsync(string spreadsheetId, string key_path)
        {
            //variable for workmonth
            Workmonth workmonth = modelControl.currentWorkmonth;

            //worksheetName and resulting targetRange
            string worksheetName = modelControl.getYearMonthString();
            string targetRange = worksheetName + "!A1:C";
            int sheetId = 0;

            // create the sheets service object
            SheetsService sheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GoogleCredential.FromFile(key_path),
                ApplicationName = "Schichtplan"
            });

            // create new worksheet
            // get existing worksheets
            SpreadsheetsResource.GetRequest getSpreadsheetRequest = sheetsService.Spreadsheets.Get(spreadsheetId);
            Spreadsheet spreadsheet = await getSpreadsheetRequest.ExecuteAsync();

            bool alreadyCreated = false;
            foreach(Sheet worksheet in spreadsheet.Sheets)
            {
                if(worksheet.Properties.Title == worksheetName)
                {
                    alreadyCreated = true;
                    //set sheetId
                    sheetId = (int)worksheet.Properties.SheetId;
                }
            }

            //create new worksheet if not already created
            if (!alreadyCreated)
            {
                BatchUpdateSpreadsheetRequest batchUpdateRequestNewWorksheet = new BatchUpdateSpreadsheetRequest();
                List<Request> requestsNewWorksheet = new List<Request>();

                AddSheetRequest addSheetRequest = new AddSheetRequest();
                addSheetRequest.Properties = new SheetProperties { Title = worksheetName };
                requestsNewWorksheet.Add(new Request { AddSheet = addSheetRequest });

                batchUpdateRequestNewWorksheet.Requests = requestsNewWorksheet.ToArray();

                SpreadsheetsResource.BatchUpdateRequest batchUpdateNewWorksheet = sheetsService.Spreadsheets.BatchUpdate(batchUpdateRequestNewWorksheet, spreadsheetId);
                try
                {
                    await batchUpdateNewWorksheet.ExecuteAsync();

                    //get the spreadsheet again to optain the sheetId for the new worksheet
                    SpreadsheetsResource.GetRequest getSpreadsheetRequestRepeat = sheetsService.Spreadsheets.Get(spreadsheetId);
                    Spreadsheet spreadsheetRepeat = await getSpreadsheetRequestRepeat.ExecuteAsync();

                    foreach (Sheet worksheet in spreadsheetRepeat.Sheets)
                    {
                        if (worksheet.Properties.Title == worksheetName)
                        {
                            //set sheet id from new worksheet
                            sheetId = (int)worksheet.Properties.SheetId;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating new worksheet: " + ex.Message);
                    return;
                }
            }

            //create request to clear and then fill the google sheet with the shiftplan
            //collect shiftplan data and put it in the google sheets list format
            // batchudaterequest for data
            BatchUpdateSpreadsheetRequest batchUpdateRequestData = new BatchUpdateSpreadsheetRequest();
            List<Request> requestsData = new List<Request>();

            //get shiftplan for export
            List<ExportShiftPlanCell[]> exportShiftPlan = modelControl.getExportShiftPlan();

            List<RowData> values = new List<RowData>();

            for (int rowIndex = 0; rowIndex < exportShiftPlan.Count; rowIndex++)
            {
                List<CellData> cellDatas = new List<CellData>();
                foreach(ExportShiftPlanCell cell in exportShiftPlan[rowIndex])
                {
                    var cellData = new CellData();
                    cellData.UserEnteredValue = new ExtendedValue { StringValue = cell.text };

                    var format = new CellFormat();
                    format.BackgroundColorStyle = new ColorStyle
                    {
                        RgbColor = new Color
                        {
                            Red = cell.backColor.R / 255f,
                            Green = cell.backColor.G / 255f,
                            Blue = cell.backColor.B / 255f
                        }
                    };
                    format.TextFormat = new TextFormat
                    {
                        ForegroundColorStyle = new ColorStyle
                        {
                            RgbColor = new Color
                            {
                                Red = cell.foreColor.R / 255f,
                                Green = cell.foreColor.G / 255f,
                                Blue = cell.foreColor.B / 255f
                            }
                        },
                        FontSize = 12
                    };

                    cellData.UserEnteredFormat = format;

                    cellDatas.Add(cellData);
                }
                values.Add(new RowData() { Values = cellDatas });
            }

            //create data request
            var updateCellsRequest = new UpdateCellsRequest();
            updateCellsRequest.Start = new GridCoordinate
            {
                ColumnIndex = 0,
                RowIndex = 0,
                SheetId = sheetId
            };
            updateCellsRequest.Rows = values;
            updateCellsRequest.Fields = "*";

            //create column width request
            var updateDimensionRequest = new UpdateDimensionPropertiesRequest();
            updateDimensionRequest.Range = new DimensionRange { SheetId = sheetId, Dimension = "COLUMNS", StartIndex = 0, EndIndex = 3 };
            updateDimensionRequest.Fields = "*";
            updateDimensionRequest.Properties = new DimensionProperties { PixelSize = 200 }; // Set desired width in pixels
            
            //add requsts
            requestsData.Add(new Request { UpdateDimensionProperties = updateDimensionRequest });
            requestsData.Add(new Request { UpdateCells = updateCellsRequest });

            //clear current sheet
            ClearValuesRequest clearValuesRequest = new ClearValuesRequest();
            SpreadsheetsResource.ValuesResource.ClearRequest clearRequest = sheetsService.Spreadsheets.Values.Clear(clearValuesRequest, spreadsheetId, targetRange);

            //color request
            batchUpdateRequestData.Requests = requestsData.ToArray();
            SpreadsheetsResource.BatchUpdateRequest batchUpdateData = sheetsService.Spreadsheets.BatchUpdate(batchUpdateRequestData, spreadsheetId);

            //asynchronously execute the append request and handle potential errors
            try
            {
                ClearValuesResponse clearResponse = await clearRequest.ExecuteAsync();
                BatchUpdateSpreadsheetResponse changeDataResponse =  await batchUpdateData.ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error appending data: " + ex.Message);
            }
        }

    }
}
