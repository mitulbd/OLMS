﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OLMS.BackEnd.Model;
using OLMS.BackEnd.RequestModel;
using OLMS.BackEnd.ViewModel;

namespace OLMS.BackEnd.API.Controllers
{
    [RoutePrefix("api/Content")]
    public class ContentController  : BaseController<Content, ContentRequestModel, ContentViewModel>
    {
       
      
    }
}
