﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RicePkg.Models;
using RicePkg.Models.ErrorMessage;

namespace RicePkg.Controllers
{
    public class RicePeopleController : ApiController
    {
        // GET api/<controller>/
        public HttpResponseMessage Get(string firstname, string lastname, string college)
        {
            try
            {
                if (firstname == null || lastname == null || college == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new NullInputeMessage());
                return Request.CreateResponse(HttpStatusCode.OK, RicePeople.get(firstname, lastname, college));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new GeneralFailureMessage());
            }
        }
    }
}