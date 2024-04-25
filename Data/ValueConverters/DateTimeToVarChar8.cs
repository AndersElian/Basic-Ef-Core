using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Basic.Ef.Core.Data.ValueConverters;

public class DateTimeToVarChar8 : ValueConverter<DateTime, string>
{
    public DateTimeToVarChar8() : base(
        dateTime => dateTime.ToString("yyyyMMdd"),
        stringValue => DateTime.ParseExact(stringValue, "yyyyMMdd", null))
    {}
}