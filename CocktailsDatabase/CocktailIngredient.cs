using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsDatabase
{
    /// <summary>
    /// Элемент списка инградиентов коктейля
    /// </summary>
    public class CocktailIngredient
    {
        /// <summary>
        /// Идентификатор коктейля
        /// </summary>
        [Key, Column(Order = 0)]
        public int CocktailId { set; get; }

        /// <summary>
        /// Идентификатор ингредиента
        /// </summary>
        [Key, Column(Order = 1)]
        public int IngredientId { set; get; }

        /// <summary>
        /// Количество ингредиента
        /// </summary>
        public int Count { set; get; }

        /// <summary>
        /// Коктейль
        /// </summary>
        public virtual Cocktail Cocktail { set; get; }

        /// <summary>
        /// Ингредиент
        /// </summary>
        public virtual Ingredient Ingredient { set; get; }
    }
}
