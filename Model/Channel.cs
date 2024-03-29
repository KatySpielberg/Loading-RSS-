﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UWPRSSapp.Model
{
    public class Channel
    {
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("item")]
        public List<NewsItem> NewsItems { get; set; }

        public Channel()
        {
            this.NewsItems = new List<NewsItem>();
        }
    }
}
