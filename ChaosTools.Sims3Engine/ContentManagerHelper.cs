using System;
using System.Collections.Generic;
using System.Text;

namespace ChaosTools.Sims3Engine
{
    /// <summary>
    /// This class provides helper functions to supplement the functions provided by
    /// <see cref="T:Sims3.SimIFace.CustomContent.IContentManager"/> and
    /// <see cref="T:Sims3.SimIFace.CustomContent.IDownloadContent"/>.
    /// </summary>
    public static class ContentManagerHelper
    {
        private static Sims3.SimIFace.IStringTable gStringTable =
            AppDomain.CurrentDomain.GetData("LocalizedStringService") as Sims3.SimIFace.IStringTable;
        private static Sims3.SimIFace.IGameUtils gGameUtils =
            AppDomain.CurrentDomain.GetData("GameUtils") as Sims3.SimIFace.IGameUtils;

        private static string LocalizeString(string key)
        {
            if (gStringTable == null)
                return key;
            if (!string.IsNullOrEmpty(key))
            {
                string result = gStringTable.GetLocalizedString(key);
                return string.IsNullOrEmpty(result) ? key : result;
            }
            return key;
        }

        /// <summary>
        /// Human readable enumeration of result codes returned by
        /// <see cref="M:Sims3.SimIFace.CustomContent.IContentManager.InstallContent(System.String)"/>,
        /// <see cref="M:Sims3.SimIFace.CustomContent.IContentManager.UnInstallContent(Sims3.SimIFace.PackageId)"/>,
        /// <see cref="M:Sims3.SimIFace.CustomContent.IDownloadContent.SetPackageEnabled(Sims3.SimIFace.PackageId,System.Boolean)"/>
        /// </summary>
        /// <remarks>
        /// Copied from <see cref="T:Sims3.UI.BaseContentModify.ModifyResult"/>
        /// </remarks>
        public enum ModifyResult : uint
        {
            /// <summary>
            /// Specified content's cache entry in DCCache database is corrupted
            /// </summary>
            kCacheEntryCorrupted = 2,
            /// <summary>
            /// Specified file cannot be opened (possibly due to lack of permission)
            /// </summary>
            kCanNotOpenFile = 6,
            /// <summary>
            /// Specified package cannot be opened (possibly due to lack of permission)
            /// </summary>
            kCanNotOpenPackage = 7,
            /// <summary>
            /// Could not import custom sim file
            /// </summary>
            kCASSimImportFailed = 3,
            /// <summary>
            /// Critical System Failure
            /// </summary>
            kCriticalSystemFailed = 1,
            /// <summary>
            /// General Failure
            /// </summary>
            kFailed = 0,
            /// <summary>
            /// Specified file does not exist
            /// </summary>
            kFileNotExist = 5,
            /// <summary>
            /// Other content depends on Specified content
            /// </summary>
            kHasDependents = 11,
            /// <summary>
            /// Content modification successful despite dependency on missing content
            /// </summary>
            kMissingDependency = 0x1003,
            /// <summary>
            /// Content modification successful despite dependency on missing expansion/stuff pack content
            /// </summary>
            kMissingEPDependency = 0x1005,
            /// <summary>
            /// Specified file is missing its internal manifest
            /// </summary>
            kMissingManifest = 10,
            /// <summary>
            /// Content modification successful despite dependency on missing store content
            /// </summary>
            kMissingPaidContent = 0x1004,
            /// <summary>
            /// Game Engine needs to be restarted to finish content modification
            /// </summary>
            kNeedsRestart = 0x1001,
            /// <summary>
            /// Specified package is already installed
            /// </summary>
            kPackageAlreadyInstalled = 0x1002,
            /// <summary>
            /// Specified package is corrupted and cannot be opened
            /// </summary>
            kPackageCorrupted = 8,
            /// <summary>
            /// Specified package was not found
            /// </summary>
            kPackageNotFound = 9,
            /// <summary>
            /// Specified content is read-only
            /// </summary>
            kReadOnlyMode = 4,
            /// <summary>
            /// Specified content requires missing game patch update
            /// </summary>
            kRequiresGameUpdate = 13,
            /// <summary>
            /// Specified content requires missing expansion/stuff pack
            /// </summary>
            kRequiresMissingEP = 12,
            /// <summary>
            /// Specified content requires missing store content
            /// </summary>
            kRequiresMissingPaidObject = 14,
            /// <summary>
            /// Content modification successful
            /// </summary>
            kSuccess = 0x1000,
            /// <summary>
            /// Specified World is already installed
            /// </summary>
            kWorldAlreadyInstalled = 15
        }

        /// <summary>
        /// Return the localized message for the given 
        /// custom content modification result.
        /// </summary>
        /// <param name="resCode">Modification Result Code</param>
        /// <returns>Localized message for display</returns>
        /// <remarks>
        /// Copied from <see cref="M:Sims3.UI.BaseContentModify.GetResName(System.UInt32)"/>
        /// </remarks>
        public static string GetResultMessage(uint resCode)
        {
            return GetResultMessage((ModifyResult)resCode);
        }

