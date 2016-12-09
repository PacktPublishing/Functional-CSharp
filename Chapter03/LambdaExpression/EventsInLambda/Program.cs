using System;

namespace EventsInLambda
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //CreateAndRaiseEvent();
            //CreateAndRaiseEvent2();
            CreateAndRaiseEvent3();
        }
    }

    public partial class Program
    {
        private static void CreateAndRaiseEvent()
        {
            EventClassWithoutEvent ev = new EventClassWithoutEvent();
            ev.OnChange += () => 
                Console.WriteLine("1st: Event raised");
            ev.OnChange += () => 
                Console.WriteLine("2nd: Event raised");
            ev.OnChange += () => 
                Console.WriteLine("3rd: Event raised");
            ev.OnChange += () =>
                Console.WriteLine("4th: Event raised");
            ev.OnChange += () => 
                Console.WriteLine("5th: Event raised");
            ev.Raise();
        }
    }

    public class EventClassWithoutEvent
    {
        public Action OnChange { get; set; }
        public void Raise()
        {
            if (OnChange != null)
            {
                OnChange();
            }
        }
    }

    public class EventClassWithEvent
    {
        public event Action OnChange = () => { };

        public void Raise()
        {
            OnChange();
        }
    }

    public partial class Program
    {
        private static void CreateAndRaiseEvent2()
        {
            EventClassWithEvent ev = new EventClassWithEvent();
            ev.OnChange += () =>
                Console.WriteLine("1st: Event raised");
            ev.OnChange += () =>
                Console.WriteLine("2nd: Event raised");
            ev.OnChange += () =>
                Console.WriteLine("3rd: Event raised");
            ev.OnChange += () =>
                Console.WriteLine("4th: Event raised");
            ev.OnChange += () =>
                Console.WriteLine("5th: Event raised");
            ev.Raise();
        }
    }

    public partial class Program
    {
        private static void CreateAndRaiseEvent3()
        {
            EventClassWithoutEvent ev = new EventClassWithoutEvent();
            ev.OnChange += () =>
                Console.WriteLine("1st: Event raised");
            ev.OnChange += () =>
                Console.WriteLine("2nd: Event raised");
            ev.OnChange += () =>
                Console.WriteLine("3rd: Event raised");
            ev.OnChange();
            ev.OnChange += () =>
                Console.WriteLine("4th: Event raised");
            ev.OnChange += () =>
                Console.WriteLine("5th: Event raised");
            ev.Raise();
        }
    }

    public partial class Program
    {
        private static void CreateAndRaiseEvent4()
        {
            EventClassWithEvent ev = new EventClassWithEvent();
            ev.OnChange += () =>
                Console.WriteLine("1st: Event raised");
            ev.OnChange += () =>
                Console.WriteLine("2nd: Event raised");
            ev.OnChange += () =>
                Console.WriteLine("3rd: Event raised");
            ev.OnChange += () =>
                Console.WriteLine("4th: Event raised");
            ev.OnChange += () =>
                Console.WriteLine("5th: Event raised");
            ev.Raise();
        }
    }
}
