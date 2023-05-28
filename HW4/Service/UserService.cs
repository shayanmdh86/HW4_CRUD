using HW4.Entity;
namespace HW4.Service
{
    public class UserService : IUserServise
    {
        private string filepath;
        private List<User> user;

        public UserService()
        {
            string? solutionFolderPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            string dataStorageFolderPath = Path.Combine(solutionFolderPath, "DataBase");
            filepath = Path.Combine(dataStorageFolderPath, "FileDataStorage.csv");


            user = ReadUsers();
        }

        public void CreateUser(string fullName, string phone, DateTime dateOfBirth)
        {
            int lastUserId;
            if (user.Count > 0)
            {
                lastUserId = user.Max(u => u.Id);
            }
            else
            {
                lastUserId = 0;
            }

            var newUser = new User()
            {
                Id = lastUserId + 1,
                Name = fullName,
                Mobile = phone,
                BirthDay = dateOfBirth,
                createDate = DateTime.Now
            };
            user.Add(newUser);

            WriteInCsvFile(user);
        }

        //public List<User> ReadUser()
        //{
        //    return user.ToList();
        //}


        private List<User> ReadUsers()
        {
            var users = new List<User>();

            using (StreamReader reader = new StreamReader(filepath))
            {
                string line;
                bool isFirstLine = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    var index = line.Split(',');
                    var user = new User
                    {
                        Id = int.Parse(index[0]),
                        Name = index[1],
                        Mobile = index[2],
                        BirthDay = DateTime.Parse(index[3]),
                        createDate = DateTime.Parse(index[4]),
                    };

                    users.Add(user);
                }
            }

            return users;
        }

        private void WriteInCsvFile(List<User> users)
        {
            using (var writer = new StreamWriter(filepath))
            {
                writer.WriteLine("Id,FullName,Phone,DateOfBirth,UserCreationDate");

                foreach (var user in users)
                {
                    var line = $"{user.Id},{user.Name} , {user.Mobile} , {user.BirthDay} , {user.createDate}";
                    writer.WriteLine(line);
                }
            }
        }


    }
}
