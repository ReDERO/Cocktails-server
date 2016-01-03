using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsDatabase
{
    /// <summary>
    /// Описывает сущность ингредиента
    /// </summary>
    public class Ingredient
    {
        public Ingredient()
        {
            this.Cocktails = new HashSet<CocktailIngredient>();
        }

        /// <summary>
        /// Идентификатор ингредиента
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Название ингредиента
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Описание ингредиента
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// Список коктейтей, котоые имеют в составе текущий элемент
        /// </summary>
        public virtual ICollection<CocktailIngredient> Cocktails { set; get; }
    }
}
