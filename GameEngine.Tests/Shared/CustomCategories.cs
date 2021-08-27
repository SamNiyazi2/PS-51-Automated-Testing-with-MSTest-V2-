using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// 08/27/2021 09:19 am - SSN - [20210827-0917] - [001] - M06-05 - Creating custom reusable test category attributes

namespace GameEngine.Tests
{


    public class PlayerDefaultsCategoryAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Player Defaults" };
    }


    public class PlayerHealthCategoryAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Player Health" };
    }


    public class EnemyCreationCategoryAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Enemy Creation" };
    }

}

