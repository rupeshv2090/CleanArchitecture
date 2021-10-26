// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
using Newtonsoft.Json;
using System.Collections.Generic;

public class Xml
{
    [JsonProperty("@version")]
    public string Version { get; set; }

    [JsonProperty("@encoding")]
    public string Encoding { get; set; }
}

public class Item
{
    public string title { get; set; }
    public string link { get; set; }
    public string description { get; set; }
    public string pubDate { get; set; }
    public string baseCurrency { get; set; }
    public string baseName { get; set; }
    public string targetCurrency { get; set; }
    public string targetName { get; set; }
    public string exchangeRate { get; set; }
    public string inverseRate { get; set; }
    public string inverseDescription { get; set; }
}

public class Channel
{
    public string title { get; set; }
    public string link { get; set; }
    public string xmlLink { get; set; }
    public string description { get; set; }
    public string language { get; set; }
    public string baseCurrency { get; set; }
    public string pubDate { get; set; }
    public string lastBuildDate { get; set; }
    public List<Item> item { get; set; }
}

public class Root
{
    [JsonProperty("?xml")]
    public Xml Xml { get; set; }

    [JsonProperty("?xml-stylesheet")]
    public string XmlStylesheet { get; set; }
    public Channel channel { get; set; }
}

