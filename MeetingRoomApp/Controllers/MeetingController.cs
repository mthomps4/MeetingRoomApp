﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingRoomApp.Controllers
{
    public class MeetingController : Controller
    {
        // GET: Meeting
        public ActionResult Create()
        {
            return View();
        }
    }
}