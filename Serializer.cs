using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Schichtplan
{
    internal class Serializer
    {

        private static Serializer serializer;

        /// <summary>
        /// checks if the serializer object exists and creates it if not, then returns the object
        /// </summary>
        /// <returns>returns the serializer object</returns>
        public static Serializer Instance()
        {
            if(serializer == null)
            {
                serializer = new Serializer();
            }
            return serializer;
        }

        /// <summary>
        /// creates a directory in a given path
        /// </summary>
        /// <param name="path">the path in which the dir should be created</param>
        public void createDir(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// writes a binary object to a file and saves it in a given path
        /// </summary>
        /// <param name="path">the path to save the file</param>
        /// <param name="o">the object to be written</param>
        public void saveObject(string path, object o)
        {
            Stream s = new FileStream(path, FileMode.Create, FileAccess.Write);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, o);
            s.Close();
        }

        /// <summary>
        /// loads an object read from a file of a given path
        /// </summary>
        /// <param name="path">filepath to the file, from which to read the object</param>
        /// <returns>the read object from the file</returns>
        public object loadObject(string path)
        {
            Stream s = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            object o = b.Deserialize(s);
            s.Close();

            return o;
        }

        /// <summary>
        /// checks if a file exists in a given path
        /// </summary>
        /// <param name="path">path to be checked</param>
        /// <returns>if the file at the given path exists</returns>
        public bool fileExists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// writes text to a file at a given path
        /// </summary>
        /// <param name="filePath">path of the file</param>
        /// <param name="content">content to be written in the file</param>
        public void writeToFile(string filePath, string content)
        {
            try
            {
                // write the content to the file
                File.WriteAllText(filePath, content);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing to file: " + e.Message);
            }
        }

    }
}
