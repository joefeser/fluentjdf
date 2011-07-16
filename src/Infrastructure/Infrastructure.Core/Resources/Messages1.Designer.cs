﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Core.Resources {
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
    public class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Infrastructure.Core.Resources.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to Error Creating Directory: &apos;{0}&apos;.
        /// </summary>
        public static string DirectoryAndFileHelper_ErrorCreatingDirectory {
            get {
                return ResourceManager.GetString("DirectoryAndFileHelper_ErrorCreatingDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The destination file already exists and could not be deleted &apos;{0}&apos;.
        /// </summary>
        public static string DirectoryAndFileHelper_SaveStreamToFile_CouldNotDeleteExistingFile {
            get {
                return ResourceManager.GetString("DirectoryAndFileHelper_SaveStreamToFile_CouldNotDeleteExistingFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The destination file already exists and overrideFile is false &apos;{0}&apos;.
        /// </summary>
        public static string DirectoryAndFileHelper_SaveStreamToFile_DestinationFileExists {
            get {
                return ResourceManager.GetString("DirectoryAndFileHelper_SaveStreamToFile_DestinationFileExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error creating Or writing to temporary file used to write stream {0}.
        /// </summary>
        public static string DirectoryAndFileHelper_SaveStreamToFile_ErrorCreatingTempFile {
            get {
                return ResourceManager.GetString("DirectoryAndFileHelper_SaveStreamToFile_ErrorCreatingTempFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error during rename of temp file from {0} to {1}.
        /// </summary>
        public static string DirectoryAndFileHelper_SaveStreamToFile_ErrorRenamingFileFromTempFile {
            get {
                return ResourceManager.GetString("DirectoryAndFileHelper_SaveStreamToFile_ErrorRenamingFileFromTempFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unhandled exception.  Actual exception is not known.
        /// </summary>
        public static string LogInitializer_HookUnhandledExceptionEvents_Unhandled_UnknownException {
            get {
                return ResourceManager.GetString("LogInitializer_HookUnhandledExceptionEvents_Unhandled_UnknownException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unhandled exception.
        /// </summary>
        public static string LogInitializer_HookUnhandledExceptionEvents_UnhandledException {
            get {
                return ResourceManager.GetString("LogInitializer_HookUnhandledExceptionEvents_UnhandledException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not delete mime buffer file {0}.
        /// </summary>
        public static string Mime_Dispose_CouldNoDeleteMimeBufferFile {
            get {
                return ResourceManager.GetString("Mime_Dispose_CouldNoDeleteMimeBufferFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unrecognized charset: {0}.
        /// </summary>
        public static string Mime_GetMimeCharset_UnrecognizedCharset {
            get {
                return ResourceManager.GetString("Mime_GetMimeCharset_UnrecognizedCharset", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error occurred during mime encoding.
        /// </summary>
        public static string Mime_GetMimeCollectionFile_ErrorDuringEncoding {
            get {
                return ResourceManager.GetString("Mime_GetMimeCollectionFile_ErrorDuringEncoding", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unrecognized MimeEncoding: {0}.
        /// </summary>
        public static string Mime_GetMimeEncoding_UnrecognizedMimeEncoding {
            get {
                return ResourceManager.GetString("Mime_GetMimeEncoding_UnrecognizedMimeEncoding", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not delete temp file {0} used to create mime body.
        /// </summary>
        public static string Mime_GetMimeStream_CouldNotDeleteTempFileUsedToCreateBody {
            get {
                return ResourceManager.GetString("Mime_GetMimeStream_CouldNotDeleteTempFileUsedToCreateBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unrecognized charset: .
        /// </summary>
        public static string MimeBodyPart_GetMimeCharsetUnrecognizedCharset {
            get {
                return ResourceManager.GetString("MimeBodyPart_GetMimeCharsetUnrecognizedCharset", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unrecognized MimeEncoding: .
        /// </summary>
        public static string MimeBodyPart_GetMimeEncoding_UnrecognizedMimeEncoding {
            get {
                return ResourceManager.GetString("MimeBodyPart_GetMimeEncoding_UnrecognizedMimeEncoding", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Header is not in the expected name:value form.  The raw data is {0}.
        /// </summary>
        public static string MimeHeader_ParseLine_HeaderIsNotInCorrectForm {
            get {
                return ResourceManager.GetString("MimeHeader_ParseLine_HeaderIsNotInCorrectForm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Header param with same name already exists.  The header is {0}.
        /// </summary>
        public static string MimeHeaderParamCollection_Add_HeaderParamWithNameExists {
            get {
                return ResourceManager.GetString("MimeHeaderParamCollection_Add_HeaderParamWithNameExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid position {0} to add a parameter in a Mime Header.
        /// </summary>
        public static string MimeHeaderParamCollection_AddAt_InvalidPositionForMiimeHeader {
            get {
                return ResourceManager.GetString("MimeHeaderParamCollection_AddAt_InvalidPositionForMiimeHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Content type is unknown because message has no body.
        /// </summary>
        public static string MimeMessage_ContentTypeUnknownBecauseNoBody {
            get {
                return ResourceManager.GetString("MimeMessage_ContentTypeUnknownBecauseNoBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mime message must have a body part.
        /// </summary>
        public static string MimeMessage_Write_MimeMustHaveBody {
            get {
                return ResourceManager.GetString("MimeMessage_Write_MimeMustHaveBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid boundary string.
        /// </summary>
        public static string MimeParser_ParseBoundary_InvalidBoundaryString {
            get {
                return ResourceManager.GetString("MimeParser_ParseBoundary_InvalidBoundaryString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid multipart.
        /// </summary>
        public static string MimeParser_ParseBoundary_InvalidMultipart {
            get {
                return ResourceManager.GetString("MimeParser_ParseBoundary_InvalidMultipart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid MIME stream.
        /// </summary>
        public static string MimeParser_ValidateVersionHeader_InvalidMimeStream {
            get {
                return ResourceManager.GetString("MimeParser_ValidateVersionHeader_InvalidMimeStream", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find component with name {0} of type {1}.
        /// </summary>
        public static string NameSelectorCannotFindComponent {
            get {
                return ResourceManager.GetString("NameSelectorCannotFindComponent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parameter {0} is required..
        /// </summary>
        public static string ParameterCheck_GetParameterRequiredErrorMessage {
            get {
                return ResourceManager.GetString("ParameterCheck_GetParameterRequiredErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter {0} must be greater than zero..
        /// </summary>
        public static string ParameterCheck_IntParameterGreaterThanZero {
            get {
                return ResourceManager.GetString("ParameterCheck_IntParameterGreaterThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parameter {0} must not have a zero value.
        /// </summary>
        public static string ParameterCheck_IntParameterIsNonZero {
            get {
                return ResourceManager.GetString("ParameterCheck_IntParameterIsNonZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enumerable {0} must contain at least one member.
        /// </summary>
        public static string ParameterCheck_ListMustContainAtLeastOne {
            get {
                return ResourceManager.GetString("ParameterCheck_ListMustContainAtLeastOne", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The string parameter {0} must not be null, empty or contain only whitespace.
        /// </summary>
        public static string ParameterCheck_StringRequiredAndNotWhitespace {
            get {
                return ResourceManager.GetString("ParameterCheck_StringRequiredAndNotWhitespace", resourceCulture);
            }
        }
    }
}
