using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanReadableDurationFormat
{
    public class HumanTimeFormat
    {   
        public static string formatDuration(int seconds)
        {
            if (seconds == 0)
                return "now";
            
            return ReplaceLastOccurrence(
                string.Join(
                    ", ",
                    SecondsToTimeComponents(seconds)
                        .Where(c => c.Value != 0)
                        .Select(TimeComponentToString)
                ),
                ",",
                " and"
            );
        }
        
        public enum TimeComponentType
        {
            Seconds,
            Minutes, 
            Hours,
            Days,
            Years
        }
        
        private struct TimeComponent
        {
            public TimeComponentType Type;
            public int Value;
        }

        private static IEnumerable<TimeComponent> SecondsToTimeComponents(int seconds)
        {     
            yield return new TimeComponent
            {
                Type = TimeComponentType.Years, 
                Value = seconds / (60 * 60 * 24 * 365)
            };
            yield return new TimeComponent
            {
                Type = TimeComponentType.Days,
                Value = seconds / (60 * 60 * 24) % 365
            };
            yield return new TimeComponent
            {
                Type = TimeComponentType.Hours,
                Value = seconds / (60 * 60) % 24,
            };
            yield return new TimeComponent
            {
                Type = TimeComponentType.Minutes,
                Value = seconds / 60 % 60
            };
            yield return new TimeComponent
            {
                Type = TimeComponentType.Seconds,
                Value = seconds % 60
            };
        }

        private static string TimeComponentToString(TimeComponent timeComponent)
        {
            var timeComponentName = timeComponent.Type.ToString().ToLower();
            timeComponentName = timeComponent.Value == 1 
                ? timeComponentName.Remove(timeComponentName.Length - 1)
                : timeComponentName;
            
            return $"{timeComponent.Value} {timeComponentName}";
        }
        
        private static string ReplaceLastOccurrence(string source, string find, string replace)
        {
            var place = source.LastIndexOf(find, StringComparison.Ordinal);
            return place == -1
                ? source 
                : source.Remove(place, find.Length).Insert(place, replace);
        }
    }
}