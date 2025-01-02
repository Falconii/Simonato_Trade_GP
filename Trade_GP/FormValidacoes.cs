using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Dao.postgre;
using Trade_GP.Util;
using Trade_GP.Extensoes;

namespace Trade_GP
{
    public partial class FormValidacoes : Form
    {
        private List<ParamLocal> Parametros = new List<ParamLocal>();

        private List<GridLocais> lsLocais = new List<GridLocais>();

        private List<tarefa> lsTarefas = new List<tarefa>();

        private List<meses> lsMeses = new List<meses>();

        private Boolean btProximoFlag = false;

        private string Cod_Emp = "";

        private string Local = "";

        private Boolean Cancelar = false;

        public ToolStripMenuItem menu { get; internal set; }
        public FormValidacoes()
        {
            InitializeComponent();
        }

        private void FormValidacoes_Load(object sender, EventArgs e)
        {
            btProximoFlag = false;

            status_inical();
        }

        private void FormValidacoes_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormValidacoes_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private void LoadDbGridLocais()
        {

            lsLocais.Clear();

            foreach (var param in Parametros)
            {
                GridLocais grid = new GridLocais();

                grid.Cod_Emp = param.Cod_Emp;
                grid.Local = param.Local;
                grid.Razao = param.Razao;
                grid.Obs = "";

                lsLocais.Add(grid);

            }

            var bindingList = new BindingList<GridLocais>(lsLocais);

            var source = new BindingSource(bindingList, null);

            dbLocais.DataSource = source;

            ConfiguraDbLocais();

        }
        private void ConfiguraDbLocais()
        {
            dbLocais.AutoResizeColumns();
            dbLocais.Columns[00].HeaderText = "Empresa";
            dbLocais.Columns[00].Width = 60;
            dbLocais.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbLocais.Columns[01].HeaderText = "Local";
            dbLocais.Columns[01].Width = 50;
            dbLocais.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbLocais.Columns[02].HeaderText = "Razao";
            dbLocais.Columns[02].Width = 300;
            dbLocais.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbLocais.Columns[03].HeaderText = "Observacao";
            dbLocais.Columns[03].Width = 300;

            dbLocais.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dbLocais.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbLocais.BorderStyle = BorderStyle.Fixed3D;
            dbLocais.EnableHeadersVisualStyles = false;
            dbLocais.ShowEditingIcon = false;

        }
        private void PosicaoInicial()
        {
            btProximo.Enabled = btProximoFlag;
            lblLocalPeriodo.Text = "";
        }
        private void btParametros_Click(object sender, EventArgs e)
        {
            var parametros = new FormParametros("3");

            var Result = parametros.ShowDialog();

            if (Result == DialogResult.OK)
            {

                Parametros = parametros.Parametros;

                btProximoFlag = true;

                PosicaoInicial();
            }
            else
            {

                btProximoFlag = false;

                PosicaoInicial();
            }

            parametros.Dispose();
        }
        private void ConfiguraDbGridLog()
        {
            dtGridLog.AutoResizeColumns();
            dtGridLog.Columns[00].HeaderText = "Seq";
            dtGridLog.Columns[00].Width = 50;
            dtGridLog.Columns[01].HeaderText = "Data";
            dtGridLog.Columns[01].Width = 120;
            dtGridLog.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtGridLog.Columns[02].HeaderText = "Inicio";
            dtGridLog.Columns[02].Width = 120;
            dtGridLog.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[03].HeaderText = "Final";
            dtGridLog.Columns[03].Width = 120;
            dtGridLog.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[04].HeaderText = "Observação";
            dtGridLog.Columns[04].Width = 190;
            dtGridLog.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtGridLog.Columns[05].HeaderText = "Status";
            dtGridLog.Columns[05].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtGridLog.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dtGridLog.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.BorderStyle = BorderStyle.Fixed3D;
            dtGridLog.EnableHeadersVisualStyles = false;
            dtGridLog.ShowEditingIcon = false;

            dtGridLog.CellFormatting += new DataGridViewCellFormattingEventHandler(dtGridLog_FormatarData);


        }
        private void dtGridLog_FormatarData(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtGridLog.Columns[e.ColumnIndex].Name.Equals("Inicial") || dtGridLog.Columns[e.ColumnIndex].Name.Equals("Final"))
            {
                if (e.Value == null || e.Value.GetType().Name == "String") return;
                String stringValue = ((DateTime)e.Value).ToString("dd-MM-yyyy hh:mm:ss");
                e.Value = stringValue;
            }
        }

