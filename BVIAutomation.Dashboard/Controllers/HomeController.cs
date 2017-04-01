using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BVIAutomation.Model.Entities;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using BVIAutomation.Model.DTO;

namespace Bolado.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        /// <summary>
        /// API to retrieve a Json Tree from a Modules List
        /// </summary>
        /// <param name="arrModules"></param>
        /// <returns>Returns a Json Tree Map of Modules</returns>
        [HttpPost]
        public ActionResult GetMap(List<Module> arrModules)
        {
            var treeObj = BuildTreeAndGetRoots(arrModules);

            var r = JsonConvert.SerializeObject(treeObj, Formatting.Indented,
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }
                );
            return Json(r);          
        }
        /// <summary>
        /// Method to unflatten a list into a Tree Map
        /// </summary>
        /// <param name="actualObjects"></param>
        /// <returns>Returns a Tree List (ModuleNode roots with children)</returns>
        public List<ModuleNode> BuildTreeAndGetRoots(List<Module> actualObjects)
        {
            var lookup = new Dictionary<int, ModuleNode>();
            var rootNodes = new List<ModuleNode>();

            foreach (var item in actualObjects)
            {
                // add us to lookup
                ModuleNode ourNode;
                if (lookup.TryGetValue(item.Id, out ourNode))
                {   // was already found as a parent - register the actual object
                    ourNode.Source = item;
                }
                else
                {
                    ourNode = new ModuleNode() { Source = item };
                    lookup.Add(item.Id, ourNode);
                }

                // hook into parent
                if (item.IdModule == 0)
                {   // is a root node
                    rootNodes.Add(ourNode);
                }
                else
                {   // is a child row - so we have a parent
                    ModuleNode parentNode;
                    if (!lookup.TryGetValue(item.IdModule, out parentNode))
                    {   // unknown parent, construct preliminary parent
                        parentNode = new ModuleNode();
                        lookup.Add(item.IdModule, parentNode);
                    }
                    parentNode.Children.Add(ourNode);
                    ourNode.Parent = parentNode;
                }
            }

            return rootNodes;
        }
    }
}
