using Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalDependency
{
    
    public class CreditDecision
    {
    
      
        
        
              

        public string MakeCreditDecision(int creditScore)
        {
            var service = new CreditDecisionService(); // External Dependency
            var result= service.GetCreditDecision(creditScore);//Mock this call

            if (result != null)
            {
                service.sendMail();
                return result;
            }
            else
                throw new InvalidCreditScore();
            
        }

       
    }
}
