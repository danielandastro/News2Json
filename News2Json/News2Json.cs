using System;
using Newtonsoft.Json;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Collections.Generic;

namespace News2Json
{
    public class Json
    {
        public string ReturnJson(string url)
        {
            var dataToSerialise = new List<Data>();
            foreach (SyndicationItem item in XMLParser.Parser(url).Items)
            {
                var obj = new Data();
                try
                {
                    obj.author = item.Authors.ToString();
                }
                catch (Exception)
                {
                    obj.author = "Failed to parse field author";
                }

                try
                {
                    obj.title = item.Title.Text;
                }
                catch (Exception)
                {
                    obj.title = "Failed to parse field title";
                }

                try
                {
                    obj.content= item.Content.ToString();
                }
                catch (Exception)
                {
                    obj.content = "Failed to parse field content";
                }
                obj.source = url;

                try
                {
                    obj.publishingDate = item.PublishDate.Date;
                }
                catch (Exception)
                {
                    obj.publishingDate = DateTime.Parse("00, 00, 00, 0000");
                }

                try
                {
                    obj.contributors = item.Contributors.ToString();
                }
                catch (Exception)
                {
                    obj.contributors = "Failed to parse field contributors";
                }

                try
                {
                    obj.copyright = item.Copyright.Text;
                }
                catch (Exception)
                {
                    obj.copyright = "Failed to parse field copyright";
                }

                try
                {
                    obj.links = item.Links.ToString();
                }
                catch (Exception)
                {
                    obj.links = "Failed to parse field links";
                }
                try
                {
                    obj.summary = item.Summary.Text;
                }
                catch (Exception)
                {
                    obj.summary = "Failed to parse field summary";
                }
                dataToSerialise.Add(obj);
            }
            var dataToSend = JsonConvert.SerializeObject(dataToSerialise);
            return dataToSend;
        }

    }
    static class XMLParser
    {
        public static SyndicationFeed Parser(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            return SyndicationFeed.Load(reader);
        }

    }

    public class Data
    {
        public string title;
        public string content;
        public string source;
        public string author;
        public DateTime publishingDate;
        public string contributors;
        public string copyright;
        public string links;
        public string summary;
    }
}