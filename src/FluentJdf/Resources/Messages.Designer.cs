﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.431
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FluentJdf.Resources {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FluentJdf.Resources.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to You must pass at least one type in order to create a process.
        /// </summary>
        internal static string AtLeastOneProcessMustBeSpecified {
            get {
                return ResourceManager.GetString("AtLeastOneProcessMustBeSpecified", resourceCulture);
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
        ///   Looks up a localized string similar to Cannot operate on {0} element.  This extension only operate on JDF or JMF nodes..
        /// </summary>
        internal static string ElementExtensions_ThrowExceptionIfNotJdfOrJmfElement {
            get {
                return ResourceManager.GetString("ElementExtensions_ThrowExceptionIfNotJdfOrJmfElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ValidateJdf requires the document to be of type Ticket.  Use Ticket.Create()..
        /// </summary>
        internal static string ElementExtensions_ValidateJdf_ValidateJdfRequiresDocumentOfTypeTicket {
            get {
                return ResourceManager.GetString("ElementExtensions_ValidateJdf_ValidateJdfRequiresDocumentOfTypeTicket", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ValidateJmf requires the document to be of type Message.  Use Message.Create().
        /// </summary>
        internal static string ElementExtensions_ValidateJmf_MessageRequired {
            get {
                return ResourceManager.GetString("ElementExtensions_ValidateJmf_MessageRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Encodings must be of type IEncoding.
        /// </summary>
        internal static string EncodingSettings_ThrowExceptionIfTypeIsNotIEncoding {
            get {
                return ResourceManager.GetString("EncodingSettings_ThrowExceptionIfTypeIsNotIEncoding", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FluentJDF requires a root node when copying a document..
        /// </summary>
        internal static string FluentJdfDocumentBase_FluentJdfDocumentBase_FluentJDF_RootNodeRequired {
            get {
                return ResourceManager.GetString("FluentJdfDocumentBase_FluentJdfDocumentBase_FluentJDF_RootNodeRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Timeout in seconds must not be less than zero unless set to Timeout.Infinite.
        /// </summary>
        internal static string HttpTransmissionSettingsBuilder_TimeoutInSeconds_MustNotBeLessThanZero {
            get {
                return ResourceManager.GetString("HttpTransmissionSettingsBuilder_TimeoutInSeconds_MustNotBeLessThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to At least one transmission part is required for transmission..
        /// </summary>
        internal static string HttpTransmitter_Transmit_AtLeastOneTransmissionPartIsRequired {
            get {
                return ResourceManager.GetString("HttpTransmitter_Transmit_AtLeastOneTransmissionPartIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to HttpTransmitter failed to transmit {0} because of unexpected exception.
        /// </summary>
        internal static string HttpTransmitter_Transmit_HttpTransmitter_UnexpectedException {
            get {
                return ResourceManager.GetString("HttpTransmitter_Transmit_HttpTransmitter_UnexpectedException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to HTTP transmitter only works with http urls.
        /// </summary>
        internal static string HttpTransmitter_Transmit_RequiresHttpUrl {
            get {
                return ResourceManager.GetString("HttpTransmitter_Transmit_RequiresHttpUrl", resourceCulture);
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
        ///   Looks up a localized string similar to Can only add JMF as root element.  Root element {0} already exists.
        /// </summary>
        internal static string JmfElementExtensions_AddJmfElement_JMFMustBeRoot {
            get {
                return ResourceManager.GetString("JmfElementExtensions_AddJmfElement_JMFMustBeRoot", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided sender id is null or whitespace and no default sender id is configured.
        /// </summary>
        internal static string JmfElementExtensions_SetSenderId_SenderIdMustBeProvided {
            get {
                return ResourceManager.GetString("JmfElementExtensions_SetSenderId_SenderIdMustBeProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The element must be contained in a Message object.
        /// </summary>
        internal static string JmfElementExtensions_ThrowExceptionIfNotInMessage_CannotOperateOnElementUnlessItIsInMessage {
            get {
                return ResourceManager.GetString("JmfElementExtensions_ThrowExceptionIfNotInMessage_CannotOperateOnElementUnlessItI" +
                        "sInMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can only operate on JMF nodes.  The name is {0}..
        /// </summary>
        internal static string JmfElementExtensions_ThrowExceptionIfNotJmfElement_CanOnlyOperateOnJmfNodes {
            get {
                return ResourceManager.GetString("JmfElementExtensions_ThrowExceptionIfNotJmfElement_CanOnlyOperateOnJmfNodes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to load and compile JDF schema.  The error is {0}.
        /// </summary>
        internal static string Loader_Loader_FailedToLoadAndCompileSchema {
            get {
                return ResourceManager.GetString("Loader_Loader_FailedToLoadAndCompileSchema", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The root of the Message must exist and must be a JMF.
        /// </summary>
        internal static string Message_ModifyJmfNode_RootMustExistAndMustbeJmf {
            get {
                return ResourceManager.GetString("Message_ModifyJmfNode_RootMustExistAndMustbeJmf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pass through encoder cannot encode a transmission part collection containing more than one part..
        /// </summary>
        internal static string PassThroughEncoder_Encode_CannotEncodeMoreThanOnePart {
            get {
                return ResourceManager.GetString("PassThroughEncoder_Encode_CannotEncodeMoreThanOnePart", resourceCulture);
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
        
        /// <summary>
        ///   Looks up a localized string similar to Root must exist and must be JDF.
        /// </summary>
        internal static string Ticket_ModifyJdfNode_RootMustExistAndBeJdf {
            get {
                return ResourceManager.GetString("Ticket_ModifyJdfNode_RootMustExistAndBeJdf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to transmit ticket to {0}.
        /// </summary>
        internal static string Ticket_Transmit_Failed {
            get {
                return ResourceManager.GetString("Ticket_Transmit_Failed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot create transmission part from file {0} because it does not exist.
        /// </summary>
        internal static string TransmissionPart_CannotCreatePartAsFileDoesNotExist {
            get {
                return ResourceManager.GetString("TransmissionPart_CannotCreatePartAsFileDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transmission part with id {0} already exists.
        /// </summary>
        internal static string TransmissionPartCollection_Add_TransmissionPartExists {
            get {
                return ResourceManager.GetString("TransmissionPartCollection_Add_TransmissionPartExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TransmissionParts must be of type ITransmissionPart.
        /// </summary>
        internal static string TransmissionPartSettings_ThrowExceptionIfTypeIsNotITransmissionPart {
            get {
                return ResourceManager.GetString("TransmissionPartSettings_ThrowExceptionIfTypeIsNotITransmissionPart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The assigned transmitter must implement ITransmitter.
        /// </summary>
        internal static string TransmissionSettings_ThrowExceptionIfTypeIsNotITransmitter {
            get {
                return ResourceManager.GetString("TransmissionSettings_ThrowExceptionIfTypeIsNotITransmitter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scheme {0} is not configured with a transmitter..
        /// </summary>
        internal static string TransmitterFactory_GetTransmitterForScheme_SchemeNotConfigured {
            get {
                return ResourceManager.GetString("TransmitterFactory_GetTransmitterForScheme_SchemeNotConfigured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to load XDocument from {0}.
        /// </summary>
        internal static string XmlTransmissionPart_FailedToLoadXDocumentFromFile {
            get {
                return ResourceManager.GetString("XmlTransmissionPart_FailedToLoadXDocumentFromFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to load XDocument from stream.
        /// </summary>
        internal static string XmlTransmissionPart_FailedToLoadXDocumentFromStream {
            get {
                return ResourceManager.GetString("XmlTransmissionPart_FailedToLoadXDocumentFromStream", resourceCulture);
            }
        }
    }
}
