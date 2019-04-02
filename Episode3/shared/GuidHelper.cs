using System;

public class GuidHelper
{
    public static string GetRandomGuid()
    {
        return Guid.NewGuid().ToString();
    }
}