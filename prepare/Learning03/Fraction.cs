using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction() : this(1, 1) {}

    public Fraction(int top) : this(top, 1) {}

    public Fraction(int top, int bottom)
    {
        if (bottom == 0)
            throw new ArgumentException("Denominator cannot be zero.");

        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString() => $"{_top}/{_bottom}";

    public double GetDecimalValue() => (double)_top / _bottom;
}
