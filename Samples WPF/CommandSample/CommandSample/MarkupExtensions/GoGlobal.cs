using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Markup;
using System.Windows;
using System.ComponentModel;
using System.Collections;
using System.Globalization;
using System.Diagnostics;
using System.Windows.Data;

namespace CommandSample
{
    [MarkupExtensionReturnType(typeof(CommandSample.App), typeof(CommandSample.App))]
    public class ReferenceCurrentApplicationExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return (App)Application.Current as CommandSample.App;    
        }
    }



  
        [ContentProperty("TypeArguments")]
    [MarkupExtensionReturnType(typeof(Type))]
    public class GenericTypeExtension : TypeExtension
    {
        private ArrayList typeArguments;

        [DefaultValue(null)]
        [TypeConverter(typeof(TypeArgumentsConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public IList TypeArguments
        {
            get 
            {
                return typeArguments;
            }
            set 
            {
                typeArguments.Clear();
                typeArguments.AddRange(value);
            }
        }

        public GenericTypeExtension(): base()
        {
            typeArguments = new ArrayList();
        }

        public GenericTypeExtension(String typeName) : base(typeName)
        {
            typeArguments = new ArrayList();
        }

        public GenericTypeExtension(String typeName, Type typeArgument) :base(typeName)
        {
            typeArguments = new ArrayList();
            typeArguments.Add(typeArgument);
        }

        public GenericTypeExtension(Type type): base(type)
        {
            typeArguments = new ArrayList();
        }

        public override Object ProvideValue(IServiceProvider serviceProvider)
        {
            Debugger.Break();


            // If type arguments are not specified, we can fallback to TypeExtension's implementation.
            if (typeArguments == null || typeArguments.Count == 0)
            {
                return base.ProvideValue(serviceProvider);
            }

            IXamlTypeResolver resolver = serviceProvider.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;
            if (resolver == null)
            {
                throw new InvalidOperationException("sdfasdf");
            }

            String typeName = TypeName + "`" + typeArguments.Count.ToString();
            Type genericType = resolver.Resolve(typeName);
            if (genericType == null)
            {
                throw new InvalidOperationException("");
            }

            Type[] arguments = typeArguments.ToArray(typeof(Type)) as Type[];
            if (arguments == null || arguments.Length == 0)
            {
                throw new InvalidOperationException("");
            }

            Type constructedType = genericType.MakeGenericType(arguments);
            if (constructedType == null)
            {
                throw new InvalidOperationException("");
            }

            TypeName = typeName;
            Type = constructedType;
            return constructedType;
        }
    }

    internal class TypeArgumentsConverter : TypeConverter
    {
        public override Boolean CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            IXamlTypeResolver resolver = context.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;
            if (sourceType == typeof(Type) || context != null) return true;
            return false;
        }

        public override Object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, Object value)
        {
            IXamlTypeResolver resolver = context.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;
            if (value is String)
            {
                String[] stringArray = ((String)value).Split(',');
                List<Type> types = new List<Type>();
                for (Int32 i = 0; i < stringArray.Length; i++)
                {
                    Type type = resolver.Resolve(stringArray[i].Trim());
                    if (type == null)
                    {
                        throw new InvalidOperationException("");
                    }
                    else
                    {
                        types.Add(type);
                    }
                }

                return types;
            }

            return null;
        }

        public override Boolean CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return base.CanConvertTo(context, destinationType);
        }

        public override Object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, Object value, Type destinationType)
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

}
