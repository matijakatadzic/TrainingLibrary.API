using System;

namespace TrainingLibrary.API.Helpers
{
    public static class DateTimeOffsetExtenstion
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset)
        {
            var curentDate = DateTime.UtcNow;
            int age = curentDate.Year - dateTimeOffset.Year;

            if(curentDate < dateTimeOffset.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
