namespace BureauApp
{
    class User
    {
        private static string login;
        public static string Login { get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }
        private static string role;
        public static string Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
            }
        }
        private static string selectedTable;
        public static string SelectedTable
        {
            get
            {
                return selectedTable;
            }
            set
            {
                selectedTable = value;
            }
        }
    }
}
