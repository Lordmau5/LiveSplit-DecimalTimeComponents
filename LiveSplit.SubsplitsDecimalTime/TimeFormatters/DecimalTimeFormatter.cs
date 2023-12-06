using System;

namespace LiveSplit.TimeFormatters
{
    public class DecimalTimeFormatter : GeneralTimeFormatter
    {
        public DecimalTimeFormatter(TimeAccuracy accuracy = TimeAccuracy.Hundredths)
        {
            Accuracy = accuracy;
            NullFormat = NullFormat.ZeroWithAccuracy;
        }

        public string Format(TimeSpan? timeNullable, TimeFormat timeFormat)
        {
            var formatter = new DecimalTimeFormatter
            {
                Accuracy = this.Accuracy,
                NullFormat = this.NullFormat,
                TimeFormat = timeFormat
            };

            return formatter.Format(timeNullable);
        }

        public string Format(TimeSpan? timeNullable)
        {
            bool isNull = (!timeNullable.HasValue);
            if (isNull)
            {
                if (NullFormat == NullFormat.Dash)
                {
                    return TimeFormatConstants.DASH;
                }
                else if (NullFormat == NullFormat.ZeroWithAccuracy)
                {
                    return ZeroWithAccuracy();
                }
                else if (NullFormat == NullFormat.ZeroDotZeroZero)
                {
                    return "0.00";
                }
                else if (NullFormat == NullFormat.ZeroValue || NullFormat == NullFormat.Dashes)
                {
                    timeNullable = TimeSpan.Zero;
                }
            }

            TimeSpan time = timeNullable.Value;

            string minusString;
            if (time < TimeSpan.Zero)
            {
                minusString = TimeFormatConstants.MINUS;
                time = -time;
            }
            else
            {
                minusString = (ShowPlus ? "+" : "");
            }

            var TotalDecimalMilliSeconds = (long)time.TotalMilliseconds / 0.864;
            var TotalDecimalSeconds = (long)TotalDecimalMilliSeconds / 1000;
            var TotalDecimalMinutes = TotalDecimalSeconds / 100;
            var TotalDecimalHours = TotalDecimalMinutes / 100;

            var DecimalMilliSeconds = (long)TotalDecimalMilliSeconds % 1000;
            var DecimalSeconds = TotalDecimalSeconds % 100;
            var DecimalMinutes = TotalDecimalMinutes % 100;

            string DecimalMilliSecondsFormated = "";
            if (AutomaticPrecision)
            {
                if (Accuracy == TimeAccuracy.Seconds || TotalDecimalSeconds % 1 == 0)
                    DecimalMilliSecondsFormated = "";
                else if (Accuracy == TimeAccuracy.Tenths || (10 * TotalDecimalSeconds) % 1 == 0)
                    DecimalMilliSecondsFormated = $".{DecimalMilliSeconds / 100}";
                else if (Accuracy == TimeAccuracy.Hundredths || (100 * TotalDecimalSeconds) % 1 == 0)
                    DecimalMilliSecondsFormated = $".{DecimalMilliSeconds / 10:D2}";
                else
                    DecimalMilliSecondsFormated = $".{DecimalMilliSeconds:D3}";
            }
            else
            {
                if (DropDecimals && time.TotalMinutes >= 1)
                    DecimalMilliSecondsFormated = "";
                else if (Accuracy == TimeAccuracy.Seconds)
                    DecimalMilliSecondsFormated = "";
                else if (Accuracy == TimeAccuracy.Tenths)
                    DecimalMilliSecondsFormated = $".{DecimalMilliSeconds / 100}";
                else if (Accuracy == TimeAccuracy.Hundredths)
                    DecimalMilliSecondsFormated = $".{DecimalMilliSeconds / 10:D2}";
                else if (Accuracy == TimeAccuracy.Milliseconds)
                    DecimalMilliSecondsFormated = $".{DecimalMilliSeconds:D3}";
            }

            string timeFormated = "";
            if (ShowDays && time.TotalDays > 0)
            {
                var DecimalHours = TotalDecimalHours % 10;
                timeFormated = $"{time.TotalDays}:{DecimalHours}:{DecimalMinutes:D2}:{DecimalSeconds:D2}{DecimalMilliSecondsFormated}";
            }
            else if (TotalDecimalHours > 0 || DigitsFormat == DigitsFormat.DoubleDigitHours || DigitsFormat == DigitsFormat.SingleDigitHours)
            {
                timeFormated = $"{TotalDecimalHours}:{DecimalMinutes:D2}:{DecimalSeconds:D2}{DecimalMilliSecondsFormated}";
            }
            else if (DecimalMinutes > 9 || DigitsFormat == DigitsFormat.DoubleDigitMinutes)
            {
                timeFormated = $"{DecimalMinutes:D2}:{DecimalSeconds:D2}{DecimalMilliSecondsFormated}";
            }
            else if (DecimalMinutes > 0 || DigitsFormat == DigitsFormat.SingleDigitMinutes)
            {
                timeFormated = $"{DecimalMinutes:D1}:{DecimalSeconds:D2}{DecimalMilliSecondsFormated}";
            }
            else if (DecimalSeconds > 9 || DigitsFormat == DigitsFormat.DoubleDigitSeconds)
            {
                timeFormated = $"{DecimalSeconds:D2}{DecimalMilliSecondsFormated}";
            }
            else
            {
                timeFormated = $"{DecimalSeconds:D1}{DecimalMilliSecondsFormated}";
            }
            return minusString + timeFormated;
        }

        private string ZeroWithAccuracy()
        {
            if (AutomaticPrecision || Accuracy == TimeAccuracy.Seconds)
                return "0";
            else if (Accuracy == TimeAccuracy.Tenths)
                return "0.0";
            else if (Accuracy == TimeAccuracy.Milliseconds)
                return "0.000";
            else
                return "0.00";
        }
    }
}
