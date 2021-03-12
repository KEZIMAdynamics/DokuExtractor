[![Build Status](https://dev.azure.com/thomas0077/thomas_0077/_apis/build/status/KEZIMAdynamics.DokuExtractor)](https://dev.azure.com/thomas0077/thomas_0077/_build/latest?definitionId=1)

# DokuExtractor

Easily **extract data** from PDF **documents**!

## What is DokuExtractor?

DokuExtractor is a .NET (core) library to simplify data extraction from PDF documents.  

To find out more, please visit us on https://dokuextractor.com

## Features

- Data extraction based on templates for different document types and layouts
- Automatic document classification based on your templates
- Automatic creation of new document class templates for known document types - Say you configured DokuExtractor
to extract data from invoices and feed it an invoice from a previously unknown supplier, DokuExtractor
can figure out which information you want to extract and prepares a new template for you
- Calculated values based on extracted data - Can be used to validate a document or to create data
 which is not even in the actual document if you need to

- Can be embedded as library into your projects or used as a standalone application
- Optional GUI components included for an easy start and sample usage

## Goals

The main goal of this project is to provide .NET developers with an easy to use tool to extract data
 from documents. 

Did you ever come across the need to get something from a PDF and in different layouts? Like getting the 
invoice total from different invoices of different suppliers? 
If so, you will have quickly noticed what the world has to offer to you:
Either some half-baked random samples in environments that do not match a .NET tool stack *OR* some
huge companies who basically seem to do a good job with the task at hand. 
Unfortunatelly, they don't just provide you with a simple library. Once you chewed through hours of
discussions with yet another precious sales rep and explained your needs, 
they push more and more complex products at you with ever growing dollar signs in their eyes. 

We've been there, done that and didn't like it. So we decided to create DokuExtractor. For us - and for you!

It's simple: Need it, get it, use it :smiley:


## Using DokuExtractor

### Vocabulary

**Groups** define the general type of documents you want to extract data from (e.g. Invoice, Offer, ...).

**Classes** are the sub categories of groups and belong to specific documents (e.g. Invoice Amazon, Invoice PayPal, ...).

![groups and classes](/docs/GroupsAndClasses.png)

**Group Templates** are templates containing definitions to extract data from documents of a document group. 
Additionally they are the base to create Class Templates

**Class Templates** are templates containing definitions to extract data from specific document classes.

**Extracted Data Fields** are data fields, which can directly be extracted from the PDF text by regex or position.

**Extracted Calculation Fields** contain the result of calculations of Extracted Data Fields (e.g. to validate VAT of an invoice).

**Extracted Conditional Fields** contain the result of a condition check (according to the extracted text).

**Data Field Group Templates** are templates to extract data by using simple text anchors, if there is no Data Field Class Template.

![data field group template](/docs/DataFieldGroupTemplate.png)

**Data Field Class Templates** are templates to extract data by using regex or defined areas.

![data field class template](/docs/DataFieldClassTemplate.png)

**Calculation Field Templates** are templates, which define what shall be calculated by which data fields.

![calculation field template](/docs/CalculationFieldTemplate.png)

**Conditional Field Templates** define values according to conditions.

![conditional field template](/docs/ConditionalFieldTemplate.png)

### Data extraction

![extraction process](/docs/ExtractionProcess.png)

### DokuExtractor Standard GUI

PDF documents you drop on the PDF dropzone are listed on the left side. The selected document is shown within the PDF viewer in the middle. By clicking the "Go!" button the data extraction is processed.

![dokuextractor gui](/docs/DokuExtractorGUI.png)

### Templates

![field templates](/docs/FieldTemplates.png)

### DokuExtractor Code

DokuExtractor is not limited to being a standalone application, ofcourse.
You can use or embed DokuExtractor in your own projects as well. 

Using DokuExtractor in your code with predefined templates is easy and can be done in just a few lines of code:
```Csharp
// Create a new template processor.
var templateProcessor = new TemplateProcessor(Application.StartupPath);

// Load group and class templates. You may use the template processor to load them from disk if desired or you 
// can load them from somewhere else (database or whatever)
var classTemplates = templateProcessor.LoadClassTemplatesFromDisk();
var groupTemplates = templateProcessor.LoadGroupTemplatesFromDisk();

// Create a new pdf text loader. It will extract the text from your pdf document.
IPdfTextLoaderFull pdfTextLoader = new PdfTextLoaderFull();

// Get the text from your pdf.
var inputString = await PdfTextLoader.GetTextFromPdf(selectedFilePath, false);

// Let the template processsor find the matching class template for your pdf
var matchingTemplateResult = templateProcessor.MatchTemplates(this.classTemplates, inputString);
var template = matchingTemplateResult.GetTemplate();

// Let the template processor perform its magic extract the pdf data according to your document template fields!
var result = await templateProcessor.ExtractData(template, groupTemplates, inputString, selectedFilePath);

// For your convenience, DokuExtractor can also give you the extracted data as JSON if you prefer.
var resultAsJson = await templateProcessor.ExtractDataAsJson(template, groupTemplates, inputString, selectedFilePath);
```


If you need to create new document class templates from a group template, DokuExtractor's template processor can automatically create
the class template for you. DokuExtractor will also try fill in the necessary information in the new template to minimize user interaction.
```Csharp
var newDocumentClassTemplate = templateProcessor.AutoCreateClassTemplate("NewTemplateName", inputString, selectedGroupTemplate);
```

In case you are working with more than one group template, Dokuextractor can also help finding the right one:
```Csharp
 templateProcessor.MatchTemplates(groupTemplates, inputString);
```

When editing data fields within new class templates, there is also support for automatic regex expression generation using the RegexExpressionFinder class.


Ofcourse it is also possible to create/edit your templates with the *DokuExtractor Standard GUI* and then use those templates from your own code.


## License Information

DokuExtractor is Copyright © 2018-2021 by [KEZIMA dynamics UG (haftungsbeschränkt)](https://kezima-dynamics.de) and is licensed under a Community License. 
This basically means:

-  DokuExtractor licenses are **free for non commercial projects**. 
-  DokuExtractor licenses are **free** for commercial projects for **individual developers and small business**.
-  If you are *not* an individual developer or a small business and want to use DokuExtractor for commercial projects, you have to **purchase** a license.

All DokuExtractor licenses include **royalty free deployment**.

For more detailed information please refer to the [LICENSE.md](https://github.com/KEZIMAdynamics/DokuExtractor/blob/master/LICENSE.md) file in this repository.

