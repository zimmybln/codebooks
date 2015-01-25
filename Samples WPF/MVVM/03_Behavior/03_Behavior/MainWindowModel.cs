using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace _03_Behavior
{
    /// <summary>
    /// Model des Hauptfensters der Anwendung. Stellt Drag & Drop
    /// mit der Logik aus dem Model zur Verfügung.
    /// </summary>
    /// <remarks>
    /// Start
    ///  - Wenn die Elemente mit "John" oder "George" beginnen, dürfen sie verschoben werden,
    ///    andernfalls werden sie kopiert
    /// 
    /// </remarks>
    public class MainWindowModel : INotifyPropertyChanged
    {
        private DragAdapter mv_objDragAdapter;
        private DropAdapter mv_objDropAdapter;
        private readonly ObservableCollection<string> mv_lstDroppedItems;


        public MainWindowModel()
        {
            DragAdapter = new CustomDragAdapter();
            DropAdapter = new CustomDropAdapter(this);
            mv_lstDroppedItems = new ObservableCollection<string>();
        }

        public DragAdapter DragAdapter
        {
            get { return mv_objDragAdapter; }
            set 
            {
                mv_objDragAdapter = value;
                RaisePropertyChanged("DragAdapter");
            }
        }

        public DropAdapter DropAdapter
        {
            get { return mv_objDropAdapter; }
            set 
            {
                mv_objDropAdapter = value;
                RaisePropertyChanged("DropAdapter");
            }
        }

        public ObservableCollection<string> DroppedValues
        {
            get { return mv_lstDroppedItems; }
        }

        #region "Implementierung INotifyPropertyChanged"
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string Name)
        {
            PropertyChangedEventHandler h = this.PropertyChanged;

            if (h != null)
                h(this, new PropertyChangedEventArgs(Name));
        }

        #endregion

        /// <summary>
        /// Diese Klasse setzt ein angepasstes Verhalten bei
        /// Drag & Drop um.
        /// </summary>
        protected class CustomDragAdapter : DragAdapter
        {
            protected override System.Windows.DragDropEffects GetAllowedEffects(object SelectedItem)
            {
                if (SelectedItem is String)
                {
                    var s = (string)SelectedItem;
                    if (s.StartsWith("John") || s.StartsWith("George"))
                        return DragDropEffects.Move;
                    else
                        return DragDropEffects.Copy;
                }

                return DragDropEffects.None;
            }

            protected override void Dragged(object DraggedItem, DragDropEffects ActionEffect)
            {
                Trace.WriteLine(String.Format("Dragged: {0}", ActionEffect));
            }
        }

        protected class CustomDropAdapter : DropAdapter
        {
            private readonly MainWindowModel mv_objHost;
            private int mv_nCounter = 0;

            protected internal CustomDropAdapter(MainWindowModel Host)
            {
                mv_objHost = Host;
            }

            protected override DragDropEffects GetAllowedDragEnterEffects(IDataObject DataObject, DragDropEffects AllowedEffects, DragDropKeyStates KeyStates)
            {
                return DragDropEffects.All;
            }

            protected override void OnDrop(object HitTestElement, IDataObject DataObject)
            {
                if (DataObject.GetDataPresent(typeof(string)))
                {
                    string strHitTest = HitTestElement == null ? "null" : HitTestElement.ToString();
                    
                    mv_nCounter++;
                    mv_objHost.mv_lstDroppedItems.Add(String.Format("{0:#00}: {1}", mv_nCounter, (string) DataObject.GetData(typeof (string))));
                }
            }

            /// <summary>
            /// Führt eine Überprüfung der Daten während des Vorgangs durch
            /// </summary>
            /// <remarks>
            /// - Wenn sich der Cursor über einem Element befindet, 
            ///     dass den Text "John" enthält, darf jede Aktion durchgeführt werden.
            /// - Wenn sich der Cursor über keinem Element befindet,
            ///     darf die Quelle kopiert werden (Mauszeiger mit Plus)
            /// </remarks>
            protected override DragDropEffects GetAllowedDragOverEffects(object HitTestElement, IDataObject DataObject, DragDropEffects AllowedEffects, DragDropKeyStates KeyStates)
            {
                if (DataObject.GetDataPresent(typeof(string)))
                {
                    string strHitTest = HitTestElement == null ? null : HitTestElement.ToString();

                    if (String.IsNullOrEmpty(strHitTest))
                        return DragDropEffects.Copy;

                    if (strHitTest.Contains("John"))
                        return DragDropEffects.All;
                    else
                    {
                        return DragDropEffects.None;
                    }
                }

                return base.GetAllowedDragOverEffects(HitTestElement, DataObject, AllowedEffects, KeyStates);
            }
        }
    }
}
