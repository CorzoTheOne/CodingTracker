﻿using System;

public static class CodingSession
{
    public static int Id = 1;
    private static DateTime StartCodingSession()
    {
        DateTime start = DateTime.Now;
        return start;
    }

    private static DateTime EndCodingSession()
    {
        DateTime end = DateTime.Now;
        return end;
    }

    private static string CodingSessionDuration(DateTime start, DateTime end)
    {
        TimeSpan duration = end.Subtract(start);
        string formattedDuration = string.Format("{0}h " + "{1}m " + "{2}s",
                                          duration.Hours,
                                          duration.Minutes,
                                          duration.Seconds);
        string test = formattedDuration;
        return test;
    }

    public static void CodingSessionActive()
    {
        DateTime start = StartCodingSession();

        Console.WriteLine("The Coding session is now active. Press 'Enter' 3 times to end it.");

        Console.ReadLine();
        Console.ReadLine();
        Console.ReadLine();

        DateTime end = EndCodingSession();
        string time = CodingSessionDuration(start, end);

        DatabaseManager.InsertSession(time);
    }
}