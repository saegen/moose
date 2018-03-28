using DataLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        public static void DeleteContent(string elementId)
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

        public static void AddContent(string elementId, string content, string url = "")
        {
            if (string.IsNullOrWhiteSpace(elementId))
            {
                throw new ArgumentNullException("elementId");
            }
            using (DataModel db = new DataModel())
            {
                var contentToSave = new DataLib.Models.EditableContent();
                contentToSave.ElementId = elementId;
                contentToSave.Content = content;
                contentToSave.View = url;
                //db.Content.AddOrUpdate(c => c.ElementId, contentToSave);
                db.Content.AddOrUpdate(contentToSave);
                db.SaveChanges();
            }
        }

        public static void UpdateContent(string elementId, string content)
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

        public static void UpdateContent(EditableContent content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }
            using (DataModel db = new DataModel())
            {
                var _content = db.Content.Find(content.ElementId);
                if (_content == null)
                {
                    throw new Exception($"Nothing to update. Could not find id: {content.ElementId}");
                }
                _content.Content = content.Content;
                _content.View = content.View;
                db.SaveChanges();
            }
        }
    }
}
