using System;
using System.Collections.Generic;

namespace TutorialPagina.Models
{
    public partial class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? IdBrand { get; set; }

        public virtual Brand? IdBrandNavigation { get; set; }
    }
}
