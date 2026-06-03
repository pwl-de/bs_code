using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Add On:
using ClosedXML.Excel;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Drawing.Diagrams;



namespace excelmerge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string[] listen = Directory.GetFiles(path);



            //Erstelle Gesamte Excel Tabelle:
            //.........................................................................
            string totalList = path + "\\Fahrtenbuch_Gesamt_";
            //prüft ob ein Gesamtfahrtenbuch bereits existiert:
            foreach (string allFiles in Directory.GetFiles(path))
            {
                if (allFiles.StartsWith(totalList)) {
                    System.IO.File.Delete(allFiles);
                }
            }
            //sets name
            totalList += DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            //create data
            XLWorkbook totalBook = new XLWorkbook();
            IXLWorksheet totalSheet = totalBook.AddWorksheet(1);

            // add headers
            totalSheet.Cell(1, 1).Value = "Fahrtenbuch - Gesamt";
            totalSheet.Cell(2, 1).Value = "Fahrzeug";
            totalSheet.Cell(2, 2).Value = "Datum";
            totalSheet.Cell(2, 3).Value = "MitarbeiterNr";
            totalSheet.Cell(2, 4).Value = "Fahrt";
            totalSheet.Cell(2, 5).Value = "UhrzeitVon";
            totalSheet.Cell(2, 6).Value = "UhrzeitBis";
            totalSheet.Cell(2, 7).Value = "Dauer";
            totalSheet.Cell(2, 8).Value = "kmVon";
            totalSheet.Cell(2, 9).Value = "kmBis";
            totalSheet.Cell(2, 10).Value = "Strecke";

            int emptyIndex = 3;


            //List for Doublettencheck
            List<string> lineKeys = new List<string>();
            

            // Lese alle 
            foreach (XLWorkbook book in allBooks(path))
            {

                //opensheet and check size
                IXLWorksheet sheet = book.Worksheet(1);
                int rowCount = sheet.RangeUsed().RowCount();
                
                // MACHE EINE ZEILE AUF
                for (int i = 6; i <= rowCount; i++, emptyIndex++)
                {
                    //copy paste Kennzeichen
                    if (sheet.Cell(3, 3).IsEmpty())
                    {
                        //totalSheet.Cell(emptyIndex, 1).Value = hole name von dateiname !MARK
                    }
                    else
                    {
                        totalSheet.Cell(emptyIndex, 1).Value = sheet.Cell(3, 3).Value;
                    }
               
                    //Datum, MitarbeiterNr, Fahrt
                    for (int j = 1; j <= 3; j++)
                    {
                        if (sheet.Cell(i, j).IsEmpty())
                        {
                            //error LOG 
                            totalSheet.Cell(emptyIndex, j + 1).Value = "error";
                        } else
                        {
                            totalSheet.Cell(emptyIndex, j + 1).Value = sheet.Cell(i, j).Value;
                        }
                    }
                    
                    //UhrzeitVon, UhrzeitBis, Dauer
                    // ---------------------------------------------------
                    bool start = sheet.Cell(i, 4).IsEmpty();
                    bool ende = sheet.Cell(i, 5).IsEmpty();
                    bool diff = sheet.Cell(i, 6).IsEmpty();


                    //flip
                    if (!start && !ende && sheet.Cell(i, 4).GetTimeSpan() > sheet.Cell(i, 5).GetTimeSpan())
                    {
                        var temp = sheet.Cell(i, 4).GetTimeSpan();
                        sheet.Cell(i, 4).Value = sheet.Cell(i, 5).Value;
                        sheet.Cell(i, 5).Value = temp;
                        // LOG
                    }

                    // Uhrzeit Von
                    if (start)
                    {
                        if (ende == false && diff == false)
                        {
                            totalSheet.Cell(emptyIndex, 5).Value = sheet.Cell(i, 5).GetTimeSpan() - sheet.Cell(i, 6).GetTimeSpan();
                        } else
                        {
                            //error log
                            totalSheet.Cell(emptyIndex, 5).Value = "error";
                        }
                    } else
                    {
                        //simple copy
                        totalSheet.Cell(emptyIndex, 5).Value = sheet.Cell(i, 4).Value;
                    }

                    // Uhrzeit Bis
                    if (ende)
                    {
                        if (start == false && diff == false)
                        {
                            totalSheet.Cell(emptyIndex, 6).Value = sheet.Cell(i, 4).GetTimeSpan() + sheet.Cell(i, 6).GetTimeSpan();
                        }
                        else
                        {
                            //error log
                            totalSheet.Cell(emptyIndex, 6).Value = "error";
                        }
                    }
                    else
                    {
                        //simple copy
                        totalSheet.Cell(emptyIndex, 6).Value = sheet.Cell(i, 5).Value;
                    }

                    // Duration
                    if (diff)
                    {
                        if (ende == false && start == false)
                        {
                            totalSheet.Cell(emptyIndex, 7).Value = sheet.Cell(i, 5).GetTimeSpan() - sheet.Cell(i, 4).GetTimeSpan();
                        }
                        else
                        {
                            //error log
                            totalSheet.Cell(emptyIndex, 7).Value = "error";
                        }
                    }
                    else
                    {
                        //simple copy
                        totalSheet.Cell(emptyIndex, 7).Value = sheet.Cell(i, 6).Value;
                    }


                    // ------------------------------------------------------------------------------------
                    // KILOMETER!!!!!!

                    start = sheet.Cell(i, 7).IsEmpty();
                    ende = sheet.Cell(i, 8).IsEmpty();
                    diff = sheet.Cell(i, 9).IsEmpty();


                    //flip
                    if ((!start && !ende) && sheet.Cell(i, 7).GetDouble() > sheet.Cell(i, 8).GetDouble()) 
                    {
                        var temp = sheet.Cell(i, 7).GetDouble();
                        sheet.Cell(i, 7).Value = sheet.Cell(i, 8).Value;
                        sheet.Cell(i, 8).Value = temp;
                        // LOG
                    }

                    // Kilometer Von
                    if (start)
                    {
                        if (ende == false && diff == false)
                        {
                            totalSheet.Cell(emptyIndex, 8).Value = sheet.Cell(i, 8).GetDouble() - sheet.Cell(i, 9).GetDouble();
                        }
                        else
                        {
                            //error log
                            totalSheet.Cell(emptyIndex, 8).Value = "error";
                        }
                    }
                    else
                    {
                        //simple copy
                        totalSheet.Cell(emptyIndex, 8).Value = sheet.Cell(i, 7).Value;
                    }

                    // Kilometer Bis
                    if (ende)
                    {
                        if (start == false && diff == false)
                        {
                            totalSheet.Cell(emptyIndex, 9).Value = sheet.Cell(i, 7).GetDouble() + sheet.Cell(i, 9).GetDouble();
                        }
                        else
                        {
                            //error log
                            totalSheet.Cell(emptyIndex, 9).Value = "error";
                        }
                    }
                    else
                    {
                        //simple copy
                        totalSheet.Cell(emptyIndex, 9).Value = sheet.Cell(i, 8).Value;
                    }

                    // diff Kilometer
                    if (diff)
                    {
                        if (ende == false && start == false)
                        {
                            totalSheet.Cell(emptyIndex, 10).Value = sheet.Cell(i, 8).GetDouble() - sheet.Cell(i, 7).GetDouble();
                        }
                        else
                        {
                            //error log
                            totalSheet.Cell(emptyIndex, 10).Value = "error";
                        }
                    }
                    else
                    {
                        //simple copy
                        totalSheet.Cell(emptyIndex, 10).Value = sheet.Cell(i, 9).Value;
                    }
                    


                    // add uniqueLineKey
                    string uniqueLineKey = "";
                    for (int k = 1; k <= 10; k++)
                    {
                        uniqueLineKey += totalSheet.Cell(emptyIndex, k).GetValue<string>() + "|";
                    }
                    //check if Line is already in List
                    if (lineKeys.Contains(uniqueLineKey))
                    {
                        totalSheet.Row(emptyIndex).Delete();
                        emptyIndex--; //Sorgt dafür, dass wir keine Zeile weiterspringen. -> Wir überschreiben die aktuelle Zeile
                        Console.Write("\n duplicate found" + uniqueLineKey + "\n");
                        // LOG!
                    }
                    else
                    {
                        lineKeys.Add(uniqueLineKey);
                        Console.Write("\n added folling line: " + uniqueLineKey + "\n");
                    }



                }




            }

            //save totalbook
            totalBook.SaveAs(totalList);

        }
        

        // Creates List with all .xlsx Doc.
        static List<XLWorkbook> allBooks(string workingDir)
        {
           string[] allFiles = Directory.GetFiles(workingDir);
           List<XLWorkbook> excelList = new List<XLWorkbook>();
          
          foreach (string file in allFiles)
            {
                if (file.EndsWith(".xlsx"))
                {
                    excelList.Add(new XLWorkbook(file));
                    Console.Write(file + " was added to the list... \n");
                }
            }
        return excelList;
        }
    }
}