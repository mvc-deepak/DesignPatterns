using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        //Added Comments Test
        static void Main(string[] args)
        {
            //Cannot create an instance of the abstract class or interface
            //var factory = new  ICreditUnionFactory();

            //Convert type SavingsAcctFactory to ICreditUnionFactory 
            //via a reference conversion, boxing conversion, unboxing conversion, wrapping conversion, or null type conversion 
            //var factory = new SavingsAcctFactory();
            //ICreditUnionFactory factory = new SavingsAcctFactory();
            var factory = new SavingsAcctFactory() as ICreditUnionFactory;
            Console.WriteLine(factory.GetType()); //FactoryMethod.SavingsAcctFactory
            
            //Local Variable 
            ICreditUnionFactory creditunionfactory;
            //Console.WriteLine(creditunionfactory.GetType()); //Use of unassigned local variable 'creditunionfactory' 

             creditunionfactory=null;
             //Console.WriteLine(creditunionfactory.GetType()); //System.NullReferenceException: 'Object reference not set to an instance of an object.' creditunionfactory was null.

            creditunionfactory = factory; //Convert type SavingsAcctFactory to ICreditUnionFactory
            Console.WriteLine(factory.GetType()); //FactoryMethod.SavingsAcctFactory

            var citiAcct = factory.GetSavingsAccount("CITI-321");
            var nationalAcct = factory.GetSavingsAccount("NATIONAL-987");

            Console.WriteLine($"My citi balance is ${citiAcct.Balance}" +
                $" and national balance is ${nationalAcct.Balance}");

            // Interface Basics
            var factory2 = new SavingsAcctFactory();
            var f2 = factory2.GetSavingsAccount(null);
            var f22 = factory2.GetSavingsAccount2(null);

            var factory3 = new SavingsAcctFactory() as ICreditUnionFactory2;
            var f3 = factory3.GetSavingsAccount2(null);
            //ICreditUnionFactory2' does not contain a definition for 'GetSavingsAccount' and 
            //no extension method 'GetSavingsAccount' accepting a first argument of type 'ICreditUnionFactory2' could be found(are you missing a using directive or an assembly reference
            //var f33 = factory3.GetSavingsAccount(null);

            Console.Read();
        }
    }

    // Product
    public abstract class ISavingsAccount
    {
        public decimal Balance { get; set; }
    }

    // Concrete Product
    public class CitiSavingsAcct : ISavingsAccount
    {
        public CitiSavingsAcct()
        {
            Balance = 5000;
        }
    }

    // Concrete Product
    public class NationalSavingsAcct : ISavingsAccount
    {
        public NationalSavingsAcct()
        {
            Balance = 2000;
        }
    }

    // Creator
    interface ICreditUnionFactory
    {
        ISavingsAccount GetSavingsAccount(string acctNo);
    }

    // Creator
    interface ICreditUnionFactory2
    {
        ISavingsAccount GetSavingsAccount2(string acctNo);
    }

    // Concrete Creators
    public class SavingsAcctFactory : ICreditUnionFactory, ICreditUnionFactory2
    {
        public ISavingsAccount GetSavingsAccount(string acctNo)
        {
            if (acctNo.Contains("CITI"))
            {
                //ISavingsAccount citisavingaccount = new CitiSavingsAcct();
                //return citisavingaccount;
                return new CitiSavingsAcct();
            }
            else if (acctNo.Contains("NATIONAL"))
            {
                //ISavingsAccount nationalsavingaccount = new NationalSavingsAcct();
                //return nationalsavingaccount;
                return new NationalSavingsAcct();
            }
            else
            {
                throw new ArgumentException("Invalid Account Number");
            }
        }
        public ISavingsAccount GetSavingsAccount2(string acctNo)
        {
            return null;
        }
    }
}
