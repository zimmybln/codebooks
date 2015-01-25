// Type: System.ComponentModel.Composition.Hosting.ExportProvider
// Assembly: System.ComponentModel.Composition, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Programme\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.ComponentModel.Composition.dll

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Runtime;

namespace System.ComponentModel.Composition.Hosting
{
    public abstract class ExportProvider
    {
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        protected ExportProvider();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public IEnumerable<Export> GetExports(ImportDefinition definition);

        public IEnumerable<Export> GetExports(ImportDefinition definition, AtomicComposition atomicComposition);

        public bool TryGetExports(ImportDefinition definition, AtomicComposition atomicComposition,
                                  out IEnumerable<Export> exports);

        protected abstract IEnumerable<Export> GetExportsCore(ImportDefinition definition,
                                                              AtomicComposition atomicComposition);

        protected virtual void OnExportsChanged(ExportsChangeEventArgs e);
        protected virtual void OnExportsChanging(ExportsChangeEventArgs e);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public Lazy<T> GetExport<T>();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public Lazy<T> GetExport<T>(string contractName);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public Lazy<T, TMetadataView> GetExport<T, TMetadataView>();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public Lazy<T, TMetadataView> GetExport<T, TMetadataView>(string contractName);

        public IEnumerable<Lazy<object, object>> GetExports(Type type, Type metadataViewType, string contractName);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public IEnumerable<Lazy<T>> GetExports<T>();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public IEnumerable<Lazy<T>> GetExports<T>(string contractName);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public IEnumerable<Lazy<T, TMetadataView>> GetExports<T, TMetadataView>();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public IEnumerable<Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(string contractName);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public T GetExportedValue<T>();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public T GetExportedValue<T>(string contractName);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public T GetExportedValueOrDefault<T>();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public T GetExportedValueOrDefault<T>(string contractName);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public IEnumerable<T> GetExportedValues<T>();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public IEnumerable<T> GetExportedValues<T>(string contractName);

        public event EventHandler<ExportsChangeEventArgs> ExportsChanged;
        public event EventHandler<ExportsChangeEventArgs> ExportsChanging;
    }
}
