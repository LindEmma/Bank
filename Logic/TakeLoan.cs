using Bank.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Logic
{
    public class TakeLoan
    {
        private decimal LoanAmount;
        private string LoanPurpose;
        private int LoanDurationMonths;

        public TakeLoan(decimal loanAmount, string loanPurpose, int loanDurationMonths)
        {
            LoanAmount = loanAmount;
            LoanPurpose = loanPurpose;
            LoanDurationMonths = loanDurationMonths;
        }

    }
   



}
