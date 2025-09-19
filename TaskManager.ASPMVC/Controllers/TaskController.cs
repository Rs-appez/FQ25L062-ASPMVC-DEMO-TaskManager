using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.ASPMVC.Mapper;
using TaskManager.ASPMVC.Models.Task;
using TaskManager.BLL.Entities;
using TaskManager.Common.Repositories;

namespace TaskManager.ASPMVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository<ManagedTask> _taskService;

        public TaskController(ITaskRepository<ManagedTask> taskService)
        {
            _taskService = taskService;
        }

        // GET: TaskController
        public ActionResult Index()
        {
            IEnumerable<TaskListItem> model = _taskService.Get().Select(bll => bll.ToListItem());
            return View(model);
        }

        // GET: TaskController/Details/5
        public ActionResult Details(Guid id)
        {
            TaskDetails model = _taskService.Get(id).ToDetails();
            return View(model);
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Formulaire invalide");
                Guid taskId = _taskService.Insert(form.ToBLL());
                return RedirectToAction(nameof(Details), new { id = taskId });
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Edit/5
        public ActionResult Edit(Guid id)
        {
            TaskEditForm model = _taskService.Get(id).ToEditForm();
            return View(model);
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, TaskEditForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Formulaire invalide");
                if (!_taskService.Update(id, form.ToBLL())) throw new Exception("Échec de la mise à jour");
                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(Guid id)
        {
            TaskDelete model = _taskService.Get(id).ToDelete();
            return View(model);
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, TaskDelete form)
        {
            try
            {
                if (!_taskService.Delete(id)) throw new Exception("Échec de la suppression");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
}
