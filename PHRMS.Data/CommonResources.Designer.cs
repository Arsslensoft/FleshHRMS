﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PHRMS.Data
{
    using System;


    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class CommonResources
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommonResources()
        {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PHRMS.Data.CommonResources", typeof(CommonResources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Confirmation.
        /// </summary>
        public static string Confirmation_Caption
        {
            get
            {
                return ResourceManager.GetString("Confirmation_Caption", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Voulez-vous supprimer celui-ci {0}?.
        /// </summary>
        public static string Confirmation_Delete
        {
            get
            {
                return ResourceManager.GetString("Confirmation_Delete", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Cliquez sur OK pour recharger l&apos;entité et de perdre les modifications non enregistrées. Cliquez sur Annuler pour continuer l&apos;édition de données..
        /// </summary>
        public static string Confirmation_Reset
        {
            get
            {
                return ResourceManager.GetString("Confirmation_Reset", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Voulez-vous enregistrer les modifications?.
        /// </summary>
        public static string Confirmation_Save
        {
            get
            {
                return ResourceManager.GetString("Confirmation_Save", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to  *.
        /// </summary>
        public static string Entity_Changed
        {
            get
            {
                return ResourceManager.GetString("Entity_Changed", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to  (Nouveau).
        /// </summary>
        public static string Entity_New
        {
            get
            {
                return ResourceManager.GetString("Entity_New", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Erreur de demande DataService.
        /// </summary>
        public static string Exception_DataServiceRequestErrorCaption
        {
            get
            {
                return ResourceManager.GetString("Exception_DataServiceRequestErrorCaption", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Erreur de mise à jour.
        /// </summary>
        public static string Exception_UpdateErrorCaption
        {
            get
            {
                return ResourceManager.GetString("Exception_UpdateErrorCaption", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Erreur de validation.
        /// </summary>
        public static string Exception_ValidationErrorCaption
        {
            get
            {
                return ResourceManager.GetString("Exception_ValidationErrorCaption", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Avertissement.
        /// </summary>
        public static string Warning_Caption
        {
            get
            {
                return ResourceManager.GetString("Warning_Caption", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Certains champs contiennent des données non valides. Cliquez sur OK pour fermer la page et de perdre les modifications non enregistrées. Appuyez sur Annuler pour continuer l&apos;édition de données..
        /// </summary>
        public static string Warning_SomeFieldsContainInvalidData
        {
            get
            {
                return ResourceManager.GetString("Warning_SomeFieldsContainInvalidData", resourceCulture);
            }
        }
    }
}
