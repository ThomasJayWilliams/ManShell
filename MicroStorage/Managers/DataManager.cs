using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MicroStorage
{
    public static class DataManager
    {
        private static JSONDataModel _data;
        private static string _json;

        public static string JSON
        {
            get
            {
                if (_json == null)
                    _json = string.Empty;
                return _json;
            }
        }

        public static JSONDataModel Data
        {
            get
            {
                if (_data == null)
                    _data = new JSONDataModel();
                return _data;
            }
        }

        public static void Load(string data)
        {
            _data = new JSONDataModel();

            _json = data;
            ParseToData();
        }

        public static void ParseToData()
        {
            if (!string.IsNullOrEmpty(_json))
                _data = JsonConvert.DeserializeObject<JSONDataModel>(_json);
        }

        public static void ParseToJSON()
        {
            if (_data != null)
                _json = JsonConvert.SerializeObject(_data);
        }

        public static void AddCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
                throw new ArgumentNullException();

            if (IsElementExist(categoryName))
                throw new DuplicateInsertingException();

            Category category = new Category()
            {
                CategoryName = categoryName
            };

            List<Category> tempList = _data.Categories.ToList<Category>();
            tempList.Add(category);
            _data.Categories = tempList.ToArray<Category>();
        }

        public static void AddContent(string entryName, string content)
        {
            if (string.IsNullOrEmpty(entryName) || string.IsNullOrEmpty(content))
                throw new ArgumentNullException();

            if (!IsElementExist(entryName))
                throw new EntryNotFoundException();

            Entry entry = GetEntryByName(entryName);
            entry.EntryData = content;
        }

        public static void AddEntry(string categoryName, string entryName)
        {
            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(entryName))
                throw new ArgumentNullException();

            if (IsElementExist(entryName))
                throw new DuplicateInsertingException();

            if (!IsElementExist(categoryName))
                throw new CategoryNotFoundException();

            Entry entry = new Entry()
            {
                EntryName = entryName
            };

            Category category = _data.Categories.ToList<Category>().Find(c => c.CategoryName == categoryName);
            List<Entry> items = category.Items.ToList<Entry>();
            items.Add(entry);
            category.Items = items.ToArray<Entry>();
        }

        public static Entry GetEntryByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            Entry entry = new Entry();
            Category category = new Category();
            category = GetCategoryByEntryName(name);

            if (category == null)
                return null;

            entry = category.Items.ToList<Entry>().Find(e => string.CompareOrdinal(e.EntryName, name) == 0);

            return entry;
        }

        public static Category GetCategoryByEntryName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            Category category = new Category();

            category = _data.Categories
                .ToList<Category>()
                    .Find(c => c.Items.ToList<Entry>().Find(e => string.CompareOrdinal(e.EntryName, name) == 0) != null);

            return category;
        }

        public static Category GetCategoryByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            Category category = new Category();
            category = _data.Categories.ToList<Category>().Find(c => string.CompareOrdinal(c.CategoryName, name) == 0);

            return category;
        }

        public static bool GetTypeByName(string element, ref ScopeType type)
        {
            if (string.IsNullOrEmpty(element))
                throw new ArgumentNullException();

            if (!IsElementExist(element))
                return false;

            if (GetEntryByName(element) != null)
            {
                type = ScopeType.Entry;
                return true;
            }

            if (GetCategoryByName(element) != null)
            {
                type = ScopeType.Category;
                return true;
            }

            return false;
        }

        internal static bool IsElementExist(string name)
        {
            bool result = false;

            if (GetEntryByName(name) != null ^ GetCategoryByName(name) != null)
                result = true;

            return result;
        }
    }

    public class JSONDataModel
    {
        public Category[] Categories { get; set; }

        public JSONDataModel() { this.Categories = new Category[0]; }
    }

    public class Entry
    {
        public string EntryName { get; set; }
        public string EntryData { get; set; }
    }

    public class Category
    {
        public string CategoryName { get; set; }
        public Entry[] Items { get; set; }

        public Category() { this.Items = new Entry[0]; }
    }
}
