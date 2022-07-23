using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

namespace Dariusz_Chmiel_LAB1
{
    public class Fraction : IEquatable<Fraction>, IComparable
    {
        private int counter { get; }
        private int denominator { get; }


        public Fraction()
        {
            counter = 0;
            denominator = 0;
        }

        public Fraction(int counter, int denominator)
            {
            this.counter = counter;
            this.denominator = denominator;
            }

        public Fraction(Fraction _fractrion)
        {
            this.counter = _fractrion.counter;
            this.denominator = _fractrion.denominator;
        }

        public override string ToString()
        {
            return "Counter: " + GetCounter() + "; Denominator: " + GetDenominator();
        }

        public int GetCounter()
        {
            return counter;
        }
        public int GetDenominator()
        {
            return denominator;
        }

        public bool Equals([AllowNull] Fraction other)
        {
            return other.GetCounter() / other.GetDenominator() == GetCounter() / GetDenominator();
        }

        public float ToDecimals()
        {
            return (float)GetCounter() / (float)GetDenominator();
        }

        public int CompareTo(object ob)
        {
            if (ob == null) return 1;
            Fraction otherFraction = ob as Fraction;
            if (otherFraction != null)
            {
                return ToDecimals().CompareTo(otherFraction.ToDecimals());
            }
            throw new NotImplementedException();
        }

        public int Ceiling()
        {
            return (int)MathF.Ceiling(ToDecimals());
        }

        public int Floor()
        {
            return (int)MathF.Floor(ToDecimals());
        }
        public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a.counter * b.denominator + b.counter * a.denominator, a.denominator * b.denominator);

        public static Fraction operator -(Fraction a) => new Fraction(-a.counter, a.denominator);
        public static Fraction operator -(Fraction a, Fraction b) => a + (-b);
        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.counter * b.counter, a.denominator * b.denominator);
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.counter == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.counter * b.denominator, a.denominator * b.counter);
        }

        static void Main(string[] args)
        {
            List<Fraction> fractionList = new List<Fraction>();
            Fraction a1 = new Fraction(1, 9);
            Fraction a2 = new Fraction(1, 2);
            Fraction a3 = new Fraction(1, 60);

            fractionList.Add(a2);
            fractionList.Add(a3);
            fractionList.Add(a1);

            Console.WriteLine("Before sorting:");
            foreach (Fraction f in fractionList)
            {
                Console.WriteLine(f.ToString());
            }

            Console.WriteLine("After sorting:");
            fractionList.Sort();
            foreach (Fraction f in fractionList)
            {
                Console.WriteLine(f.ToString());
            }
            Console.ReadKey();
        }
    }
}