        private void LoadDbMeses()
        {

            var bindingList = new BindingList<meses>(lsMeses);

            var source = new BindingSource(bindingList, null);

            dbMeses.DataSource = source;

            ConfiguraDbMeses();

        }
        private void ConfiguraDbMeses()
        {
            dbMeses.AutoResizeColumns();
            dbMeses.Columns[00].HeaderText = "Seq";
            dbMeses.Columns[00].Width = 50;
            dbMeses.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbMeses.Columns[01].HeaderText = "Mês E Ano";
            dbMeses.Columns[01].Width = 80;
            dbMeses.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbMeses.Columns[02].HeaderText = "Notas";
            dbMeses.Columns[02].Width = 80;
            dbMeses.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbMeses.Columns[03].HeaderText = "Status";
            dbMeses.Columns[03].Width = 100;
            dbMeses.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbMeses.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dbMeses.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbMeses.BorderStyle = BorderStyle.Fixed3D;
            dbMeses.EnableHeadersVisualStyles = false;
            dbMeses.ShowEditingIcon = false;


        }
        private async Task<int> contagem(int id_grupo, string cod_emp, string local)
        {
            int result = 0;

            int i = 0;

            string Periodo = "";

            int _qtd_notas = 0;

            pgProcesso.Value = 0;

            daoNfeDetTrade daoDet = new daoNfeDetTrade();

            foreach (meses mes in lsMeses)
            {


                lblLocalPeriodo.Text = $"Local {local} -  Mês {mes.Mes} ";
                i++;
                lblProcesso.Text = $"Contagem {i}/{lsMeses.Count}";
                //pgProcesso.Value = i;
                mes.Status = "Processando...";

                try
                {

                    _qtd_notas = await daoDet.Processou_Devolucao(UsuarioSistema.Id_Grupo, cod_emp, local, mes.Mes);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }

                mes.Registros = _qtd_notas ;

                mes.Status = _qtd_notas > 0 ? "Aguardando..!" : "Processado..!";

                if (Cancelar)
                {
                    mes.Status = "Processamento Cancelado!";
                }

                LoadDbMeses();

                if (Cancelar) break;

            }


            if (Cancelar)
            {
                while (i < lsMeses.Count)
                {
                    lsMeses[i].Status = "Cancelado !!";
                    i++;
                };
                result = -1;
            }

            i = lsMeses.Count;

            lblProcesso.Text = $"Processando Mês {i}/{lsMeses.Count}";

            //pgProcesso.Value = i;

            return result;
        }
        private void NewTarefas(string periodo)
        {
            int seq = 1;

            string[] mes_ano = periodo.Split('/');

            int ultimoDia = DateTime.DaysInMonth(mes_ano[1].IntParse(), mes_ano[0].IntParse());

            lsTarefas.Clear();

            for (int dia = 1; dia <= ultimoDia; dia++)
            {
                var hoje = new DateTime(mes_ano[1].IntParse(), mes_ano[0].IntParse(), dia);

                tarefa obj = new tarefa()
                {
                    Sequencia = seq,
                    Data = hoje.ToString("dd/MM/yyyy"),
                    Inicial = null,
                    Final = null,
                    Observacao = "",
                    Status = "Aguardando"
                };

                lsTarefas.Add(obj);
                seq++;
            }

            LoadDbGridLog();
        }
        private void LoadDbGridLog()
        {

            var bindingList = new BindingList<tarefa>(lsTarefas);

            var source = new BindingSource(bindingList, null);

            dtGridLog.DataSource = source;

            ConfiguraDbGridLog();

        }
        private class tarefa
        {
            public int Sequencia { get; set; }
            public string Data { get; set; }
            public DateTime? Inicial { get; set; }
            public DateTime? Final { get; set; }
            public string Observacao { get; set; }
            public string Status { get; set; }
        }

        private class meses
        {
            public int Sequencia { get; set; }
            public string Mes { get; set; }
            public int Registros { get; set; }
            public string Status { get; set; }
        }



