﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.431
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jdp.Jdf.Resources {
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
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Jdp.Jdf.Resources.Messages", typeof(Messages).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can only operate on JDF node.  The node is a {0}.
        /// </summary>
        internal static string CanOnlyOperateOnJdfNode {
            get {
                return ResourceManager.GetString("CanOnlyOperateOnJdfNode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can only operate on resource link.  The node is a {0}.
        /// </summary>
        internal static string CanOnlyOperateOnResourceLink {
            get {
                return ResourceManager.GetString("CanOnlyOperateOnResourceLink", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to AddContent requires content to add.
        /// </summary>
        internal static string ElementExtensions_AddContent_RequiresContentToAdd {
            get {
                return ResourceManager.GetString("ElementExtensions_AddContent_RequiresContentToAdd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This node is not a JDF and it does not have a JDF parent.  The node is {0}.
        /// </summary>
        internal static string ElementExtensions_FirstJdf_NodeNotJdfAndNoJdfParent {
            get {
                return ResourceManager.GetString("ElementExtensions_FirstJdf_NodeNotJdfAndNoJdfParent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find JDF parent for element {0}.
        /// </summary>
        internal static string ElementExtensions_JdfParent_NoJdfParentFound {
            get {
                return ResourceManager.GetString("ElementExtensions_JdfParent_NoJdfParentFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The element {0} does not have a JDF root.
        /// </summary>
        internal static string ElementExtensions_JdfRoot_NoJdfRootFound {
            get {
                return ResourceManager.GetString("ElementExtensions_JdfRoot_NoJdfRootFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find resource with id {0} and could not create it because name was not provided.
        /// </summary>
        internal static string JdfElementExtensions_LinkResource_CouldNotFindResourceWithGivenIdAndNameWasNotProvided {
            get {
                return ResourceManager.GetString("JdfElementExtensions_LinkResource_CouldNotFindResourceWithGivenIdAndNameWasNotPro" +
                        "vided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Linking a resource requires either the resource name or the id (or both)..
        /// </summary>
        internal static string JdfElementExtensions_LinkResource_ResourceNameOrIdOrBothRequired {
            get {
                return ResourceManager.GetString("JdfElementExtensions_LinkResource_ResourceNameOrIdOrBothRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Resource with ID {0} cannot be found.
        /// </summary>
        internal static string ResourceExtensions_Resource_ResourceWithIdCannotBeFound {
            get {
                return ResourceManager.GetString("ResourceExtensions_Resource_ResourceWithIdCannotBeFound", resourceCulture);
            }
        }
    }
}
