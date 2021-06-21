﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNS_Access_List.Data_Connections
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="EquipmentLogs")]
	public partial class EquipmentDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertEquipment(Equipment instance);
    partial void UpdateEquipment(Equipment instance);
    partial void DeleteEquipment(Equipment instance);
    #endregion
		
		public EquipmentDataContext() : 
				base(global::CNS_Access_List.Properties.Settings.Default.EquipmentLogsConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public EquipmentDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EquipmentDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EquipmentDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EquipmentDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Equipment> Equipments
		{
			get
			{
				return this.GetTable<Equipment>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Equipment")]
	public partial class Equipment : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _TagID;
		
		private string _SerialNumber;
		
		private System.Nullable<char> _BitlockerStatus;
		
		private System.Nullable<System.DateTime> _DateEncryptionChecked;
		
		private string _CurrentLocation;
		
		private string _PreviousLocation;
		
		private string _CurrentAssignee;
		
		private string _PreviousAssignee;
		
		private System.Nullable<bool> _Destroyed;
		
		private string _Type;
		
		private string _Notes;
		
		private System.Nullable<bool> _IsPatient;
		
		private string _Installed_Software;
		
		private string _P_Software;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnTagIDChanging(string value);
    partial void OnTagIDChanged();
    partial void OnSerialNumberChanging(string value);
    partial void OnSerialNumberChanged();
    partial void OnBitlockerStatusChanging(System.Nullable<char> value);
    partial void OnBitlockerStatusChanged();
    partial void OnDateEncryptionCheckedChanging(System.Nullable<System.DateTime> value);
    partial void OnDateEncryptionCheckedChanged();
    partial void OnCurrentLocationChanging(string value);
    partial void OnCurrentLocationChanged();
    partial void OnPreviousLocationChanging(string value);
    partial void OnPreviousLocationChanged();
    partial void OnCurrentAssigneeChanging(string value);
    partial void OnCurrentAssigneeChanged();
    partial void OnPreviousAssigneeChanging(string value);
    partial void OnPreviousAssigneeChanged();
    partial void OnDestroyedChanging(System.Nullable<bool> value);
    partial void OnDestroyedChanged();
    partial void OnTypeChanging(string value);
    partial void OnTypeChanged();
    partial void OnNotesChanging(string value);
    partial void OnNotesChanged();
    partial void OnIsPatientChanging(System.Nullable<bool> value);
    partial void OnIsPatientChanged();
    partial void OnInstalled_SoftwareChanging(string value);
    partial void OnInstalled_SoftwareChanged();
    partial void OnP_SoftwareChanging(string value);
    partial void OnP_SoftwareChanged();
    #endregion
		
		public Equipment()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TagID", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string TagID
		{
			get
			{
				return this._TagID;
			}
			set
			{
				if ((this._TagID != value))
				{
					this.OnTagIDChanging(value);
					this.SendPropertyChanging();
					this._TagID = value;
					this.SendPropertyChanged("TagID");
					this.OnTagIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SerialNumber", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string SerialNumber
		{
			get
			{
				return this._SerialNumber;
			}
			set
			{
				if ((this._SerialNumber != value))
				{
					this.OnSerialNumberChanging(value);
					this.SendPropertyChanging();
					this._SerialNumber = value;
					this.SendPropertyChanged("SerialNumber");
					this.OnSerialNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BitlockerStatus", DbType="Char(1)")]
		public System.Nullable<char> BitlockerStatus
		{
			get
			{
				return this._BitlockerStatus;
			}
			set
			{
				if ((this._BitlockerStatus != value))
				{
					this.OnBitlockerStatusChanging(value);
					this.SendPropertyChanging();
					this._BitlockerStatus = value;
					this.SendPropertyChanged("BitlockerStatus");
					this.OnBitlockerStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateEncryptionChecked", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateEncryptionChecked
		{
			get
			{
				return this._DateEncryptionChecked;
			}
			set
			{
				if ((this._DateEncryptionChecked != value))
				{
					this.OnDateEncryptionCheckedChanging(value);
					this.SendPropertyChanging();
					this._DateEncryptionChecked = value;
					this.SendPropertyChanged("DateEncryptionChecked");
					this.OnDateEncryptionCheckedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CurrentLocation", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string CurrentLocation
		{
			get
			{
				return this._CurrentLocation;
			}
			set
			{
				if ((this._CurrentLocation != value))
				{
					this.OnCurrentLocationChanging(value);
					this.SendPropertyChanging();
					this._CurrentLocation = value;
					this.SendPropertyChanged("CurrentLocation");
					this.OnCurrentLocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PreviousLocation", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string PreviousLocation
		{
			get
			{
				return this._PreviousLocation;
			}
			set
			{
				if ((this._PreviousLocation != value))
				{
					this.OnPreviousLocationChanging(value);
					this.SendPropertyChanging();
					this._PreviousLocation = value;
					this.SendPropertyChanged("PreviousLocation");
					this.OnPreviousLocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CurrentAssignee", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string CurrentAssignee
		{
			get
			{
				return this._CurrentAssignee;
			}
			set
			{
				if ((this._CurrentAssignee != value))
				{
					this.OnCurrentAssigneeChanging(value);
					this.SendPropertyChanging();
					this._CurrentAssignee = value;
					this.SendPropertyChanged("CurrentAssignee");
					this.OnCurrentAssigneeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PreviousAssignee", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string PreviousAssignee
		{
			get
			{
				return this._PreviousAssignee;
			}
			set
			{
				if ((this._PreviousAssignee != value))
				{
					this.OnPreviousAssigneeChanging(value);
					this.SendPropertyChanging();
					this._PreviousAssignee = value;
					this.SendPropertyChanged("PreviousAssignee");
					this.OnPreviousAssigneeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Destroyed", DbType="Bit")]
		public System.Nullable<bool> Destroyed
		{
			get
			{
				return this._Destroyed;
			}
			set
			{
				if ((this._Destroyed != value))
				{
					this.OnDestroyedChanging(value);
					this.SendPropertyChanging();
					this._Destroyed = value;
					this.SendPropertyChanged("Destroyed");
					this.OnDestroyedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Notes", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Notes
		{
			get
			{
				return this._Notes;
			}
			set
			{
				if ((this._Notes != value))
				{
					this.OnNotesChanging(value);
					this.SendPropertyChanging();
					this._Notes = value;
					this.SendPropertyChanged("Notes");
					this.OnNotesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsPatient", DbType="Bit")]
		public System.Nullable<bool> IsPatient
		{
			get
			{
				return this._IsPatient;
			}
			set
			{
				if ((this._IsPatient != value))
				{
					this.OnIsPatientChanging(value);
					this.SendPropertyChanging();
					this._IsPatient = value;
					this.SendPropertyChanged("IsPatient");
					this.OnIsPatientChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Installed Software]", Storage="_Installed_Software", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Installed_Software
		{
			get
			{
				return this._Installed_Software;
			}
			set
			{
				if ((this._Installed_Software != value))
				{
					this.OnInstalled_SoftwareChanging(value);
					this.SendPropertyChanging();
					this._Installed_Software = value;
					this.SendPropertyChanged("Installed_Software");
					this.OnInstalled_SoftwareChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[P Software]", Storage="_P_Software", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string P_Software
		{
			get
			{
				return this._P_Software;
			}
			set
			{
				if ((this._P_Software != value))
				{
					this.OnP_SoftwareChanging(value);
					this.SendPropertyChanging();
					this._P_Software = value;
					this.SendPropertyChanged("P_Software");
					this.OnP_SoftwareChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
