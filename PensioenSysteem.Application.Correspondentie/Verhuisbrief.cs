using Dapper;
using Newtonsoft.Json;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PensioenSysteem.Application.Correspondentie.Model;
using PensioenSysteem.Application.Correspondentie.Properties;
using PensioenSysteem.Domain.Deelnemer.Events;
using System;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PensioenSysteem.Application.Correspondentie
{
    public static class Verhuisbrief
    {
        static Deelnemer _deelnemer;
        static DeelnemerVerhuisd _event;
        static double _positionX = 50;
        static double _positionY = 50;
        static XFont _titelFont = new XFont("Verdana", 14, XFontStyle.Bold);
        static XFont _font = new XFont("Verdana", 11, XFontStyle.Regular);
        static XFont _fontBold = new XFont("Verdana", 11, XFontStyle.Bold);
        static PdfDocument _document;
        static PdfPage _page;
        static XGraphics _gfx;

        public static bool Genereer(Deelnemer deelnemer, DeelnemerVerhuisd deelnemerVerhuisd)
        {
            _deelnemer = deelnemer;
            _event = deelnemerVerhuisd;

            // start pdf document
            _document = new PdfDocument();
            _document.Info.Title = "Verhuisbrief " + _deelnemer.Naam;
            _document.Info.Author = "Verhuisbrief Generator";

            // voeg pagina toe
            _page = _document.AddPage();
            _gfx = XGraphics.FromPdfPage(_page);

            // vul pagina
            PlaatsLogo();
            PlaatsTitel();
            PlaatsNAWGegevens();
            PlaatsInhoud();

            // sla document op
            SlaPdfOp();

            return true;
        }


        private static void PlaatsLogo()
        {
            var logo = XImage.FromGdiPlusImage(Resources.Logo);
            _gfx.DrawImage(logo, _positionX, _positionY);
        }

        private static void PlaatsTitel()
        {
            _gfx.DrawString("Informatie over uw verhuizing", _titelFont,
                XBrushes.Black, _positionX, _positionY += 110);
        }

        private static void PlaatsNAWGegevens()
        {
            _gfx.DrawString(_deelnemer.Naam, _fontBold, XBrushes.Black, _positionX, _positionY += 35);
            string straatEnHuisnummer = string.Format("{0} {1}{2}", _event.Straat, _event.Huisnummer, _event.HuisnummerToevoeging);
            _gfx.DrawString(straatEnHuisnummer, _font, XBrushes.Black, _positionX, _positionY += 15);
            _gfx.DrawString(_event.Postcode, _font, XBrushes.Black, _positionX, _positionY += 15);
            _gfx.DrawString(_event.Plaats, _font, XBrushes.Black, _positionX, _positionY += 15);
        }

        private static void PlaatsInhoud()
        {

            string inhoud = string.Format(Resources.VerhuisBriefTekst, _deelnemer.Naam);

            var formatter = new XTextFormatter(_gfx);
            XRect layoutRect = new XRect(_positionX, _positionY += 25, _page.Width - 100, _page.Height - _positionY);
            formatter.DrawString(inhoud, _font, XBrushes.Black, layoutRect);
        }

        private static void SlaPdfOp()
        {
            string outputFolder = ConfigurationManager.AppSettings["PdfOutputFolder"];
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
            string fileName = string.Format("{0}-{1}.pdf", DateTime.Now.ToString("yyyyMMddhhmmssffffff"), _deelnemer.Naam);
            string outputFile = Path.Combine(outputFolder, fileName);
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }
            _document.Save(outputFile);
        }
    }
}
