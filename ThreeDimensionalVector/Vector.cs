using System;
using System.Linq;

namespace ThreeDimensionalArray
{
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
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator +(Vector vectorA, Vector vectorB) => new Vector(vectorA.X + vectorB.X, vectorA.Y + vectorB.Y, vectorA.Z + vectorB.Z);

        /// <summary>
        /// Overloaded binary operator "-" for three-dimensional vectors
        /// </summary>
        /// <param name="vectorA">First three-dimensional vector object</param>
        /// <param name="vectorB">Second three-dimensional vector object</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator -(Vector vectorA, Vector vectorB) => new Vector(vectorA.X - vectorB.X, vectorA.Y - vectorB.Y, vectorA.Z - vectorB.Z);

        /// <summary>
        /// Overloaded binary operator "*" for three-dimensional vectors
        /// </summary>
        /// <param name="vectorA">First three-dimensional vector object</param>
        /// <param name="vectorB">Second three-dimensional vector object</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator *(Vector vectorA, Vector vectorB) => new Vector((vectorA.Y * vectorB.Z) - (vectorA.Z * vectorB.Y), (vectorA.Z * vectorB.X) - (vectorA.X * vectorB.Z), (vectorA.X * vectorB.Y) - (vectorA.Y * vectorB.X));

        /// <summary>
        /// Overloaded binary operator "/" for three-dimensional vectors
        /// </summary>
        /// <param name="vectorA">First three-dimensional vector object</param>
        /// <param name="vectorB">Second three-dimensional vector object</param>
        /// <returns>Three-dimensional vector object</returns>
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
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator +(Vector vectorA, double value) => new Vector(vectorA.X + value, vectorA.Y + value, vectorA.Z + value);

        /// <summary>
        /// Overloaded binary operator "-" for three-dimensional vector and number
        /// </summary>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <param name="value">Number</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator -(Vector vectorA, double value) => new Vector(vectorA.X - value, vectorA.Y - value, vectorA.Z - value);

        /// <summary>
        /// Overloaded binary operator "*" for three-dimensional vector and number
        /// </summary>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <param name="value">Number</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator *(Vector vectorA, double value) => new Vector(vectorA.X * value, vectorA.Y * value, vectorA.Z * value);

        /// <summary>
        /// Overloaded binary operator "/" for three-dimensional vector and number
        /// </summary>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <param name="value">Number</param>
        /// <returns>Three-dimensional vector object</returns>
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
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator %(Vector vectorA, double value) => new Vector(vectorA.X % value, vectorA.Y % value, vectorA.Z % value);

        /// <summary>
        /// Overloaded binary operator "+" for number and three-dimensional vector
        /// </summary>
        /// <param name="value">Number</param>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator +(double value, Vector vectorA) => vectorA + value;

        /// <summary>
        /// Overloaded binary operator "-" for number and three-dimensional vector
        /// </summary>
        /// <param name="value">Number</param>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator -(double value, Vector vectorA) => vectorA - value;

        /// <summary>
        /// Overloaded binary operator "*" for number and three-dimensional vector
        /// </summary>
        /// <param name="value">Number</param>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator *(double value, Vector vectorA) => vectorA * value;

        /// <summary>
        /// Overloaded binary operator "/" for number and three-dimensional vector
        /// </summary>
        /// <param name="value">Number</param>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator /(double value, Vector vectorA) => vectorA / value;

        /// <summary>
        /// Overloaded binary operator "%" for number and three-dimensional vector
        /// </summary>
        /// <param name="value">Number</param>
        /// <param name="vectorA">Three-dimensional vector object</param>
        /// <returns>Three-dimensional vector object</returns>
        public static Vector operator %(double value, Vector vectorA) => vectorA % value;

        /// <summary>
        /// Overloaded binary operator "==" for three-dimensional vectors
        /// </summary>
        /// <param name="vectorA">First three-dimensional vector</param>
        /// <param name="vectorB">Second three-dimensional vector</param>
        /// <returns>Boolean</returns>
        public static bool operator ==(Vector vectorA, Vector vectorB)
        {
            return !(vectorA is null) && !(vectorB is null) ? ReferenceEquals(vectorA, vectorB) || vectorA.Length == vectorB.Length : vectorA is null && vectorB is null;
        }

        /// <summary>
        /// Overloaded binary operator "!=" for three-dimensional vectors
        /// </summary>
        /// <param name="vectorA">First three-dimensional vector</param>
        /// <param name="vectorB">Second three-dimensional vector</param>
        /// <returns>Boolean</returns>
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

        public override int GetHashCode() => X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode() + Length.GetHashCode();

        public override string ToString() => $"Vertex coordinates ({X}; {Y}; {Z})";

        /// <summary>
        /// Checking the input data for the presence of zero
        /// </summary>
        /// <param name="numbers">Input values</param>
        /// <returns>Boolean</returns>
        private static bool IsZero(params double[] numbers) => numbers.Any(n => n == 0d);
    }
}