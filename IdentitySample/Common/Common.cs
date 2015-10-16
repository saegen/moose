using System;

namespace DataLib.Common
{
    //Innehåller de roller som ska finnas. Dessa användes till att seeda databasen och ska användas till Authorize attributen.
    //skapat ett custom Extensions.AuthorizeRolesAttribute autentisera mot flera attribut. (Enums fungerar inte då värdena måste vara konstanter så tex ToString())
    public struct UserRole
    {
        public const string Admin = "Admin";
        public const string Staff = "Personal";
        public const string Parent = "Förälder";
    }

}