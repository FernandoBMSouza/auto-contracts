using Project.Interfaces;

namespace Project.Services
{
    class PayPalPaymentService : IPayment
    {
        public double MonthlyInterest(double amount, int month)
        {
            return amount * 0.01 * month;
        }

        public double Tax(double amount)
        {
            return amount * 0.02;
        }
    }
}