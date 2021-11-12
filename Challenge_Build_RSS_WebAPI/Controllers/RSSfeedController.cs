using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge_Build_RSS_WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RSSfeedController : ControllerBase
  {
    // GET: api/<RSSfeedController>
    [HttpGet]
    public IActionResult Get(string feed = null)
    {
      var feedDecodede = HttpUtility.UrlDecode(feed); // "http://feeds.tv2.dk/nyheder/rss"
      if (Uri.IsWellFormedUriString(feedDecodede, UriKind.Absolute) &&
              feedDecodede.Substring(feedDecodede.Length - 3) == "rss")
      {
        SyndicationFeed feedinput = null;
        using (var reader = XmlReader.Create(feedDecodede))
        {
          feedinput = SyndicationFeed.Load(reader);
        }

        var TheseEntries = feedinput.Items.Select(a =>
              new ReturnTypes.RSSfeed.RSSentries
              {
                title = a.Title.Text,
                authors = a.Authors.Select(a => a.Name).ToList(),
                link = a.Links.First().GetAbsoluteUri().AbsoluteUri,
                pubDate = ReturnTypes.RSSfeed.ChangeUtcTimeToGMTplus2(a.PublishDate.UtcDateTime)
              }).Take(5).ToList();

        var EntireRSS = new ReturnTypes.RSSfeed();
        EntireRSS.entries = TheseEntries;

        EntireRSS.desc = feedinput.Description.Text;
        EntireRSS.title = feedinput.Title.Text;
        EntireRSS.img.title = "";
        EntireRSS.img.url = "";

        DateTime AuthorsThreshold24UtcHours = DateTime.UtcNow.AddDays(-1);
        // Sammentæl unikke rullende forfattere indenfor de sidste og forvent at vi har feed-data som dækker dette tidsvindue
        var NumberOfAuthors = feedinput.Items.Where(a => a.PublishDate.UtcDateTime > AuthorsThreshold24UtcHours).SelectMany(a => a.Authors).Distinct().Count();
        EntireRSS.authorsToday = NumberOfAuthors;
        return Ok(EntireRSS);
      }
      else
        return NotFound("Unable to resolve RSSfeed. Invalid Uri");
    }


  }
}
