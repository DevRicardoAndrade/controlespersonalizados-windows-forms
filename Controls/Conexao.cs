using System;
using System.Windows.Forms;
using System.Configuration;
using Npgsql;

namespace Sales.Classes
{
    public class Conexao
    {
        public static string server = $"Server={ConfigurationSettings.AppSettings["server"]};Username=postgres;Database={ConfigurationSettings.AppSettings["db"]};Port=5432;Password={ConfigurationSettings.AppSettings["password"]};SSLMode=Prefer";
        public NpgsqlConnection con;
        public Conexao()
        {
            try
            {
                con = new NpgsqlConnection(server);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                con = new NpgsqlConnection($"Server={ConfigurationSettings.AppSettings["server"]};Username=postgres;Database=postgres;Port=5432;Password={ConfigurationSettings.AppSettings["password"]};SSLMode=Prefer");
                CriarBanco();
                con = new NpgsqlConnection(server);

            }

        }
        public int Testar()
        {
            try
            {
                con.Open();
                if(con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                    return 1;
                }
                else
                {
                    return 0;
                }
                
            }
            catch (NpgsqlException ex)
            {
                var mensagem = ex.Message;
                var res = new Mensagem(Mensagem.TipoMensagem.Erro, mensagem).ShowDialog();
                return 0;
            }
        }
        public void Conectar()
        {
            con.Open();
        }
        public void Desconectar()
        {
            con.Close();
        }
        public void CriarBanco()
        {
             try
            {
                con.Open();
                var Banco = "CREATE DATABASE sales;";
                var sql = "SELECT 1 FROM pg_database WHERE datname = 'sales'";
                using (NpgsqlCommand select = new NpgsqlCommand(sql,con))
                {
                    using (var reader = select.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            con.Close();
                            return;
                        }
                        else
                        {
                            reader.Close();
                            using (NpgsqlCommand cmd = new NpgsqlCommand(Banco, con))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                con.Close();
                new Mensagem(Mensagem.TipoMensagem.Informacao, "Sistema e dados atualizados!").ShowDialog();
                

            }
            catch (NpgsqlException ex)
            {
                var mensagem = ex.Message;
                var res = new Mensagem(Mensagem.TipoMensagem.Erro, mensagem).ShowDialog();
                con.Close();
            }
        }
        
        public static bool LimparTabela(string tabela)
        {
            var sql = "TRUNCATE " + tabela + " RESTART IDENTITY;";
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(server))
                {
                    con.Open();
                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                        {
                            cmd.ExecuteNonQuery();
                            con.Close();
                            return true;
                        }
                    
                }
            }
            catch (NpgsqlException ex)
            {
                var mensagem = ex.Message;
                var res = new Mensagem(Mensagem.TipoMensagem.Erro, mensagem).ShowDialog();
                return false;
            }
        }
        public void CriarTabelaConfiguracao()
        {
            try
            {
                con.Open();
                var Tabela = "CREATE TABLE IF NOT EXISTS public.tbdconfiguracao ( " +
                    "id_configuracao integer GENERATED ALWAYS AS IDENTITY," +
                    "tp_enterigualtab boolean," +
                    "tp_logo bytea," +
                    "PRIMARY KEY (id_configuracao));" +
                    "ALTER TABLE IF EXISTS public.tbdconfiguracao " +
                    "OWNER to postgres;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(Tabela, con))
                {
                    cmd.ExecuteNonQuery();
                    var sql = "SELECT * FROM tbdconfiguracao";
                    using (NpgsqlCommand cmd2 = new NpgsqlCommand(sql,con))
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                con.Close();
                                return;
                            }
                            else
                            {
                                reader.Close(); 
                                var insert = "INSERT INTO tbdconfiguracao (tp_enterigualtab,tp_logo) VALUES (null,null)";
                                using (NpgsqlCommand cmd3 = new NpgsqlCommand(insert,con))
                                {
                                    cmd3.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    con.Close();
                }
            }
            catch (NpgsqlException ex)
            {
                var mensagem = ex.Message;
                var res = new Mensagem(Mensagem.TipoMensagem.Erro, mensagem).ShowDialog();
                con.Close();
            }
        }
        public void CriarTabelaUsuario()
        {
            try
            {
                con.Open();
                var Tabela = "CREATE TABLE IF NOT EXISTS public.tbdusuario " +
                    "( id_usuario integer NOT NULL GENERATED ALWAYS AS IDENTITY(INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1), " +
                    "ds_usuario character varying(100) NOT NULL, " +
                    "ds_nome character varying(255) NOT NULL, " +
                    "ds_senha character varying(40) NOT NULL, " +
                    "tp_inativo character(1) DEFAULT 'N'::bpchar, " +
                    "dt_cadastro date DEFAULT CURRENT_DATE, " +
                    "ds_observacao character varying, " +
                    "CONSTRAINT tbdusuario_pkey PRIMARY KEY(id_usuario), " +
                    "CONSTRAINT tbdusuario_ds_usuario_key UNIQUE(ds_usuario) ) " +
                    "TABLESPACE pg_default; " +
                    "ALTER TABLE IF EXISTS public.tbdusuario " +
                    "OWNER to postgres;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(Tabela, con))
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (NpgsqlException ex)
            {
                var mensagem = ex.Message;
                var res = new Mensagem(Mensagem.TipoMensagem.Erro, mensagem).ShowDialog();
                con.Close();
            }
        }
        public void CriarTabelaBotao()
        {
            try
            {
                con.Open();
                var Tabela = "CREATE TABLE IF NOT EXISTS public.tbdbotaoopcoes" +
                    "( id_botao integer NOT NULL GENERATED ALWAYS AS IDENTITY (INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ), " +
                    "ds_botao character varying(255) NOT NULL, " +
                    "ds_nome character varying(100) NOT NULL, " +
                    "CONSTRAINT tbdbotaoopcoes_pkey PRIMARY KEY(id_botao) ) " +
                    "TABLESPACE pg_default; " +
                    "ALTER TABLE IF EXISTS public.tbdbotaoopcoes " +
                    "OWNER to postgres; ";
                using (NpgsqlCommand cmd = new NpgsqlCommand(Tabela, con))
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (NpgsqlException ex)
            {
                var mensagem = ex.Message;
                var res = new Mensagem(Mensagem.TipoMensagem.Erro, mensagem).ShowDialog();
                con.Close();
            }
        }
        public void CriarTabelaMenu()
        {
            try
            {
                con.Open();
                var Tabela = "CREATE TABLE IF NOT EXISTS public.tbdmenuopcoes " +
                    "( id_menuopcoes integer NOT NULL GENERATED ALWAYS AS IDENTITY (INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ), " +
                    "ds_nome character varying(100) NOT NULL, ds_menu character varying(255) NOT NULL, " +
                    "nr_nivel smallint NOT NULL, " +
                    "CONSTRAINT tbdmenuopcoes_pkey PRIMARY KEY(id_menuopcoes) ) " +
                    "TABLESPACE pg_default; " +
                    "ALTER TABLE IF EXISTS public.tbdmenuopcoes " +
                    "OWNER to postgres; ";
                using (NpgsqlCommand cmd = new NpgsqlCommand(Tabela, con))
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (NpgsqlException ex)
            {
                var mensagem = ex.Message;
                var res = new Mensagem(Mensagem.TipoMensagem.Erro, mensagem).ShowDialog();
                con.Close();
            }
        }
        public void CriarTabelaAcessoMenu()
        {
            try
            {
                con.Open();
                var Tabela = "CREATE TABLE IF NOT EXISTS public.tbdmenuacessos " +
                    "( id_usuario integer, " +
                    "id_menuopcoes integer, " +
                    "id_menuacesso integer GENERATED ALWAYS AS IDENTITY, " +
                    "tp_liberado character(1) DEFAULT 'N', " +
                    "PRIMARY KEY(id_menuacesso), " +
                    "CONSTRAINT fk_tbdusuario FOREIGN KEY(id_usuario) " +
                    "REFERENCES tbdusuario(id_usuario), " +
                    "CONSTRAINT fk_tbdmenuopcoes FOREIGN KEY(id_menuopcoes) " +
                    "REFERENCES tbdmenuopcoes(id_menuopcoes) ); " +
                    "ALTER TABLE IF EXISTS public.tbdmenuacessos OWNER to postgres;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(Tabela, con))
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (NpgsqlException ex)
            {
                var mensagem = ex.Message;
                var res = new Mensagem(Mensagem.TipoMensagem.Erro, mensagem).ShowDialog();
                con.Close();
            }
        }
        public void CriarTabelaAcessoBotao()
        {
            try
            {
                con.Open();
                var Tabela = "CREATE TABLE IF NOT EXISTS public.tbdbotaoacessos " +
                    "( id_usuario integer, " +
                    "id_botao integer, " +
                    "id_botaoacesso integer GENERATED ALWAYS AS IDENTITY, " +
                    "tp_liberado character(1) DEFAULT 'N', " +
                    "PRIMARY KEY (id_botaoacesso), " +
                    "CONSTRAINT fk_tbdusuario FOREIGN KEY(id_usuario) " +
                    "REFERENCES tbdusuario(id_usuario), " +
                    "CONSTRAINT fk_tbdbotaoopcoes FOREIGN KEY(id_botao) " +
                    "REFERENCES tbdbotaoopcoes(id_botao) ); " +
                    "ALTER TABLE IF EXISTS public.tbdbotaoacessos OWNER to postgres;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(Tabela, con))
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (NpgsqlException ex)
            {
                var mensagem = ex.Message;
                var res = new Mensagem(Mensagem.TipoMensagem.Erro, mensagem).ShowDialog();
                con.Close();
            }
        }
    }
}
