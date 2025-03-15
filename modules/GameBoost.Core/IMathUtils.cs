namespace GameBoost.Core
{
    public interface IMathUtils
    {
        double Sin(double angle);
        double Cos(double angle);
        double Tan(double angle);
        double Sqrt(double value);
        double Abs(double value);
        double Min(double a, double b);
        double Max(double a, double b);
        double Clamp(double value, double min, double max);
        double Lerp(double a, double b, double t);
        double Round(double value);
    }
}
