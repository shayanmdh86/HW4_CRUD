using CsvHelper;
using HW4.Entity;
using System.Globalization;

namespace HW4.Service
{
    public class UserService : IUserServise
    {
        int id = 0;

        public void Create(string name, string mobile, DateTime strbirthDate)
        {
            List<User> users = new List<User>();
            DateTime BirthDate = strbirthDate;
            if (mobile != null && mobile.Length == 11)
            {
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
            else
            {
                Console.WriteLine("your Phone NUmber is notcorrect!!");
            }
        }

        public List<User> ReadUser()
        {
            List<string> usersr = new List<string>();

            string? solutionFolderPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            string dataFolderPath = Path.Combine(solutionFolderPath, "DataBase");
            string filePath = Path.Combine(dataFolderPath, "FileDataStorage.csv");

            StreamReader stream = null;

            if (File.Exists(filePath))
            {
                stream = new StreamReader(File.OpenRead(filePath));
                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine();
                    usersr.Add(line);

                }
                foreach (var lines in usersr)
                {
                    Console.WriteLine(lines);

                }
            }

        }

        public void SaveOnCsv(List<User> users)
        {
            string? solutionFolderPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            string dataFolderPath = Path.Combine(solutionFolderPath, "DataBase");
            string filePath = Path.Combine(dataFolderPath, "FileDataStorage.csv");

            using (var sw = new StreamWriter(filePath))
            using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<User>();
                csv.NextRecord();
                foreach (var user in users)
                {
                    csv.WriteRecord(user);
                    csv.NextRecord();
                }
            }


            //using (TextWriter writer = new StreamWriter(filePath))
            //{
            //    foreach (var item in users)
            //    {
            //        var line=(item.Id,item.Name,item.Mobile,item.birthDate,item.createDate);
            //        writer.WriteLine(line);
            //    }
            //}
        }
    }
}













