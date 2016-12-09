using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImperativeCode
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] buffer;

            using (var stream = Utility.GeneratePlanetsStream())
            {
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
            }

            var options =
                Encoding
                    .UTF8
                    .GetString(buffer)
                    .Split(new[] { Environment.NewLine, }, 
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select((s, ix) => Tuple.Create(ix, s))
                    .ToDictionary(k => k.Item1, v => v.Item2);

            var orderedList = Utility.GenerateOrderedList(
                options, "thePlanets", true);

            Console.WriteLine(orderedList);
        }
    }

    public static partial class Utility
    {
        public static Stream GeneratePlanetsStream()
        {
            var planets =
                String.Join(
                    Environment.NewLine,
                    new[] {
                        "Mercury", "Venus", "Earth",
                        "Mars", "Jupiter", "Saturn",
                        "Uranus", "Neptune"
                    });

            var buffer = Encoding.UTF8.GetBytes(planets);

            var stream = new MemoryStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Position = 0L;

            return stream;
        }
    }

    public static partial class Utility
    {
        public static string GenerateOrderedList(
            IDictionary<int, string> options, 
            string id, 
            bool includeSun)
        {
            var html = new StringBuilder();
            html.AppendFormat("<ol id=\"{0}\">", id);
            html.AppendLine();

            if (includeSun)
            {
                html.AppendLine("\t<li>The Sun/li>");
            }

            foreach (var opt in options)
            {
                html.AppendFormat("\t<li value=\"{0}\">{1}</li>", 
                    opt.Key, 
                    opt.Value);
                html.AppendLine();
            }

            html.AppendLine("</ol>");

            return html.ToString();
        }
    }
}
