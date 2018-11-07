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

### DokuExtractor Standard GUI

![dokuextractor gui](/docs/DokuExtractorGUI.png)

### Data extraction

![extraction process](/docs/ExtractionProcess.png)

### Templates

![field templates](/docs/FieldTemplates.png)

### DokuExtractor Code

Comming soon...

## License Information

DokuExtractor is Copyright © 2018 by [KEZIMA dynamics UG (haftungsbeschränkt)](https://kezima-dynamics.de) and is licensed under a Community License. 
This basically means:

-  DokuExtractor licenses are **free for non commercial projects**. 
-  DokuExtractor licenses are **free** for commercial projects for **individual developers and small business**.
-  If you are *not* an individual developer or a small business and want to use DokuExtractor for commercial projects, you have to **purchase** a license.

For more detailed information please refer to the [LICENSE.md](https://github.com/KEZIMAdynamics/DokuExtractor/blob/master/LICENSE.md) file in this repository.




> EOF
> 
> Markdown samples:

++d++
==d==
^k^
~d~
~~bb~~

```Csharp
private void SomeThing()
{
int foo = new object();
string.IsnullOrEmpty(x);
} 
```

* asdf
* asdfasdf
* asdfsad
  * asasdf
  * asdfasdf
  * asdfasd
    * asdfasdfasd

```javascript
function fancyAlert(arg) {
  if(arg) {
    $.facebox({div:'#foo'})
  }
}
```

### 1. adsfasdf
2. asdfasdf
   1. __*adfasdf*__
   2. df
   3. dfasdf
      1. asdfasdf

