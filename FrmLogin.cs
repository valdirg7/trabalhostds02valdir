﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LojaCL
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexao.obterConexao();
            string usu = "select login,senha from usuario where login=@login and senha=@senha";
            SqlCommand cmd = new SqlCommand(usu, con);
            cmd.Parameters.AddWithValue("@login", SqlDbType.NChar).Value = txtLogin.Text.Trim();
            cmd.Parameters.AddWithValue("@senha", SqlDbType.NChar).Value = txtSenha.Text.Trim();
            Conexao.obterConexao();
            cmd.CommandType = CommandType.Text;
            SqlDataReader usuario = cmd.ExecuteReader();
            if (usuario.HasRows)
            {
                this.Hide();
                FrmPrincipal pri = new FrmPrincipal();
                pri.Show();
                Conexao.fecharConexao();
            } else
            {
                MessageBox.Show("Login ou senha incorretos! Tente novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Text = "";
                txtSenha.Text = "";
                con.Close();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }
    }
}
