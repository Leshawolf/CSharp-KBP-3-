using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML0802
{
    public class BankAccount
    {
        private int numberAccount;
        private string ownerFio;
        private double sumAccount;
        private DateTime openDataAccount;
        private double accrualPercentage;

        public BankAccount(int numberAccount, string ownerFIO, double sumAccount, DateTime openDataAccount, double accrualPercentage)
        {
            NumberAccount = numberAccount;
            OwnerFio = ownerFIO;
            SumAccount = sumAccount;
            OpenDataAccount = openDataAccount;
            AccrualPercentage = accrualPercentage;
        }
        public BankAccount() { }
        public int NumberAccount 
        {
            get => numberAccount;
            set
            {
                if(value <=-1)
                {
                    throw new NullArgumentException("Вы не ввели номер аккаунта.");
                }
                else
                {
                    numberAccount = value;
                }
            }
        }
        public string OwnerFio 
        {
            get => ownerFio;
            set 
            {
                if(value != "")
                {
                    ownerFio = value;
                }
                else
                {
                    throw new NullArgumentException("Вы не ввели ФИО пользователя.");
                }
            }
        }
        public double SumAccount {
            get => sumAccount;
            set 
            {
                if(value <=0) throw new NullArgumentException("Вы не ввели сумму."); 
                else { sumAccount = value; }
            }
        }
        public DateTime OpenDataAccount { 
            get=>openDataAccount; 
            set
            {
                if (value.Month <=0 || value.Month >= 13)
                    throw new NullArgumentException("Ошибка в месяце");
                else { openDataAccount = value;  }
            }
        }
        public double AccrualPercentage 
        { 
            get=>accrualPercentage;
            set
            {
                if (value <= 0)
                    throw new NullArgumentException("Вы не ввели процент.");
                else { accrualPercentage = value;  }
            }
        }
      
        public override string ToString()
        {
            return $"\tНомер аккаунта: {numberAccount}\n Дата создания счёта: {openDataAccount.ToShortDateString()}\n Имя пользователя: {ownerFio}\n На счету: {sumAccount} рублей\n Процент начисления: {accrualPercentage}\n\tБОЛЬШЕ ИНФОРМАЦИИ НЕТУ\n";
        }
    }
}
