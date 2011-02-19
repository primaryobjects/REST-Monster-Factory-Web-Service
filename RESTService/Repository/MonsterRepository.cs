using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESTService.Models;

namespace RESTService.Repository
{
    public class MonsterRepository
    {
        private static int _nextId = 1;
        private List<Monster> _repository = new List<Monster>();

        public MonsterRepository()
        {
            // Initialize the repository with some monsters.
            Insert(new Monster("Jackraw", 12, "A small, stubby, woodland creature with sharp claws.", WeaponType.Club, ArmorType.Cloth));
            Insert(new Monster("Shredwraith", 12, "A ghostly apparition with a menacing stare.", WeaponType.Scythe, ArmorType.Cloth));
        }

        /// <summary>
        /// Helper method to find a monster in the repository, by Id.
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns>Monster</returns>
        public Monster GetById(int id)
        {
            var query = from m in _repository
                        where m.Id == id
                        select m;

            return GetFirstOrNull<Monster>(query);
        }

        /// <summary>
        /// Helper method to find a monster in the repository, by Name.
        /// </summary>
        /// <param name="name">string</param>
        /// <returns>Monster</returns>
        public Monster GetByName(string name)
        {
            var query = from m in _repository
                        where m.MonsterName.ToLower() == name.ToLower()
                        select m;

            return GetFirstOrNull<Monster>(query);
        }

        public void Insert(Monster monster)
        {
            monster.Id = _nextId++;

            _repository.Add(monster);
        }

        public void Delete(Monster monster)
        {
            Monster target = GetById(monster.Id);

            if (target != null)
            {
                _repository.Remove(target);
            }
        }

        #region Helper Methods

        /// <summary>
        /// Gets the first element in an IEnumerable list or null.
        /// </summary>
        /// <param name="list">IEnumerable, such as result from a LINQ query.</param>
        /// <returns>object or null</returns>
        private T GetFirstOrNull<T>(IEnumerable<T> list)
        {
            T result = default(T);

            if (list.Count() > 0)
            {
                result = list.ToList()[0];
            }

            return result;
        }

        #endregion
    }
}