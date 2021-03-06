﻿

namespace Cinema.Movie.Movie.Entities
{
    using Newtonsoft.Json;
    using Repositories;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ConnectionKey("Movie"), DisplayName("Movie"), InstanceName("Movie"), TwoLevelCached]
    [JsonConverter(typeof(JsonRowConverter))]
    [ModifyPermission("Administration")]
    [LookupScript("Movie.Movie")]
    public sealed class MovieRow : Row, IIdRow, INameRow
    {
        [DisplayName("Movie Id"), Identity]
        public Int64? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Title Original"), Size(400), NotNull, QuickSearch]
        public String TitleOriginal
        {
            get { return Fields.TitleOriginal[this]; }
            set { Fields.TitleOriginal[this] = value; }
        }

        [DisplayName("Title Translation"), Size(400)]
        public String TitleTranslation
        {
            get { return Fields.TitleTranslation[this]; }
            set { Fields.TitleTranslation[this] = value; }
        }
        [DisplayName("Title Display")]
        public String TitleDisplay
        {
            get { return (!String.IsNullOrWhiteSpace(TitleTranslation)&& TitleTranslation != TitleOriginal ? TitleTranslation+" / " : "")+ TitleOriginal+ " (" + (YearStart.HasValue == true && YearStart != YearEnd ? YearStart.ToString() : "") + YearEnd + ")"; }
        }

        [DisplayName("Url"), Size(400), NotNull]
        public String Url
        {
            get { return Fields.Url[this]; }
            set { Fields.Url[this] = value; }
        }
        [DisplayName("Description"), Size(10000)]
        public String[] Description
        {
            get { return !String.IsNullOrWhiteSpace(Fields.Description[this])?Fields.Description[this].Split(new[] { "<br>", "<br />" }, StringSplitOptions.None):new string[0]; }
            set { Fields.Description[this] =String.Join("<br>", value); }
        }

        [DisplayName("Year Start")]
        public Int16? YearStart
        {
            get { return Fields.YearStart[this]; }
            set { Fields.YearStart[this] = value; }
        }

        [DisplayName("Year End"), NotNull]
        public Int16? YearEnd
        {
            get { return Fields.YearEnd[this]; }
            set { Fields.YearEnd[this] = value; }
        }

        [DisplayName("Release World Date")]
        public DateTime? ReleaseWorldDate
        {
            get { return Fields.ReleaseWorldDate[this]; }
            set { Fields.ReleaseWorldDate[this] = value; }
        }

        [DisplayName("Release Other Date")]
        public DateTime? ReleaseOtherDate
        {
            get { return Fields.ReleaseOtherDate[this]; }
            set { Fields.ReleaseOtherDate[this] = value; }
        }

        [DisplayName("Release Dvd"), Column("ReleaseDVD")]
        public DateTime? ReleaseDvd
        {
            get { return Fields.ReleaseDvd[this]; }
            set { Fields.ReleaseDvd[this] = value; }
        }

        [DisplayName("Runtime"), Size(300)]
        public String Runtime
        {
            get { return Fields.Runtime[this]; }
            set { Fields.Runtime[this] = value; }
        }

        [DisplayName("Create Date Time"), NotNull]
        public DateTime? CreateDateTime
        {
            get { return Fields.CreateDateTime[this]; }
            set { Fields.CreateDateTime[this] = value; }
        }

        [DisplayName("Update Date Time"), NotNull]
        public DateTime? UpdateDateTime
        {
            get { return Fields.UpdateDateTime[this]; }
            set { Fields.UpdateDateTime[this] = value; }
        }

        [DisplayName("Publish Date Time"), NotNull]
        public DateTime? PublishDateTime
        {
            get { return Fields.PublishDateTime[this]; }
            set { Fields.PublishDateTime[this] = value; }
        }

        [DisplayName("Kind"), NotNull, DefaultValue(MovieKind.Film)]
        public MovieKind? Kind
        {
            get { return (MovieKind?)Fields.Kind[this]; }
            set { Fields.Kind[this] = (Int16?)value; }
        }

        [DisplayName("Rating"), NotNull]
        public Int16? Rating
        {
            get { return Fields.Rating[this]; }
            set { Fields.Rating[this] = value; }
        }

        [DisplayName("Mpaa"), Column("MPAA"), Size(6)]
        public String Mpaa
        {
            get { return Fields.Mpaa[this]; }
            set { Fields.Mpaa[this] = value; }
        }

        [DisplayName("Path Image"), Size(300)]
        public String PathImage
        {
            get { return Fields.PathImage[this]; }
            set { Fields.PathImage[this] = value; }
        }

        [DisplayName("Nice"), NotNull, DefaultValue(false)]
        public Boolean? Nice
        {
            get { return Fields.Nice[this]; }
            set { Fields.Nice[this] = value; }
        }

        [DisplayName("Cont Season")]
        public Int16? ContSeason
        {
            get { return Fields.ContSeason[this]; }
            set { Fields.ContSeason[this] = value; }
        }

        
        [DisplayName("Tagline"), Size(400)]
        public String Tagline
        {
            get { return Fields.Tagline[this]; }
            set { Fields.Tagline[this] = value; }
        }
        [DisplayName("Budget")]
        public Int32? Budget
        {
            get { return Fields.Budget[this]; }
            set { Fields.Budget[this] = value; }
        }
        [DisplayName("Genres")]
        [LookupEditor(typeof(GenreRow), Multiple = true), NotMapped]
        [LinkingSetRelation(typeof(MovieGenreRow), "MovieId", "GenreId")]
        public List<Int16> GenreList
        {
            get { return Fields.GenreList[this]; }
            set { Fields.GenreList[this] = value; }
        }
        [DisplayName("Genres")]
        [LookupEditor(typeof(GenreRow), Multiple = true), NotMapped]
        [LinkingSetRelation(typeof(MovieGenreRow), "MovieId", "GenreName")]
        public List<string> GenreListName
        {
            get { return Fields.GenreListName[this]; }
            set { Fields.GenreListName[this] = value; }
        }
        [DisplayName("Tags")]
        [LookupEditor(typeof(TagRow), Multiple = true), NotMapped]
        [LinkingSetRelation(typeof(MovieTagRow), "MovieId", "TagId")]
        public List<Int64> TagList
        {
            get { return Fields.TagList[this]; }
            set { Fields.TagList[this] = value; }
        }
        [DisplayName("Tags")]
        [LookupEditor(typeof(TagRow), Multiple = true), NotMapped]
        [LinkingSetRelation(typeof(MovieTagRow), "MovieId", "TagName")]
        public List<string> TagListName
        {
            get { return Fields.TagListName[this]; }
            set { Fields.TagListName[this] = value; }
        }
        
        public SortedList<string,string> CountrySortedList { get; set; }
        public List<CastRow> CastList { get; set; }
        public SortedList<string,List<CastRow>> CastSortList { get; set; }
        public List<VideoRow> VideoList { get; set; }
        public List<ServiceRatingRow> ServiceRatingList { get; set; }

        IIdField IIdRow.IdField
        {
            get { return Fields.MovieId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TitleOriginal; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public MovieRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field MovieId;
            public StringField TitleOriginal;
            public StringField TitleTranslation;
            public StringField Url;
            public StringField Description;
            public Int16Field YearStart;
            public Int16Field YearEnd;
            public DateTimeField ReleaseWorldDate;
            public DateTimeField ReleaseOtherDate;
            public DateTimeField ReleaseDvd;
            public StringField Runtime;
            public DateTimeField CreateDateTime;
            public DateTimeField UpdateDateTime;
            public DateTimeField PublishDateTime;
            public Int16Field Kind;
            public Int16Field Rating;
            public StringField Mpaa;
            public StringField PathImage;
            public BooleanField Nice;
            public Int16Field ContSeason;
            public StringField Tagline;
            public Int32Field Budget;
            public ListField<Int16> GenreList;
            public ListField<string> GenreListName;
            public ListField<Int64> TagList;
            public ListField<string> TagListName;

            public RowFields()
                : base("[mov].[Movie]")
            {
                LocalTextPrefix = "Movie.Movie";
            }
        }
    }
}