using System;
using System.Collections.Generic;
using System.IO;

namespace Toolificent
{
    public class IO
    {
        public static List<string> ReadFile(string fileName)
        {
            List<string> lines = new List<string>();
            StreamReader file = new StreamReader(fileName);
            string line;

            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }

        public static void WriteFile<T>(string fileName, T data)
        {
            StreamWriter fWrite = new StreamWriter(fileName);
            fWrite.WriteLine(data.ToString());
        }

        public static void WriteFile<T>(string fileName, List<T> data)
        {
            StreamWriter fWrite = new StreamWriter(fileName);
            foreach (T item in data)
            {
                fWrite.WriteLine(item.ToString());
            }
        }

        public static void WriteFile<K, V>(string fileName, Dictionary<K, V> data)
        {
            StreamWriter fWrite = new StreamWriter(fileName);
            foreach (KeyValuePair<K, V> item in data)
            {
                fWrite.WriteLine(item.Key.ToString() + "::" + item.Value.ToString());
            }
        }

        public static void WriteFile<K, V>(string fileName, Dictionary<K, V> data, string seperator)
        {
            StreamWriter fWrite = new StreamWriter(fileName);
            foreach (KeyValuePair<K, V> item in data)
            {
                fWrite.WriteLine(item.Key.ToString() + seperator + item.Value.ToString());
            }
        }

        public static Dictionary<string, string> ReadKeyPair(string fileName, string seperator)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            string[] stringSeperator = { seperator };

            foreach (string s in ReadFile(fileName))
            {
                string[] line = s.Split(stringSeperator, StringSplitOptions.RemoveEmptyEntries);
                keyValuePairs.Add(line[0], line[1]);
            }


            return keyValuePairs;
        }

        public static Dictionary<string, string> ReadKeyPair(string fileName)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            string[] stringSeperator = { "::" };

            foreach (string s in ReadFile(fileName))
            {
                string[] line = s.Split(stringSeperator, StringSplitOptions.RemoveEmptyEntries);
                keyValuePairs.Add(line[0], line[1]);
            }

            return keyValuePairs;
        }

        public static bool CheckExists(string fileName)
        {
            FileInfo fInfo = new FileInfo(fileName);
            return fInfo.Exists;
        }

        public static void AddFile(string fileName)
        {
            if (!CheckExists(fileName))
            {
                new FileStream(fileName, FileMode.Create);
            }
            else
            {
                throw new Exception(String.Format("File Already Exists. ({0})", fileName));
            }
        }

        public static void RemoveFile(string fileName)
        {
            if (CheckExists(fileName))
            {
                File.Delete(fileName);        
            }
            else
            {
                throw new Exception(String.Format("File does not Exist. ({0})", fileName));
            }
        }
    }
}
