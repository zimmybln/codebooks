using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContainerApplication.Components
{
    /// <summary>
    /// Diese Klasse dient dazu, Daten innerhalb eines Requests zwischen allen Beteiligten
    /// zu verteilen.
    /// </summary>
    [Serializable]
    public class SharedDataBag
    {
        public int Number { get; set; }

        public string Id { get; set; }
    }
}