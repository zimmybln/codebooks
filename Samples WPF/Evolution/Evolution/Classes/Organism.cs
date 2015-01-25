using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Classes
{
    /// <summary>
    /// Diese Klasse beschreibt die Grundzüge eines Organismus.
    /// </summary>
    public abstract class Organism
    {


        /// <summary>
        /// Liefert die Anzahl der Lebenspunkte.
        /// </summary>
        /// <remarks>
        /// Lebenspunkte werden durch verschiedene Ereignisse beeinflusst.
        /// </remarks>
        public long LifePoints { get; private set; }        

    }
}
