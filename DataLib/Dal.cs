using DataLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    using Models.Identity;
    using Models.Content;
    public static class DAL
    {
        public static string getContent(string elementId)
        {
            if (string.IsNullOrWhiteSpace(elementId))
            {
                throw new ArgumentNullException("elementId");
            }
            using (DataModel db = new DataModel())
            {
                var content = db.Content.Find(elementId);
                return content != null ? content.Content : "";
            }
        }

        public static void deleteContent(string elementId)
        {
            if (string.IsNullOrWhiteSpace(elementId))
            {
                throw new ArgumentNullException("elementId");
            }
            using (DataModel db = new DataModel())
            {
                var content = db.Content.Find(elementId);
                if (content != null)
                {
                    db.Content.Remove(content);
                    db.SaveChanges();
                }
            }
        }

        public static void addContent(string elementId, string content, string url = "")
        {
            if (string.IsNullOrWhiteSpace(elementId))
            {
                throw new ArgumentNullException("elementId");
            }
            using (DataModel db = new DataModel())
            {
                var _content = db.Content.Find(elementId);
                if (_content != null)
                {
                    throw new ArgumentException("Id already exists", "elementId");
                }
                var contentToSave = new EditableContent();
                contentToSave.ElementId = elementId;
                contentToSave.Content = content;
                contentToSave.View = url;
                db.Content.Add(contentToSave);
                db.SaveChanges();
            }
        }

        public static void updateContent(string elementId, string content)
        {
            if (string.IsNullOrWhiteSpace(elementId))
            {
                throw new ArgumentNullException("elementId");
            }
            using (DataModel db = new DataModel())
            {
                var _content = db.Content.Find(elementId);
                if (_content == null )
                {
                    throw new ArgumentException("could not find {0}", elementId);
                }
                _content.Content = content;
                db.SaveChanges();
            }
        }

        public static DataLibUser getAdminUser(string adminId)
        {
            if (string.IsNullOrWhiteSpace(adminId))
            {
                throw new ArgumentNullException("adminId");
            }
            using (DataModelContext db = new DataModelContext())
            {
                var admin = db.Users.Find(adminId);
                return admin;   
            }
        }

        public static DataLibUser getUser(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException("userId");
            }
            using (DataModelContext db = new DataModelContext())
            {
                var admin = db.Users.Find(userId);
                return admin;
            }
        }

        public static IEnumerable<DataLibUser> getUsers()
        {
            using (DataModelContext db = new DataModelContext())
            {
                foreach (var user in db.Users)
                {
                   yield return user;
                }
            }
        }

        public static void addUser(DataLibUser user)
        {
            if (null == user)
            {
                throw new ArgumentNullException("user");
            }
            using (DataModelContext db = new DataModelContext())
            {
                if (db.Users.Find(user.Id) != null)
                {
                    throw new ArgumentException("User already exists");
                }
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public static void deleteUser(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException("userId");
            }
            using (DataModelContext db = new DataModelContext())
            {
                var user = db.Users.Find(userId);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }

        public static void deleteUser(DataLibUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            using (DataModelContext db = new DataModelContext())
            {
                var dbuser = db.Users.Find(user.Id);
                if (dbuser != null)
                {
                    db.Users.Remove(dbuser);
                    db.SaveChanges();
                }
            }
        }
    }
}
