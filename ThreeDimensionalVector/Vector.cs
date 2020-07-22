using System;
using System.Linq;

namespace ThreeDimensionalArray
{
    /// <summary>
    /// Сlass that describes working with a three-dimensional vector
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        public double X { get; private set; } = 0;

        /// <summary>
        /// Y coordinate
        /// </summary>
        public double Y { get; private set; } = 0;

        /// <summary>
        /// Z coordinate
        /// </summary>
        public double Z { get; private set; } = 0;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Vector() { }

        /// <summary>
        /// A parameterized constructor that accepts the coordinates of the vertices
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Vector length
        /// </summary>
        public double Length => Math.Round(Math.Sqrt(X * X) + (Y * Y) + (Z * Z), 2);

        /// <summary>
        /// Overloaded unary operator "+" for three-dimensional vector
        /// </summary>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator +(Vector vectorA) => new Vector(vectorA.X, vectorA.Y, vectorA.Z);

        /// <summary>
        /// Overloaded unary operator "-" for three-dimensional vector
        /// </summary>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator -(Vector vectorA) => new Vector(-vectorA.X, -vectorA.Y, -vectorA.Z);

        /// <summary>
        /// Overloaded unary operator "++" for three-dimensional vector
        /// </summary>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator ++(Vector vectorA) => new Vector(++vectorA.X, ++vectorA.Y, ++vectorA.Z);

        /// <summary>
        /// Overloaded unary operator "--" for three-dimensional vector
        /// </summary>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator --(Vector vectorA) => new Vector(--vectorA.X, --vectorA.Y, --vectorA.Z);

        /// <summary>
        /// Overloaded binary operator "+" for three-dimensional vectors
        /// </summary>
        /// <param name="vectorA">First three-dimensional vector object</param>
        /// <param name="vectorB">Second three-dimensional vector object</param>
        /// <returns>Result of adding vectors</returns>
        public static Vector operator +(Vector vectorA, Vector vectorB) => new Vector(vectorA.X + vectorB.X, vectorA.Y + vectorB.Y, vectorA.Z + vectorB.Z);

        /// <summary>
        /// Overloaded binary operator "-" for three-dimensional vectors
        /// </summary>
        /// <param name="vectorA">First three-dimensional vector object</param>
        /// <param name="vectorB">Second three-dimensional vector object</param>
        /// <returns>The result of the subtraction of vectors</returns>
        public static Vector operator -(Vector vectorA, Vector vectorB) => new Vector(vectorA.X - vectorB.X, vectorA.Y - vectorB.Y, vectorA.Z - vectorB.Z);

        /// <summary>
        /// Overloaded binary operator "*" for three-dimensional vectors
        /// </summary>
        /// <param name="vectorA">First three-dimensional vector object</param>
        /// <param name="vectorB">Second three-dimensional vector object</param>
        /// <returns>The result of the multiplication of vectors</returns>
        public static Vector operator *(Vector vectorA, Vector vectorB) => new Vector((vectorA.Y * vectorB.Z) - (vectorA.Z * vectorB.Y), (vectorA.Z * vectorB.X) - (vectorA.X * vectorB.Z), (vectorA.X * vectorB.Y) - (vectorA.Y * vectorB.X));

        /// <summary>
        /// Overloaded binary operator "/" for three-dimensional vectors
        /// </summary>
        /// <param name="vectorA">First three-dimensional vector object</param>
        /// <param name="vectorB">Second three-dimensional vector object</param>
        /// <returns>The result of dividing the vectors</returns>
        public static Vector operator /(Vector vectorA, Vector vectorB)
        {
            if (IsZero(vectorB.X, vectorB.Y, vectorB.Z))
            {
                throw new DivideByZeroException("Can't divide by zero");
            }

            return new Vector(Math.Round(vectorA.X / vectorB.X, 2), Math.Round(vectorA.Y / vectorB.Y, 2), Math.Round(vectorA.Z / vectorB.Z, 2));
        }

        /// <summary>
        /// Overloaded binary operator "+" for three-dimensional vector and number
        /// </summary>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <param name="value">Number</param>
        /// <returns>Result of adding a vector and a number</returns>
        public static Vector operator +(Vector vectorA, double value) => new Vector(vectorA.X + value, vectorA.Y + value, vectorA.Z + value);

        /// <summary>
        /// Overloaded binary operator "-" for three-dimensional vector and number
        /// </summary>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <param name="value">Number</param>
        /// <returns>Result of subtraction a vector and a number</returns>
        public static Vector operator -(Vector vectorA, double value) => new Vector(vectorA.X - value, vectorA.Y - value, vectorA.Z - value);

