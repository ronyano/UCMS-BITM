using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UniversityCourseAndResultManagement.BLL;

namespace UniversityCourseAndResultManagement.Models.EntityModels
{
    public class Pdf
    {
        public Pdf(Student student, Result result)
        {
            PdfPTable tableLayout = new PdfPTable(4);

            //Creating a Page of specified size, we must have to create a iTextSharp.text.Rectangle object
            //and Passing the size as argument to its constructor

            //1. First Way to define Page Size
            //Creating Page Size by Pixels or Inch
            //NOTE: In iTextSharp library, unit is 'point'. 72 points = 1 inch
            //Creating a PDF File of width = 2 inch & height = 10 inch
            //So, I've to provide 144pt for 2 inch & 72pt for 10 inch
            Rectangle rec = new Rectangle(144, 720);

            //2. Second Way to define Page Size
            //Taking Page Size from in-built iTextSharp.text.PageSize class
            Rectangle rec2 = new Rectangle(PageSize.A4);

            //3. Third Way to define Page Size: Rotating Document i.e. height becomes width & vice-versa
            Rectangle rec3 = new Rectangle(PageSize.A4.Rotate());


            // Setting Background Color of PDF Document

            // First Way to Set Background Color
            // It takes the object of iTextSharp.text.BaseColor
            // BaseColor constructor takes in-built System.Drawing.Color object
            // Or you can pass RGB values to the constructor in different forms.
            rec.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);

            // Second Way to Set Background Color
            // It takes the object of  iTextSharp.text.pdf.CMYKColor
            // CMYKColor constructor takes only CMYK values in different forms
            rec2.BackgroundColor = new CMYKColor(25, 90, 25, 0);

            //string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            string appRootDir = System.Web.HttpContext.Current.Server.MapPath("~/Report/");
            string strPDFFileName = string.Format("SamplePdf" + DateTime.Now.ToString("yyyyMMdd") + ".pdf");
            try
            {
                // Creating System.IO.FileStream object
                using (
                    FileStream fs = new FileStream(appRootDir + "strPDFFileName.pdf", FileMode.Create,
                        FileAccess.Write, FileShare.None))
                    // Creating iTextSharp.text.Document object
                using (Document doc = new Document(rec2))

                    // Creating iTextSharp.text.pdf.PdfWriter object
                    // It helps to write the Document to the Specified FileStream

                using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                {
                    // Setting Encryption properties
                    writer.SetEncryption(PdfWriter.STRENGTH40BITS, null, null, PdfWriter.ALLOW_COPY);

                    // Openning the Document
                    doc.Open();

                    // Adding a paragraph
                    // NOTE: When we want to insert text, then we've to do it through creating paragraph
                    doc.Add(Add_Content_To_PDF(tableLayout,student,result));

                    // Closing the Document
                    doc.Close();
                }
            }
                // Catching iTextSharp.text.DocumentException if any
            catch (DocumentException de)
            {
                throw de;
            }
                // Catching System.IO.IOException if any
            catch (IOException ioe)
            {
                throw ioe;
            }


        }

        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout, Student student, Result result)
        {
            ResultManager resultManager = new ResultManager();

            float[] headers = { 50, 24, 45, 35, 50 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top  

            List<Result> employees = resultManager.GetAllResults();



            tableLayout.AddCell(new PdfPCell(new Phrase("Result of "+student.StudentName+" is this: ", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });


            ////Add header  
            AddCellToHeader(tableLayout, "Course Name");
            AddCellToHeader(tableLayout, "Course Code");
            AddCellToHeader(tableLayout, "Grade");
            AddCellToHeader(tableLayout, "Student Name");


            ////Add body  
            /// 
            CourseManager courseManager = new CourseManager();
            var course = courseManager.GetAllCourses().Where(a => a.Id == result.CourseId);


            /*
            foreach (var emp in employees)
            {
                AddCellToBody(tableLayout, emp.Id.ToString());
                AddCellToBody(tableLayout, emp.Id.ToString());
                AddCellToBody(tableLayout, emp.Id.ToString());
                AddCellToBody(tableLayout, emp.Id.ToString());
            }*/

            /*  AddCellToBody(tableLayout, student.StudentName.ToString());
                AddCellToBody(tableLayout, student.Address.ToString());
                AddCellToBody(tableLayout, student.RegNo);
                AddCellToBody(tableLayout, student.Id.ToString());
                AddCellToBody(tableLayout, student.Address);
                AddCellToBody(tableLayout, student.ContactNo);
                AddCellToBody(tableLayout, student.Email);
                AddCellToBody(tableLayout, student.Email);
             * */
            foreach (var sc in course)
            {
                AddCellToBody(tableLayout, sc.CourseName.ToString());
                AddCellToBody(tableLayout, sc.CourseCode);
                AddCellToBody(tableLayout, result.Grade);
                AddCellToBody(tableLayout, student.StudentName.ToString());

            }





            //}

            return tableLayout;
        }
        // Method to add single cell to the Header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
            });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
            });
        }  
		
    }
}