using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RESTService.Repository;
using RESTService.Models;

namespace RESTService.Controllers
{
    /// <summary>
    /// 
    /// This is an example of creating an MVC REST web service, supporing XML and JSON responses.
    /// The example simulates an RPG monster creation tool, which creates and returns monsters based upon RESTful web service calls.
    /// 
    /// By Kory Becker
    /// http://www.primaryobjects.com/articledirectory.aspx
    /// 
    /// </summary>
    public class MonsterController : Controller
    {
        private static MonsterRepository _repository = new MonsterRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return new ViewResult();
        }

        /// <summary>
        /// Insert a new monster @ /API/Monster. All other requests to this URL are ignored.
        /// </summary>
        [HttpPost]
        public ActionResult InsertMonster(Monster monster)
        {
            _repository.Insert(monster);

            return new ObjectResult<Monster>(monster);
        }

        /// <summary>
        /// Read an existing monster @ /API/Monster/{name}
        /// </summary>
        [HttpGet]
        public ActionResult Monster(string name)
        {
            Monster monster = _repository.GetByName(name);
            return new ObjectResult<Monster>(monster);
        }

        /// <summary>
        /// Update an existing monster @ /API/Monster/{name}
        /// </summary>
        [HttpPut]
        public ActionResult Monster(string name, Monster updateMonster)
        {
            Monster monster = _repository.GetByName(name);

            if (monster != null)
            {
                monster.MonsterName = updateMonster.MonsterName;
                monster.Age = updateMonster.Age;
                monster.Description = updateMonster.Description;
            }

            return new ObjectResult<Monster>(monster);
        }

        /// <summary>
        /// Delete an existing monster @ /API/Monster/{name}
        /// </summary>
        [HttpDelete]
        public ActionResult Monster(string name, FormCollection form)
        {
            Monster monster = _repository.GetByName(name);

            if (monster != null)
            {
                _repository.Delete(monster);
            }

            return new ObjectResult<Monster>(monster);
        }
    }
}
