using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Tiles
{
    public class Logger
    {
        private static readonly ArrayList array = new ArrayList();


        public static void Log(string msg)
        {
            array.Add(msg);
        }

        public static string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("-------------LOG-------------");
            stringBuilder.AppendLine("Num:\t" + "Time:\t" + "Message...........");

            for (var i = 0; i < array.Count; i++) stringBuilder.AppendLine(i + ":\t" + "[" + DateTime.Now + "]\t" + array[i]);

            return stringBuilder.ToString();
        }

        public static void Print()
        {
            Console.Out.Write(ToString());
        }

        public static void WriteToFile(string filename)
        {
            if (!File.Exists(filename))
                using (var fs = File.Create(filename))
                {
                    fs.Flush();
                }

            using (var writer = new StreamWriter(filename))
            {
                writer.Flush();
                writer.Write(ToString());
            }
        }
    }
}