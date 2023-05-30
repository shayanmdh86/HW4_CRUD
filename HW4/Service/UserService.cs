﻿using DocumentFormat.OpenXml.Wordprocessing;
using HW4.Entity;
using System.Reflection;

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

        public void CreateUser(string name, string mobile, DateTime birth)
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
                Name = name,
                Mobile = mobile,
                BirthDate = birth,
                CreateDate = DateTime.Now
            };
            user.Add(newUser);

            Csvwriter(user);
        }

        public List<User> ReadUser()
        {
            return user.ToList();
        }

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
                        BirthDate = DateTime.Parse(index[3]),
                        CreateDate = DateTime.Parse(index[4]),
                    };

                    users.Add(user);
                }
            }

            return users;
        }
        public void UpdateUser(int id, string name, string mobile)
        {
            var test = user.Find(u => u.Id == id);
            if (test!=null)
            {
                test.Name = name;
                test.Mobile = mobile;
                Csvwriter(user);

            }
            else
            {
                Console.WriteLine("kdbjkbvjk");
            }
        }



        private void Csvwriter(List<User> users)
        {
            using (var writer = new StreamWriter(filepath))
            {
                writer.WriteLine("Id,Name,PhoneNumber,BirthDate,CreateUser");

                foreach (var user in users)
                {
                    var line = $"{user.Id},{user.Name} , {user.Mobile} , {user.BirthDate} , {user.CreateDate}";
                    writer.WriteLine(line);
                }
            }
        } 
        public void DeleteUser(int id)
        {
            var test = user.Find(u => u.Id == id);
            if (test!=null)
            {
                user.Remove(test);
                Csvwriter(user);

            }
            else
            {
                Console.WriteLine("  ");
            }
           
        }

     
    }
}
