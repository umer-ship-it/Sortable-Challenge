using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Sortable_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reading Json into a string

            string Product_Text = File.ReadAllText(@"C:\Users\Umer\Desktop\products.txt"); 
            string Listing_Text = File.ReadAllText(@"C:\Users\Umer\Desktop\listings.txt");

            //Serializing the String 

            var Product_List = JsonExtensions.FromDelimitedJson<Product>(new StringReader(Product_Text)).ToList();
            var Listing_List = JsonExtensions.FromDelimitedJson<Listing>(new StringReader(Listing_Text)).ToList();


            foreach (var Listing_iterator in Listing_List) //Starting a loop from the Listing
            {
                foreach (var Product_iterator in Product_List) //Starting a inner loop from Product
                {
                    //Check to see if Manufactuer from Listing = Manufacture from Product

                    if (Listing_iterator.manufacturer.Equals(Product_iterator.manufacturer))
                    {
                        //Store Title of Listing List into splittingWord
                        var splittingWord = Listing_iterator.title;
                        //Replace the commas in the title with spaces 
                        splittingWord = splittingWord.Replace(',', ' ');
                        //Now split into seperate words based on spaces and store in array
                        string[] splittingArray = splittingWord.Split(' ');

                        //Now for ever seperate word in the array 
                        foreach (var temp in splittingArray)
                        {
                            //Compare the seperate words with model values from Product List 
                            if (temp.Equals(Product_iterator.model))
                            {
                                //Because they are now equal, (we ignore family), we can serialize them
                                //Create an object for Results
                                Results serializer = new Results();
                                serializer.Product_name = Listing_iterator.title; //This will serve as the Product Name in Results
                                List<string> Seralize_List = new List<string>(); //Declared new List 

                                //Adding correspoding manufacture, model and family into list
                                Seralize_List.Add(Product_iterator.manufacturer);
                                Seralize_List.Add(Product_iterator.model);
                                Seralize_List.Add(Product_iterator.family);

                                serializer.listing = Seralize_List; //The object serializer now has the List too

                                //Now we want to create a new file or add to exisiting one
                                using (StreamWriter file = File.AppendText(@"C:\Users\Umer\Desktop\Results.txt"))
                                {
                                    JsonSerializer serializer2 = new JsonSerializer();
                                    serializer2.Serialize(file, serializer); //We sent the "serializer" that contains both product name and list
                                }




                            }
                        }
                    }
                }
        }   }   
   }
}
