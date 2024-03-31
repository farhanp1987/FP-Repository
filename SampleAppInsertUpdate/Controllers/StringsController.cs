using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web.Http;
using SampleAppInsertUpdate.Models;
using SampleAppInsertUpdate.Data;

namespace SampleAppInsertUpdate.Controllers
{
    public class StringsController: ApiController
    {
        private readonly StringRepository _repository;

        public StringsController()
        {
            _repository = new StringRepository();
        }

        // GET: api/strings
        public IHttpActionResult GetStrings()
        {
            var strings = _repository.GetStrings();
            return Ok(strings);
        }

        // POST: api/strings
        public IHttpActionResult PostString(StringModel stringModel)
        {
            stringModel.UpdatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _repository.AddOrUpdateString(stringModel);
            return Ok();
        }
    }
}