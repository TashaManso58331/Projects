using InfoPanelModels.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetFuelBuyerMembersAsyncTest()
        {
            var buyers = Task.Run(async() => await MemberManager.DefaultManager.GetFuelBuyerMembersAsync()).Result;
            Assert.IsNotEmpty(buyers);
        }

        [Test]
        public void ACHBalancesAsyncTest()
        {
            var buyers = Task.Run(async () => await ACHBalanceManager.DefaultManager.GetAllItemsAsync()).Result;
            Assert.IsNotEmpty(buyers);
        }
        [Test]
        public void AllMembersAsyncTest()
        {
            var allMembers = Task.Run(async () => await MemberManager.DefaultManager.GetAllItemsAsync()).Result;
            Assert.IsNotEmpty(allMembers);
        }
        [Test]
        public void SendPaymentTest()
        {
            var newValues = new Dictionary<string, object>{
                { "Amount", 100},
                { "CurrencyId", "8d67c5b2e9264f518ae5ff121a71841c"},
                { "MemberBeneficiaryId", "b3afc85e-4ea0-4810-8a39-c5d8beec1535"},
                { "MemberSenderId", "994f7811-29ce-4128-b495-b6cf8074a461"},
                { "PaymentDate", DateTime.Now}
            };
            ACHPaymentManager.DefaultManager.SendPayment(newValues);
        }       
    }
}