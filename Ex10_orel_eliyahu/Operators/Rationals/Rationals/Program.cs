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
                return Numerator / (double)denominator;
            }
        }

        public Rational(int _numerator, int _denominator)
        {
            if (_denominator == 0)
            {
                _denominator = 1;
            }
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
            result = new Rational(first.Numerator * second.Numerator, first.Denominator * second.Denominator);
            return result;

        }
        public static Rational Sub(Rational first, Rational second)
        {
            Rational result;

            int newDenominator = first.Denominator * second.Denominator;
            result = new Rational(first.Numerator * second.Denominator - second.Numerator * first.Denominator, newDenominator);

            return result;

        }
        public static Rational Div(Rational first, Rational second)
        {
            Rational result;
            result = new Rational(first.Numerator * second.Denominator, first.Denominator * second.Numerator);
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
            return other.Number == this.Number;

        }
        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        // operators
        public static Rational operator + (Rational first, Rational second)
        {
            return Add(first,second);
        }
        public static Rational operator - (Rational first, Rational second)
        {
            return Sub(first, second);
        }
        public static Rational operator * (Rational first, Rational second)
        {
            return Mul (first, second);
        }
        public static Rational operator / (Rational first, Rational second)
        {
            return Div (first, second);
        }

        public static implicit operator double(Rational r)
        {
            return r.Number;
        }
        public static implicit operator Rational(int i)
        {
            return new Rational(i);
        }

    };

    class Program
    {


        static void Main(string[] args)
        {
            Rational r1 = new Rational(7, 8);
            Rational r2 = new Rational(5, 10);
            Rational r3 = r1 + r2;
            Console.WriteLine($"{r1} + {r2} = {r3}");
            r3 = r1 - r2;
            Console.WriteLine($"{r1} - {r2} = {r3}");
            r3 = r1 * r2;
            Console.WriteLine($"{r1} * {r2} = {r3}");
            r3 = r1 / r2;
            Console.WriteLine($"{r1} / {r2} = {r3}");
            r3 = 6;
            Console.WriteLine($"6 = {r3}");
            double toDouble = r1;
            Console.WriteLine($"{r1} = {toDouble}");




        }
    }
}
