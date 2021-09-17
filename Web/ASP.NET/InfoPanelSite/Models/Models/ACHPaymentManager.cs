using InfoPanelModels.Common;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace InfoPanelModels.Models
{
    public partial class ACHPaymentManager : BaseFakeItemManager<ACHPayment>
    {
        //        readonly MobileServiceClient client = new MobileServiceClient(Constants.ACHPaymentServiceURL);

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["MemberSenderId"] == null
                || newValues["MemberBeneficiaryId"] == null
                || newValues["PaymentDate"] == null
                    || newValues["Amount"] == null
                || newValues["CurrencyId"] == null)
                return false;

            return true;
        }

        public static ACHPaymentManager DefaultManager { get; private set; } = new ACHPaymentManager();

        protected override void UpdateItemBody(ACHPayment item, IDictionary newValues)
        {
            return;
        }

        public void SendPayment(System.Collections.IDictionary newValues)
        {
            Task.Run(async () =>
            {
                try
                {
                    Dictionary<string, string> parameters = ConvertParams(newValues);

                    try
                    {
                        var client = new MobileServiceClient(DMSettings.Services.ACHPaymentUrl);
                        var sendRes = await client.InvokeApiAsync<bool>("AppendPaymentApi", System.Net.Http.HttpMethod.Get, parameters);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }).Wait();
        }

        private static Dictionary<string, string> ConvertParams(IDictionary newValues)
        {
            return new Dictionary<string, string> {
                    { "amount", Convert.ToString(newValues["Amount"], CultureInfo.InvariantCulture) },
                    { "currencyId", newValues["CurrencyId"]?.ToString() },
                    { "memberBeneficiaryId", newValues["MemberBeneficiaryId"]?.ToString() },
                    { "memberSenderId", newValues["MemberSenderId"]?.ToString() },
                    { "paymentDate", Convert.ToString(newValues["PaymentDate"], CultureInfo.InvariantCulture) },
                };
        }
    }
}
