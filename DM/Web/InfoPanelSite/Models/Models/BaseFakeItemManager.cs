using System;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace InfoPanelModels.Models
{
    public class BaseFakeItemManager<T> where T : BaseFakeItem, new()
    {
        protected MobileServiceClient client;

        protected IMobileServiceTable<T> todoTable;

        protected const string offlineDbPath = @"localstore.db";

        protected BaseFakeItemManager()
        {
            this.client = new MobileServiceClient(DMSettings.Services.InfoPanelUrl);
            this.todoTable = client.GetTable<T>();
        }

        protected virtual bool CheckValues(IDictionary newValues)
        {
            if (newValues == null)
                return false;

            return true;
        }

        public async void InsertItem(System.Collections.IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            var item = new T();

            if (item.HasFake())
                return;

            UpdateItemBody(item, newValues);

            await todoTable.InsertAsync(item);
        }

        public async void DeleteItem(System.Collections.IDictionary keys)
        {
            var item = await FindItem(keys["Id"].ToString());
            if (item.HasFake())
                return;

            await todoTable.DeleteAsync(item);
        }

        public async void UpdateItem(System.Collections.IDictionary keys, System.Collections.IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            var item = (T)await FindItem(keys["Id"].ToString());

            if (item.HasFake())
                return;

            UpdateItemBody(item, newValues);            

            await todoTable.UpdateAsync(item);
        }

        protected virtual void UpdateItemBody(T item, IDictionary newValues)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindItem(string id)
        {
            return await todoTable.LookupAsync(id);
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public virtual async Task<ObservableCollection<T>> GetAllItemsAsync(bool syncItems = false)
        {
            try
            {
                var filteredByFake = await todoTable.Where(c => c.Fake == FakeManger.Instance.IsFake).ToListAsync();
                return new ObservableCollection<T>(filteredByFake);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }
    }
}
