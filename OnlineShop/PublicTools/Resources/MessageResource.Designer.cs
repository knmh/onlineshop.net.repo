﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PublicTools.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MessageResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MessageResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PublicTools.Resources.MessageResource", typeof(MessageResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Access denied. Please contact the administrator..
        /// </summary>
        public static string Error_AccessDenied {
            get {
                return ResourceManager.GetString("Error_AccessDenied", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to EntityNotFound.
        /// </summary>
        public static string Error_EntityNotFound {
            get {
                return ResourceManager.GetString("Error_EntityNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Process was failed..
        /// </summary>
        public static string Error_FailProcess {
            get {
                return ResourceManager.GetString("Error_FailProcess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The file you are looking for could not be found..
        /// </summary>
        public static string Error_FileNotFound {
            get {
                return ResourceManager.GetString("Error_FileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An internal server error occurred..
        /// </summary>
        public static string Error_InternalServerError {
            get {
                return ResourceManager.GetString("Error_InternalServerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please provide valid input..
        /// </summary>
        public static string Error_InvalidInput {
            get {
                return ResourceManager.GetString("Error_InvalidInput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to InvalidToken.
        /// </summary>
        public static string Error_InvalidToken {
            get {
                return ResourceManager.GetString("Error_InvalidToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mandatory field. Please fill out this field..
        /// </summary>
        public static string Error_MandatoryField {
            get {
                return ResourceManager.GetString("Error_MandatoryField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to the value of a field has exceeded the maximum allowed length..
        /// </summary>
        public static string Error_MaxLengthField {
            get {
                return ResourceManager.GetString("Error_MaxLengthField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NoAuthorization.
        /// </summary>
        public static string Error_NoAuthorization {
            get {
                return ResourceManager.GetString("Error_NoAuthorization", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Process was Successful..
        /// </summary>
        public static string Info_SuccessfullProcess {
            get {
                return ResourceManager.GetString("Info_SuccessfullProcess", resourceCulture);
            }
        }
    }
}
