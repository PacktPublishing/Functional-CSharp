using System;

namespace SimpleLazyEvaluation
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //GetMember();
            GetMemberANDOperator();
        }
    }

    public partial class Program
    {
        private static MemberData GetMember()
        {
            MemberData member = null;
            try
            {
                if (member != null || member.Age > 50)
                {
                    Console.WriteLine("IF Statement is TRUE");
                    return member;
                }
                else
                {
                    Console.WriteLine("IF Statement is FALSE");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                return null;
            }
        }
    }

    public partial class Program
    {
        private static MemberData GetMemberANDOperator()
        {
            MemberData member = null;
            try
            {
                if (member != null && member.Age > 50)
                {
                    Console.WriteLine("IF Statement is TRUE");
                    return member;
                }
                else
                {
                    Console.WriteLine("IF Statement is FALSE");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                return null;
            }
        }
    }

    public class MemberData
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
