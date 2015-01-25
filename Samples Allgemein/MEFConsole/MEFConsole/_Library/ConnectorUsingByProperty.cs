using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace MEFConsole
{
    
    /// <summary>
    /// 
    /// </summary>
    public class ConnectorUsingByProperty
    {
        [Import(typeof(IComponentConnector))]
        public IComponentConnector Connector { get; set; }
        
    }
}
