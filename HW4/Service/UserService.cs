using HW4.Entity;

namespace HW4.Service
{
    public class UserService : IUserServise
    {
        int id = 0;

        public void Create(string name, string mobile, string strbirthDate)
        {
            List<User> users = new List<User>();

            DateTime BirthDate;
            DateTime.TryParse(strbirthDate, out BirthDate);
            BirthDate.ToString("0000/00/00");

            if (BirthDate < DateTime.Now)
            {
                id = id + 1;
                User user = new User(id, name, mobile, BirthDate, DateTime.Now);
                users.Add(user);
                SaveOnCsv(users);

            }
            else
            {
                Console.WriteLine("birthDate is correect!!");
            }

        }

        public void SaveOnCsv(List<User> users)
        {
            string? solutionFolderPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            string dataFolderPath = Path.Combine(solutionFolderPath, "DataBase");
            string filePath = Path.Combine(dataFolderPath, "FileDataStorage.csv");
            using(StreamReader reader = new StreamReader(filePath))
            using (var stream = File.CreateText(filePath))
            {
                stream.WriteLine("ID,Name,Phone,BirthDay,CreateDate");
                foreach (var user in users)
                {
                    var line = (user.Id, user.Name, user.Mobile, user.birthDate, user.createDate);
                    stream.WriteLine(line);
                    stream.Close();
                }
            }
        }
    }
}













