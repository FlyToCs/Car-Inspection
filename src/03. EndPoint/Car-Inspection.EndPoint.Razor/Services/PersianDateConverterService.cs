using System.Globalization;

namespace Car_Inspection.EndPoint.Razor.Services;

public class PersianDateConverterService : IPersianDateConverterService
{
    private static readonly PersianCalendar PersianCalendar = new PersianCalendar();

    public DateOnly? ToGregorianDate(string? persianDate)
    {
        if (string.IsNullOrWhiteSpace(persianDate))
        {
            return null;
        }

        string cleanedDate = persianDate.Trim();
        string[] parts = cleanedDate.Split('/');

       
        if (parts.Length != 3 ||
            !int.TryParse(parts[0], out int year) ||
            !int.TryParse(parts[1], out int month) ||
            !int.TryParse(parts[2], out int day))
        {
            return null; 
        }

        try
        {

            DateTime gregorianDateTime = PersianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);

            return DateOnly.FromDateTime(gregorianDateTime);
        }
        catch (ArgumentOutOfRangeException)
        {

            return null;
        }
    }
}