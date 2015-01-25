using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Metadata;

namespace CustomControlLibrary.Design
{
    public class Metadata : IProvideAttributeTable
    {
        public AttributeTable AttributeTable
        {
            get
            {
                AttributeTableBuilder builder = CreateAttributeTable();
                return builder.CreateTable();
            }
        }

        private static AttributeTableBuilder CreateAttributeTable()
        {
            AttributeTableBuilder builder = new AttributeTableBuilder();

            // ToolbarBrowsable...
            //builder.AddCustomAttributes(typeof(ColumnsPresenter), new ToolboxBrowsableAttribute(false));


            return builder;
        }
    }
}
