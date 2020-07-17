using System;
using System.Collections.Generic;
using System.Linq;

namespace MathPolynomial
{
    /// <summary>
    /// Сlass that describes working with a polynomial
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// Degree of the polynomial
        /// </summary>
        public int Degree { get; private set; }

        /// <summary>
        /// Coefficients of the polynomial
        /// </summary>
        public double[] Coeffs { get; private set; }

        /// <summary>
        /// Indexer for getting the coefficient of a polynomial
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Coefficient</returns>
        public double this[int i]
        {
            get
            {
                if (i < Coeffs.Length)
                {
                    return Coeffs[i];
                }

                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Constructor for creating an object of the Polynomial class that takes coefficient values
        /// </summary>
        /// <param name="coeffs"></param>
        public Polynomial(params double[] coeffs)
        {
            Coeffs = coeffs;
            Degree = Coeffs.Length;
        }

        /// <summary>
        /// Search for the maximum degree of two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>Maximum degree</returns>
        private static int GetMaxDegreeOfTwoPolynomials(Polynomial p1, Polynomial p2) => Math.Max(p1.Coeffs.Length, p2.Coeffs.Length);

        /// <summary>
        /// Overloaded binary operator "+" two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>Sum of polynomials</returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            double[] result = new double[GetMaxDegreeOfTwoPolynomials(p1, p2)];
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

        /// <summary>
        /// Overloaded binary operator "-" two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>Subtraction of polynomials</returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            double[] result = new double[GetMaxDegreeOfTwoPolynomials(p1, p2)];
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

        /// <summary>
        /// Overloaded binary operator "*" two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>Multiplication of polynomials</returns>
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

        /// <summary>
        /// Overloaded binary operator "/" two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>Division of polynomials</returns>
        public static Polynomial operator /(Polynomial p1, Polynomial p2)
        {
            int currentDegree = p1.Coeffs.Length + 1;
            List<double> coefficients = new List<double>();
            List<double> result = p1.Coeffs.ToList();

            for (int i = 0; i <= p1.Coeffs.Length - p2.Coeffs.Length; i++)
            {
                if (currentDegree < 0)
                {
                    coefficients.Add(result[i] / p2.Coeffs[0]);
                }
                else
                {
                    coefficients.Add(result[i] / p2.Coeffs[0]);
                    for (int j = 0; j < p2.Coeffs.Length; j++)
                    {
                        result[i + j] = result[i + j] - (coefficients[i] * p2.Coeffs[j]);
                    }
                    currentDegree--;
                }
            }

            result.RemoveAll(r => r == 0d);
            result = result.Select(r => Math.Round(r, 2)).ToList();
            result.RemoveAll(r => r == 0d);
            return new Polynomial(result.ToArray());
        }

        /// <summary>
        /// Overloaded binary operator "*" between polynomial and a number
        /// </summary>
        /// <param name="p1">Polynomial</param>
        /// <param name="p2">Number</param>
        /// <returns>Multiplication of a polynomial and a number</returns>
        public static Polynomial operator *(Polynomial p, double number)
        {
            double[] result = p.Coeffs;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] *= number;
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Overloaded binary operator "/" between polynomial and a number
        /// </summary>
        /// <param name="p1">Polynomial</param>
        /// <param name="p2">Number</param>
        /// <returns>Divison of a polynomial and a number</returns>
        public static Polynomial operator /(Polynomial p, double number)
        {
            if(number == 0d)
            {
                throw new DivideByZeroException("Can't divide by zero");
            }

            double[] result = p.Coeffs;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(result[i] / number, 2);
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Overloaded binary operator "*" between number and polynomial
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="p">Polynomial</param>
        /// <returns>Multiplication of a number and a polynomial</returns>
        public static Polynomial operator *(double number, Polynomial p) => p * number;

        /// <summary>
        /// Overloaded binary operator "/" between number and polynomial
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="p">Polynomial</param>
        /// <returns>Divison of a number and a polynomial</returns>
        public static Polynomial operator /(double number, Polynomial p) => p / number;

        /// <summary>
        /// Overloaded operator "==" for comparing two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>The result of the comparison polynomials</returns>
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

        /// <summary>
        /// Overloaded operator "!=" for comparing two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>The result of the comparison polynomials</returns>
        public static bool operator !=(Polynomial p1, Polynomial p2) => !(p1 == p2);

        public override bool Equals(object obj) => obj is Polynomial polynomial && Degree == polynomial.Degree && Enumerable.SequenceEqual(Coeffs, polynomial.Coeffs);

        public override int GetHashCode() => Degree.GetHashCode() + Coeffs.GetHashCode();
    }
}