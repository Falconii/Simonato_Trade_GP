﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trade_GP.Dao.postgre;
using Trade_GP.Util;

namespace Trade_GP
{
    public partial class FormImplacaoSaldo : Form
    {
        private List<ParamLocal> Parametros = new List<ParamLocal>();

        private List<GridLocais> lsLocais = new List<GridLocais>();

        private List<tarefa> lsTarefas = new List<tarefa>();

        private Boolean btProximoFlag = false;

        private string Cod_Emp = "";

        private string Local = "";

        private Boolean Cancelar = false;

        public ToolStripMenuItem menu { get; internal set; }
        public FormImplacaoSaldo()
        {
            InitializeComponent();
        }

    

        private void FormImplacaoSaldo_Load(object sender, EventArgs e)
        {
            btProximoFlag = false;

            status_inical();
        }

        private void FormImplacaoSaldo_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormImplacaoSaldo_FormClosed(object sender, FormClosedEventArgs e)
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
            var parametros = new FormParametros("1");

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
            dtGridLog.Columns[01].HeaderText = "MÊS E ANO";
            dtGridLog.Columns[01].Width = 400;
            dtGridLog.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtGridLog.Columns[02].HeaderText = "Inicio";
            dtGridLog.Columns[02].Width = 120;
            dtGridLog.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[03].HeaderText = "Final";
            dtGridLog.Columns[03].Width = 120;
            dtGridLog.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridLog.Columns[04].HeaderText = "Observação";
            dtGridLog.Columns[04].Width = 350;
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
        private async Task<int> NewTarefas(ParamLocal param)
        {
            int seq = 0;

            int total = 0;

            int vezes = 0;

            int resto = 0;

            int retorno = 0;

            daoSaldo daosaldo = new daoSaldo();

            lsTarefas.Clear();

            try
            {
                total = await daosaldo.GetContador(1, param.Cod_Emp, param.Local);

            } catch(Exception ex)
            {
                total = 0;
            }

            vezes = total / 300;

            resto = total % 300;

            if (resto > 0)
            {
                vezes++;
            }

            for( seq = 1; seq <= vezes; seq++)
            {
                tarefa obj = new tarefa()
                {
                    Sequencia = seq,
                    Descricao = $"Lote {seq}",
                    Inicial = null,
                    Final = null,
                    Observacao = "",
                    Status = "Aguardando"
                };

                lsTarefas.Add(obj);
            }
 
            try
            {

                LoadDbGridLog();

            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return lsTarefas.Count();
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
            public string Descricao { get; set; }
            public DateTime? Inicial { get; set; }
            public DateTime? Final { get; set; }
            public string Observacao { get; set; }
            public string Status { get; set; }
        }
        private async void btProcessar_Click(object sender, EventArgs e)
        {

            if ((int)btProcessar.Tag == 0) // Processamento
            {
                DateTime tempoInicial = DateTime.Now;

                Cancelar = false;
                
                status_processando();

                int resultado = -1;

                int Nro_Locais = 0;

                lblProcesso.Text = "Processando Local";
                pgProcesso.Value = 1;
                pgProcesso.Minimum = 0;
                pgProcesso.Maximum = this.Parametros.Count();

                foreach (var par in Parametros)
                {
                    Nro_Locais++;

                    pgProcesso.Value = Nro_Locais;

                    int NroTarefas = await NewTarefas(par);

                    if (NroTarefas == 0)
                    {
                        continue;
                    }

                    resultado = await processamento(UsuarioSistema.Id_Grupo, par.Cod_Emp, par.Local);

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

                    await pausaAsync();

                }

                status_processado();


                DateTime tempoFinal = DateTime.Now;

                TimeSpan tempo = (TimeSpan)(tempoFinal - tempoInicial);

                string tempoDecorrido = String.Format("{0:00}:{1:00}:{2:00}", tempo.Hours, tempo.Minutes, tempo.Seconds);

                MessageBox.Show($"Tempo Decorrido Total : {tempoDecorrido}");


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

            int _qtd_saldos = 0;

            daoSaldo daosaldo = new daoSaldo();

            foreach (tarefa tar in lsTarefas)
            {

                lblLocalPeriodo.Text = $"Local {local} - Lote {tar.Sequencia} ";
                i++;
                Periodo = tar.Descricao.Trim();
                tar.Inicial = DateTime.Now;
                await Task.Run(async delegate
                {
                    await Task.Delay(300);
                });
                try
                {
                    _qtd_saldos = await daosaldo.calculo_saldo_inicial(UsuarioSistema.Id_Grupo, cod_emp, local);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }

                tar.Final = DateTime.Now;

                TimeSpan tempo = (TimeSpan)(tar.Final - tar.Inicial);

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", tempo.Hours, tempo.Minutes, tempo.Seconds);

                tar.Status = $"Processado! {elapsedTime}";

                tar.Observacao = $"N° Produtos Processados {_qtd_saldos}.";

                if (Cancelar)
                {
                    tar.Observacao = "Cancelamento Solicitado !";
                }
                if (i > 0)
                {
                   
                    dtGridLog.InvalidateCell(2, i-1);
                    dtGridLog.InvalidateCell(3, i-1);
                    dtGridLog.InvalidateCell(4, i-1);
                    dtGridLog.InvalidateCell(5, i-1);
                    
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

            lblProcesso.Text = $"Processando Lote {i}/{lsTarefas.Count}";

            return 1;
        }
        private void status_inical()
        {
            gbMensaProcessamento.Visible = false;
            lbTituloErros.Visible = false;
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
            lbTituloErros.Visible = false;
            btExcel.Visible = false;
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
            lbTituloErros.Visible = true;
            btExcel.Visible = true;
            dtGridLog.Visible = true;
            dbLocais.Visible = true;
            btProcessar.Text = "Cancelar Processamento";
            btProcessar.Tag = 1;
            lblCancelamentoAtivado.Visible = false;
        }
        private void status_aguardando_cancelar()
        {
            gbMensaProcessamento.Visible = true;
            lbTituloErros.Visible = true;
            btExcel.Visible = true;
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

         private async Task<int> pausaAsync()
        {

            await Task.Run(async delegate
            {
                await Task.Delay(300);
            });

            return 1;
        }
    }

}
