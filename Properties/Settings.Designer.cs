﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNS_IT_Ticketing_System_v1._0.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.7.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.10.23;Initial Catalog=ITTickets;Persist Security Info=True;Us" +
            "er ID=SA")]
        public string ITTicketsConnectionString {
            get {
                return ((string)(this["ITTicketsConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.10.23;Initial Catalog=ITTickets;Persist Security Info=True;Us" +
            "er ID=SA;Password=Cap$y$Pwd!")]
        public string ITTicketsConnectionString1 {
            get {
                return ((string)(this["ITTicketsConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.10.23;Initial Catalog=ITTickets;Persist Security Info=True;Us" +
            "er ID=SA;Password=Cap$y$Pwd!")]
        public string ITTicketsConnectionString2 {
            get {
                return ((string)(this["ITTicketsConnectionString2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.10.23;Initial Catalog=ITTickets;Persist Security Info=True;Us" +
            "er ID=SA;Password=Cap$y$Pwd!;Encrypt=True;TrustServerCertificate=True")]
        public string ITTicketsConnectionString3 {
            get {
                return ((string)(this["ITTicketsConnectionString3"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=CNS-VM-SQL08R2;Initial Catalog=ITTickets;Persist Security Info=True;U" +
            "ser ID=SA;Password=Cap$y$Pwd!")]
        public string ITTicketsConnectionString4 {
            get {
                return ((string)(this["ITTicketsConnectionString4"]));
            }
        }
    }
}