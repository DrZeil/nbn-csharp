/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.IO;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace LearnByErrorLibrary
{
    public static class HistoryPDFExtensions {
        public static void ToLog(this Exception ex)
        {
        }
    }
    /// <summary>
    /// Learn history to PDF saver
    /// </summary>
    public class HistoryPDF
    {
        
        #region BASIC
        /// <summary>
        /// Document
        /// </summary>
        private Document document = null;

        /// <summary>
        /// Filename
        /// </summary>
        private String filename = "";

        /// <summary>
        /// Chart filename
        /// </summary>
        private String chartFilename = "";

        /// <summary>
        /// Learn result data
        /// </summary>
        private LearnByErrorLibrary.LearnResult result;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="result">LearnResult - learning result</param>
        /// <param name="chartFilename">string - char filename</param>
        /// <param name="includeDataTable">bool - true id learning data should be included</param>
        public HistoryPDF(LearnByErrorLibrary.LearnResult result, String chartFilename, bool includeDataTable = false)
        {
            this.result = result;
            this.chartFilename = chartFilename;

            document = new Document();
            document.Info.Title = "NBN C# - wynik uczenia sieci neuronowej";
            document.Info.Subject = "Uczenie sieci neuronowej za pomocą algorytmu NBN C#";
            document.Info.Author = "Marek Bar 33808";
            document.Info.Comment = "...ponieważ tylko dobry kod się liczy.";
            document.Info.Keywords = "C#, NBN, neuron, uczenie, sieć, nbn c#";
    
            DefineStyles(document);
            DefineCover(document);
            DefineInfo(document, result);
            DefineChartArea(document, chartFilename, Path.GetFileNameWithoutExtension(result.Filename));
            DefineWeightsSection(document, result);

            if (includeDataTable)
            {
                MatrixMB mat = MatrixMB.Load(result.Filename);
                AddMatrixTable(document, mat);
            }

            Section section = document.LastSection;

            section.AddPageBreak();//index of pages 
            Paragraph paragraph = section.AddParagraph("Spis treści");
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.SpaceAfter = 24;
            paragraph.Format.OutlineLevel = OutlineLevel.Level1;

            paragraph = section.AddParagraph();
            paragraph.Style = "TOC";

            //first link
            Hyperlink hyperlink = paragraph.AddHyperlink("Informacje na temat sieci neuronowej");
            hyperlink.AddText("\r\n" + "Informacje na temat sieci neuronowej" + "\t");
            hyperlink.AddPageRefField("Informacje na temat sieci neuronowej");

            hyperlink = paragraph.AddHyperlink("Wykres przebiegu uczenia");
            hyperlink.AddText("\r\n" + "Wykres przebiegu uczenia" + "\t");
            hyperlink.AddPageRefField("Wykres przebiegu uczenia");

            hyperlink = paragraph.AddHyperlink("Wagi otrzymane w procesie uczenia");
            hyperlink.AddText("\r\n" + "Wagi otrzymane w procesie uczenia" + "\t");
            hyperlink.AddPageRefField("Wagi otrzymane w procesie uczenia");
            if (includeDataTable)
            {
                hyperlink = paragraph.AddHyperlink("Dane wejściowe");
                hyperlink.AddText("\r\n" + "Dane wejściowe" + "\t");
                hyperlink.AddPageRefField("Dane wejściowe");
            }
        }

        /// <summary>
        /// Main page
        /// </summary>
        /// <param name="document">Document - pdf document</param>
        /// <param name="result">LearnResult - learning result</param>
        private void DefineInfo(Document document, LearnResult result)
        {
            Section section = document.AddSection();
            document.LastSection.AddParagraph("Informacje na temat sieci neuronowej", "Heading2");
            Paragraph paragraph = section.AddParagraph("Informacje na temat sieci neuronowej" + "\r\n");
            paragraph.AddBookmark("Informacje na temat sieci neuronowej");
            paragraph.Format.SpaceAfter = "3cm";
            paragraph.Format.Font.Size = 16;
            paragraph.Format.Font.Color = Colors.Black;
            paragraph.Format.SpaceBefore = "1cm";
            paragraph.Format.SpaceAfter = "1cm";

            Table table = new Table();
            table.Borders.Width = 0.75;
            Column column = table.AddColumn(Unit.FromCentimeter(10.0));
            column.Format.Alignment = ParagraphAlignment.Left;
            Column column2 = table.AddColumn(Unit.FromCentimeter(5.5));
            column2.Format.Alignment = ParagraphAlignment.Center;
            
            Row _row = table.AddRow();
            Cell _cell1 = _row.Cells[0];
            _cell1.AddParagraph("Nazwa parametru");

            Cell _cell2 = _row.Cells[1];
            _cell2.AddParagraph("Wartość parametru");

            
            foreach (var item in result.GetInformation())
            {
                Row row = table.AddRow();
                Cell cell1 = row.Cells[0];
                cell1.AddParagraph(item[0]);

                Cell cell2 = row.Cells[1];
                cell2.AddParagraph(item[1]);
            }
                
            document.LastSection.Add(table);

        }

      
        #endregion

        #region SAVE_OPEN
        /// <summary>
        /// Open generated PDF
        /// </summary>
        public void Open()
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch (Exception ex)
            {
                ex.ToLog();
            }
        }

        /// <summary>
        /// Save generated PDF to file
        /// </summary>
        /// <param name="filename">string - file name</param>
        /// <returns>bool - true if saved</returns>
        public bool Save(String filename)
        {
            try
            {
                this.filename = filename;

                PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
                renderer.Document = document;
                renderer.RenderDocument();

                renderer.PdfDocument.Save(filename);

                if (File.Exists(chartFilename)) File.Delete(chartFilename);
                return true;
            }
            catch (Exception ex)
            {
                ex.ToLog();
                return false;
            }
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Adds learning data
        /// </summary>
        /// <param name="document">Document - pdf document</param>
        /// <param name="mat">MatrixMB - matrix object</param>
        private static void AddMatrixTable(Document document, LearnByErrorLibrary.MatrixMB mat)
        {
            try
            {
                var name = "Dane wejściowe" + " " + (mat.Name != "" ? " - " + mat.Name : "");
                Paragraph paragraph = document.LastSection.AddParagraph(name, "Heading2");
                paragraph.AddBookmark("Dane wejściowe");
                Table table = new Table();
                table.Borders.Width = 0.75;

                for (int col = 0; col < mat.Cols; col++)
                {
                    Column column = table.AddColumn(Unit.FromCentimeter(1.5));
                    column.Format.Alignment = ParagraphAlignment.Center;
                }

                for (int r = 0; r < mat.Rows; r++)
                {
                    Row row = table.AddRow();
                    row.Shading.Color = r % 2 == 0 ? Colors.LightGray : Colors.LightBlue;
                    for (int c = 0; c < mat.Cols; c++)
                    {
                        Cell cell = row.Cells[c];

                        cell.AddParagraph(mat.Data[r][c].ToString());
                    }
                }

                table.SetEdge(0, 0, mat.Cols, mat.Rows, Edge.Box, BorderStyle.Single, 0.5, Colors.Black);

                document.LastSection.Add(table);

            }
            catch (Exception ex)
            {
                ex.ToLog();
            }
        }

        /// <summary>
        /// PDF document styles
        /// </summary>
        /// <param name="document">Document - pdf document</param>
        private static void DefineStyles(Document document)
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";

            style = document.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called TextBox based on style Normal
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Distance = "3pt";
            //TODO: Colors
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

            // Create a new style called TOC based on style Normal
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Blue;

            style = document.Styles.AddStyle("Table", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            style.Font.Bold = false;
            style.Font.Size = 10;
            style.ParagraphFormat.Borders.Width = 0.0;
            style.ParagraphFormat.Borders.Distance = "1pt";
            style.ParagraphFormat.Shading.Color = Colors.White;
            style.ParagraphFormat.RightIndent = 0;
            style.ParagraphFormat.LeftIndent = 0;
        }

        public static String ApplicationFolder
        {
            get
            {
                String dir = "";
                dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NBN";
                if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
                return dir;
            }
        }

        /// <summary>
        /// Document cover definition
        /// </summary>
        /// <param name="document">Document - pdf document</param>
        private static void DefineCover(Document document)
        {
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.SpaceAfter = "3cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            String imageFile = ApplicationFolder + "\\napiszprogram.bmp";
            if (!File.Exists(imageFile))
            {
                Properties.Resources.napiszprogram.Save(imageFile);
            }
            Image image = section.AddImage(imageFile);
            image.Width = "4cm";
            image.LockAspectRatio = true;
            //image.Top = MigraDoc.DocumentObjectModel.Shapes.ShapePosition.Center;
            image.Left = MigraDoc.DocumentObjectModel.Shapes.ShapePosition.Center;
            image.RelativeHorizontal = MigraDoc.DocumentObjectModel.Shapes.RelativeHorizontal.Margin;
            //image.RelativeVertical = MigraDoc.DocumentObjectModel.Shapes.RelativeVertical.Margin;
            
            

            paragraph = section.AddParagraph(document.Info.Title);
            paragraph.Format.Font.Size = 24;
            paragraph.Format.Font.Color = Colors.LightBlue;
            paragraph.Format.SpaceBefore = "1cm";
            paragraph.Format.SpaceAfter = "1cm";

            paragraph = section.AddParagraph(document.Info.Subject);
            paragraph.Format.Font.Size = 16;
            paragraph.Format.Font.Color = Colors.LightBlue;
            paragraph.Format.SpaceBefore = "1cm";
            paragraph.Format.SpaceAfter = "1cm";

            paragraph = section.AddParagraph(document.Info.Author);
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = Colors.LightBlue;
            paragraph.Format.SpaceBefore = "1cm";
            paragraph.Format.SpaceAfter = "1cm";

            paragraph = section.AddParagraph("Data utworzenia: " + DateTime.Now.ToString());
            paragraph.Format.Font.Size = 12;
            paragraph.Format.Font.Color = Colors.LightBlue;
            paragraph.Format.SpaceBefore = "3cm";
            paragraph.Format.SpaceAfter = "1cm";
        }

        /// <summary>
        /// Learning chart
        /// </summary>
        /// <param name="document">Document - pdf document</param>
        /// <param name="chartFilename">string - chart filename of generated chart</param>
        /// <param name="chartTitle">string - chart title</param>
        private static void DefineChartArea(Document document, String chartFilename, String chartTitle)
        {
            Section section = document.AddSection();
            document.LastSection.AddParagraph("Wykres przebiegu uczenia", "Heading2");
            Paragraph paragraph = section.AddParagraph();
            paragraph.AddBookmark("Wykres przebiegu uczenia");
            paragraph.Format.SpaceAfter = "3cm";
            
            Image image = section.AddImage(chartFilename);
            image.Width = "18cm";


            paragraph = section.AddParagraph("Wykres przebiegu uczenia dla " + chartTitle);
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Size = 16;
            paragraph.Format.Font.Color = Colors.Black;
            paragraph.Format.SpaceBefore = "1cm";
            paragraph.Format.SpaceAfter = "1cm";
            
        }

        /// <summary>
        /// Learing weights
        /// </summary>
        /// <param name="document">Document - pdf document</param>
        /// <param name="result">LearnResult - learn result</param>
        private static void DefineWeightsSection(Document document, LearnResult result)
        {
            Section section = document.AddSection();
            document.LastSection.AddParagraph("Wagi otrzymane w procesie uczenia", "Heading2");
            Paragraph paragraph = section.AddParagraph("Wagi otrzymane w procesie uczenia dla: " + Path.GetFileNameWithoutExtension(result.Filename) + "\r\n");
            paragraph.AddBookmark("Wagi otrzymane w procesie uczenia");
            paragraph.Format.SpaceAfter = "3cm";                        
            paragraph.Format.Font.Size = 16;
            paragraph.Format.Font.Color = Colors.Black;
            paragraph.Format.SpaceBefore = "1cm";
            paragraph.Format.SpaceAfter = "1cm";
            
            int i = 1;
            foreach (var item in result.ResultWeights)
            {
                paragraph = section.AddParagraph("\r\n" + "Wagi otrzymane z uczenia dla próby nr: " + i.ToString() + "\r\n");
                paragraph.Format.SpaceAfter = "3cm";
                paragraph.Format.Font.Size = 16;
                paragraph.Format.Font.Color = Colors.Black;
                paragraph.Format.SpaceBefore = "1cm";
                paragraph.Format.SpaceAfter = "1cm";
                Table table = new Table();
                
                table.Borders.Width = 0.75;
                Column column = table.AddColumn(Unit.FromCentimeter(1.5));
                column.Format.Alignment = ParagraphAlignment.Center;
                Column column2 = table.AddColumn(Unit.FromCentimeter(5.5));
                column2.Format.Alignment = ParagraphAlignment.Center;

                int w = 1;
                
                Row _row = table.AddRow();
                Cell _cell1 = _row.Cells[0];
                _cell1.AddParagraph("Numer wagi");

                Cell _cell2 = _row.Cells[1];
                _cell2.AddParagraph("Waga");
                foreach (var weight in item)
                {
                    Row row = table.AddRow();
                    Cell cell1 = row.Cells[0];
                    cell1.AddParagraph(w.ToString());

                    Cell cell2 = row.Cells[1];
                    cell2.AddParagraph(weight.ToString());
                    w++;
                }
                paragraph.Section.Add(table);
                //document.LastSection.Add(table);

                i++;
            }
        }
        #endregion
    }
}
