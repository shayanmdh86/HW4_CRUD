namespace HW4.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime createDate { get; set; }

        private string _mobile;
        public string Mobile
        {
            get
            {
                return _mobile;
            }

            set
            {
                if (value.Length == 11)
                {
                    _mobile = value;
                }
                else
                {
                    Console.WriteLine("is notcorrects");
                }
            }
        }
        private DateTime _birthDate;
        public DateTime BirthDay
        {
            get
            {
                return _birthDate;
            }

            set
            {
                if (value < DateTime.Today)
                {
                    _birthDate = value;
                }
                else
                {
                    Console.WriteLine("sbdckbds");
                }

            }

        }

        
    }




}

