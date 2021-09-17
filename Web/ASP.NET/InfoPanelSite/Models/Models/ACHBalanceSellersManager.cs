using System.Collections;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace InfoPanelModels.Models
{
    public partial class ACHBalanceSellersManager : BaseFakeItemManager<ACHBalance>
    {
        protected override void UpdateItemBody(ACHBalance item, IDictionary newValues)
        {
            return;
        }

        public static ACHBalanceSellersManager DefaultManager { get; private set; } = new ACHBalanceSellersManager();

        public override async Task<ObservableCollection<ACHBalance>> GetAllItemsAsync(bool syncItems = false)
        {
            var rows = await this.todoTable
                .Where(c=> c.Fake == FakeManger.Instance.IsFake)
                .ToListAsync();
            var result = rows
                .GroupBy(c => c.MemberBeneficiaryId)
                .Select(c => new ACHBalance{ MemberBeneficiaryId = c.Select(d => d.MemberBeneficiaryId).FirstOrDefault(), Amount = c.Sum(d => d.Amount), Id = Guid.NewGuid().ToString() })
                .ToList();

            return new ObservableCollection<ACHBalance>(result);
        }
    }
}
