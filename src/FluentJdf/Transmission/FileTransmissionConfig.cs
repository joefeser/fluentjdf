﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FluentJdf.Transmission {

    /// <summary>
    /// Stuff used for the file transmission config
    /// </summary>
    public static class FileTransmissionConfig {

        /// <summary>
        /// Full path of the configuration file.
        /// </summary>
        public static string ConfigurationFile {
            get {
                return AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            }
        }

        /// <summary>
        /// Path where the executable is located without the name of the executable. (same as InstallationRoot)
        /// </summary>
        public static string ExecutablePath {
            get {
                return Path.GetDirectoryName(ConfigurationFile);
            }
        }

        /// <summary>
        /// Path where the executable is located without the name of the executable. (same as ExecutablePath)
        /// </summary>
        public static string InstallationRoot {
            get {
                return Path.GetDirectoryName(ConfigurationFile);
            }
        }

        /// <summary>
        /// The Log Folder
        /// </summary>
        public static string LogFolder {
            get {
                //TODO how do we determine the log folder path?
                return null;
            }
        }

        /// <summary>
        /// The Temp folder
        /// </summary>
        public static string TempFolder {
            get {
                return Path.GetTempPath();
            }
        }

        /// <summary>
        /// Fixup a path in a configuration string replacing ${InstallationRoot}, ${ConfigurationFolder},
        /// ${TempFolder} and ${FileStorageRoot} etc. with corresponding values from the configuration file.
        /// </summary>
        /// <param name="pathString">The path to fixup.</param>
        /// <returns>The path with all variables replaced.</returns>
        public static string FixupConfigItemPath(string pathString) {
            try {
                string oldString = null;
                do {
                    oldString = pathString;

                    if (pathString.IndexOf("${InstallationRoot}") > -1) {
                        pathString = ReplaceVar(pathString, "InstallationRoot", InstallationRoot);
                    }
                    if (pathString.IndexOf("${ConfigurationFolder}") > -1) {
                        pathString = ReplaceVar(pathString, "ConfigurationFolder", ExecutablePath);
                    }
                    if (pathString.IndexOf("${TempFolder}") > -1) {
                        pathString = ReplaceVar(pathString, "TempFolder", TempFolder);
                    }
                    if (pathString.IndexOf("${RuntimeExecutableFolder}") > -1) {
                        pathString = ReplaceVar(pathString, "RuntimeExecutableFolder", ExecutablePath);
                    }
                } while (oldString != pathString);
            }
            catch {
                //Ignoring errors because the logging comes in here as it starts so there may be no place to log anything!
            }
            return pathString;
        }

        /// <summary>
        /// Replace a variable like ${name} with given information assuming
        /// that the result is supposed to be a legal file path.  Used internally by ConfigBase.
        /// </summary>
        /// <param name="pathString">The string that contains the replacement variable and other text.</param>
        /// <param name="varName">The name of the replacement variable without the opening "${" or the closing
        /// "}".</param>
        /// <param name="varValue">The value that should replace all occurences of the variable.</param>
        /// <returns>The string with replacements made.</returns>
        public static string ReplaceVar(string pathString, string varName, string varValue) {
            if (varValue != null) {
                string fullVarName = "${" + varName + "}";

                while (pathString.IndexOf(fullVarName, 0, StringComparison.InvariantCultureIgnoreCase) > -1) {
                    var tempReplaceValue = varValue;
                    var index = pathString.IndexOf(fullVarName);
                    if (index > 0 && IsSeparatorChar(tempReplaceValue[0]) && IsSeparatorChar(pathString[index - 1])) {
                        tempReplaceValue = tempReplaceValue.Substring(1);
                    }
                    if (IsSeparatorChar(tempReplaceValue[tempReplaceValue.Length - 1]) && index + fullVarName.Length < pathString.Length && IsSeparatorChar(pathString[index + fullVarName.Length])) {
                        tempReplaceValue = tempReplaceValue.Substring(0, tempReplaceValue.Length - 1);
                    }
                    if (index + fullVarName.Length < pathString.Length) {
                        pathString = pathString.Substring(0, index) + tempReplaceValue + pathString.Substring(index + fullVarName.Length);
                    }
                    else {
                        pathString = pathString.Substring(0, index) + tempReplaceValue;
                    }

                }
            }

            return pathString;
        }

        /// <summary>
        /// If the character is a / or a \ we will return true 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static bool IsSeparatorChar(char item) {
            if (item == Path.DirectorySeparatorChar) {
                return true;
            }
            if (item == Path.AltDirectorySeparatorChar) {
                return true;
            }
            return false;
        }

    }
}
