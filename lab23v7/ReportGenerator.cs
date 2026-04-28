using System;

namespace lab23
{
    public class ReportGenerator
    {
        private readonly IDocumentProcessor _processor;

        public ReportGenerator()
        {
            _processor = new WordDocumentProcessor();
        }

        public void GenerateReport()
        {
            _processor.Read("report.docx");
            _processor.Write("report.docx", "Annual Report Data");
            _processor.ConvertToPdf("report.docx");
        }
    }
}