        /// <summary>
        /// Return the localized message for the given 
        /// custom content modification result.
        /// </summary>
        /// <param name="resCode">Modification Result Code</param>
        /// <returns>Localized message for display</returns>
        /// <remarks>
        /// Copied from <see cref="M:Sims3.UI.BaseContentModify.GetResName(System.UInt32)"/>
        /// </remarks>
        public static string GetResultMessage(ModifyResult resCode)
        {
            switch (resCode)
            {
                case ModifyResult.kFailed:
                    return LocalizeString("Ui/Caption/Install:Failed");

                case ModifyResult.kCriticalSystemFailed:
                case ModifyResult.kCacheEntryCorrupted:
                    return LocalizeString("Ui/Caption/Install:CriticalSystemFailed");

                case ModifyResult.kCASSimImportFailed:
                    return LocalizeString("Ui/Caption/Install:CASSimImportFailed");

                case ModifyResult.kReadOnlyMode:
                    return LocalizeString("Ui/Caption/Install:ReadOnlyMode");

                case ModifyResult.kFileNotExist:
                    return LocalizeString("Ui/Caption/Install:FileNotExist");

                case ModifyResult.kCanNotOpenFile:
                    return LocalizeString("Ui/Caption/Install:CanNotOpenFile");

                case ModifyResult.kCanNotOpenPackage:
                    return LocalizeString("Ui/Caption/Install:CanNotOpenPackage");

                case ModifyResult.kPackageCorrupted:
                case ModifyResult.kMissingManifest:
                    return LocalizeString("Ui/Caption/Install:PackageCorrupted");

                case ModifyResult.kPackageNotFound:
                    return LocalizeString("Ui/Caption/Install:PackageNotFound");

                case ModifyResult.kHasDependents:
                    return LocalizeString("Ui/Caption/Install:HasDependents");

                case ModifyResult.kRequiresMissingEP:
                    return LocalizeString("Ui/Caption/Install:RequiresMissingEP");

                case ModifyResult.kRequiresGameUpdate:
                    return LocalizeString("Ui/Caption/Install:RequiresGameUpdate");

                case ModifyResult.kRequiresMissingPaidObject:
                    return LocalizeString("Ui/Caption/Install:RequiresMissingPaidObject");

                case ModifyResult.kWorldAlreadyInstalled:
                case ModifyResult.kPackageAlreadyInstalled:
                    return LocalizeString("Ui/Caption/Install:PackageAlreadyInstalled");

                case ModifyResult.kSuccess:
                    if (gGameUtils == null || gGameUtils.GetCommandLineSwitch("ccuninstall") == null)
                    {
                        return LocalizeString("Ui/Caption/Install:Success");
                    }
                    return LocalizeString("Ui/Caption/Install:UninstallSuccess");

                case ModifyResult.kNeedsRestart:
                    return LocalizeString("Ui/Caption/Install:NeedsRestart");

                case ModifyResult.kMissingDependency:
                    return LocalizeString("Ui/Caption/Install:MissingDependancy");

                case ModifyResult.kMissingPaidContent:
                    return LocalizeString("Ui/Caption/Install:MissingPaidContent");

                case ModifyResult.kMissingEPDependency:
                    return LocalizeString("Ui/Caption/Install:MissingEPDependency");
            }
            return LocalizeString("Ui/Caption/Install:UnknownError");
        }

        /// <summary>
        /// Returns the message for the given
        /// custom content modification result.
        /// </summary>
        /// <param name="resCode">Modification Result Code</param>
        /// <returns>Message for display</returns>
        public static string GetResultName(ModifyResult resCode)
        {
            switch (resCode)
            {
                case ModifyResult.kFailed:
                    return "Failed";

                case ModifyResult.kCriticalSystemFailed:
                    return "Critical System Failed";

                case ModifyResult.kCacheEntryCorrupted:
                    return "Cache Entry Corrupted";

                case ModifyResult.kCASSimImportFailed:
                    return "CAS Sim Import Failed";

                case ModifyResult.kReadOnlyMode:
                    return "Read Only Mode";

                case ModifyResult.kFileNotExist:
                    return "File Does Not Exist";

                case ModifyResult.kCanNotOpenFile:
                    return "Can't Open File";

                case ModifyResult.kCanNotOpenPackage:
                    return "Can't Open Package";

                case ModifyResult.kPackageCorrupted:
                    return "Package Corrupted";

                case ModifyResult.kMissingManifest:
                    return "Missing Manifest";

                case ModifyResult.kPackageNotFound:
                    return "Package Not Found";

                case ModifyResult.kHasDependents:
                    return "Has Dependents";

                case ModifyResult.kRequiresMissingEP:
                    return "Requires Missing Expansion Pack";

                case ModifyResult.kRequiresGameUpdate:
                    return "Requires Game Update";

                case ModifyResult.kRequiresMissingPaidObject:
                    return "Requires Missing Paid Object";

                case ModifyResult.kWorldAlreadyInstalled:
                    return "World Already Installed";

                case ModifyResult.kPackageAlreadyInstalled:
                    return "Package Already Installed";

                case ModifyResult.kSuccess:
                    if (gGameUtils == null || gGameUtils.GetCommandLineSwitch("ccuninstall") == null)
                    {
                        return "Success";
                    }
                    return "Successfully Uninstalled";

                case ModifyResult.kNeedsRestart:
                    return "Needs Restart";

                case ModifyResult.kMissingDependency:
                    return "Missing Dependancy";

                case ModifyResult.kMissingPaidContent:
                    return "Missing Paid Content";

                case ModifyResult.kMissingEPDependency:
                    return "Missing Expansion Pack Dependency";
            }
            return "Unknown Error";
        }
    }
}
