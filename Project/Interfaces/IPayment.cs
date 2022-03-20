namespace Project.Interfaces
{
    interface IPayment
    {
        double MonthlyInterest(double amount, int months);
        double Tax(double amount);
    }
}