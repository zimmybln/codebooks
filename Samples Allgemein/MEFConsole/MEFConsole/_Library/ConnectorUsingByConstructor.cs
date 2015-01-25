using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace MEFConsole
{
    [Export("Connector")]
    public class ConnectorUsingByConstructor
    {
        private readonly IComponentConnector mv_implComponentConnector = null;

        [ImportingConstructor]
        public ConnectorUsingByConstructor(IComponentConnector Connector)
        {
            mv_implComponentConnector = Connector;
        }

        public IComponentConnector Connector
        {
            get { return mv_implComponentConnector; }
        }

    }
}
