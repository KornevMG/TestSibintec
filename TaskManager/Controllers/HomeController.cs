using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using System.Threading.Tasks;
using System.Threading;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            DB _db = new DB();
            foreach (TaskList t in _db.TaskLists)
            {
                if (t.Mark) t.Name = String.Format("Comlete  {0}", t.Name);
            }
            return View(_db.TaskLists.OrderBy(x => x.Dt).ToList());
        }
        [HttpPost]
        public ActionResult TaskSearch()
        {
            DB _db = new DB();
            var all = _db.TaskLists.OrderBy(x => x.Dt).ToList();
            if (all.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(all);
        }
        public ActionResult SaveNewTask(string name, string Mark)
        {
            DB db = new DB();
            try
                {
                    TaskList tasks = new TaskList();
                    tasks.Id = Guid.NewGuid();
                    tasks.Name = name;
                    tasks.Dt = DateTime.Now;

                    db.TaskLists.Add(tasks);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    String er = ex.Message;
                }
            return PartialView("TaskSearch", db.TaskLists.OrderBy(x => x.Dt).ToList());
        }
        public ActionResult CheckTask(Guid? Id, string Mark)
        {
            
            if (Id!=null)
                try
                {
                    DB db = new DB();
                    TaskList task = db.TaskLists.Find(Id);

                    if (Mark == "0") task.Mark = false;
                    if (Mark == "1") task.Mark = true;

                    db.Entry(task).State = EntityState.Modified;
                    db.SaveChanges();

                    var all = db.TaskLists.OrderBy(x => x.Dt).ToList();
                    foreach (TaskList t in db.TaskLists)
                    {
                        if (t.Mark) t.Name = String.Format("Comlete  {0}", t.Name);
                    }
                    if (all.Count <= 0)
                    {
                        return HttpNotFound();
                    }
                    return PartialView("TaskSearch",all);
                }
                catch (Exception ex)
                {
                    String er = ex.Message;
                }
            return RedirectToAction("TaskSearch");
        } 
    }
}
