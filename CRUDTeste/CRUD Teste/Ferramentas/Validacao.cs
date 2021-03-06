using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Ferramentas
{
    public class Validacao
    {
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0, resto = 0;
            string tempCpf = "", digito = "";

            try
            {
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "");

                if (cpf.Length != 11)
                {
                    return false;
                }
                else
                {
                    tempCpf = cpf.Substring(0, 9);

                    soma = 0;

                    for (int i = 0; i < 9; i++)
                    {
                        soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                    }

                    resto = soma % 11;

                    if (resto < 2)
                    {
                        resto = 0;
                    }
                    else
                    {
                        resto = 11 - resto;
                    }

                    digito = resto.ToString();
                    tempCpf = tempCpf + digito;

                    soma = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                    }

                    resto = soma % 11;

                    if (resto < 2)
                    {
                        resto = 0;
                    }
                    else
                    {
                        resto = 11 - resto;
                    }

                    digito = digito + resto.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cpf.EndsWith(digito);
        }


        public static bool ValidaEmail(string email)
        {
            bool ValidEmail = false;
            int indexArr = email.IndexOf("@");

            try
            {
                if (email.Trim().Length != 0)
                {
                    if (indexArr > 0)
                    {
                        if (email.IndexOf("@", indexArr + 1) > 0)
                        {
                            return ValidEmail;
                        }

                        int indexDot = email.IndexOf(".", indexArr);
                        if (indexDot - 1 > indexArr)
                        {
                            if (indexDot + 1 < email.Length)
                            {
                                string indexDot2 = email.Substring(indexDot + 1, 1);
                                if (indexDot2 != ".")
                                {
                                    ValidEmail = true;
                                }
                            }
                        }
                    }
                    return ValidEmail;
                }
                else
                {
                    return ValidEmail = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static string MensagemErro()
        {
            string mensagem = "\t\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20\x20 Ops! Houve um erro! \n\n\x20\x20\x20\x20\x20\x20\x20\x20 Favor informar à equipe de desenvolvimento pelo seguinte email: \n\t\t\x20\x20\x20\x20\x20 marcoservio22@hotmail.com \n\n\t\t\x20\x20\x20\x20\x20\x20 Agradecemos sua paciência!";

            return mensagem;
        }


        public static string MensagemErroSQL()
        {
            string mensagem = "\t\x20\x20\x20 Ops! Houve um erro ao conectar no banco de dados! \n\n\x20\x20\x20\x20\x20\x20\x20\x20 Favor informar à equipe de desenvolvimento pelo seguinte email: \n\t\t\x20\x20\x20\x20\x20 marcoservio22@hotmail.com \n\n\t\t\x20\x20\x20\x20\x20\x20 Agradecemos sua paciência!";

            return mensagem;
        }
    }
}
