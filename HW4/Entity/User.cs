namespace HW4.Entity
{
    public class User
    {
        public int Id { get { return _id; } }
        private int _id { get; set; }

        public string Name { get { return _name; } }
        private string _name { get; set; }

        public string Mobile { get { return _mobile; } }
        private string _mobile { get; set; }

        public DateTime birthDate { get { return _birthdate; } }
        private DateTime _birthdate { get; set; }

        public DateTime createDate { get { return _createDate; } }
        private DateTime _createDate { get; set; }

        public User(int id, string name, string mobile, DateTime birthdate, DateTime createDate)
        {
            _id = id;
            _name = name;
            _mobile = mobile;
            _birthdate = birthdate;
            _createDate = createDate;

           
            
        }
    }
}
