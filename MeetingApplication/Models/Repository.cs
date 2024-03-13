namespace MeetingApps.Models
{
    public static class Repository
    {
        private static List<UserInfo> _users = new();

        static Repository()
        {
            _users.Add(new UserInfo() { Id=1, Name="Ahmet", Phone = "234213", EMail = "ahmet@gmail.com", WillAttend = true });
            _users.Add(new UserInfo() { Id=2, Name="Mert", Phone = "2351232113", EMail = "mert@outlook.com", WillAttend = false });
            _users.Add(new UserInfo() { Id=3, Name="Sinem", Phone = "91378u22", EMail = "sinem@hotmail.com", WillAttend = true });
        }
        
        public static List<UserInfo> Users{
            get {
                return _users;
            }
        }
        public static void CreateUser(UserInfo user)
        {
            user.Id = Users.Count + 1;
            _users.Add(user);
        }
        
        public static UserInfo? GetById(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }
    }
}