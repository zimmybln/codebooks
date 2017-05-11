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
         
        public static T Create<T>()
            where T : class, new()
        {
            Type t = typeof(T);

            // Alternatives Assembly suchen
            var path = Path.Combine(Path.GetDirectoryName(new Uri(typeof (Factory).Assembly.CodeBase).LocalPath), "Alternatives");

            foreach (string file in Directory.GetFiles(path, "*.dll"))
            {
                var assembly = Assembly.LoadFile(file);
                Type alternativeType = null;

                foreach (Type exportedType in assembly.GetExportedTypes())
                {
                    var attr = exportedType.GetCustomAttributes(typeof (AlternativeTypeAttribute), false);

                    if (attr.Any())
                    {
                        var alternativeTypeAttribute = attr[0] as AlternativeTypeAttribute;
                        if (alternativeTypeAttribute != null && exportedType.IsSubclassOf(t))
                        {
                            alternativeType = exportedType;
                            break;
                        }
                    }
                }

                if (alternativeType != null)
                {
                    t = alternativeType;
                }
            }

            return Activator.CreateInstance(t) as T;
        }


    }
}
