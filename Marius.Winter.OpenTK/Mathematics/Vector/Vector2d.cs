﻿/*
Copyright (c) 2006 - 2008 The Open Toolkit library.

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Xml.Serialization;

namespace OpenTK.Mathematics;

/// <summary>
/// Represents a 2D vector using two double-precision floating-point numbers.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public struct Vector2d : IEquatable<Vector2d>, IFormattable
{
    /// <summary>
    /// The X coordinate of this instance.
    /// </summary>
    public double X;

    /// <summary>
    /// The Y coordinate of this instance.
    /// </summary>
    public double Y;

    /// <summary>
    /// Defines a unit-length Vector2d that points towards the X-axis.
    /// </summary>
    public static readonly Vector2d UnitX = new Vector2d(1, 0);

    /// <summary>
    /// Defines a unit-length Vector2d that points towards the Y-axis.
    /// </summary>
    public static readonly Vector2d UnitY = new Vector2d(0, 1);

    /// <summary>
    /// Defines an instance with all components set to 0.
    /// </summary>
    public static readonly Vector2d Zero = new Vector2d(0, 0);

    /// <summary>
    /// Defines an instance with all components set to 1.
    /// </summary>
    public static readonly Vector2d One = new Vector2d(1, 1);

    /// <summary>
    /// Defines an instance with all components set to positive infinity.
    /// </summary>
    public static readonly Vector2d PositiveInfinity = new Vector2d(double.PositiveInfinity, double.PositiveInfinity);

    /// <summary>
    /// Defines an instance with all components set to negative infinity.
    /// </summary>
    public static readonly Vector2d NegativeInfinity = new Vector2d(double.NegativeInfinity, double.NegativeInfinity);

    /// <summary>
    /// Defines the size of the Vector2d struct in bytes.
    /// </summary>
    public static readonly int SizeInBytes = Unsafe.SizeOf<Vector2d>();

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector2d"/> struct.
    /// </summary>
    /// <param name="value">The value that will initialize this instance.</param>
    public Vector2d(double value)
    {
        X = value;
        Y = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector2d"/> struct.
    /// </summary>
    /// <param name="x">The x component of the Vector2d.</param>
    /// <param name="y">The y component of the Vector2d.</param>
    public Vector2d(double x, double y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Gets or sets the value at the index of the Vector.
    /// </summary>
    /// <param name="index">The index of the component from the Vector.</param>
    /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than 0 or greater than 1.</exception>
    public double this[int index]
    {
        readonly get
        {
            if (index == 0)
            {
                return X;
            }

            if (index == 1)
            {
                return Y;
            }

            throw new IndexOutOfRangeException("You tried to access this vector at index: " + index);
        }

        set
        {
            if (index == 0)
            {
                X = value;
            }
            else if (index == 1)
            {
                Y = value;
            }
            else
            {
                throw new IndexOutOfRangeException("You tried to set this vector at index: " + index);
            }
        }
    }

    /// <summary>
    /// Gets the length (magnitude) of the vector.
    /// </summary>
    /// <seealso cref="LengthSquared"/>
    public readonly double Length => Math.Sqrt((X * X) + (Y * Y));

    /// <summary>
    /// Gets an approximation of 1 over the length (magnitude) of the vector.
    /// </summary>
    public readonly double ReciprocalLengthFast => Math.ReciprocalSqrtEstimate((X * X) + (Y * Y));

    /// <summary>
    /// Gets an approximation of the vector length (magnitude).
    /// </summary>
    /// <remarks>
    /// This property uses an approximation of the square root function to calculate vector magnitude.
    /// </remarks>
    /// <see cref="Length"/>
    /// <seealso cref="LengthSquared"/>
    public readonly double LengthFast => 1.0 / Math.ReciprocalSqrtEstimate((X * X) + (Y * Y));

    /// <summary>
    /// Gets the square of the vector length (magnitude).
    /// </summary>
    /// <remarks>
    /// This property avoids the costly square root operation required by the Length property. This makes it more suitable
    /// for comparisons.
    /// </remarks>
    /// <see cref="Length"/>
    public readonly double LengthSquared => (X * X) + (Y * Y);

    /// <summary>
    /// Gets the perpendicular vector on the right side of this vector.
    /// </summary>
    public readonly Vector2d PerpendicularRight => new Vector2d(Y, -X);

    /// <summary>
    /// Gets the perpendicular vector on the left side of this vector.
    /// </summary>
    public readonly Vector2d PerpendicularLeft => new Vector2d(-Y, X);

    /// <summary>
    /// Returns a copy of the Vector2d scaled to unit length.
    /// </summary>
    /// <returns>The normalized copy.</returns>
    public readonly Vector2d Normalized()
    {
        Vector2d v = this;
        v.Normalize();
        return v;
    }

    /// <summary>
    /// Scales the Vector2 to unit length.
    /// </summary>
    public void Normalize()
    {
        double scale = 1.0 / Length;
        X *= scale;
        Y *= scale;
    }

    /// <summary>
    /// Scales the Vector2d to approximately unit length.
    /// </summary>
    public void NormalizeFast()
    {
        double scale = Math.ReciprocalSqrtEstimate((X * X) + (Y * Y));
        X *= scale;
        Y *= scale;
    }

    /// <summary>
    /// Returns a new vector that is the component-wise absolute value of the vector.
    /// </summary>
    /// <returns>The component-wise absolute value vector.</returns>
    public readonly Vector2d Abs()
    {
        Vector2d result = this;
        result.X = Math.Abs(result.X);
        result.Y = Math.Abs(result.Y);
        return result;
    }

    /// <summary>
    /// Adds two vectors.
    /// </summary>
    /// <param name="a">Left operand.</param>
    /// <param name="b">Right operand.</param>
    /// <returns>Result of operation.</returns>
    [Pure]
    public static Vector2d Add(Vector2d a, Vector2d b)
    {
        Add(in a, in b, out a);
        return a;
    }

    /// <summary>
    /// Adds two vectors.
    /// </summary>
    /// <param name="a">Left operand.</param>
    /// <param name="b">Right operand.</param>
    /// <param name="result">Result of operation.</param>
    public static void Add(in Vector2d a, in Vector2d b, out Vector2d result)
    {
        result.X = a.X + b.X;
        result.Y = a.Y + b.Y;
    }

    /// <summary>
    /// Subtract one Vector from another.
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <returns>Result of subtraction.</returns>
    [Pure]
    public static Vector2d Subtract(Vector2d a, Vector2d b)
    {
        Subtract(in a, in b, out a);
        return a;
    }

    /// <summary>
    /// Subtract one Vector from another.
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <param name="result">Result of subtraction.</param>
    public static void Subtract(in Vector2d a, in Vector2d b, out Vector2d result)
    {
        result.X = a.X - b.X;
        result.Y = a.Y - b.Y;
    }

    /// <summary>
    /// Multiplies a vector by a scalar.
    /// </summary>
    /// <param name="vector">Left operand.</param>
    /// <param name="scale">Right operand.</param>
    /// <returns>Result of the operation.</returns>
    [Pure]
    public static Vector2d Multiply(Vector2d vector, double scale)
    {
        Multiply(in vector, scale, out vector);
        return vector;
    }

    /// <summary>
    /// Multiplies a vector by a scalar.
    /// </summary>
    /// <param name="vector">Left operand.</param>
    /// <param name="scale">Right operand.</param>
    /// <param name="result">Result of the operation.</param>
    public static void Multiply(in Vector2d vector, double scale, out Vector2d result)
    {
        result.X = vector.X * scale;
        result.Y = vector.Y * scale;
    }

    /// <summary>
    /// Multiplies a vector by the components a vector (scale).
    /// </summary>
    /// <param name="vector">Left operand.</param>
    /// <param name="scale">Right operand.</param>
    /// <returns>Result of the operation.</returns>
    [Pure]
    public static Vector2d Multiply(Vector2d vector, Vector2d scale)
    {
        Multiply(in vector, in scale, out vector);
        return vector;
    }

    /// <summary>
    /// Multiplies a vector by the components of a vector (scale).
    /// </summary>
    /// <param name="vector">Left operand.</param>
    /// <param name="scale">Right operand.</param>
    /// <param name="result">Result of the operation.</param>
    public static void Multiply(in Vector2d vector, in Vector2d scale, out Vector2d result)
    {
        result.X = vector.X * scale.X;
        result.Y = vector.Y * scale.Y;
    }

    /// <summary>
    /// Divides a vector by a scalar.
    /// </summary>
    /// <param name="vector">Left operand.</param>
    /// <param name="scale">Right operand.</param>
    /// <returns>Result of the operation.</returns>
    [Pure]
    public static Vector2d Divide(Vector2d vector, double scale)
    {
        Divide(in vector, scale, out vector);
        return vector;
    }

    /// <summary>
    /// Divides a vector by a scalar.
    /// </summary>
    /// <param name="vector">Left operand.</param>
    /// <param name="scale">Right operand.</param>
    /// <param name="result">Result of the operation.</param>
    public static void Divide(in Vector2d vector, double scale, out Vector2d result)
    {
        result.X = vector.X / scale;
        result.Y = vector.Y / scale;
    }

    /// <summary>
    /// Divides a vector by the components of a vector (scale).
    /// </summary>
    /// <param name="vector">Left operand.</param>
    /// <param name="scale">Right operand.</param>
    /// <returns>Result of the operation.</returns>
    [Pure]
    public static Vector2d Divide(Vector2d vector, Vector2d scale)
    {
        Divide(in vector, in scale, out vector);
        return vector;
    }

    /// <summary>
    /// Divide a vector by the components of a vector (scale).
    /// </summary>
    /// <param name="vector">Left operand.</param>
    /// <param name="scale">Right operand.</param>
    /// <param name="result">Result of the operation.</param>
    public static void Divide(in Vector2d vector, in Vector2d scale, out Vector2d result)
    {
        result.X = vector.X / scale.X;
        result.Y = vector.Y / scale.Y;
    }

    /// <summary>
    /// Returns a vector created from the smallest of the corresponding components of the given vectors.
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <returns>The component-wise minimum.</returns>
    [Pure]
    public static Vector2d ComponentMin(Vector2d a, Vector2d b)
    {
        a.X = a.X < b.X ? a.X : b.X;
        a.Y = a.Y < b.Y ? a.Y : b.Y;
        return a;
    }

    /// <summary>
    /// Returns a vector created from the smallest of the corresponding components of the given vectors.
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <param name="result">The component-wise minimum.</param>
    public static void ComponentMin(in Vector2d a, in Vector2d b, out Vector2d result)
    {
        result.X = a.X < b.X ? a.X : b.X;
        result.Y = a.Y < b.Y ? a.Y : b.Y;
    }

    /// <summary>
    /// Returns a vector created from the largest of the corresponding components of the given vectors.
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <returns>The component-wise maximum.</returns>
    [Pure]
    public static Vector2d ComponentMax(Vector2d a, Vector2d b)
    {
        a.X = a.X > b.X ? a.X : b.X;
        a.Y = a.Y > b.Y ? a.Y : b.Y;
        return a;
    }

    /// <summary>
    /// Returns a vector created from the largest of the corresponding components of the given vectors.
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <param name="result">The component-wise maximum.</param>
    public static void ComponentMax(in Vector2d a, in Vector2d b, out Vector2d result)
    {
        result.X = a.X > b.X ? a.X : b.X;
        result.Y = a.Y > b.Y ? a.Y : b.Y;
    }

    /// <summary>
    /// Returns the Vector2d with the minimum magnitude. If the magnitudes are equal, the second vector
    /// is selected.
    /// </summary>
    /// <param name="left">Left operand.</param>
    /// <param name="right">Right operand.</param>
    /// <returns>The minimum Vector2d.</returns>
    [Pure]
    public static Vector2d MagnitudeMin(Vector2d left, Vector2d right)
    {
        return left.LengthSquared < right.LengthSquared ? left : right;
    }

    /// <summary>
    /// Returns the Vector2d with the minimum magnitude. If the magnitudes are equal, the second vector
    /// is selected.
    /// </summary>
    /// <param name="left">Left operand.</param>
    /// <param name="right">Right operand.</param>
    /// <param name="result">The magnitude-wise minimum.</param>
    public static void MagnitudeMin(in Vector2d left, in Vector2d right, out Vector2d result)
    {
        result = left.LengthSquared < right.LengthSquared ? left : right;
    }

    /// <summary>
    /// Returns the Vector2d with the minimum magnitude. If the magnitudes are equal, the first vector
    /// is selected.
    /// </summary>
    /// <param name="left">Left operand.</param>
    /// <param name="right">Right operand.</param>
    /// <returns>The minimum Vector2d.</returns>
    [Pure]
    public static Vector2d MagnitudeMax(Vector2d left, Vector2d right)
    {
        return left.LengthSquared >= right.LengthSquared ? left : right;
    }

    /// <summary>
    /// Returns the Vector2d with the maximum magnitude. If the magnitudes are equal, the first vector
    /// is selected.
    /// </summary>
    /// <param name="left">Left operand.</param>
    /// <param name="right">Right operand.</param>
    /// <param name="result">The magnitude-wise maximum.</param>
    public static void MagnitudeMax(in Vector2d left, in Vector2d right, out Vector2d result)
    {
        result = left.LengthSquared >= right.LengthSquared ? left : right;
    }

    /// <summary>
    /// Clamp a vector to the given minimum and maximum vectors.
    /// </summary>
    /// <param name="vec">Input vector.</param>
    /// <param name="min">Minimum vector.</param>
    /// <param name="max">Maximum vector.</param>
    /// <returns>The clamped vector.</returns>
    [Pure]
    public static Vector2d Clamp(Vector2d vec, Vector2d min, Vector2d max)
    {
        vec.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
        vec.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
        return vec;
    }

    /// <summary>
    /// Clamp a vector to the given minimum and maximum vectors.
    /// </summary>
    /// <param name="vec">Input vector.</param>
    /// <param name="min">Minimum vector.</param>
    /// <param name="max">Maximum vector.</param>
    /// <param name="result">The clamped vector.</param>
    public static void Clamp(in Vector2d vec, in Vector2d min, in Vector2d max, out Vector2d result)
    {
        result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
        result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
    }

    /// <summary>
    /// Take the component-wise absolute value of a vector.
    /// </summary>
    /// <param name="vec">The vector to apply component-wise absolute value to.</param>
    /// <returns>The component-wise absolute value vector.</returns>
    public static Vector2d Abs(Vector2d vec)
    {
        vec.X = Math.Abs(vec.X);
        vec.Y = Math.Abs(vec.Y);
        return vec;
    }

    /// <summary>
    /// Take the component-wise absolute value of a vector.
    /// </summary>
    /// <param name="vec">The vector to apply component-wise absolute value to.</param>
    /// <param name="result">The component-wise absolute value vector.</param>
    public static void Abs(in Vector2d vec, out Vector2d result)
    {
        result.X = Math.Abs(vec.X);
        result.Y = Math.Abs(vec.Y);
    }

    /// <summary>
    /// Compute the euclidean distance between two vectors.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The distance.</returns>
    [Pure]
    public static double Distance(Vector2d vec1, Vector2d vec2)
    {
        Distance(in vec1, in vec2, out double result);
        return result;
    }

    /// <summary>
    /// Compute the euclidean distance between two vectors.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <param name="result">The distance.</param>
    public static void Distance(in Vector2d vec1, in Vector2d vec2, out double result)
    {
        result = Math.Sqrt(((vec2.X - vec1.X) * (vec2.X - vec1.X)) + ((vec2.Y - vec1.Y) * (vec2.Y - vec1.Y)));
    }

    /// <summary>
    /// Compute the squared euclidean distance between two vectors.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <returns>The squared distance.</returns>
    [Pure]
    public static double DistanceSquared(Vector2d vec1, Vector2d vec2)
    {
        DistanceSquared(in vec1, in vec2, out double result);
        return result;
    }

    /// <summary>
    /// Compute the squared euclidean distance between two vectors.
    /// </summary>
    /// <param name="vec1">The first vector.</param>
    /// <param name="vec2">The second vector.</param>
    /// <param name="result">The squared distance.</param>
    public static void DistanceSquared(in Vector2d vec1, in Vector2d vec2, out double result)
    {
        result = ((vec2.X - vec1.X) * (vec2.X - vec1.X)) + ((vec2.Y - vec1.Y) * (vec2.Y - vec1.Y));
    }

    /// <summary>
    /// Scale a vector to unit length.
    /// </summary>
    /// <param name="vec">The input vector.</param>
    /// <returns>The normalized copy.</returns>
    [Pure]
    public static Vector2d Normalize(Vector2d vec)
    {
        double scale = 1.0 / vec.Length;
        vec.X *= scale;
        vec.Y *= scale;
        return vec;
    }

    /// <summary>
    /// Scale a vector to unit length.
    /// </summary>
    /// <param name="vec">The input vector.</param>
    /// <param name="result">The normalized vector.</param>
    public static void Normalize(in Vector2d vec, out Vector2d result)
    {
        double scale = 1.0 / vec.Length;
        result.X = vec.X * scale;
        result.Y = vec.Y * scale;
    }

    /// <summary>
    /// Scale a vector to approximately unit length.
    /// </summary>
    /// <param name="vec">The input vector.</param>
    /// <returns>The normalized copy.</returns>
    [Pure]
    public static Vector2d NormalizeFast(Vector2d vec)
    {
        double scale = Math.ReciprocalSqrtEstimate((vec.X * vec.X) + (vec.Y * vec.Y));
        vec.X *= scale;
        vec.Y *= scale;
        return vec;
    }

    /// <summary>
    /// Scale a vector to approximately unit length.
    /// </summary>
    /// <param name="vec">The input vector.</param>
    /// <param name="result">The normalized vector.</param>
    public static void NormalizeFast(in Vector2d vec, out Vector2d result)
    {
        double scale = Math.ReciprocalSqrtEstimate((vec.X * vec.X) + (vec.Y * vec.Y));
        result.X = vec.X * scale;
        result.Y = vec.Y * scale;
    }

    /// <summary>
    /// Calculate the dot (scalar) product of two vectors.
    /// </summary>
    /// <param name="left">First operand.</param>
    /// <param name="right">Second operand.</param>
    /// <returns>The dot product of the two inputs.</returns>
    [Pure]
    public static double Dot(Vector2d left, Vector2d right)
    {
        return (left.X * right.X) + (left.Y * right.Y);
    }

    /// <summary>
    /// Calculate the dot (scalar) product of two vectors.
    /// </summary>
    /// <param name="left">First operand.</param>
    /// <param name="right">Second operand.</param>
    /// <param name="result">The dot product of the two inputs.</param>
    public static void Dot(in Vector2d left, in Vector2d right, out double result)
    {
        result = (left.X * right.X) + (left.Y * right.Y);
    }

    /// <summary>
    /// Returns a new vector that is the linear blend of the 2 given vectors.
    /// </summary>
    /// <param name="a">First input vector.</param>
    /// <param name="b">Second input vector.</param>
    /// <param name="blend">The blend factor.</param>
    /// <returns>a when blend=0, b when blend=1, and a linear combination otherwise.</returns>
    [Pure]
    public static Vector2d Lerp(Vector2d a, Vector2d b, double blend)
    {
        a.X = (blend * (b.X - a.X)) + a.X;
        a.Y = (blend * (b.Y - a.Y)) + a.Y;
        return a;
    }

    /// <summary>
    /// Returns a new vector that is the linear blend of the 2 given vectors.
    /// </summary>
    /// <param name="a">First input vector.</param>
    /// <param name="b">Second input vector.</param>
    /// <param name="blend">The blend factor.</param>
    /// <param name="result">a when blend=0, b when blend=1, and a linear combination otherwise.</param>
    public static void Lerp(in Vector2d a, in Vector2d b, double blend, out Vector2d result)
    {
        result.X = (blend * (b.X - a.X)) + a.X;
        result.Y = (blend * (b.Y - a.Y)) + a.Y;
    }

    /// <summary>
    /// Returns a new vector that is the component-wise linear blend of the 2 given vectors.
    /// </summary>
    /// <param name="a">First input vector.</param>
    /// <param name="b">Second input vector.</param>
    /// <param name="blend">The blend factor.</param>
    /// <returns>a when blend=0, b when blend=1, and a component-wise linear combination otherwise.</returns>
    [Pure]
    public static Vector2d Lerp(Vector2d a, Vector2d b, Vector2d blend)
    {
        a.X = (blend.X * (b.X - a.X)) + a.X;
        a.Y = (blend.Y * (b.Y - a.Y)) + a.Y;
        return a;
    }

    /// <summary>
    /// Returns a new vector that is the component-wise linear blend of the 2 given vectors.
    /// </summary>
    /// <param name="a">First input vector.</param>
    /// <param name="b">Second input vector.</param>
    /// <param name="blend">The blend factor.</param>
    /// <param name="result">a when blend=0, b when blend=1, and a component-wise linear combination otherwise.</param>
    public static void Lerp(in Vector2d a, in Vector2d b, Vector2d blend, out Vector2d result)
    {
        result.X = (blend.X * (b.X - a.X)) + a.X;
        result.Y = (blend.Y * (b.Y - a.Y)) + a.Y;
    }

    /// <summary>
    /// Returns a new vector that is the spherical interpolation of the two given vectors.
    /// <paramref name="a"/> and <paramref name="b"/> need to be normalized for this function to work properly.
    /// </summary>
    /// <param name="a">Unit vector start point.</param>
    /// <param name="b">Unit vector end point.</param>
    /// <param name="t">The blend factor.</param>
    /// <returns><paramref name="a"/> when <paramref name="t"/>=0, <paramref name="b"/> when <paramref name="t"/>=1, and a spherical interpolation between the vectors otherwise.</returns>
    [Pure]
    public static Vector2d Slerp(Vector2d a, Vector2d b, double t)
    {
        double abLength = a.Length * b.Length;
        double cosTheta;
        if (abLength == 0 || Math.Abs(cosTheta = Dot(a, b) / abLength) > 0.99999999)
        {
            return Lerp(a, b, t);
        }
        else
        {
            double theta = Math.Acos(Math.Clamp(cosTheta, -1, 1));
            // We use the fact that:
            // sin(θ) = sqrt(1 - cos(θ)^2)
            // to avoid doing sin(θ) which is slower than sqrt.
            double sinTheta = Math.Sqrt(1 - (cosTheta * cosTheta));
            double acoef = Math.Sin((1 - t) * theta) / sinTheta;
            double bcoef = Math.Sin(t * theta) / sinTheta;
            return (acoef * a) + (bcoef * b);
        }
    }

    /// <summary>
    /// Returns a new vector that is the spherical interpolation of the two given vectors.
    /// <paramref name="a"/> and <paramref name="b"/> need to be normalized for this function to work properly.
    /// </summary>
    /// <param name="a">Unit vector start point.</param>
    /// <param name="b">Unit vector end point.</param>
    /// <param name="t">The blend factor.</param>
    /// <param name="result">Is <paramref name="a"/> when <paramref name="t"/>=0, <paramref name="b"/> when <paramref name="t"/>=1, and a spherical interpolation between the vectors otherwise.</param>
    public static void Slerp(in Vector2d a, in Vector2d b, double t, out Vector2d result)
    {
        double abLength = a.Length * b.Length;
        if (abLength == 0)
        {
            Lerp(in a, in b, t, out result);
        }
        else
        {
            Dot(in a, in b, out double cosTheta);
            cosTheta /= abLength;
            if (Math.Abs(cosTheta) > 0.99999999)
            {
                Lerp(in a, in b, t, out result);
            }
            else
            {
                double theta = Math.Acos(cosTheta);
                // We use the fact that:
                // sin(θ) = sqrt(1 - cos(θ)^2)
                // to avoid doing sin(θ) which is slower than sqrt.
                double sinTheta = Math.Sqrt(1 - (cosTheta * cosTheta));
                double acoef = Math.Sin((1 - t) * theta) / sinTheta;
                double bcoef = Math.Sin(t * theta) / sinTheta;
                result = (acoef * a) + (bcoef * b);
            }
        }
    }

    /// <summary>
    /// Returns a new vector that is the exponential interpolation of the two vectors.
    /// Equivalent to <c>a * pow(b/a, t)</c>.
    /// </summary>
    /// <param name="a">The starting value. Must be non-negative.</param>
    /// <param name="b">The end value. Must be non-negative.</param>
    /// <param name="t">The blend factor.</param>
    /// <returns>The exponential interpolation between <paramref name="a"/> and <paramref name="b"/>.</returns>
    /// <seealso cref="MathHelper.Elerp(double, double, double)"/>
    public static Vector2d Elerp(Vector2d a, Vector2d b, double t)
    {
        a.X = Math.Pow(a.X, 1 - t) * Math.Pow(b.X, t);
        a.Y = Math.Pow(a.Y, 1 - t) * Math.Pow(b.Y, t);
        return a;
    }

    /// <summary>
    /// Returns a new vector that is the exponential interpolation of the two vectors.
    /// Equivalent to <c>a * pow(b/a, t)</c>.
    /// </summary>
    /// <param name="a">The starting value. Must be non-negative.</param>
    /// <param name="b">The end value. Must be non-negative.</param>
    /// <param name="t">The blend factor.</param>
    /// <param name="result">The exponential interpolation between <paramref name="a"/> and <paramref name="b"/>.</param>
    /// <seealso cref="MathHelper.Elerp(double, double, double)"/>
    public static void Elerp(in Vector2d a, in Vector2d b, double t, out Vector2d result)
    {
        result.X = Math.Pow(a.X, 1 - t) * Math.Pow(b.X, t);
        result.Y = Math.Pow(a.Y, 1 - t) * Math.Pow(b.Y, t);
    }

    /// <summary>
    /// Interpolate 3 Vectors using Barycentric coordinates.
    /// </summary>
    /// <param name="a">First input Vector.</param>
    /// <param name="b">Second input Vector.</param>
    /// <param name="c">Third input Vector.</param>
    /// <param name="u">First Barycentric Coordinate.</param>
    /// <param name="v">Second Barycentric Coordinate.</param>
    /// <returns>a when u=v=0, b when u=1,v=0, c when u=0,v=1, and a linear combination of a,b,c otherwise.</returns>
    [Pure]
    public static Vector2d BaryCentric(Vector2d a, Vector2d b, Vector2d c, double u, double v)
    {
        BaryCentric(in a, in b, in c, u, v, out Vector2d result);
        return result;
    }

    /// <summary>
    /// Interpolate 3 Vectors using Barycentric coordinates.
    /// </summary>
    /// <param name="a">First input Vector.</param>
    /// <param name="b">Second input Vector.</param>
    /// <param name="c">Third input Vector.</param>
    /// <param name="u">First Barycentric Coordinate.</param>
    /// <param name="v">Second Barycentric Coordinate.</param>
    /// <param name="result">
    /// Output Vector. a when u=v=0, b when u=1,v=0, c when u=0,v=1, and a linear combination of a,b,c
    /// otherwise.
    /// </param>
    public static void BaryCentric
    (
        in Vector2d a,
        in Vector2d b,
        in Vector2d c,
        double u,
        double v,
        out Vector2d result
    )
    {
        Subtract(in b, in a, out Vector2d ab);
        Multiply(in ab, u, out Vector2d abU);
        Add(in a, in abU, out Vector2d uPos);

        Subtract(in c, in a, out Vector2d ac);
        Multiply(in ac, v, out Vector2d acV);
        Add(in uPos, in acV, out result);
    }

    /// <summary>
    /// Transform a Vector by the given Matrix.
    /// </summary>
    /// <param name="vec">The vector to transform.</param>
    /// <param name="mat">The desired transformation.</param>
    /// <returns>The transformed vector.</returns>
    [Pure]
    public static Vector2d TransformRow(Vector2d vec, Matrix2d mat)
    {
        TransformRow(in vec, in mat, out Vector2d result);
        return result;
    }

    /// <summary>
    /// Transform a Vector by the given Matrix.
    /// </summary>
    /// <param name="vec">The vector to transform.</param>
    /// <param name="mat">The desired transformation.</param>
    /// <param name="result">The transformed vector.</param>
    public static void TransformRow(in Vector2d vec, in Matrix2d mat, out Vector2d result)
    {
        result = new Vector2d(
            (vec.X * mat.Row0.X) + (vec.Y * mat.Row1.X),
            (vec.X * mat.Row0.Y) + (vec.Y * mat.Row1.Y));
    }

    /// <summary>
    /// Transforms a vector by a quaternion rotation.
    /// </summary>
    /// <param name="vec">The vector to transform.</param>
    /// <param name="quat">The quaternion to rotate the vector by.</param>
    /// <returns>The result of the operation.</returns>
    [Pure]
    public static Vector2d Transform(Vector2d vec, Quaterniond quat)
    {
        Transform(in vec, in quat, out Vector2d result);
        return result;
    }

    /// <summary>
    /// Transforms a vector by a quaternion rotation.
    /// </summary>
    /// <param name="vec">The vector to transform.</param>
    /// <param name="quat">The quaternion to rotate the vector by.</param>
    /// <param name="result">The result of the operation.</param>
    public static void Transform(in Vector2d vec, in Quaterniond quat, out Vector2d result)
    {
        Quaterniond v = new Quaterniond(vec.X, vec.Y, 0, 0);
        Quaterniond.Invert(in quat, out Quaterniond i);
        Quaterniond.Multiply(in quat, in v, out Quaterniond t);
        Quaterniond.Multiply(in t, in i, out v);

        result.X = v.X;
        result.Y = v.Y;
    }

    /// <summary>
    /// Transform a Vector by the given Matrix using right-handed notation.
    /// </summary>
    /// <param name="mat">The desired transformation.</param>
    /// <param name="vec">The vector to transform.</param>
    /// <returns>The transformed vector.</returns>
    [Pure]
    public static Vector2d TransformColumn(Matrix2d mat, Vector2d vec)
    {
        TransformColumn(in mat, in vec, out Vector2d result);
        return result;
    }

    /// <summary>
    /// Transform a Vector by the given Matrix using right-handed notation.
    /// </summary>
    /// <param name="mat">The desired transformation.</param>
    /// <param name="vec">The vector to transform.</param>
    /// <param name="result">The transformed vector.</param>
    public static void TransformColumn(in Matrix2d mat, in Vector2d vec, out Vector2d result)
    {
        result.X = (mat.Row0.X * vec.X) + (mat.Row0.Y * vec.Y);
        result.Y = (mat.Row1.X * vec.X) + (mat.Row1.Y * vec.Y);
    }

    /// <summary>
    /// Gets or sets an OpenTK.Vector2d with the Y and X components of this instance.
    /// </summary>
    [XmlIgnore]
    public Vector2d Yx
    {
        readonly get => new Vector2d(Y, X);
        set
        {
            Y = value.X;
            X = value.Y;
        }
    }

    /// <summary>
    /// Adds two instances.
    /// </summary>
    /// <param name="left">The left instance.</param>
    /// <param name="right">The right instance.</param>
    /// <returns>The result of the operation.</returns>
    [Pure]
    public static Vector2d operator +(Vector2d left, Vector2d right)
    {
        left.X += right.X;
        left.Y += right.Y;
        return left;
    }

    /// <summary>
    /// Subtracts two instances.
    /// </summary>
    /// <param name="left">The left instance.</param>
    /// <param name="right">The right instance.</param>
    /// <returns>The result of the operation.</returns>
    [Pure]
    public static Vector2d operator -(Vector2d left, Vector2d right)
    {
        left.X -= right.X;
        left.Y -= right.Y;
        return left;
    }

    /// <summary>
    /// Negates an instance.
    /// </summary>
    /// <param name="vec">The instance.</param>
    /// <returns>The result of the operation.</returns>
    [Pure]
    public static Vector2d operator -(Vector2d vec)
    {
        vec.X = -vec.X;
        vec.Y = -vec.Y;
        return vec;
    }

    /// <summary>
    /// Multiplies an instance by a scalar.
    /// </summary>
    /// <param name="vec">The instance.</param>
    /// <param name="f">The scalar.</param>
    /// <returns>The result of the operation.</returns>
    [Pure]
    public static Vector2d operator *(Vector2d vec, double f)
    {
        vec.X *= f;
        vec.Y *= f;
        return vec;
    }

    /// <summary>
    /// Multiply an instance by a scalar.
    /// </summary>
    /// <param name="f">The scalar.</param>
    /// <param name="vec">The instance.</param>
    /// <returns>The result of the operation.</returns>
    [Pure]
    public static Vector2d operator *(double f, Vector2d vec)
    {
        vec.X *= f;
        vec.Y *= f;
        return vec;
    }

    /// <summary>
    /// Component-wise multiplication between the specified instance by a scale vector.
    /// </summary>
    /// <param name="scale">Left operand.</param>
    /// <param name="vec">Right operand.</param>
    /// <returns>Result of multiplication.</returns>
    [Pure]
    public static Vector2d operator *(Vector2d vec, Vector2d scale)
    {
        vec.X *= scale.X;
        vec.Y *= scale.Y;
        return vec;
    }

    /// <summary>
    /// Transform a Vector by the given Matrix.
    /// </summary>
    /// <param name="vec">The vector to transform.</param>
    /// <param name="mat">The desired transformation.</param>
    /// <returns>The transformed vector.</returns>
    [Pure]
    public static Vector2d operator *(Vector2d vec, Matrix2d mat)
    {
        TransformRow(in vec, in mat, out Vector2d result);
        return result;
    }

    /// <summary>
    /// Transform a Vector by the given Matrix using right-handed notation.
    /// </summary>
    /// <param name="mat">The desired transformation.</param>
    /// <param name="vec">The vector to transform.</param>
    /// <returns>The transformed vector.</returns>
    [Pure]
    public static Vector2d operator *(Matrix2d mat, Vector2d vec)
    {
        TransformColumn(in mat, in vec, out Vector2d result);
        return result;
    }

    /// <summary>
    /// Transforms a vector by a quaternion rotation.
    /// </summary>
    /// <param name="quat">The quaternion to rotate the vector by.</param>
    /// <param name="vec">The vector to transform.</param>
    /// <returns>The transformed vector.</returns>
    [Pure]
    public static Vector2d operator *(Quaterniond quat, Vector2d vec)
    {
        Transform(in vec, in quat, out Vector2d result);
        return result;
    }

    /// <summary>
    /// Divides an instance by a scalar.
    /// </summary>
    /// <param name="vec">The instance.</param>
    /// <param name="f">The scalar.</param>
    /// <returns>The result of the operation.</returns>
    [Pure]
    public static Vector2d operator /(Vector2d vec, double f)
    {
        vec.X /= f;
        vec.Y /= f;
        return vec;
    }

    /// <summary>
    /// Component-wise division between the specified instance by a scale vector.
    /// </summary>
    /// <param name="vec">Left operand.</param>
    /// <param name="scale">Right operand.</param>
    /// <returns>Result of the division.</returns>
    [Pure]
    public static Vector2d operator /(Vector2d vec, Vector2d scale)
    {
        vec.X /= scale.X;
        vec.Y /= scale.Y;
        return vec;
    }

    /// <summary>
    /// Compares two instances for equality.
    /// </summary>
    /// <param name="left">The left instance.</param>
    /// <param name="right">The right instance.</param>
    /// <returns>True, if both instances are equal; false otherwise.</returns>
    public static bool operator ==(Vector2d left, Vector2d right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Compares two instances for ienquality.
    /// </summary>
    /// <param name="left">The left instance.</param>
    /// <param name="right">The right instance.</param>
    /// <returns>True, if the instances are not equal; false otherwise.</returns>
    public static bool operator !=(Vector2d left, Vector2d right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Converts OpenTK.Vector2d to OpenTK.Vector2.
    /// </summary>
    /// <param name="vec">The Vector2d to convert.</param>
    /// <returns>The resulting Vector2.</returns>
    [Pure]
    public static explicit operator Vector2(Vector2d vec)
    {
        return new Vector2((float)vec.X, (float)vec.Y);
    }

    /// <summary>
    /// Converts OpenTK.Vector2d to OpenTK.Vector2h.
    /// </summary>
    /// <param name="vec">The Vector2d to convert.</param>
    /// <returns>The resulting Vector2h.</returns>
    [Pure]
    public static explicit operator Vector2h(Vector2d vec)
    {
        return new Vector2h((Half)vec.X, (Half)vec.Y);
    }

    /// <summary>
    /// Converts OpenTK.Vector2d to OpenTK.Vector2i.
    /// </summary>
    /// <param name="vec">The Vector2d to convert.</param>
    /// <returns>The resulting Vector2i.</returns>
    [Pure]
    public static explicit operator Vector2i(Vector2d vec)
    {
        return new Vector2i((int)vec.X, (int)vec.Y);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector2d"/> struct using a tuple containing the component
    /// values.
    /// </summary>
    /// <param name="values">A tuple containing the component values.</param>
    /// <returns>A new instance of the <see cref="Vector2d"/> struct with the given component values.</returns>
    [Pure]
    public static implicit operator Vector2d((double X, double Y) values)
    {
        return new Vector2d(values.X, values.Y);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return ToString(null, null);
    }

    /// <inheritdoc cref="ToString(string, IFormatProvider)"/>
    public string ToString(string format)
    {
        return ToString(format, null);
    }

    /// <inheritdoc cref="ToString(string, IFormatProvider)"/>
    public string ToString(IFormatProvider formatProvider)
    {
        return ToString(null, formatProvider);
    }

    /// <inheritdoc/>
    public readonly string ToString(string format, IFormatProvider formatProvider)
    {
        return string.Format(
            "({0}{2} {1})",
            X.ToString(format, formatProvider),
            Y.ToString(format, formatProvider),
            MathHelper.GetListSeparator(formatProvider));
    }

    /// <inheritdoc/>
    public override bool Equals(object obj)
    {
        return obj is Vector2d && Equals((Vector2d)obj);
    }

    /// <inheritdoc/>
    public readonly bool Equals(Vector2d other)
    {
        Vector128<double> thisVec = Vector128.LoadUnsafe(in X);
        Vector128<double> otherVec = Vector128.LoadUnsafe(in other.X);

        return thisVec == otherVec;
    }

    /// <inheritdoc/>
    public readonly override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    /// <summary>
    /// Deconstructs the vector into it's individual components.
    /// </summary>
    /// <param name="x">The X component of the vector.</param>
    /// <param name="y">The Y component of the vector.</param>
    [Pure]
    public readonly void Deconstruct(out double x, out double y)
    {
        x = X;
        y = Y;
    }
}