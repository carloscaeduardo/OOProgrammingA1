using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //enable to read/write files

namespace DeCarvalhoAlvesLab1
{
    class Program
    {
        //Create a class level constant SIZE
        const int SIZE = 12;






        static void Main(string[] args)
        {
            //Declare companiesArray to hold strings
            string[] companiesArray;
            //Assign companiesArray:
            companiesArray = new string[12];
            //Declare listingsArray to store integers
            int[] listingsArray;
            //Assign listingsArray
            listingsArray = new int[12];

            //Test readCompanies
            ReadCompanies(companiesArray);
            //Test readlistings
            ReadListings(listingsArray);


            //Create an output file within main named AlvesLab1.txt
            StreamWriter outputFile = new StreamWriter(@"c:\files\AlvesLab1.txt"); // declaration

            string firstName = "Carlos", lastName ="Alves" ;
            
            outputFile.WriteLine(String.Format("{0,50}", "Listings"));
            outputFile.WriteLine(String.Format("{0,50}", "========"));
            outputFile.WriteLine(String.Format("{0,20}", "Created by: " + firstName + " " + lastName + "\n"));
            outputFile.WriteLine(String.Format("{0,30}{1, 45}\n", "Listings","Companies"));
            outputFile.WriteLine(String.Format("{0,30}{1, 45}\n", "********", "*********"));

            //make a for loop to show listings and companies
            int i = 0;
            for(i = 0; i < SIZE; i ++  )
            {
                outputFile.WriteLine(String.Format("{0,30}{1, 45}\n", companiesArray[i], listingsArray[i]));
               
            }
            outputFile.WriteLine(String.Format("{0,10}", "Average Number of Listings: 99.99 \n"));
            outputFile.WriteLine(String.Format("{0,5}", "High Performers: 9"));
            //Close the file (and save)
            outputFile.Close();
            //Wait for an input to close the window
            Console.ReadKey();


        }


        /* Name: ReadCompanies
        * Sent: str[] companiesArray
        * Returned: bool 
        * Description: Return true if the file opens and place the data in companiesArray, else, 
        * return false
        */
        private static bool ReadCompanies(string[] companiesArray)
        {
            //stub
            //Console.WriteLine("ReadCompanies is working!");

            // directory of the file in the system
            string filedir = @"c:\files\";
            // the txt file path in the system
            string filepath = filedir + "Companies.txt";
            try
            {   
                //Read the txt file
                StreamReader inputFile = new StreamReader(filepath);

                //create a counter
                int index = 0;
                while (inputFile.Peek()!= -1)
                {
                    //add the line to the CompaniesArray
                    companiesArray[index] = inputFile.ReadLine();
                    //test
                    //Console.Write(companiesArray[index] + "\n");
                    //add 1 to counter
                    index++;
                }
                Array.Sort(companiesArray);
                return true;
            }
            catch (Exception ex)
            {
                //Show error in console:
                Console.WriteLine(ex.Message);

                return false;
            }
            

            
        }
        /* Name: ReadListings
         * Sent: listingArray   
         * Returned: bool
         * Description: Return false if there is some problem with file, else return true and read the data 
         * from Listings.txt, placing its values in listingArray.
         */
        private static bool ReadListings(int[] listingsArray)
        {
            // directory of the file in the system
            string filedir = @"c:\files\";
            // the txt file path in the system
            string filepath = filedir + "Listings.txt";

            try
            {
                // index counter for the while
                int index = 0;
                // Read the txt file
                StreamReader inputFile = new StreamReader(filepath);
                
                while(inputFile.Peek() != -1 && index < SIZE)
                {
                    //send the data from the txt to the array
                    listingsArray[index] =Convert.ToInt32( inputFile.ReadLine());
                    //Console.Write(listingsArray[index] + "\n");
                    index ++;
                    //Console.Write("the index is: " + index);
                    
                }
                
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }
            
        }
    }
}
