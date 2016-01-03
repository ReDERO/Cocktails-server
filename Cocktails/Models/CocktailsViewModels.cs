using CocktailsDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails.Models
{
    class CocktailViewModel
    {
        public CocktailViewModel(Cocktail cocktail)
        {
            this.Ingredients = new HashSet<CocktailIngredientViewModel>();

            this.Id = cocktail.Id;
            this.Name = cocktail.Name;
            this.Description = cocktail.Description;

            foreach (var ingredient in cocktail.Ingredients)
            {
                this.Ingredients.Add(new CocktailIngredientViewModel()
                {
                    Id = ingredient.IngredientId,
                    Name = ingredient.Ingredient.Name,
                    Count = ingredient.Count
                });
            }
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
        public virtual ICollection<CocktailIngredientViewModel> Ingredients { set; get; }
    }

    class CocktailIngredientViewModel
    {
        /// <summary>
        /// Идентификатор ингредиента
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Название ингредиента
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Количество ингредиента
        /// </summary>
        public int Count { set; get; }
    }
}