        /// <summary>
        /// Overloaded binary operator "*" for three-dimensional vector and number
        /// </summary>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <param name="value">Number</param>
        /// <returns>Result of multiplying a vector and a number</returns>
        public static Vector operator *(Vector vectorA, double value) => new Vector(vectorA.X * value, vectorA.Y * value, vectorA.Z * value);

        /// <summary>
        /// Overloaded binary operator "/" for three-dimensional vector and number
        /// </summary>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <param name="value">Number</param>
        /// <returns>Result of dividing a vector and a number</returns>
        public static Vector operator /(Vector vectorA, double value)
        {
            if (IsZero(value))
            {
                throw new DivideByZeroException("Can't divide by zero");
            }

            return new Vector(Math.Round(vectorA.X / value, 2), Math.Round(vectorA.Y / value, 2), Math.Round(vectorA.Z / value, 2));
        }

        /// <summary>
        /// Overloaded binary operator "%" for three-dimensional vector and number
        /// </summary>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <param name="value">Number</param>
        /// <returns>Result of the remainder from dividing a vector and a number</returns>
        public static Vector operator %(Vector vectorA, double value) => new Vector(vectorA.X % value, vectorA.Y % value, vectorA.Z % value);

        /// <summary>
        /// Overloaded binary operator "+" for number and three-dimensional vector
        /// </summary>
        /// <param name="value">Number</param>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Result of adding a number and a vector</returns>
        public static Vector operator +(double value, Vector vectorA) => vectorA + value;

        /// <summary>
        /// Overloaded binary operator "-" for number and three-dimensional vector
        /// </summary>
        /// <param name="value">Number</param>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Result of subtracting a number and vector</returns>
        public static Vector operator -(double value, Vector vectorA) => vectorA - value;

        /// <summary>
        /// Overloaded binary operator "*" for number and three-dimensional vector
        /// </summary>
        /// <param name="value">Number</param>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Result of multiplying a number and vector</returns>
        public static Vector operator *(double value, Vector vectorA) => vectorA * value;

        /// <summary>
        /// Overloaded binary operator "/" for number and three-dimensional vector
        /// </summary>
        /// <param name="value">Number</param>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Result of dividing a number and a vector</returns>
        public static Vector operator /(double value, Vector vectorA) => vectorA / value;

        /// <summary>
        /// Overloaded binary operator "%" for number and three-dimensional vector
        /// </summary>
        /// <param name="value">Number</param>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Result of the remainder of the number and vector division</returns>
        public static Vector operator %(double value, Vector vectorA) => vectorA % value;

        /// <summary>
        /// Overloaded binary operator "==" for three-dimensional vectors
        /// </summary>
        /// <param name="vectorA">First three-dimensional vector</param>
        /// <param name="vectorB">Second three-dimensional vector</param>
        /// <returns>The result of the comparison vectors</returns>
        public static bool operator ==(Vector vectorA, Vector vectorB)
        {
            return !(vectorA is null) && !(vectorB is null) ? ReferenceEquals(vectorA, vectorB) || vectorA.Length == vectorB.Length : vectorA is null && vectorB is null;
        }

        /// <summary>
        /// Overloaded binary operator "!=" for three-dimensional vectors
        /// </summary>
        /// <param name="vectorA">First three-dimensional vector</param>
        /// <param name="vectorB">Second three-dimensional vector</param>
        /// <returns>The result of the comparison vectors</returns>
        public static bool operator !=(Vector vectorA, Vector vectorB) => !(vectorA == vectorB);

        public override bool Equals(object obj)
        {
            if((obj as Vector) == null || !(obj is Vector))
            {
                return false;
            }

            Vector vector = obj as Vector;
            return X == vector.X && Y == vector.Y && Z == vector.Z;
        }

        public override int GetHashCode()
        {
            int hashCode = 612420109;
            hashCode = (hashCode * -1521134295) + X.GetHashCode();
            hashCode = (hashCode * -1521134295) + Y.GetHashCode();
            hashCode = (hashCode * -1521134295) + Z.GetHashCode();
            hashCode = (hashCode * -1521134295) + Length.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"Vertex coordinates ({X}; {Y}; {Z})";

        /// <summary>
        /// Checking the input data for the presence of zero
        /// </summary>
        /// <param name="numbers">Input values</param>
        /// <returns>The result of checking for zero</returns>
        private static bool IsZero(params double[] numbers) => numbers.Any(n => n == 0d);
    }
}