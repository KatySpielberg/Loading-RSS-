using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UWPRSSapp.Model
{
   public class NewsItem
    {
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("link")]
        public string Link { get; set; }
        [XmlElement("image")]
        public string Image { get; set; }

    }
}
