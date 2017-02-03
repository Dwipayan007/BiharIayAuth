using BiharIayAuth.API.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BiharIayAuth.API
{
    public class ReportPdfGen
    {
        public static String BlockLevelPdfGen(_IayForm _data)
        {
            String retval = "Error";
            String msgstrng = "";
            try
            {

                //-----------------------------------------------------------------------------------------//
                string pdfname = "Block_Level_Report_" + DateTime.Now.Millisecond.ToString() + ".pdf";
                retval = pdfname;
                FileStream fs = new FileStream(WebConfigurationManager.AppSettings["pdfstore"] + pdfname, FileMode.Create);
                Document document = new Document(PageSize.A4, 10, 10, 15, 15);
                document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                PdfWriter writer = PdfWriter.GetInstance(document, fs);

                HeaderFooter PageEventHandler = new HeaderFooter();
                PageEventHandler.msg = "IAY-14";
                writer.PageEvent = PageEventHandler;
                // Define the page header
                PageEventHandler.HeaderFont = FontFactory.GetFont("Calibri (Body)", 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);
                PageEventHandler.HeaderRight = "";
                document.Open();


                # region ****************PDFCONTENT***********************

                //----------------------------------------NEW CODE-------------------------------------------
                iTextSharp.text.Font font8B = FontFactory.GetFont("Calibri (Body)", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);
                iTextSharp.text.Font font8N = FontFactory.GetFont("Calibri (Body)", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);
                iTextSharp.text.Font font10B = FontFactory.GetFont("Calibri (Body)", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);
                iTextSharp.text.Font font10N = FontFactory.GetFont("Calibri (Body)", 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);
                iTextSharp.text.Font font12B = FontFactory.GetFont("Calibri (Body)", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);


                PdfPTable ptbl = new PdfPTable(3);
                ptbl.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                float[] twidth = { 100, 300, 100 };
                ptbl.WidthPercentage = 95;
                ptbl.SetWidths(twidth);

                PdfPCell cell = new PdfPCell();

                try
                {

                    PdfPTable nestTBL = new PdfPTable(1);
                    nestTBL.WidthPercentage = 100;
                    nestTBL.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;

                    cell = new PdfPCell(new Phrase("Weekly Report For Block Development Officer Level", font12B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 3;
                    nestTBL.AddCell(cell);

                    cell = new PdfPCell(nestTBL);
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 3;
                    ptbl.AddCell(cell);

                    cell = new PdfPCell(new Phrase(" "));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.BorderWidthTop = 1f;
                    cell.Colspan = 3;
                    ptbl.AddCell(cell);

                    document.Add(ptbl);

                    PdfPTable nestTBL2 = new PdfPTable(3);
                    nestTBL2.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    float[] twidth44 = { 150, 300, 150 };
                    nestTBL2.SetWidths(twidth44);
                    nestTBL2.WidthPercentage = 95;

                    cell = new PdfPCell(new Phrase("Block Name : " + _data.BLOCK.BNAME, font10B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font10N));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("BDO Name : Mr Abcd", font10B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("District Name : "+_data.DISTRICT.DNAME, font10B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font10N));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Mobile No. : 912345678", font10B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Physical Progress Status of Indira Awas Yojna in Block", font12B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.BorderWidthBottom = .1f;
                    cell.Colspan = 3;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase(" "));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 3;
                    nestTBL2.AddCell(cell);

                    document.Add(nestTBL2);

                    PdfPTable nestTBL3 = new PdfPTable(13);
                    nestTBL3.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    float[] twidth45 = { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
                    nestTBL3.SetWidths(twidth45);
                    nestTBL3.WidthPercentage = 95;

                    cell = new PdfPCell(new Phrase("Pakhik", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .0f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Prakhnd me barsh 2014-15 ke liye lambit iay ka sankhya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .0f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Prakhnd me barsh 2014-15 ke liye sukruti iay ka sankhya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .0f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("kul sukrit iay ka sankhya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .0f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakshya me kitna iay ka parikyan kiya gaya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 2;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakshya me kitna iay ka parikyan kiya gaya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 2;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakshya me kitna iay ka parikyan kiya gaya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .0f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakshya me kitna iay ka parikyan kiya gaya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 2;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakshya me kitna iay ka parikyan kiya gaya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 2;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("1", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("2", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("4", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("4", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("5", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("6", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("7", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("8", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("9", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("10", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("11", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("12", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("13", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);


                    cell = new PdfPCell(new Phrase("Pratham Paksya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);


                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);


                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Dutiya pakhsya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);


                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 13;
                    nestTBL3.AddCell(cell);

                    document.Add(nestTBL3);

                    PdfPTable nestTBL4 = new PdfPTable(6);
                    nestTBL3.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    float[] twidth46 = { 100, 100, 100, 100, 100, 100 };
                    nestTBL4.SetWidths(twidth46);
                    nestTBL4.WidthPercentage = 95;

                    cell = new PdfPCell(new Phrase("Pakhik", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakhik", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakhik", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakhik", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("14", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("15", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("16", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("17", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    nestTBL4.AddCell(cell);

                    document.Add(nestTBL4);
                    // document.Add(new Paragraph("Hello World!"));

                # endregion


                }
                catch (Exception exc)
                {
                    retval = "Error, PDFgen-" + exc.Message;
                }
                document.Close();
            }
            catch (Exception ee)
            {
                retval = "Error, creating PDF document.";
            }

            return retval;

        }

        public static String PanchayatLevelPdfGen(_IayForm _data)
        {
            String retval = "Error";
            String msgstrng = "";
            try
            {

                //-----------------------------------------------------------------------------------------//
                string pdfname = "Panchayat_Level_Report_" + DateTime.Now.Millisecond.ToString() + ".pdf";
                retval = pdfname;
                FileStream fs = new FileStream(WebConfigurationManager.AppSettings["pdfstore"] + retval, FileMode.Create);
                Document document = new Document(PageSize.A4, 10, 10, 15, 15);
                document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                PdfWriter writer = PdfWriter.GetInstance(document, fs);

                HeaderFooter PageEventHandler = new HeaderFooter();
                PageEventHandler.msg = "IAY-14";
                writer.PageEvent = PageEventHandler;
                // Define the page header
                PageEventHandler.HeaderFont = FontFactory.GetFont("Calibri (Body)", 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);
                PageEventHandler.HeaderRight = "";
                document.Open();


                # region ****************PDFCONTENT***********************

                //----------------------------------------NEW CODE-------------------------------------------
                iTextSharp.text.Font font8B = FontFactory.GetFont("Calibri (Body)", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);
                iTextSharp.text.Font font8N = FontFactory.GetFont("Calibri (Body)", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);
                iTextSharp.text.Font font10B = FontFactory.GetFont("Calibri (Body)", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);
                iTextSharp.text.Font font10N = FontFactory.GetFont("Calibri (Body)", 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);
                iTextSharp.text.Font font12B = FontFactory.GetFont("Calibri (Body)", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);


                PdfPTable ptbl = new PdfPTable(3);
                ptbl.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                float[] twidth = { 100, 300, 100 };
                ptbl.WidthPercentage = 95;
                ptbl.SetWidths(twidth);

                PdfPCell cell = new PdfPCell();

                try
                {

                    PdfPTable nestTBL = new PdfPTable(1);
                    nestTBL.WidthPercentage = 100;
                    nestTBL.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;

                    cell = new PdfPCell(new Phrase("Weekly Report For Block Development Officer Level", font12B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 3;
                    nestTBL.AddCell(cell);

                    cell = new PdfPCell(nestTBL);
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 3;
                    ptbl.AddCell(cell);

                    cell = new PdfPCell(new Phrase(" "));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.BorderWidthTop = 1f;
                    cell.Colspan = 3;
                    ptbl.AddCell(cell);

                    document.Add(ptbl);

                    PdfPTable nestTBL2 = new PdfPTable(3);
                    nestTBL2.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    float[] twidth44 = { 150, 300, 150 };
                    nestTBL2.SetWidths(twidth44);
                    nestTBL2.WidthPercentage = 95;

                    cell = new PdfPCell(new Phrase("Panchayat Name : " + _data.PANCHAYAT.PNAME, font10B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font10N));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Block Name : " + _data.BLOCK.BNAME, font10B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font10N));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("PTA Name : Mr Abcd", font10B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("District Name : " + _data.DISTRICT.DNAME, font10B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font10N));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Mobile No. : 912345678", font10B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 1;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Physical Progress Status of Indira Awas Yojna in Panchayat", font12B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.BorderWidthBottom = .1f;
                    cell.Colspan = 3;
                    nestTBL2.AddCell(cell);

                    cell = new PdfPCell(new Phrase(" "));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Colspan = 3;
                    nestTBL2.AddCell(cell);

                    document.Add(nestTBL2);

                    PdfPTable nestTBL3 = new PdfPTable(13);
                    nestTBL3.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    float[] twidth45 = { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
                    nestTBL3.SetWidths(twidth45);
                    nestTBL3.WidthPercentage = 95;

                    cell = new PdfPCell(new Phrase("Pakhik", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .0f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Prakhnd me barsh 2014-15 ke liye lambit iay ka sankhya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .0f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Prakhnd me barsh 2014-15 ke liye sukruti iay ka sankhya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .0f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("kul sukrit iay ka sankhya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .0f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakshya me kitna iay ka parikyan kiya gaya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 2;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakshya me kitna iay ka parikyan kiya gaya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 2;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakshya me kitna iay ka parikyan kiya gaya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .0f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakshya me kitna iay ka parikyan kiya gaya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 2;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakshya me kitna iay ka parikyan kiya gaya", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 2;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("dfsdfsd", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("1", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("2", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("4", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("4", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("5", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("6", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("7", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("8", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("9", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("10", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("11", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("12", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("13", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);


                    cell = new PdfPCell(new Phrase("First Week", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);


                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);


                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Second Week", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);


                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Third Week", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);


                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Fourth Week", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);


                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL3.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 13;
                    nestTBL3.AddCell(cell);

                    document.Add(nestTBL3);

                    PdfPTable nestTBL4 = new PdfPTable(6);
                    nestTBL3.HorizontalAlignment = iTextSharp.text.Table.ALIGN_LEFT;
                    float[] twidth46 = { 100, 100, 100, 100, 100, 100 };
                    nestTBL4.SetWidths(twidth46);
                    nestTBL4.WidthPercentage = 95;

                    cell = new PdfPCell(new Phrase("Pakhik", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakhik", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakhik", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Pakhik", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .5f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("14", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("15", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("16", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("17", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .5f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.BorderWidthLeft = .0f;
                    cell.BorderWidthTop = .0f;
                    cell.BorderWidthRight = .5f;
                    cell.BorderWidthBottom = .5f;
                    cell.Colspan = 1;
                    nestTBL4.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", font8B));
                    cell.HorizontalAlignment = iTextSharp.text.Table.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    nestTBL4.AddCell(cell);

                    document.Add(nestTBL4);
                    // document.Add(new Paragraph("Hello World!"));

                # endregion


                }
                catch (Exception exc)
                {
                    retval = "Error, PDFgen-" + exc.Message;
                }
                document.Close();
            }
            catch (Exception ee)
            {
                retval = "Error, creating PDF document.";
            }

            return retval;

        }

        public class HeaderFooter : PdfPageEventHelper
        {
            public String msg;

            // This is the contentbyte object of the writer
            PdfContentByte cb;

            // we will put the final number of pages in a template
            PdfTemplate template;

            // this is the BaseFont we are going to use for the header / footer
            BaseFont bf = null;

            //// This keeps track of the creation time
            //DateTime PrintTime = DateTime.Now;


            #region Properties
            private string _HeaderRight;
            public string HeaderRight
            {
                get { return _HeaderRight; }
                set { _HeaderRight = value; }
            }

            private Font _HeaderFont;
            public Font HeaderFont
            {
                get { return _HeaderFont; }
                set { _HeaderFont = value; }
            }

            private Font _FooterFont;
            public Font FooterFont
            {
                get { return _FooterFont; }
                set { _FooterFont = value; }
            }

            #endregion

            // we override the onOpenDocument method
            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                try
                {
                    //PrintTime = DateTime.Now;
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    cb = writer.DirectContent;
                    template = cb.CreateTemplate(50, 50);
                }
                catch (DocumentException de)
                {
                }
                catch (System.IO.IOException ioe)
                {
                }
            }

            public override void OnStartPage(PdfWriter writer, Document document)
            {
                base.OnStartPage(writer, document);

                Rectangle pageSize = document.PageSize;

                if (HeaderRight != string.Empty)
                {
                    PdfPTable HeaderTable = new PdfPTable(2);
                    HeaderTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    HeaderTable.TotalWidth = pageSize.Width - 10;
                    HeaderTable.SetWidthPercentage(new float[] { 45, 45 }, pageSize);

                    PdfPCell HeaderRightCell = new PdfPCell(new Phrase(8, HeaderRight, HeaderFont));
                    HeaderRightCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    HeaderRightCell.Border = 0;
                    HeaderRightCell.Colspan = 2;
                    HeaderTable.AddCell(HeaderRightCell);

                    cb.SetRGBColorFill(0, 0, 0);
                    HeaderTable.WriteSelectedRows(0, -1, pageSize.GetLeft(0), pageSize.GetTop(10), cb);
                }
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                int pageN = writer.PageNumber;
                String text = msg + "     Page " + pageN;
                float len = bf.GetWidthPoint(text, 8);

                Rectangle pageSize = document.PageSize;

                cb.SetRGBColorFill(100, 100, 100);

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetColorFill(Color.BLACK);
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, text, 570, 15, 0);
                cb.EndText();

                cb.AddTemplate(template, pageSize.GetLeft(570) + len, pageSize.GetBottom(15));

            }

            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                base.OnCloseDocument(writer, document);

                template.BeginText();
                template.SetFontAndSize(bf, 8);
                template.SetTextMatrix(0, 0);
                template.ShowText("" + (writer.PageNumber - 1));
                template.EndText();
            }

        }

        public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        public static System.Drawing.Bitmap Base64ToImage(string base64String)
        {
            Byte[] bitmapData = new Byte[base64String.Length];
            bitmapData = Convert.FromBase64String(base64String);
            System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
            System.Drawing.Bitmap bitImage = new System.Drawing.Bitmap((System.Drawing.Bitmap)System.Drawing.Image.FromStream(streamBitmap));
            bitImage.MakeTransparent(System.Drawing.Color.Black);
            return bitImage;

        }
    }
}