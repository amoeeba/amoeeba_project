﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace deserialDAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Serialize();
        }

        static void Serialize()
        {
            // Create a hashtable of values that will eventually be serialized.
            Hashtable addresses = new Hashtable();
            addresses.Add("Jeff", "123 Main Street, Redmond, WA 98052");
            addresses.Add("Fred", "987 Pine Road, Phila., PA 19116");
            addresses.Add("Mary", "PO Box 112233, Palo Alto, CA 94301");

            // To serialize the hashtable and its key/value pairs,   
            // you must first open a stream for writing.  
            // In this case, use a file stream.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, addresses);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
