using ManShell.BusinessObjects;
using System.Collections.Generic;
using System.Linq;

namespace MicroStorage
{
	internal class DeleteCommand : CommandBase
    {
        internal DeleteCommand(string argument)
        {
            if (string.IsNullOrEmpty(argument) && LocalScopeManager.Current.Scope.Type != ScopeType.Entry)
                throw new NoCommandArgumentException("Argument is required for this command!");

            this.argument = argument;
        }

        internal override void Invoke()
        {
            ScopeType type = LocalScopeManager.Current.Scope.Type;

            if (type == ScopeType.Enviroment)
            {
                if (DataManager.Data.Categories != null && DataManager.Data.Categories.Length > 0)
                {
                    if (this.argument == "all")
                        DataManager.Data.Categories = new Category[0];

                    else
                    {
                        List<Category> cats = DataManager.Data.Categories.ToList<Category>();
                        Category category = DataManager.GetCategoryByName(this.argument);

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

                    if (this.argument == "all")
                        cat.Items = new Entry[0];

                    else if (cat.Items != null && cat.Items.Length > 0)
                    {
                        List<Entry> entries = cat.Items.ToList<Entry>();
                        Entry entry = DataManager.GetEntryByName(this.argument);

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

                if (entry != null && string.IsNullOrEmpty(this.argument))
                    entry.EntryData = string.Empty;

                else
                    throw new EntryNotFoundException("Error occured while deleting entry content!");
            }

            DataManager.ParseToJSON();
            FileManager.Save(DataManager.JSON);

            this.isSuccessfull = true;
        }
    }
}
