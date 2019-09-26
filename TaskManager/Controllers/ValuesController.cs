using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;
using TaskManager.Logs;

namespace TaskManager.Controllers
{
    public class ValuesController : ApiController
    {
        DB db = new DB();
        ILogger log;
        public ValuesController(ILogger L)
        {
             log = L;
        }
        public IEnumerable<TaskList> GetTaskList()
        {
            log.log("GetTaskList()");
            return db.TaskLists.OrderBy(x => x.Dt).ToList();
        }
    }
}
