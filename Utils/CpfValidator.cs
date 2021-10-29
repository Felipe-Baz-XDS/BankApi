using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Utils
{
    public class CpfValidator
    {
        public bool cpfValidator(string cpf)
        {
            string[] cpf_ = cpf.Split(new char[] {'.','-'});
            List<int> cpf_num = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                int num = int.Parse(cpf_[i]);
                cpf_num.Add(num/100);
                cpf_num.Add((num-(num/100)*100)/10);
                cpf_num.Add(num-(num/10)*10);
            }
            int num_dig = int.Parse(cpf_[3]);
            cpf_num.Add(num_dig/10);
            cpf_num.Add(num_dig-((num_dig/10)*10));
            //first digit
            int sum = 0;
            for (int i = 10; i > 1; i--)
            {
                sum += cpf_num[10-i]*i;
            }
            int resto = sum % 11;
            if (resto < 2)
            {
                if (cpf_num[9] != 0 || cpf_num[9] != (11-resto))
                {
                    return false;
                }
            }
            sum = 0;
            for (int i = 11; i > 1; i--)
            {
                sum += cpf_num[11-i]*i;
            }
            resto = sum % 11;
            if (resto < 2)
            {
                if (cpf_num[9] != 0 || cpf_num[9] != (11-resto))
                {
                    return false;
                }
            }
            return true;
        }
    }
}