using System;
using Project.Entities;
using Project.Interfaces;

namespace Project.Services
{
    class ContractService
    {
        private IPayment _payment;

        public ContractService(IPayment payment)
        {
            _payment = payment;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;

            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updateQuota = basicQuota + _payment.MonthlyInterest(basicQuota, i);
                double fullQuota = updateQuota + _payment.Tax(updateQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}