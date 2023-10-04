using System;
using System.IO;
using System.Text;

namespace DanishLearningSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder ical = new StringBuilder();
            DateTime startDate = new DateTime(2024, 1, 1);
            string[] phases = {
                "Grammar and Vocabulary Building",
                "Writing Exercises",
                "Reading Danish Texts",
                "Advanced Grammar and Style",
                "Write and Revise",
                "Professional Writing Exercises"
            };

            // Begin Calendar
            ical.AppendLine("BEGIN:VCALENDAR");
            ical.AppendLine("VERSION:2.0");
            ical.AppendLine("PRODID:-//Danish Learning Schedule//EN");

            for (int phase = 0; phase < phases.Length; phase++)
            {
                for (int week = 0; week < 4; week++)  // Each phase lasts for 4 weeks
                {
                    DateTime eventDate = startDate.AddDays((phase * 4 + week) * 7);
                    string summary = phases[phase];
                    string description = $"Phase {phase + 1}: {summary}";

                    // Begin Event
                    ical.AppendLine("BEGIN:VEVENT");
                    ical.AppendLine($"DTSTART;TZID=Europe/Copenhagen:{eventDate:yyyyMMdd}T090000");  // Assumes a start time of 9:00 AM
                    ical.AppendLine($"DTEND;TZID=Europe/Copenhagen:{eventDate:yyyyMMdd}T100000");    // Assumes an end time of 10:00 AM
                    ical.AppendLine($"SUMMARY:{summary}");
                    ical.AppendLine($"DESCRIPTION:{description}");
                    ical.AppendLine("END:VEVENT");
                }
            }

            // End Calendar
            ical.AppendLine("END:VCALENDAR");

            // Write to file
            File.WriteAllText("LearningSchedule.ics", ical.ToString());
            Console.WriteLine("iCalendar file created successfully.");
        }
    }
}
