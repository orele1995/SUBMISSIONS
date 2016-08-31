using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    struct Rational
    {
        int denominator;
        int numerator;

        public int Denominator
        {
            get
            {
                return denominator;
            }

            set
            {
                if (value != 0)
                    denominator = value;
                else
                    denominator = 1;
            }
        }
        public int Numerator
        {
            get
            {
                return numerator;
            }

            set
            {
                numerator = value;
            }
        }
        public double Number
        {
            get
            {
                return Numerator / denominator;
            }
        }

        public Rational(int _numerator, int _denominator)
        {
            denominator = _denominator;
            numerator = _numerator;
        }
        public Rational(int _numerator)
        {
            denominator = 1;
            numerator = _numerator;
        }

        public static Rational Add(Rational first, Rational second)
        {
            Rational result;
         
            int newDenominator = first.Denominator * second.Denominator;
            result = new Rational(first.Numerator * second.Denominator + second.Numerator * first.Denominator, newDenominator);
    

            return result;

        }
        public static Rational Mul(Rational first, Rational second)
        {
            Rational result;
            result = new Rational( first.Numerator * second.Numerator, first.Denominator * second.Denominator);
            return result;

        }

        public void Reduce()
        {
            int num = Denominator < numerator ? Denominator : Numerator;
            for (int i = num; i > 0; i--)
            {
                if (Denominator % i == 0 && Numerator % i == 0)
                {
                    denominator = denominator / i;
                    numerator = numerator / i;
                }
            }
        }

        //override
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            Rational other = (Rational)obj;
            Rational temp1 = new Rational(Numerator, Denominator);
            Rational temp2 = new Rational(other.Numerator, other.Denominator);
            temp1.Reduce(); temp2.Reduce();
            return (temp1.Numerator == temp2.Numerator && temp1.Denominator == temp2.Denominator);

        }
        public override string ToString()
        {
            return Numerator+"/"+Denominator;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    };

    class Program
    {


        static void Main(string[] args)
        {
            Rational r1 = new Rational(7, 8);
            Rational r2 = new Rational(5, 10);

            // add and mult
            Rational r3 = Rational.Add(r1, r2);
            Rational r4 = Rational.Mul(r1, r2);
            Console.WriteLine(r1 + " + " + r2 + " = " + r3);
            Console.WriteLine(r1 + " * " + r2 + " = " + r4);

            // reduce
            Console.Write(r1 + " = ");
            r1.Reduce();
            Console.WriteLine(r1);
            Console.Write(r2 + " = ");
            r2.Reduce();
            Console.WriteLine(r2);
            Console.Write(r3 + " = ");
            r3.Reduce();
            Console.WriteLine(r3);
            Console.Write(r4 + " = ");
            r4.Reduce();
            Console.WriteLine(r4);

            // equlas
            if (r3.Equals(r4))
            {
                Console.WriteLine(r3 + "=" + r4);
            }
            else {
                Console.WriteLine(r3 + "!=" + r4);
            }
            r1 = new Rational(7, 8);
            r2 = new Rational(5, 10);
            if (Rational.Mul(r1, r2).Equals(r4))
            {
                Console.WriteLine(Rational.Mul(r1, r2) + " = " + r4);
            }
            else {
                Console.WriteLine(Rational.Mul(r1, r2) + " != " + r4);
            }

        }
    }
}
