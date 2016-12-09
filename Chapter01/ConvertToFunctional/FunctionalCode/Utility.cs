using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FunctionalCode
{
    public static partial class Utility
    {
        public static string GenerateOrderedList(
            IDictionary<int, string> options,
            string id,
            bool includeSun) =>
                new StringBuilder()
                    .AppendFormattedLine("<ol id=\"{0}\">", id)
                    .AppendWhen(
                        () => includeSun,
                        sb => sb.AppendLine("\t<li>The Sun/li>"))
                    .AppendSequence(
                        options,
                        (sb, opt) =>
                            sb.AppendFormattedLine(
                                "\t<li value=\"{0}\">{1}</li>",
                                opt.Key,
                                opt.Value))
                    .AppendLine("</ol>")
                    .ToString();
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
}
