using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2Console.Models.EntityFramework
{
    public partial class Avi
    {
        override public string ToString()
        {
            return (this.Film + " : Note=" + this.Note + " : Avis=" + this.Avis);
        }
    }
}
