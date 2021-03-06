﻿
namespace Cinema.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.Site")]
    [BasedOnRow(typeof(Entities.SiteRow))]
    public class SiteForm
    {
        public String Name { get; set; }
        public String Url { get; set; }
        public String Title { get; set; }
        public String Background { get; set; }
        public String Logo { get; set; }
        public String BackgroundColor { get; set; }
        public Int32 DataBaseId { get; set; }
    }
}