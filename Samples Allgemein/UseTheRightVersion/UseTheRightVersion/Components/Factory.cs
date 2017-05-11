using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UseTheRightVersion.MetaDescription;

namespace UseTheRightVersion.Components
{
    public static class Factory
    {
        private static Dictionary<Type, Type> _alternativeTypes = new Dictionary<Type, Type>();

        static Factory()
        {
            var path = Path.Combine(Path.GetDirectoryName(new Uri(typeof(Factory).Assembly.CodeBase).LocalPath), "Alternatives");

            foreach (string file in Directory.GetFiles(path, "*.dll"))
            {
                var assembly = Assembly.LoadFile(file);

                foreach (Type exportedType in assembly.GetExportedTypes())
                {
                    var attr = exportedType.GetCustomAttributes(typeof(AlternativeTypeAttribute), false);

                    if (attr.Any())
                    {
                        var alternativeTypeAttribute = attr[0] as AlternativeTypeAttribute;
                        if (alternativeTypeAttribute != null)
                        {
                            if (!_alternativeTypes.ContainsKey(alternativeTypeAttribute.AlternativeType))
                            {
                                _alternativeTypes.Add(alternativeTypeAttribute.AlternativeType, exportedType);
                            }
                        }
                    }
                }
            }
        }
         
        public static T Create<T>(params object[] constructorParameters)
            where T : class, new()
        {
            Type t = typeof(T);

            // Alternatives Assembly suchen
            if (_alternativeTypes.ContainsKey(t))
            {
                var alternativeType = _alternativeTypes[t];

                if (alternativeType.IsSubclassOf(t))
                {
                    t = alternativeType;
                }
            }
            
            return Activator.CreateInstance(t, constructorParameters) as T;
        }


    }
}
