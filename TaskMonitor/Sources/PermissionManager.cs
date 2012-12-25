using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;  // DllImport
using System.Security.Principal; // WindowsImpersonationContext
using System.Security.Permissions; // PermissionSetAttribute

namespace TaskMonitor.Sources
{
    public static class PermissionManager
    {
        #region LogonUser
        // Obtains user token
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        #endregion

        #region CloseHandle
        // Closes open handes returned by LogonUser
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
        #endregion

        #region DuplicateToken
        // Creates duplicate token handle
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static bool DuplicateToken(IntPtr ExistingTokenHandle, int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);
        #endregion

        public static WindowsImpersonationContext WindowsImpersonateUser(string sUsername, string sDomain, string sPassword)
        {
            // initialize tokens
            IntPtr pExistingTokenHandle = new IntPtr(0);
            IntPtr pDuplicateTokenHandle = new IntPtr(0);
            pExistingTokenHandle = IntPtr.Zero;
            pDuplicateTokenHandle = IntPtr.Zero;

            // if domain name was blank, assume local machine
            if (sDomain == "" || sDomain == null)
                sDomain = null;//System.Environment.MachineName;

            try
            {
                string sResult = null;

                const int LOGON32_PROVIDER_DEFAULT = 0;

                // create token
                //const int LOGON_TYPE_NEW_CREDENTIALS = 9;
                const int LOGON32_LOGON_INTERACTIVE = 2;
                //const int SecurityImpersonation = 2;

                // get handle to token
                bool bImpersonated = LogonUser(sUsername, sDomain, sPassword, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref pExistingTokenHandle);

                // did impersonation fail?
                if (false == bImpersonated)
                {
                    string nErrorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
                    int nErrorCode = Marshal.GetLastWin32Error();
                    sResult = "LogonUser() failed with error code: " + nErrorCode + "\r\n";

                    return null;                    
                }

                // Get identity before impersonation
                sResult += "Before impersonation: " +
                    WindowsIdentity.GetCurrent().Name + "\r\n";

                bool bRetVal = DuplicateToken(pExistingTokenHandle,
                    (int)SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation,
                        ref pDuplicateTokenHandle);

                // did DuplicateToken fail?
                if (false == bRetVal)
                {
                    int nErrorCode = Marshal.GetLastWin32Error();
                    // close existing handle
                    CloseHandle(pExistingTokenHandle);
                    sResult += "DuplicateToken() failed with error code: "
                        + nErrorCode + "\r\n";

                    return null;
                }
                else
                {
                    // create new identity using new primary token
                    WindowsIdentity newId = new WindowsIdentity
                                                (pDuplicateTokenHandle);
                    WindowsImpersonationContext impersonatedUser =
                                                newId.Impersonate();

                    // check the identity after impersonation
                    sResult += "After impersonation: " +
                        WindowsIdentity.GetCurrent().Name + "\r\n";

                    return impersonatedUser;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // close handle(s)
                if (pExistingTokenHandle != IntPtr.Zero)
                    CloseHandle(pExistingTokenHandle);
                if (pDuplicateTokenHandle != IntPtr.Zero)
                    CloseHandle(pDuplicateTokenHandle);
            }
        }

        public enum SECURITY_IMPERSONATION_LEVEL : int
        {
            SecurityAnonymous = 0,
            SecurityIdentification = 1,
            SecurityImpersonation = 2,
            SecurityDelegation = 3
        }
    }
}
