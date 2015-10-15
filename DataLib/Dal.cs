using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public static class DAL
    {
        public static string getContent(string elementId)
        {
            if (string.IsNullOrWhiteSpace( elementId) )
            {
                throw new ArgumentNullException("elementId");
            }
            using (DataModel db = new DataModel())
            {
                var content = db.Content.Find(elementId);
                return content.Content;
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
                var contentToSave = new DataLib.Models.EditableContent();
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
    }
}
