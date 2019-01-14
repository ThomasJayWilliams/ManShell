using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    internal class DeleteCommand : CommandBase
    {
        internal DeleteCommand(string argument)
        {
            if (string.IsNullOrEmpty(argument))
                throw new ArgumentNullException("argument", "Argument is required for this command!");

            this._argument = argument;
        }

        internal override void Invoke()
        {
            if (string.IsNullOrEmpty(this._argument) && LocalScopeManager.Current.Scope.Type != ScopeType.Entry)
                throw new NoCommandArgumentException();

            ScopeType type = LocalScopeManager.Current.Scope.Type;

            if (type == ScopeType.Enviroment)
            {
                if (DataManager.Data.Categories != null && DataManager.Data.Categories.Length > 0)
                {
                    if (this._argument == "all")
                        DataManager.Data.Categories = new Category[0];

                    else
                    {
                        List<Category> cats = DataManager.Data.Categories.ToList<Category>();
                        Category category = DataManager.GetCategoryByName(this._argument);

                        if (category != null)
                            cats.Remove(category);

                        DataManager.Data.Categories = cats.ToArray<Category>();
                    }
                }

                else
                    throw new CategoryNotFoundException("No categories found! Use 'add' command to add new category.");
            }

            else if (type == ScopeType.Category)
            {
                if (DataManager.GetCategoryByName(LocalScopeManager.Current.Scope.Name) != null)
                {
                    Category cat = DataManager.GetCategoryByName(LocalScopeManager.Current.Scope.Name);

                    if (this._argument == "all")
                        cat.Items = new Entry[0];

                    else if (cat.Items != null && cat.Items.Length > 0)
                    {
                        List<Entry> entries = cat.Items.ToList<Entry>();
                        Entry entry = DataManager.GetEntryByName(this._argument);

                        if (entry != null)
                            entries.Remove(entry);

                        else
                            throw new EntryNotFoundException();

                        cat.Items = entries.ToArray<Entry>();
                    }
                }

                else
                    throw new CategoryNotFoundException();
            }

            else if (type == ScopeType.Entry)
            {
                Entry entry = DataManager.GetEntryByName(LocalScopeManager.Current.Scope.Name);

                if (entry != null && string.IsNullOrEmpty(this._argument))
                    entry.EntryData = string.Empty;

                else
                    throw new EntryNotFoundException("Error occured while deleting entry content!");
            }

            DataManager.ParseToJSON();
            FileManager.Save(DataManager.JSON);

            this._isSuccessfull = true;
        }
    }
}
