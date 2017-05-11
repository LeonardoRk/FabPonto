using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.IO;
using log4net;
using log4net.Core;
using log4net.Repository.Hierarchy;
using SearchScope = System.DirectoryServices.SearchScope;


namespace FabPonto.Utils

{
    public class LdapConnection
    {
        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<string> SearchAllUsers()
        {
            Console.WriteLine("");
            List<string> usersList = new List<string>();
            try
            {
                string LDAPADDRESS = "LDAP://107.170.77.49/cn=SEATAF,ou=Projects,dc=fabrica,dc=fga,dc=unb,dc=br";
                DirectoryEntry directoryAuth = new DirectoryEntry(LDAPADDRESS);

                DirectorySearcher directorySearcher = new DirectorySearcher(directoryAuth);

                string query1 = "(&(inetOrgPerson=*)(memberOf=SEATAF))";
                string query2 = "(objectClass=inetOrgPerson)";
                directorySearcher.Filter = query2;
                directorySearcher.SearchRoot = directoryAuth;
                directorySearcher.SearchScope = SearchScope.Subtree;
                directorySearcher.PropertiesToLoad.Add("cn");
                directorySearcher.PropertiesToLoad.Add("uid");
                directorySearcher.PropertiesToLoad.Add("userPassword");


                Console.WriteLine("ANTES DO FOREACH");
                foreach(SearchResult result in directorySearcher.FindAll())
                {
                    //Console.WriteLine(result.ToString());
                     //grab the data - if present
                    if(result.Properties["cn"] != null && result.Properties["cn"].Count > 0)
                    {
                        var sid = result.Properties["cn"][0].ToString();
                        Console.WriteLine(sid);
                    }

                    if(result.Properties["uid"] != null && result.Properties["uid"].Count > 0)
                    {
                        var userName = result.Properties["uid"][0].ToString();
                        Console.WriteLine(userName);
                    }

                    if(result.Properties["userPassword"] != null && result.Properties["userPassword"].Count > 0)
                    {
                        var password = result.Properties["userPassword"][0].ToString();
                        Console.WriteLine(password);
                    }
                }

            }
            catch (System.Runtime.InteropServices.COMException)
            {
                System.Runtime.InteropServices.COMException exception = new System.Runtime.InteropServices.COMException();
                Console.WriteLine(exception);
            }
            catch (InvalidOperationException)
            {
                InvalidOperationException InvOpEx = new InvalidOperationException();
                Console.WriteLine(InvOpEx.Message);
            }
            catch (NotSupportedException)
            {
                NotSupportedException NotSuppEx = new NotSupportedException();
                Console.WriteLine(NotSuppEx.Message);
            }


            Console.WriteLine("Olá!");


            return usersList;
        }
    }
}