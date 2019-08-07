Sortable Challenge 
Intro:
This is my attempt at solving the Sortable Coding Challenge (https://sortable.com/coding-challenge). The language that I have written my code in is C#. 
Running:
To run the program simply clone my respoitory (https://github.com/umer-ship-it/Sortable-Challenge) run sortable_challenge.csproj.
The Challenge:
The goal is to match product listings from a 3rd party retailer, e.g. “Nikon D90 12.3MP Digital SLR Camera (Body Only)” against a set of known products, e.g. “Nikon D90”.
We’ll provide you with a set of products and a set of price listings matching some of those products. The task is to match each listing to the correct product. Precision is critical. We much prefer missed matches (lower recall) over incorrect matches, so try hard to avoid false positives. A single price listing may match at most one product.
Input and Output:
The inputs and outputs for this challenge are in the so-called JSON lines format.  That is, one valid JSON object per line, with newline separators.
Details
Data Objects
Product
{
"product_name": String // A unique id for the product
"manufacturer": String
"family": String // optional grouping of products
"model": String
"announced-date": String // ISO-8601 formatted date string, e.g. 2011-04-28T19:00:00.000-05:00
}

Listing
{
"title": String // description of product for sale
"manufacturer": String // who manufactures the product for sale
"currency": String // currency code, e.g. USD, CAD, GBP, etc.
"price": String // price, e.g. 19.99, 100.00
}

Result
A file full of Result objects is what your solution will be generating. A Result simply associates a Product with a list of matching Listing objects.
{
"product_name": String
"listings": Array[Listing]
}

Challenge Data
Contains two files:
products.txt – Contains around 700 products
listings.txt – Contains about 20,000 product listings
Download the data from the repositroy.
Input Files
Products file (products.txt)
Text file with one Product object per line.

Listings file (listings.txt)
Text file with one Listing object per line.

Output File
The output your solution creates should be a text file with one Result object per line.
