using System;
using System.Linq;

namespace ThreeDimensionalArray
{
    public class Vector
    {
        public double X { get; private set; } = 0;

        public double Y { get; private set; } = 0;

        public double Z { get; private set; } = 0;

        public Vector() { }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double Length => Math.Round(Math.Sqrt(X * X) + (Y * Y) + (Z * Z), 2);

        public static Vector operator +(Vector vectorA) => new Vector(vectorA.X, vectorA.Y, vectorA.Z);

        public static Vector operator -(Vector vectorA) => new Vector(-vectorA.X, -vectorA.Y, -vectorA.Z);

        public static Vector operator ++(Vector vectorA) => new Vector(++vectorA.X, ++vectorA.Y, ++vectorA.Z);

        public static Vector operator --(Vector vectorA) => new Vector(--vectorA.X, --vectorA.Y, --vectorA.Z);

        public static Vector operator +(Vector vectorA, Vector vectorB) => new Vector(vectorA.X + vectorB.X, vectorA.Y + vectorB.Y, vectorA.Z + vectorB.Z);

        public static Vector operator -(Vector vectorA, Vector vectorB) => new Vector(vectorA.X - vectorB.X, vectorA.Y - vectorB.Y, vectorA.Z - vectorB.Z);

        public static Vector operator *(Vector vectorA, Vector vectorB) => new Vector((vectorA.Y * vectorB.Z) - (vectorA.Z * vectorB.Y), (vectorA.Z * vectorB.X) - (vectorA.X * vectorB.Z), (vectorA.X * vectorB.Y) - (vectorA.Y * vectorB.X));

        public static Vector operator /(Vector vectorA, Vector vectorB)
        {
            if (IsZero(vectorB.X, vectorB.Y, vectorB.Z))
            {
                throw new DivideByZeroException("Can't divide by zero");
            }

            return new Vector(Math.Round(vectorA.X / vectorB.X, 2), Math.Round(vectorA.Y / vectorB.Y, 2), Math.Round(vectorA.Z / vectorB.Z, 2));
        }

        public static Vector operator +(Vector vectorA, double value) => new Vector(vectorA.X + value, vectorA.Y + value, vectorA.Z + value);

        public static Vector operator -(Vector vectorA, double value) => new Vector(vectorA.X - value, vectorA.Y - value, vectorA.Z - value);

        public static Vector operator *(Vector vectorA, double value) => new Vector(vectorA.X * value, vectorA.Y * value, vectorA.Z * value);

        public static Vector operator /(Vector vectorA, double value)
        {
            if (IsZero(value))
            {
                throw new DivideByZeroException("Can't divide by zero");
            }

            return new Vector(Math.Round(vectorA.X / value, 2), Math.Round(vectorA.Y / value, 2), Math.Round(vectorA.Z / value, 2));
        }

        public static Vector operator %(Vector vectorA, double value) => new Vector(vectorA.X % value, vectorA.Y % value, vectorA.Z % value);

        public static Vector operator +(double value, Vector vectorA) => vectorA + value;

        public static Vector operator -(double value, Vector vectorA) => vectorA - value;

        public static Vector operator *(double value, Vector vectorA) => vectorA * value;

        public static Vector operator /(double value, Vector vectorA) => vectorA / value;

        public static Vector operator %(double value, Vector vectorA) => vectorA % value;

        public static bool operator ==(Vector vectorA, Vector vectorB)
        {
            if (ReferenceEquals(vectorA, null) || ReferenceEquals(vectorB, null))
            {
                return ReferenceEquals(vectorA, null) && ReferenceEquals(vectorB, null);
            }

            return ReferenceEquals(vectorA, vectorB) || vectorA.Length == vectorB.Length;
        }

        public static bool operator !=(Vector vectorA, Vector vectorB) => !(vectorA == vectorB);

        public override bool Equals(object obj)
        {
            if (!(obj is Vector))
            {
                return false;
            }

            Vector vector = obj as Vector;
            return X == vector?.X && Y == vector?.Y && Z == vector?.Z;
        }

        public override int GetHashCode()
        {
            int hashCode = 612420109;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"Vertex coordinates ({X}; {Y}; {Z})";

        private static bool IsZero(params double[] numbers) => numbers.Any(n => n == 0d);
    }
}