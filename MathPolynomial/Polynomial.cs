using System;
using System.Linq;

namespace MathPolynomial
{
    public class Polynomial
    {
        public int Degree { get; private set; }

        public double[] Coeffs { get; private set; }

        public double this[int i] => Coeffs[i];

        public Polynomial(params double[] coeffs)
        {
            Coeffs = coeffs;
            Degree = Coeffs.Length;
        }

        public Polynomial(int degree, params double[] coeffs)
        {
            Degree = degree;
            Coeffs = coeffs;
        }

        private static int MaxDegreeOfTwoPolynomials(Polynomial p1, Polynomial p2) => Math.Max(p1.Coeffs.Length, p2.Coeffs.Length);

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            double[] result = new double[MaxDegreeOfTwoPolynomials(p1, p2)];
            for (int i = 0; i < result.Length; i++)
            {
                double x = 0;
                double z = 0;
                if (i < p1.Coeffs.Length)
                    z = p1[i];
                if (i < p2.Coeffs.Length)
                    x = p2[i];
                result[i] = z + x;
            }
            return new Polynomial(result);
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            double[] result = new double[MaxDegreeOfTwoPolynomials(p1, p2)];
            for (int i = 0; i < result.Length; i++)
            {
                double z = 0;
                double x = 0;
                if (i < p1.Coeffs.Length)
                    z = p1[i];
                if (i < p2.Coeffs.Length)
                    x = p2[i];
                result[i] = z - x;
            }
            return new Polynomial(result);
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            double[] result = new double[p1.Coeffs.Length + p2.Coeffs.Length - 1];
            for (int i = 0; i < p1.Coeffs.Length; i++)
            {
                for (int j = 0; j < p2.Coeffs.Length; j++)
                {
                    result[i + j] += p1[i] * p2[j];
                }
            }
            return new Polynomial(result);
        }

        public static Polynomial operator *(Polynomial p, double number)
        {
            double[] result = new double[p.Coeffs.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] *= number;
            }

            return new Polynomial(result);
        }

        public static Polynomial operator /(Polynomial p, double number)
        {
            double[] result = new double[p.Coeffs.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] /= number;
            }

            return new Polynomial(result);
        }

        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if (p1.Coeffs.Length != p2.Coeffs.Length)
            {
                return false;
            }

            for (int i = 0; i < p1.Coeffs.Length; i++)
            {
                if (p1[i] != p2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(Polynomial p1, Polynomial p2) => !(p1 == p2);

        public override bool Equals(object obj) => obj is Polynomial polynomial && Degree == polynomial.Degree && Enumerable.SequenceEqual(Coeffs, polynomial.Coeffs);

        public override int GetHashCode() => Degree.GetHashCode() + Coeffs.GetHashCode();
    }
}