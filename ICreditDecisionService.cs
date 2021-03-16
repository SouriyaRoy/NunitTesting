using System;

namespace Day1
{
    public interface ICreditDecisionService
    {
        int GetCreditDecision(int creditScore);

        void SendMail();
    }


    public class CreditRepo : ICreditDecisionService
    {
        public int GetCreditDecision(int creditScore)
        {
            return 6700;
        }

        public void SendMail()
        {
            
        }
    }
}