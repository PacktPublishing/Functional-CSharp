using System;
using System.Linq;
using System.Text;

namespace FunctionalCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Disposable
                .Using(
                    Utility.GeneratePlanetsStream,
                    stream => new byte[stream.Length]
                        .Tee(b => stream.Read(
                            b, 0, (int)stream.Length)))
                .Map(Encoding.UTF8.GetString)
                .Split(new[] { Environment.NewLine, },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select((s, ix) => Tuple.Create(ix, s))
                .ToDictionary(k => k.Item1, v => v.Item2)
                .Map(options => Utility.GenerateOrderedList(
                    options, "thePlanets", true))
                .Tee(Console.WriteLine);
        }
    }
}
