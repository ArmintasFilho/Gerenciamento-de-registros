using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciamento_de_registros
{
    public static class Validacoes
    {
        public static bool EmailValido(string email) {
            try
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@gmail+\.com$";
                return Regex.IsMatch(email, pattern);
            }
            catch{ return false; }
        }

        public static void NaoPermitirNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        public static bool NomeValido(string nome)
        {
            if (nome.Count() > 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TelefoneValido(string telefone)
        {
            string pattern = @"^\([1-9]{2}\) [0-9]{5}-[0-9]{4}$";
            return Regex.IsMatch(telefone, pattern);
        }
    }
}
