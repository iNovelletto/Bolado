using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BVIAutomation.Model.Entities;
using Newtonsoft.Json;
using System.Web.UI.WebControls;

namespace Bolado.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public string GetMap(List<Module> arrModules)
        {
            var treeObj = BuildTree(arrModules);

            return JsonConvert.SerializeObject(treeObj);
        }
        
        public TreeNode BuildTree(List<Module> modulesList)
        {
            TreeNode rootNode = null;
            var dic = modulesList.ToDictionary(
                      module => module.Id,
                      module => new { Module = module, Node = new TreeNode(module.Id.ToString())}
                );
            foreach(var v in dic.Values)
            {
                var module = v.Module;
                if (module.IdModule > 0) dic[(int)module.IdModule].Node.ChildNodes.Add(v.Node);
                else rootNode = v.Node;
            }

            return rootNode;
        }
        
    }
}
