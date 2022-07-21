using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace P11__Using_the_DLLImport_Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility.ImpersonateWindowsUser("Student", "Student", "Pa55w.rd");
            Console.WriteLine("Press any key to continue"); Console.ReadLine();
        }

        public class Utility
        {
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern bool LogonUser(
                string lpszUsername,
                string lpszDomain,
                string lpszPassword,
                int dwLogonType,
                int dwLogonProvider,
                out IntPtr pptrUserToken
                );

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            private extern static bool CloseHandle(IntPtr handle);

            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private extern static bool DuplicateToken(IntPtr ExistingTokenHandle,
                int SECURITY_IMPERSONATION_LEVEL, out IntPtr DuplicateTokenHandle);

            public static void ImpersonateWindowsUser(string UserName, string Domain, string Password)
            {

                const int LOGON32_LOGON_INTERACTIVE = 2;


                const int LOGON32_PROVIDER_DEFAULT = 0;
                IntPtr ptrUserToken = IntPtr.Zero;

                IntPtr ptrUserTokenDuplicate = IntPtr.Zero;


                if (LogonUser(UserName, Domain, Password,
                    LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out ptrUserToken))
                {
                    if (DuplicateToken(ptrUserToken, 2, out ptrUserTokenDuplicate))
                    {
                        // Create a WindowsIdentity from the token
                        WindowsIdentity winIdentity = new WindowsIdentity(ptrUserToken);

                        // Impersonate the user
                        Console.WriteLine("Before impersonation, the user is: " + WindowsIdentity.GetCurrent().Name + "\n");
                        WindowsImpersonationContext impContext = winIdentity.Impersonate();
                        Console.WriteLine("Impersonating the user: " + WindowsIdentity.GetCurrent().Name + "\n");

                        // Place resource access code here
                        Console.WriteLine("Writing to file c:\\temp\\testout.txt");
                        System.IO.File.WriteAllText("c:\\temp\\testout.txt", DateTime.Now.ToLongDateString());

                        // Stop impersonating
                        impContext.Undo();
                        Console.WriteLine("\nAfter imprsonation, the user is now: " +
                            WindowsIdentity.GetCurrent().Name + "\n");
                    }
                }
                else
                {
                    Console.WriteLine("Not Impersonating, user not successfully authenticated");
                }

                if (ptrUserToken != IntPtr.Zero) CloseHandle(ptrUserToken);
                if (ptrUserTokenDuplicate != IntPtr.Zero) CloseHandle(ptrUserTokenDuplicate);

            }
        }
    }
}
