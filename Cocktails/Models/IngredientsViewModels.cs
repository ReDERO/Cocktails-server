using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailsDatabase;

namespace Cocktails.Models
{
    public class IngredientListItem
    {
        public IngredientListItem(Ingredient item)
        {
            Id = item.Id;
            Name = item.Name;
        }

        /// <summary>
        /// Идентификатор ингредиента
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Название ингредиента
        /// </summary>
        public string Name { set; get; }
    }
}
