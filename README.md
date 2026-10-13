# Blazor Digital Signature Demo

## Overview

This sample demonstrates how to apply digital signatures to PDF documents in a Blazor application using the Syncfusion [Blazor PDF Viewer](https://www.syncfusion.com/pdf-viewer-sdk/blazor-pdf-viewer) component. Users can open a PDF document, interact with the viewer, and complete digital-signing workflows directly within the browser experience. This scenario is useful for document approval, compliance, and paperless business processes that require authenticated PDF signing.

The sample focuses on integrating Syncfusion PDF viewing and digital-signature capabilities into a Blazor application and provides a foundation for extending PDF-based workflows in enterprise applications.

## Key Features

- Displays PDF documents using the Syncfusion Blazor PDF Viewer, with the document loaded through the `DocumentPath` property of the `SfPdfViewerServer` component.
- Retrieves the current PDF document,plied annotations and form field changes, by invoking the `GetDocumentAsync()` method from the PDF Viewer.
- Provides a custom signing workflow through the Syncfusion `SfButton` component, allowing users to trigger document signing using the **Complete Signing** action.
- Flattens all PDF annotations before signing by iterating through `PdfLoadedPage.Annotations` and setting the `Flatten` property to `true`, ensuring annotations become permanent document content.
- Flattens all interactive PDF form fields using the `PdfLoadedDocument.Form.Flatten` property to preserve entered values in the signed document.
- Loads and processes PDF files using the Syncfusion PDF Library through the `PdfLoadedDocument` class.
- Creates a certificate-based digital signature using the `PdfCertificate` class with a `.pfx` certificate file stored in the application's `wwwroot/input-data` directory.
- Applies a digital signature to the first page of the PDF document using the `PdfSignature` class and the signature field name `"DigitalSignature"`.
- Generates a signed PDF document in memory using `MemoryStream` without modifying the original source document.
- Downloads the digitally signed PDF file to the client browser using JavaScript interop after the signing process is completed.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) compatible with the project's target framework

## How to Run the Project

**Visual Studio 2022**

1. Clone or download the repository.
2. Open the `DGSignature.sln` solution file.
3. Restore NuGet packages.
4. Build the solution.
5. Run the application with `Ctrl+F5`.

**Visual Studio Code**

1. Clone or download the repository.
2. Open the repository folder in Visual Studio Code.
3. Navigate to the project directory.

```bash
dotnet restore
dotnet run
```

4. Open the application in the browser.

## Project Structure

- `Data/PdfDigitalSignatureService.cs` - Service responsible for flattening annotations and form fields, loading the certificate, applying the digital signature, and generating the signed PDF document.
- `Pages/Index.razor` - Main sample page that hosts the `SfPdfViewerServer` component, displays the PDF document, and provides the **Complete Signing** action.
- `wwwroot/input-data/RentalAgreement.pdf` - Sample PDF document loaded into the PDF Viewer for review and signing.
- `wwwroot/input-data/DemoRootCertificate.pfx` - Digital certificate file used to create and apply the PDF digital signature.

## Support and Feedback

- For general product questions, visit the [Syncfusion Community Forum](https://www.syncfusion.com/forums) or [Syncfusion Support](https://www.syncfusion.com/support).
- To report an issue specific to this sample, open a GitHub issue in this repository.
- Documentation: https://help.syncfusion.com/document-processing/pdf/pdf-viewer/blazor/getting-started/web-app

## License

This is a Syncfusion sample project provided to demonstrate product usage. Review the [Syncfusion license terms](https://www.syncfusion.com/sales/pricing?category=ui-components) before using Syncfusion components in your own applications.