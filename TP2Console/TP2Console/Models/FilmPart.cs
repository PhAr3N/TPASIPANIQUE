using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2Console.Models.EntityFramework
{
    public partial class Film
    {        override public string ToString()
        {
            return (this.Id + " : " + this.Nom);
        }
    }
}
