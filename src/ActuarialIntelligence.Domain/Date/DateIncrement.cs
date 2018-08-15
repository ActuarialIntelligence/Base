using ActuarialIntelligence.Domain.Enums;

namespace ActuarialIntelligence.Domain.Date
{
    public class DateIncrement
    {
        public DateIncrementTypes type { get; private set; }
        public int increments { get; private set; }
        public DateIncrement(DateIncrementTypes type, int increments)
        {
            this.type = type;
            this.increments = increments;
        }

        public static string GetDateIDGivenIncrementsOnInputDateId(string dateId, DateIncrement increment)
        {
            var year = int.Parse(dateId.ToString().Substring(0, 4));
            var month = int.Parse(dateId.ToString().Substring(4, 2));
            var day = int.Parse(dateId.ToString().Substring(6, 2));

            if (increment.type == DateIncrementTypes.Year)
            {
                year = year + increment.increments > 99 ? year + increment.increments - 99 : year + increment.increments;
            }
            if (increment.type == DateIncrementTypes.Month)
            {
                if (month + increment.increments > 12)
                {
                    year = year + 1;
                }
                month = month + increment.increments > 12 ? month + increment.increments - 12 : month + increment.increments;

            }
            if (increment.type == DateIncrementTypes.Day)
            {
                day = day + increment.increments > 30 ? day + increment.increments - 30 : day + increment.increments;
            }


            return (DoubleCharacterOut(year.ToString()) + DoubleCharacterOut(month.ToString()) + DoubleCharacterOut(day.ToString()));
        }

        public static string GetDateIDGivenIncrements(string dateIdA, string dateIdB)
        {
            var year = 0m;
            var month = 0m;
            var day = 0m;


            var yearA = int.Parse(dateIdA.ToString().Substring(0, 2));
            var monthA = int.Parse(dateIdA.ToString().Substring(2, 2));
            var dayA = int.Parse(dateIdA.ToString().Substring(4, 2));


            var yearB = int.Parse(dateIdB.ToString().Substring(0, 2));
            var monthB = int.Parse(dateIdB.ToString().Substring(2, 2));
            var dayB = int.Parse(dateIdB.ToString().Substring(4, 2));


            year = yearB - yearA > 24 ? yearB - yearA - 24 : yearB - yearA;
            month = monthB - monthA > 60 ? monthB - monthA - 60 : monthB - monthA;
            day = dayB - dayA > 60 ? dayB - dayA : dayB - dayA;

            return (DoubleCharacterOut(year.ToString()) + DoubleCharacterOut(month.ToString()) + DoubleCharacterOut(day.ToString()));
        }

        private static string DoubleCharacterOut(string input)
        {
            return input.Length == 1 ? "0" + input : input;
        }
    }
}
