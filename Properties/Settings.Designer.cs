﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PLM_Lynx.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.12.0.0")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.2.27;Initial Catalog=DSGL_PLM;Persist Security Info=True;User" +
            " ID=sa;Password=\"132512Myl@@)%\";Encrypt=False")]
        public string Datacon {
            get {
                return ((string)(this["Datacon"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F:\\02. OnedriveFolder\\OneDrive\\WORKING DSGLOBAL\\06. PLM Lynx\\07. PLM Lynx Code\\PL" +
            "M_Lynx\\05_DataBase\\DSGLDataPart\\")]
        public string LinkDataPart {
            get {
                return ((string)(this["LinkDataPart"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F:\\02. OnedriveFolder\\OneDrive\\WORKING DSGLOBAL\\06. PLM Lynx\\07. PLM Lynx Code\\PL" +
            "M_Lynx\\05_DataBase\\DSGLTraskPart\\")]
        public string TrashDataPart {
            get {
                return ((string)(this["TrashDataPart"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\"C:\\Program Files\\Autodesk\\DWG TrueView 2023 - English\\dwgviewr.exe\"")]
        public string DWGTrueViewPath {
            get {
                return ((string)(this["DWGTrueViewPath"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\"C:\\Program Files\\Common Files\\eDrawings2025\\eDrawings.exe\"")]
        public string eDrawingView {
            get {
                return ((string)(this["eDrawingView"]));
            }
        }
    }
}
