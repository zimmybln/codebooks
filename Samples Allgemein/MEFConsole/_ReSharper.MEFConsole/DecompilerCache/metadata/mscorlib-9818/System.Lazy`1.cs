// Type: System.Lazy`1
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Programme\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\mscorlib.dll

using System.Diagnostics;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;

namespace System
{
    [DebuggerDisplay(
        "ThreadSafetyMode={Mode}, IsValueCreated={IsValueCreated}, IsValueFaulted={IsValueFaulted}, Value={ValueForDebugDisplay}"
        )]
    [DebuggerTypeProxy(typeof (System_LazyDebugView<T>))]
    [ComVisible(false)]
    [Serializable]
    public class Lazy<T>
    {
        public Lazy();
        public Lazy(Func<T> valueFactory);
        public Lazy(bool isThreadSafe);
        public Lazy(LazyThreadSafetyMode mode);
        public Lazy(Func<T> valueFactory, bool isThreadSafe);
        public Lazy(Func<T> valueFactory, LazyThreadSafetyMode mode);

        public bool IsValueCreated { [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public T Value { get; }

        public override string ToString();
    }
}
