using System;

namespace LiveSplit.TimeFormatters
{
    public class RegularSplitTimeFormatter : ITimeFormatter
    {
        public TimeAccuracy Accuracy { get; set; }

        public RegularSplitTimeFormatter(TimeAccuracy accuracy)
        {
            Accuracy = accuracy;
        }
        public string Format(TimeSpan? time)
        {
            var formatter = new DecimalTimeFormatter(Accuracy);
            formatter.NullFormat = NullFormat.ZeroWithAccuracy;
            formatter.DigitsFormat = DigitsFormat.SingleDigitMinutes;

            if (time == null)
                return TimeFormatConstants.DASH;
            else
                return formatter.Format(time);
        }
    }
}
