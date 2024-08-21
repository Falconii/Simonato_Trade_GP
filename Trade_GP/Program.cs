using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.DataBase;

namespace Trade_GP
{
    static class Program
    {
     
            /// <summary>
            /// Ponto de entrada principal para o aplicativo.
            /// </summary>
            [STAThread]
            static void Main(string[] args)
            {
                if (args.Length == 0)
                {
                    RunCommand.SetarBanco("SERVIDOR");
                }
                else
                {
                    RunCommand.SetarBanco(args[0]);
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);


                FormLogin Login = null;

                Login = new FormLogin();

                if (Login.ShowDialog() == DialogResult.OK)
                {
                    Util.UsuarioSistema.Usuario = Login.usuario;

                    Util.UsuarioSistema.Id_Grupo = Login.Id_Grupo;

                    Application.Run(MDISingleton.MDIParentPrincipal());

                }

            }
        }
    }
