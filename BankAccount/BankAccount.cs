using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioBancaria
{
    public class BankAccount
    {
        private static int BANK_ID = 21;
        private static string BANK_NAME = "TIMOBANK";
        private static double MAX_INT_RATE = 0.02;
        private string accountNumber;
        private string holderName;
        private string holderSurname;
        private double balance;
        private bool locked = false;
        private DateTime openingDate;
        private DateTime ?closingDate=null;
        private DateTime? lastNegativeBalanceDate;

        public BankAccount(String numCC, string holderN, string holderSN)
            :this(numCC, holderN, holderSN, 0)
        { 
            
        }

        public BankAccount(string numCC, string holderN, string holderSN, double saldoInicial) 
        {
            if (saldoInicial < 0) throw new Exception("NO ES POT FER UN CC AMB SALDO NEGATIU");
            this.holderName = holderN;
            this.holderSurname = holderSN;
            this.balance = saldoInicial;
            this.accountNumber = numCC;
            this.locked = false;
            this.openingDate = DateTime.Now;
        }

        public void Donacio(double amount)
        {
            balance = balance + amount;
        }

        #region propietats

        //Al contrari dels metoddes anteriors les propietats no utilitzaen els parentesis.
        public string NumeroDeCompte
        {
            get { return BankAccount.BANK_ID +  this.accountNumber; }
            set
            {
                this.accountNumber = value;
            }

        }

        #endregion

        #region overrides

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("NUM C.C-->" + NumeroDeCompte);
            sb.Append("\n");
            sb.Append($"TITULAR --> {this.holderSurname}, {this.holderName}");
            sb.Append("\n");
            sb.Append($"SALDO = {Math.Round(balance,2)}");
            if (this.locked)
            {
                sb.Append("\n");
                sb.Append("COMPTE BLOQUEJAT");
            }
            return sb.ToString();
        }

        #endregion
    }
}
