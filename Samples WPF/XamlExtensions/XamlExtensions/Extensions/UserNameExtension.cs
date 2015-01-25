using System;
using System.Windows.Markup;

namespace XamlExtensions
{
    [MarkupExtensionReturnType(typeof(string))]
    class UserNameExtension : MarkupExtension
    {       
        public UserNameExtension()
        {
            
        }

        public UserNameExtension(string format)
        {
            this.Format = format;
        }

        public bool IncludeDomainName { get; set; }

        [ConstructorArgument("format")]
        public string Format { get; set; }

        public override object ProvideValue(IServiceProvider ServiceProvider)
        {
            string strUserName = null;

            //if (ServiceProvider != null)
            //{
            //    IXamlTypeResolver resolver = (IXamlTypeResolver) ServiceProvider.GetService(typeof (IXamlTypeResolver));
            //    IProvideValueTarget target = (IProvideValueTarget) ServiceProvider.GetService(typeof (IProvideValueTarget));
                
            //    if (target != null)
            //    {
            //        strUserName = target.TargetProperty.GetType().ToString();
            //    }
            //}

            if (IncludeDomainName)
                strUserName += String.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName);
            else
                strUserName += Environment.UserName;
            
            if (!String.IsNullOrEmpty(this.Format))
                return String.Format(this.Format, strUserName);
            
            return strUserName;
        }
    }
}
