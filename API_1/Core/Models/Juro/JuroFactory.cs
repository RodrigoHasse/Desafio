using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Juro
{
    public partial class Juro
    {
        public static Juro Criar(decimal taxa) => new Juro() { Taxa = taxa };
    }
}
