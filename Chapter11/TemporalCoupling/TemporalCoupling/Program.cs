using System.Collections.Generic;

namespace TemporalCoupling
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

//public class MembershipDatabase
//{
//    private Address _address;
//    private Member _member;

//    public void Process(
//        string memberName,
//        string addressString)
//    {
//        CreateAddress(
//            addressString);

//        CreateMember(
//            memberName);

//        SaveMember();
//    }

//    private void CreateAddress(
//        string addressString)
//    {
//        _address = new Address(
//            addressString);
//    }

//    private void CreateMember(
//        string name)
//    {
//        _member = new Member(
//            name,
//            _address);
//    }

//    private void SaveMember()
//    {
//        var repository = new Repository();
//        repository.Save(_member);
//    }
//}

public class MembershipDatabase
{
    public void Process(
        string memberName,
        string addressString)
    {
        Address address = CreateAddress(
            addressString);

        Member member = CreateMember(
            memberName,
            address);

        SaveMember(member);
    }

    private Address CreateAddress(
        string addressString)
    {
        return new Address(
            addressString);
    }

    private Member CreateMember(
        string name,
        Address address)
    {
        return new Member(
            name,
            address);
    }

    private void SaveMember(
        Member member)
    {
        var repository = new Repository();
        repository.Save(
            member);
    }
}

public class Address
{
    public string _addressString { get; }

    public Address(
        string addressString)
    {
        _addressString = addressString;
    }
}

public class Member
{
    public string _name { get; }
    public Address _address { get; }

    public Member(
        string name,
        Address address)
    {
        _name = name;
        _address = address;
    }
}

public class Repository
{
    public static List<Member> customers { get; }

    public void Save(
        Member customer)
    {
        customers.Add(customer);
    }
}
