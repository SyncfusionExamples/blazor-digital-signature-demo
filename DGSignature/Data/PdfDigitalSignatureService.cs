using Microsoft.AspNetCore.Hosting;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DGSignature.Data
{
    public class PdfDigitalSignatureService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public PdfDigitalSignatureService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public MemoryStream AddDigitalSignature(byte[] documentData)
        {
            //Save the document into stream
            MemoryStream stream = new MemoryStream();

            //Load the PDF document           
            using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(FlattenDocument(documentData)))
            {
                //Gets the first page of the document
                PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

                //Create a certificate
                FileStream certificateStream = new FileStream(ResolveApplicationPath("DemoRootCertificate.pfx"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                PdfCertificate certificate = new PdfCertificate(certificateStream, "Password@123");

                //Create signature
                PdfSignature signature = new PdfSignature(loadedDocument, page, certificate, "DigitalSignature");

                //Save the document.
                loadedDocument.Save(stream);
            }

            stream.Position = 0;

            return stream;
        }

        #region HelperMethod
        private string ResolveApplicationPath(string fileName)
        {
            return _hostingEnvironment.WebRootPath + "//input-data//" + fileName;
        }

        private Stream FlattenDocument(byte[] documentData)
        {
            MemoryStream stream = new MemoryStream();
            //Load the PDF document           
            using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentData))
            {
                //Flatten all the annotations.
                foreach (PdfLoadedPage lPage in loadedDocument.Pages)
                {
                    if (lPage.Annotations != null)
                    {
                        lPage.Annotations.Flatten = true;
                    }
                }

                //Flatten all the form fields.
                loadedDocument.Form.Flatten = true;

                //Save and close the document.
                loadedDocument.Save(stream);
            }
            return stream;
        }
        #endregion
    }
}
