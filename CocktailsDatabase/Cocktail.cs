using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsDatabase
{
    /// <summary>
    /// Описывает сущность коктейля
    /// </summary>
    public class Cocktail
    {
        public Cocktail()
        {
            this.Ingredients = new HashSet<CocktailIngredient>();
        }

        /// <summary>
        /// Идентификатор коктейля
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Название коктейля
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Описание коктейля
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// Список иградиентов текущего коктейля
        /// </summary>
        public virtual ICollection<CocktailIngredient> Ingredients { set; get; }
    }
}
