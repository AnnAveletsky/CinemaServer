﻿using FluentMigrator;
using System;

namespace Cinema.Movie.Migrations.MovieDB
{
    [Migration(20160607115103)]
    public class MovieDB_20160607_115103_Initial : Migration
    {
        public override void Up()
        {
            
            Create.Table("Video").InSchema("mov")
                .WithColumn("VideoId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("Path").AsString(Int32.MaxValue).Nullable()
                .WithColumn("Player").AsInt16().Nullable()
                .WithColumn("PathTorrent").AsString(300).Nullable()
                .WithColumn("Name").AsString(300).Nullable()
                .WithColumn("Translation").AsInt16().Nullable().WithDefaultValue(1)
                .WithColumn("Season").AsInt16().Nullable()
                .WithColumn("Serie").AsInt16().Nullable()
                .WithColumn("Storyline").AsString(Int16.MaxValue).Nullable()
                .WithColumn("PlannePublishDate").AsDate().Nullable()
                .WithColumn("ActualPublishDateTime").AsDateTime().Nullable()
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_Video_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("ServiceId").AsInt16().Nullable()
                    .ForeignKey("FK_Video_ServiceId", "mov", "Service", "ServiceId");
            
        }
        public override void Down()
        {
        }
    }
}