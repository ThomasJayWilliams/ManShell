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
            }

            this._isSuccessfull = true;
        }

        private void ShowEntries()
        {
            Category temp = DataManager.GetCategoryByName(LocalScopeManager.Current.Scope.Name);
            Entry[] eList;

            if (temp != null && temp.Items != null && temp.Items.Length > 0)
                eList = temp.Items;
            else
                throw new EntryNotFoundException("No entries have been found!");

            List<string> strList = new List<string>();
            foreach (Entry item in eList)
                strList.Add(item.EntryName);

            if (strList.Count > 0)
                ManShell.BusinessObjects.Application.Globals.ListToOutput = strList;
        }

        private void ShowCategories()
        {
            Category[] catList = DataManager.Data.Categories;

            if (catList == null || catList.Length == 0)
                throw new CategoryNotFoundException("No categories have been found!");

            List<string> strList = new List<string>();
            foreach (Category item in catList)
                strList.Add(item.CategoryName);

            if (strList.Count > 0)
                ManShell.BusinessObjects.Application.Globals.ListToOutput = strList;
        }

        private void ShowContent()
        {
            string entryName = LocalScopeManager.Current.Scope.Name;

            if (string.IsNullOrEmpty(entryName))
                throw new InvalidCommandException("Error occured while showing content for specified entry!");

            Entry entry = DataManager.GetEntryByName(entryName);

            if (entry == null)
                throw new InvalidCommandException("Error occured while showing content for specified entry!");

            ManShell.BusinessObjects.Application.Globals.ToOutput = entry.EntryData;
        }
    }
}
