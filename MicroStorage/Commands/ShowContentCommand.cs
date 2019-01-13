using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    internal class ShowContentCommand : CommandBase
    {
        internal override void Invoke()
        {
            switch (LocalScopeManager.Current.Scope.Type)
            {
                case ScopeType.Enviroment:
                    this.ShowCategories();
                    break;
                case ScopeType.Category:
                    this.ShowEntries();
                    break;
                case ScopeType.Entry:
                    this.ShowContent();
                    break;
                default:
                    throw new InvalidScopeException();
            }

            this._isSuccessfull = true;
        }

        private void ShowEntries()
        {
            Entry[] eList = DataManager.GetCategoryByName(LocalScopeManager.Current.Scope.Name).Items;

            if (eList == null || eList.Length == 0)
                throw new EntryNotFoundException();

            List<string> strList = new List<string>();
            foreach (Entry item in eList)
                strList.Add(item.EntryName);

            if (strList.Count > 0)
                ManShell.BusinessObjects.Globals.ListToOutput = strList;
        }

        private void ShowCategories()
        {
            Category[] catList = DataManager.Data.Categories;

            if (catList == null || catList.Length == 0)
                throw new CategoryNotFoundException();

            List<string> strList = new List<string>();
            foreach (Category item in catList)
                strList.Add(item.CategoryName);

            if (strList.Count > 0)
                ManShell.BusinessObjects.Globals.ListToOutput = strList;
        }

        private void ShowContent()
        {
            string entryName = LocalScopeManager.Current.Scope.Name;
            Entry entry = DataManager.GetEntryByName(entryName);

            if (entry != null)
                ManShell.BusinessObjects.Globals.ToOutput = entry.EntryData;
        }
    }
}