        private async void btProcessar_Click(object sender, EventArgs e)
        {

            if ((int)btProcessar.Tag == 0) // Processamento
            {
                Cancelar = false;

                lblProcesso.Text = "Locais";
                pgProcesso.Value = 1;
                pgProcesso.Minimum = 0;
                pgProcesso.Maximum = Parametros.Count;

                status_processando();

                int resultado = -1;

                int rowMeses = 0;

                foreach (var par in Parametros)
                {

                    pgProcesso.Value = 1; // rowMeses+1;

                    getMeses();

                    resultado = await contagem(UsuarioSistema.Id_Grupo, par.Cod_Emp, par.Local);

                    if (Cancelar)
                    {
                        /*
                        DialogResult resposta = MessageBox.Show("Processamento Cancelado. Deseja Encerrar O Processamento ?", "Atenção!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (resposta == DialogResult.Yes)
                        {
                            
                            //FechamentoOficial.DtFinal = DateTime.Now;
                            //FechamentoOficial.Status = "1";

                            //daoFechamento dao = new daoFechamento();

                            //dao.Update(FechamentoOficial);
                            


                            
                        }
                        */

                        lblCancelamentoAtivado.Text = "Cancelamento Executado!";

                        status_processado();

                        break;
                    }

                    if (Cancelar)
                    {
                        return;
                    }



                    rowMeses = 0;

                    foreach (var mes in lsMeses)
                    {
                        if (mes.Registros == 0)
                        {
                            mes.Status = "Ignorado!";
                            dbMeses.InvalidateCell(3, rowMeses);
                            rowMeses++;
                            continue;
                        }

                        NewTarefas(mes.Mes);
                                                
                        resultado = await processamento(UsuarioSistema.Id_Grupo, par.Cod_Emp, par.Local);

                        mes.Status = "OK";

                        dbMeses.InvalidateCell(3, rowMeses);

                        rowMeses++;
                    }
                }

                status_processado();

                return;
            }
            if ((int)btProcessar.Tag == 1) // Cancelamento
            {
                DialogResult resposta = MessageBox.Show("Processamento Será Interrompido No Próximo Lote. Concorda ? ", "Atenção!",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resposta == DialogResult.Yes)
                {

                    Cancelar = true;

                    //List<ErrosImportacao> Erros = new List<ErrosImportacao>();
                    //.Add(new ErrosImportacao("ATENÇÃO!", "", "", "", 0, "Cancelamento Solicitado!"));
                    //LoadDbGridErros(Erros, false);

                    status_aguardando_cancelar();
                }
                else
                {

                    Cancelar = false;

                    status_processando();

                }

                return;
            }
            if ((int)btProcessar.Tag == 2) // Voltar Ao Processamento
            {
                Cancelar = false;

                status_processando();

            }

        }
        private async Task<int> processamento(int id_grupo, string cod_emp, string local)
        {
            int i = 0;

            string Periodo = "";

            int _qtd_dev = 0;

            int _qtd_devs = 0;

            //pgProcesso.Value = 0;

            daoNfeDetTrade daoDet = new daoNfeDetTrade();

            foreach (tarefa tar in lsTarefas)
            {


                lblLocalPeriodo.Text = $"Local {local} - Data {tar.Observacao.Trim()} ";
                i++;
                //pgProcesso.Value = i;
                Periodo = tar.Data;
                tar.Inicial = DateTime.Now;
                await Task.Run(async delegate
                {
                    await Task.Delay(300);
                });
                try
                {

                    _qtd_dev = await daoDet.Check_Devolucao(UsuarioSistema.Id_Grupo, cod_emp, local, Periodo);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                try
                {

                    _qtd_devs = await daoDet.Check_Devolucao2(UsuarioSistema.Id_Grupo, cod_emp, local, Periodo);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }

                _qtd_dev += _qtd_devs;

                tar.Final = DateTime.Now;

                TimeSpan tempo = (TimeSpan)(tar.Final - tar.Inicial);

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", tempo.Hours, tempo.Minutes, tempo.Seconds);

                tar.Status = $"Processado {elapsedTime}";

                tar.Observacao = $"N° Devoluções Encontradas {_qtd_dev}.";


                dtGridLog.InvalidateCell(2, i - 1);
                dtGridLog.InvalidateCell(3, i - 1);
                dtGridLog.InvalidateCell(4, i - 1);
                dtGridLog.InvalidateCell(5, i - 1);

                if (Cancelar)
                {
                    tar.Observacao = "Cancelamento Solicitado !";
                }

                if (Cancelar) break;

            }

            if (Cancelar)
            {
                while (i < lsTarefas.Count)
                {
                    lsTarefas[i].Observacao = "Cancelado !!";
                    i++;
                };
            }

            i = lsTarefas.Count;

            lblProcesso.Text = $"Processando Mês {i}/{lsTarefas.Count}";

           // pgProcesso.Value = i;

            return 1;
        }
        private void status_inical()
        {
            gbMensaProcessamento.Visible = false;
            dbMeses.Visible = false;
            lbTituloMeses.Visible = false;
            btExcel.Visible = false;
            dtGridLog.Visible = false;
            dbLocais.Visible = false;
            btProcessar.Enabled = true;
            lblCancelamentoAtivado.Visible = false;
            btProcessar.Tag = 0;
            btProximo.Enabled = btProximoFlag;
        }
        private void status_pre_processamento()
        {
            gbMensaProcessamento.Visible = true;
            lbTituloMeses.Visible = false;
            btExcel.Visible = false;
            dbMeses.Visible = false;
            dtGridLog.Visible = false;
            dbLocais.Visible = true;
            btProcessar.Enabled = true;
            btProcessar.Text = "Processamento";
            btProcessar.Tag = 0;
            lblCancelamentoAtivado.Visible = false;
        }
        private void status_processando()
        {
            gbMensaProcessamento.Visible = true;
            lbTituloMeses.Visible = true;
            btExcel.Visible = true;
            dbMeses.Visible = true;
            dtGridLog.Visible = true;
            dbLocais.Visible = true;
            btProcessar.Text = "Cancelar Processamento";
            btProcessar.Tag = 1;
            lblCancelamentoAtivado.Visible = false;
        }
        private void status_aguardando_cancelar()
        {
            gbMensaProcessamento.Visible = true;
            lbTituloMeses.Visible = true;
            btExcel.Visible = true;
            dbMeses.Visible = true;
            dtGridLog.Visible = true;
            dbLocais.Visible = true;
            btProcessar.Text = "Voltar Ao Processamento";
            btProcessar.Tag = 2;
            lblCancelamentoAtivado.Visible = true;
        }
        private void status_processado()
        {
            btProcessar.Text = "Processamento Encerrado!";
            btProcessar.Enabled = false;
            btProximoFlag = false;
            btProximo.Enabled = true;
            btProcessar.Tag = 0;
            Parametros.Clear();
            status_inical();
        }
        private void btProximo_Click(object sender, EventArgs e)
        {

            btProximoFlag = false;

            LoadDbGridLocais();

            status_pre_processamento();

            //NewTarefas();
        }

        private void getMeses()
        {
            lsMeses.Clear();
            int idx = 1;
            foreach (var periodo in Parametros[0].Periodos)
            {
                meses obj = new meses()
                {
                    Sequencia = idx++,
                    Mes = periodo.Data,
                    Registros = 0,
                    Status = "Aguardando Processamento!"
                };
                lsMeses.Add(obj);
            }
        }
        private void RegistrarProcessamentoEmTxt(string linha, string caminhoArquivo)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(caminhoArquivo, true))
                {
                    sw.WriteLine(linha);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar processamento no arquivo TXT: {ex.Message}");
            }
        }

        private void ConfigurarColunasDataGridView()
        {
            dbLocais.AutoResizeColumns();
            dbLocais.Columns[0].HeaderText = "Empresa";
            dbLocais.Columns[0].Width = 60;
            dbLocais.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbLocais.Columns[1].HeaderText = "Local";
            dbLocais.Columns[1].Width = 50;
            dbLocais.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbLocais.Columns[2].HeaderText = "Razao";
            dbLocais.Columns[2].Width = 300;
            dbLocais.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbLocais.Columns[3].HeaderText = "Observacao";
            dbLocais.Columns[3].Width = 300;
        }

        private async Task<int> ProcessarTarefas(int id_grupo, string cod_emp, string local)
        {
            int i = 0;
            string Periodo = "";
            
            int _qtd_dev = 0;

            daoNfeDetTrade daoDet = new daoNfeDetTrade();
            string caminhoArquivo = "caminho_do_arquivo.txt"; // Defina o caminho do seu arquivo TXT

            ConfigurarColunasDataGridView();

            foreach (tarefa tar in lsTarefas)
            {
                lblLocalPeriodo.Text = $"Local {local} - Data {tar.Observacao.Trim()}";
                i++;
                Periodo = tar.Observacao.Trim();
                tar.Inicial = DateTime.Now;

                await Task.Delay(1000);

                try
                {
                    _qtd_dev = await daoDet.Check_Devolucao(UsuarioSistema.Id_Grupo, cod_emp, local, Periodo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }

                tar.Final = DateTime.Now;
                tar.Status = "Processado !!!";
                tar.Observacao = $"N° Devoluções Encontradas {_qtd_dev}.";

                if (Cancelar)
                {
                    tar.Observacao = "Cancelamento Solicitado !";
                }

                // Registrar a linha processada no arquivo TXT
                string linhaProcessada = $"{cod_emp};{local};{Periodo};{tar.Observacao}";
                RegistrarProcessamentoEmTxt(linhaProcessada, caminhoArquivo);

                LoadDbGridLog();

                if (Cancelar) break;
            }

            if (Cancelar)
            {
                while (i < lsTarefas.Count)
                {
                    lsTarefas[i].Observacao = "Cancelado !!";
                    i++;
                }
            }

            return 1;
        }


    }
}



