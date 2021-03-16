using System;
using static ExternalDependency.CreditDecision;

namespace ExternalDependency
{
  

    public class CreditDecisionService  
    {
        public CreditDecisionService()
        {
        }

        public string GetCreditDecision(int creditScore)
        {
            //Can have code which can talk to db,web api or some service

            return "Soemthing";
        }

        public void sendMail()
        {
            //Do Something
        }
    }
}