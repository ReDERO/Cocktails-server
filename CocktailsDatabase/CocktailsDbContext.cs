using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsDatabase
{
    public class CocktailsDbContext : IdentityDbContext<ApplicationUser>
    {
        public CocktailsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CocktailsDbContext Create()
        {
            return new CocktailsDbContext();
        }

        /// <summary>
        /// Список коктейлей
        /// </summary>
        public DbSet<Cocktail> Coctails { set; get; }

        /// <summary>
        /// Список ингредиентов
        /// </summary>
        public DbSet<Ingredient> Ingredients { set; get; }

        /// <summary>
        /// Список инградиентов коктейлей
        /// </summary>
        public DbSet<CocktailIngredient> CocktailIngredients { set; get; }
    }

    public class CocktailsDbInitializer : DropCreateDatabaseAlways<CocktailsDbContext>
    {
        protected override void Seed(CocktailsDbContext context)
        {
            Cocktail screwdriver = new Cocktail() { Name = "Отвёртка", Description = "Алкогольный коктейль, содержащий водку (3 части) и апельсиновый сок (7 частей). Также в напиток добавляется лёд. Готовый коктейль украшается ломтиком апельсина." };

            Ingredient vodka = new Ingredient() { Name = "Водка", Description = "Спиртной напиток, бесцветный водно-спиртовой раствор с характерным вкусом и спиртовым запахом." };
            Ingredient orangeJuice = new Ingredient() { Name = "Апельсиновый сок", Description = "Продукт, получаемый из апельсинов. Различают «свежеотжатый (натуральный) апельсиновый сок», «апельсиновый сок прямого отжима» и «восстановленный апельсиновый сок»." };

            context.CocktailIngredients.Add(new CocktailIngredient() { Cocktail = screwdriver, Ingredient = vodka, Count = 50 });
            context.CocktailIngredients.Add(new CocktailIngredient() { Cocktail = screwdriver, Ingredient = orangeJuice, Count = 150 });

            base.Seed(context);
        }
    }
}
