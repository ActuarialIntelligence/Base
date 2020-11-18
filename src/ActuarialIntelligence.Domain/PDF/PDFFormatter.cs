using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Cyotek.GhostScript;
using Cyotek.GhostScript.PdfConversion;

namespace ActuarialIntelligence.Domain.PDF
{


    public class PDFFormatter
    {
        public PDFFormatter(Pdf2ImageSettings Settings,
        AntiAliasMode _antiAliasMode,
                            int _dpi,
                            GridFitMode _gridFitMode,
                            ImageFormat _imageFormat,
                            PaperSize _paperSize,
                            PdfTrimMode _trimMode,
                            string _pdfFileName,
                            int PageCount,
                            string PdfPassword )
        {
            this.Settings = Settings;
            this._antiAliasMode = _antiAliasMode;
            this._dpi = _dpi;
            this._gridFitMode = _gridFitMode;
            this._imageFormat = _imageFormat;
            this._paperSize = _paperSize;
            this._trimMode = _trimMode;
            this._pdfFileName = _pdfFileName;
            this.PageCount = PageCount;
            this.PdfPassword = PdfPassword;

        }
        private Pdf2ImageSettings Settings;
        private AntiAliasMode _antiAliasMode;
        private int _dpi;
        private GridFitMode _gridFitMode;
        private ImageFormat _imageFormat;
        private PaperSize _paperSize;
        private PdfTrimMode _trimMode;
        private string _pdfFileName;
        private int PageCount;
        private string PdfPassword;

        protected virtual IDictionary<GhostScriptCommand, object>
GetConversionArguments(string pdfFileName, string outputImageFileName,
int pageNumber, string password, Pdf2ImageSettings settings)
        {
            IDictionary<GhostScriptCommand, object> arguments;

            arguments = new Dictionary<GhostScriptCommand, object>();

            // basic GhostScript setup
            arguments.Add(GhostScriptCommand.Silent, null);
            arguments.Add(GhostScriptCommand.Safer, null);
            arguments.Add(GhostScriptCommand.Batch, null);
            arguments.Add(GhostScriptCommand.NoPause, null);

            // specify the output
            arguments.Add(GhostScriptCommand.Device,
            GhostScriptAPI.GetDeviceName(settings.ImageFormat));
            arguments.Add(GhostScriptCommand.OutputFile, outputImageFileName);

            // page numbers
            arguments.Add(GhostScriptCommand.FirstPage, pageNumber);
            arguments.Add(GhostScriptCommand.LastPage, pageNumber);

            // graphics options
            arguments.Add(GhostScriptCommand.UseCIEColor, null);

            if (settings.AntiAliasMode != AntiAliasMode.None)
            {
                arguments.Add(GhostScriptCommand.TextAlphaBits, settings.AntiAliasMode);
                arguments.Add(GhostScriptCommand.GraphicsAlphaBits, settings.AntiAliasMode);
            }

            arguments.Add(GhostScriptCommand.GridToFitTT, settings.GridFitMode);

            // image size
            if (settings.TrimMode != PdfTrimMode.PaperSize)
                arguments.Add(GhostScriptCommand.Resolution, settings.Dpi.ToString());

            switch (settings.TrimMode)
            {
                case PdfTrimMode.PaperSize:
                    if (settings.PaperSize != PaperSize.Default)
                    {
                        arguments.Add(GhostScriptCommand.FixedMedia, true);
                        arguments.Add(GhostScriptCommand.PaperSize, settings.PaperSize);
                    }
                    break;
                case PdfTrimMode.TrimBox:
                    arguments.Add(GhostScriptCommand.UseTrimBox, true);
                    break;
                case PdfTrimMode.CropBox:
                    arguments.Add(GhostScriptCommand.UseCropBox, true);
                    break;
            }

            // pdf password
            if (!string.IsNullOrEmpty(password))
                arguments.Add(GhostScriptCommand.PDFPassword, password);

            // pdf filename
            arguments.Add(GhostScriptCommand.InputFile, pdfFileName);

            return arguments;
        }
        public Bitmap GetImage(int pageNumber)
        {
            Bitmap result;
            string workFile;

            if (pageNumber < 1 || pageNumber > this.PageCount)
                throw new ArgumentException("Page number is out of bounds", "pageNumber");

            workFile = Path.GetTempFileName();

            try
            {
                this.ConvertPdfPageToImage(workFile, pageNumber);
                using (FileStream stream = new FileStream(workFile, FileMode.Open, FileAccess.Read))
                    result = new Bitmap(stream);
            }
            finally
            {
                File.Delete(workFile);
            }

            return result;
        }

        public Bitmap[] GetImages(int startPage, int lastPage)
        {
            List<Bitmap> results;
            
            if (startPage < 1 || startPage > this.PageCount)
                throw new ArgumentException
                ("Start page number is out of bounds", "startPage");

            if (lastPage < 1 || lastPage > this.PageCount)
                throw new ArgumentException
                ("Last page number is out of bounds", "lastPage");
            else if (lastPage < startPage)
                throw new ArgumentException
                ("Last page cannot be less than start page", "lastPage");

            results = new List<Bitmap>();
            for (int i = startPage; i <= lastPage; i++)
                results.Add(this.GetImage(i));

            return results.ToArray();
        }
        public void ConvertPdfPageToImage(string outputFileName, int pageNumber)
        {
            if (pageNumber < 1 || pageNumber > this.PageCount)
                throw new ArgumentException("Page number is out of bounds", "pageNumber");

            using (GhostScriptAPI api = new GhostScriptAPI())
                api.Execute(this.GetConversionArguments(this._pdfFileName,
                outputFileName, pageNumber, this.PdfPassword, this.Settings));
        }
    }
}
