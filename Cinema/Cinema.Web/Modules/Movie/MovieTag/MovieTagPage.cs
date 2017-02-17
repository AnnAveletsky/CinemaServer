﻿
namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;
    using Repository = Repositories.MovieTagRepository;
    using MyRow = Entities.MovieTagRow;
    using Serenity.Services;
    using Serenity.Data;

    [RoutePrefix("Movie/MovieTag"), Route("{action=index}")]
    public class MovieTagController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/MovieTag/MovieTagIndex.cshtml");
        }
        public static RetrieveResponse<MyRow> Find(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            {
                return new Repository().Find(connection, listRequest);
            }
        }
        public static ListResponse<MyRow> List(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            {
                return new Repository().List(connection, listRequest);
            }
        }
        public static SaveResponse UpdateCreate(SaveRequest<MyRow> saveRequest)
        {
            ListRequest listRequest = new ListRequest() { Criteria = new Repository().Criteria(saveRequest.Entity) };
            using (var connection = SqlConnections.NewFor<MyRow>())
            using (var uow = new UnitOfWork(connection))
            {
                if (new Repository().Exist(connection, listRequest))
                {
                    return new Repository().FindUpdate(uow, saveRequest, listRequest);
                }
                else
                {
                    return new Repository().Create(uow, saveRequest);
                }
            }
        }
    }
}