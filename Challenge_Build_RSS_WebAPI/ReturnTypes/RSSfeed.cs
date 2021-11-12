using System;
using System.Collections.Generic;

namespace Challenge_Build_RSS_WebAPI.ReturnTypes
{
  public class RSSfeed
  {
    public RSSfeed()
    {
      img = new RSSimg();
      entries = new List<RSSentries>();
    }

    public string title { get; set; }
    public int authorsToday { get; set; }
    public string desc { get; set; }
    public RSSimg img { get; set; }
    public List<RSSentries> entries { get; set; }

    public class RSSentries
    {
      public RSSentries()
      {
        authors = new List<string>();
      }
      public string title { get; set; }
      public string link { get; set; }
      public string pubDate { get; set; }
      public List<string> authors { get; set; }
    }

    public class RSSimg
    {
      public string title { get; set; }
      public string url { get; set; }
    }

    public static string ChangeUtcTimeToGMTplus2(DateTime utcDateTime)
    {
      string GMTplus2_TimeZoneName = "Middle East Standard Time";
      TimeZoneInfo GMTplus2_TimeZone = TimeZoneInfo.FindSystemTimeZoneById(GMTplus2_TimeZoneName);
      DateTime GMTplus2_DateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, GMTplus2_TimeZone);

      return GMTplus2_DateTime.ToString("dd-MM-yyyy HH:mm:ss");
    }
  }
}
