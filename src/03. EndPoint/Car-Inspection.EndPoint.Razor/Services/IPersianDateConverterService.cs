using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Car_Inspection.EndPoint.Razor.Services;

public interface IPersianDateConverterService
{
    DateOnly? ToGregorianDate(string? persianDate);
}