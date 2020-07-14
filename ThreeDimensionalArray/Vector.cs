﻿using System;

namespace ThreeDimensionalArray
{
    public class Vector
    {
        public double X { get; private set; }

        public double Y { get; private set; }

        public double Z { get; private set; }

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

        public static Vector operator *(Vector vectorA, Vector vectorB) => new Vector(vectorA.X * vectorB.X, vectorA.Y * vectorB.Y, vectorA.Z * vectorB.Z);

        public static Vector operator /(Vector vectorA, Vector vectorB)
        {
            try
            {
                return new Vector(Math.Round(vectorA.X / vectorB.X, 2), Math.Round(vectorA.Y / vectorB.Y, 2), Math.Round(vectorA.Z / vectorB.Z, 2));
            }
            catch (DivideByZeroException exc)
            {
                throw new DivideByZeroException("Can't divide by zero", exc);
            }
        }

        public static Vector operator +(Vector vectorA, double value) => new Vector(vectorA.X + value, vectorA.Y + value, vectorA.Z + value);

        public static Vector operator -(Vector vectorA, double value) => new Vector(vectorA.X - value, vectorA.Y - value, vectorA.Z - value);

        public static Vector operator *(Vector vectorA, double value) => new Vector(vectorA.X * value, vectorA.Y * value, vectorA.Z * value);

        public static Vector operator /(Vector vectorA, double value)
        {
            try
            {
                return new Vector(vectorA.X / value, vectorA.Y / value, vectorA.Z / value);
            }
            catch (DivideByZeroException exc)
            {
                throw new DivideByZeroException("Can't divide by zero", exc);
            }
        }

        public static Vector operator %(Vector vectorA, double value) => new Vector(vectorA.X % value, vectorA.Y % value, vectorA.Z % value);

        public static Vector operator +(double value, Vector vectorA) => vectorA + value;

        public static Vector operator -(double value, Vector vectorA) => vectorA - value;

        public static Vector operator *(double value, Vector vectorA) => vectorA * value;

        public static Vector operator /(double value, Vector vectorA) => vectorA / value;

        public static Vector operator %(double value, Vector vectorA) => vectorA % value;

        public static bool operator ==(Vector vectorA, Vector vectorB) => (vectorA == null && vectorB == null) || (vectorA.Length == vectorB.Length);

        public static bool operator !=(Vector vectorA, Vector vectorB) => !(vectorA == vectorB);

        public override bool Equals(object obj) => obj is Vector;

        public override int GetHashCode()
        {
            int hashCode = 612420109;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            return hashCode;
        }
    }
}