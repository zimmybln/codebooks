﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM-Beziehungsmetadaten

[assembly: EdmRelationshipAttribute("Model", "FK_Persons_Cities", "Cities", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(LINQSampleModel.Cities), "Persons", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(LINQSampleModel.Persons), true)]
[assembly: EdmRelationshipAttribute("Model", "AlbumContributors", "Albums", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(LINQSampleModel.Albums), "Persons", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(LINQSampleModel.Persons))]

#endregion

namespace LINQSampleModel
{
    #region Kontexte
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    public partial class LINQ_SamplesEntities : ObjectContext
    {
        #region Konstruktoren
    
        /// <summary>
        /// Initialisiert ein neues LINQ_SamplesEntities-Objekt mithilfe der in Abschnitt 'LINQ_SamplesEntities' der Anwendungskonfigurationsdatei gefundenen Verbindungszeichenfolge.
        /// </summary>
        public LINQ_SamplesEntities() : base("name=LINQ_SamplesEntities", "LINQ_SamplesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisiert ein neues LINQ_SamplesEntities-Objekt.
        /// </summary>
        public LINQ_SamplesEntities(string connectionString) : base(connectionString, "LINQ_SamplesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisiert ein neues LINQ_SamplesEntities-Objekt.
        /// </summary>
        public LINQ_SamplesEntities(EntityConnection connection) : base(connection, "LINQ_SamplesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partielle Methoden
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet-Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<Persons> Persons
        {
            get
            {
                if ((_Persons == null))
                {
                    _Persons = base.CreateObjectSet<Persons>("Persons");
                }
                return _Persons;
            }
        }
        private ObjectSet<Persons> _Persons;
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<Cities> Cities
        {
            get
            {
                if ((_Cities == null))
                {
                    _Cities = base.CreateObjectSet<Cities>("Cities");
                }
                return _Cities;
            }
        }
        private ObjectSet<Cities> _Cities;
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<Albums> Albums
        {
            get
            {
                if ((_Albums == null))
                {
                    _Albums = base.CreateObjectSet<Albums>("Albums");
                }
                return _Albums;
            }
        }
        private ObjectSet<Albums> _Albums;

        #endregion
        #region AddTo-Methoden
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'Persons'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToPersons(Persons persons)
        {
            base.AddObject("Persons", persons);
        }
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'Cities'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToCities(Cities cities)
        {
            base.AddObject("Cities", cities);
        }
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'Albums'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToAlbums(Albums albums)
        {
            base.AddObject("Albums", albums);
        }

        #endregion
    }
    

    #endregion
    
    #region Entitäten
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model", Name="Albums")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Albums : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues Albums-Objekt.
        /// </summary>
        /// <param name="id">Anfangswert der Eigenschaft Id.</param>
        /// <param name="name">Anfangswert der Eigenschaft Name.</param>
        public static Albums CreateAlbums(global::System.Int32 id, global::System.String name)
        {
            Albums albums = new Albums();
            albums.Id = id;
            albums.Name = name;
            return albums;
        }

        #endregion
        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion
    
        #region Navigationseigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model", "AlbumContributors", "Persons")]
        public EntityCollection<Persons> Persons
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Persons>("Model.AlbumContributors", "Persons");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Persons>("Model.AlbumContributors", "Persons", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model", Name="Cities")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Cities : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues Cities-Objekt.
        /// </summary>
        /// <param name="cityId">Anfangswert der Eigenschaft CityId.</param>
        /// <param name="name">Anfangswert der Eigenschaft Name.</param>
        public static Cities CreateCities(global::System.Int32 cityId, global::System.String name)
        {
            Cities cities = new Cities();
            cities.CityId = cityId;
            cities.Name = name;
            return cities;
        }

        #endregion
        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 CityId
        {
            get
            {
                return _CityId;
            }
            set
            {
                if (_CityId != value)
                {
                    OnCityIdChanging(value);
                    ReportPropertyChanging("CityId");
                    _CityId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("CityId");
                    OnCityIdChanged();
                }
            }
        }
        private global::System.Int32 _CityId;
        partial void OnCityIdChanging(global::System.Int32 value);
        partial void OnCityIdChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion
    
        #region Navigationseigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model", "FK_Persons_Cities", "Persons")]
        public EntityCollection<Persons> Persons
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Persons>("Model.FK_Persons_Cities", "Persons");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Persons>("Model.FK_Persons_Cities", "Persons", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model", Name="Persons")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Persons : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues Persons-Objekt.
        /// </summary>
        /// <param name="id">Anfangswert der Eigenschaft Id.</param>
        /// <param name="firstName">Anfangswert der Eigenschaft FirstName.</param>
        /// <param name="lastName">Anfangswert der Eigenschaft LastName.</param>
        public static Persons CreatePersons(global::System.Int32 id, global::System.String firstName, global::System.String lastName)
        {
            Persons persons = new Persons();
            persons.Id = id;
            persons.FirstName = firstName;
            persons.LastName = lastName;
            return persons;
        }

        #endregion
        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }
        private global::System.String _FirstName;
        partial void OnFirstNameChanging(global::System.String value);
        partial void OnFirstNameChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }
        private global::System.String _LastName;
        partial void OnLastNameChanging(global::System.String value);
        partial void OnLastNameChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> CityOfBirth
        {
            get
            {
                return _CityOfBirth;
            }
            set
            {
                OnCityOfBirthChanging(value);
                ReportPropertyChanging("CityOfBirth");
                _CityOfBirth = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CityOfBirth");
                OnCityOfBirthChanged();
            }
        }
        private Nullable<global::System.Int32> _CityOfBirth;
        partial void OnCityOfBirthChanging(Nullable<global::System.Int32> value);
        partial void OnCityOfBirthChanged();

        #endregion
    
        #region Navigationseigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model", "FK_Persons_Cities", "Cities")]
        public Cities Cities
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Cities>("Model.FK_Persons_Cities", "Cities").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Cities>("Model.FK_Persons_Cities", "Cities").Value = value;
            }
        }
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Cities> CitiesReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Cities>("Model.FK_Persons_Cities", "Cities");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Cities>("Model.FK_Persons_Cities", "Cities", value);
                }
            }
        }
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model", "AlbumContributors", "Albums")]
        public EntityCollection<Albums> Albums
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Albums>("Model.AlbumContributors", "Albums");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Albums>("Model.AlbumContributors", "Albums", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
