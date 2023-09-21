using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AjudanteDBA
{
    public static class App
    {
        public static Version AppVersion { get; private set; }
        internal static void Initialize()
        {
            try
            {
                AppVersion = Assembly.GetEntryAssembly().GetName().Version;
                //Logger.Initialize(Versao.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inicializar a aplicação.", ex);
            }
        }
    }
}
