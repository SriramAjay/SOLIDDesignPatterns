using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Specification_Pattren_EX
{
    public class Mobile
    {
        public BrandName BrandName { get; set; }
        public Type Type { get; set; }
        public int Cost;
        public string GetDescription()
        {
            return "The mobile is of brand : " + this.BrandName + " and of type : " + this.Type;
        }

        public Mobile(BrandName brandName, Type type, int cost = 0)
        {
            this.BrandName = brandName;
            this.Type = type;
            this.Cost = cost;
        }
    }

    public enum BrandName
    {
        Samsung,
        Apple,
        Htc
    }

    public enum Type
    {
        Basic,
        Smart
    }

    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T o);
        ISpecification<T> And(ISpecification<T> specification);
        ISpecification<T> Or(ISpecification<T> specification);
        ISpecification<T> Not(ISpecification<T> specification);
    }

    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T o);

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
        public ISpecification<T> Or(ISpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }
        public ISpecification<T> Not(ISpecification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }
    }

    public class AndSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> leftSpecification;
        ISpecification<T> rightSpecification;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.leftSpecification = left;
            this.rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return this.leftSpecification.IsSatisfiedBy(o)
                && this.rightSpecification.IsSatisfiedBy(o);
        }
    }

    public class OrSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> leftSpecification;
        ISpecification<T> rightSpecification;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.leftSpecification = left;
            this.rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return this.leftSpecification.IsSatisfiedBy(o)
                || this.rightSpecification.IsSatisfiedBy(o);
        }
    }

    public class NotSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> specification;

        public NotSpecification(ISpecification<T> spec)
        {
            this.specification = spec;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return !this.specification.IsSatisfiedBy(o);
        }
    }

    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private Func<T, bool> expression;
        public ExpressionSpecification(Func<T, bool> expression)
        {
            if (expression == null)
                throw new ArgumentNullException();
            else
                this.expression = expression;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return this.expression(o);
        }
    }

    public class PremiumSpecification<T> : CompositeSpecification<T>
    {
        private int cost;
        public PremiumSpecification(int cost)
        {
            this.cost = cost;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return (o as Mobile).Cost >= this.cost;
        }
    }

    class ProgramT
    {
        static void Main(string[] args)
        {
            List<Mobile> mobiles = new List<Mobile> {
                new Mobile(BrandName.Samsung, Type.Smart, 700),
                new Mobile(BrandName.Apple, Type.Smart, 800),
                new Mobile(BrandName.Htc, Type.Basic),
                new Mobile(BrandName.Samsung, Type.Basic) };

            ISpecification<Mobile> samsungExpSpec =
               new ExpressionSpecification<Mobile>(o => o.BrandName == BrandName.Samsung);
            ISpecification<Mobile> htcExpSpec =
               new ExpressionSpecification<Mobile>(o => o.BrandName == BrandName.Htc);
            ISpecification<Mobile> SamsungAndHtcSpec = samsungExpSpec.And(htcExpSpec);


            ISpecification<Mobile> SamsungHtcExpSpec =
               samsungExpSpec.Or(htcExpSpec);
            ISpecification<Mobile> NoSamsungExpSpec = new ExpressionSpecification<Mobile>(o => o.BrandName != BrandName.Samsung);

            ISpecification<Mobile> brandExpSpec = new ExpressionSpecification<Mobile>(o => o.Type == Type.Smart);
            ISpecification<Mobile> premiumSpecification = new PremiumSpecification<Mobile>(600);
            ISpecification<Mobile> complexSpec = (samsungExpSpec.Or(htcExpSpec)).And(brandExpSpec);
            ISpecification<Mobile> linqNonLinqExpSpec = NoSamsungExpSpec.And(premiumSpecification);

            //Some fun
            Console.WriteLine("\n***Samsung mobiles*****\n");
            var result = mobiles.FindAll(o => samsungExpSpec.IsSatisfiedBy(o));
            result.ForEach(o => Console.WriteLine(o.GetDescription()));

            Console.WriteLine("\n*****Htc mobiles********\n");
            result = mobiles.FindAll(o => htcExpSpec.IsSatisfiedBy(o));
            result.ForEach(o => Console.WriteLine(o.GetDescription()));

            Console.WriteLine("\n****Htc and samsung mobiles*******\n");
            result = mobiles.FindAll(o => SamsungHtcExpSpec.IsSatisfiedBy(o));
            result.ForEach(o => Console.WriteLine(o.GetDescription()));

            Console.WriteLine("\n****Not samsung*******\n");
            result = mobiles.FindAll(o => NoSamsungExpSpec.IsSatisfiedBy(o));
            result.ForEach(o => Console.WriteLine(o.GetDescription()));

            Console.WriteLine("\n****Htc and samsung mobiles (only smart)*******\n");
            result = mobiles.FindAll(o => complexSpec.IsSatisfiedBy(o));
            result.ForEach(o => Console.WriteLine(o.GetDescription()));

            //More fun
            Console.WriteLine("\n****All premium mobile phones*******\n");

            result = mobiles.FindAll(o => premiumSpecification.IsSatisfiedBy(o));
            result.ForEach(o => Console.WriteLine(o.GetDescription()));


            Console.WriteLine("\n****All premium mobile phones except samsung*******\n");
            result = mobiles.FindAll(o => linqNonLinqExpSpec.IsSatisfiedBy(o));
            result.ForEach(o => Console.WriteLine(o.GetDescription()));
            Console.ReadLine();






        }

    }



}

