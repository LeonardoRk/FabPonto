using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.IO;
using SearchScope = System.DirectoryServices.SearchScope;


namespace FabPonto.Utils

{
    public class LdapConnection
    {

        public List<string> SearchAllUsers()
        {
            String defaultDomainName = "";
            DirectoryEntry rootDSE = new DirectoryEntry("LDAP://192.168.151.194");


            // (&(objectCategory=user)(memberOf=CN=GRUPO_DISTRIBUICAO,OU=NOME_DA_OU,DC=fabrica,DC=fga,DC=unb,DC=br))
            string link = "dc=fabrica,dc=fga,dc=unb,dc=br";

            //defaultDomainName = rootDSE.Properties["defaultNamingContext"].Value.ToString();
            DirectoryEntry entryToQuery = new DirectoryEntry ("LDAP://" + link);


            DirectorySearcher ouSearch = new DirectorySearcher(entryToQuery);

//            ouSearch.Filter = "(objectCategory=organizationalUnit)";
//            ouSearch.SearchScope = SearchScope.Subtree;
//            ouSearch.PropertiesToLoad.Add("name");

            SearchResultCollection allOUS = ouSearch.FindAll();

            List<string> ListOfOus = new List<string>();
            foreach (SearchResult oneResult in allOUS)
            {
                ListOfOus.Add(oneResult.Properties["name"][0].ToString());
            }

            return ListOfOus;
        }
    }
}