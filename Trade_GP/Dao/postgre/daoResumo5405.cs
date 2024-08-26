using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trade_GP.Models;
using Trade_GP.Util;

namespace Trade_GP.Dao.postgre
{
    class daoResumo5405
    {

        public Resumo_5405 Insert(Resumo_5405 obj)
        {
            Resumo_5405 retorno = null;

            String StringInsert = $"insert into resumo_5405(id_grupo, cod_emp, local, material) " +
                                  $"values({obj.id_grupo}, '{obj.cod_emp}', '{obj.local}', '{obj.material}') RETURNING  * ";
            try
            {

                using (var objConexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                {
                    using (var objCommand = new NpgsqlCommand(StringInsert, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                while (objDataReader.Read())
                                {

                                    retorno = PopulaResumo(objDataReader);

                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            objConexao.Close();
                        }
                    }
                }

                return retorno;
            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");

                retorno = null;
            }

            return retorno;

        }

        public Resumo_5405 Update(Resumo_5405 obj)
        {

            Resumo_5405 resumo = this.Seek(obj);

            if (resumo == null)
            {
                try
                {
                    obj = this.Insert(obj);
                }
                catch (Exception ex)
                {
                    obj = null;
                }
            }

            return obj;
        }

        public void Delete(Resumo_5405 obj)
        {

            String StringDelete = $" DELETE FROM  resumo_5405  WHERE id_grupo = {obj.id_grupo} and  cod_emp = '{obj.cod_emp}' and  local = '{obj.local}' and  material = '{obj.material}';";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }

        public Resumo_5405 Seek(Resumo_5405 obj)
        {

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"select * from resumo_5405 where id_grupo = {obj.id_grupo} and  cod_emp = '{obj.cod_emp}' and  local = '{obj.local}' and  material = '{obj.material}';";

            using (var objConexao = new NpgsqlConnection(strStringConexao))
            {
                using (var objCommand = new NpgsqlCommand(strSelect, objConexao))
                {
                    try
                    {
                        objConexao.Open();

                        var objDataReader = objCommand.ExecuteReader();

                        if (objDataReader.HasRows)
                        {

                            objDataReader.Read();

                            obj = new Resumo_5405();

                            obj = PopulaResumo(objDataReader);
                        }
                        else
                        {
                            obj = null;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }

            return obj;
        }

        private Resumo_5405 PopulaResumo(NpgsqlDataReader objDataReader)
        {

            var obj = new Resumo_5405
            {
                id_grupo = Convert.ToInt16(objDataReader["id_grupo"]),
                cod_emp = objDataReader["cod_emp"].ToString(),
                local = objDataReader["local"].ToString(),
                material = objDataReader["material"].ToString()
            };

            return obj;
        }

        public List<string> getAll(int id_grupo, string cod_emp, string local)
        {

            List<string> lista = new List<string>();

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = SqlGrid( id_grupo,  cod_emp,  local);

            Console.WriteLine(strSelect);

            using (var objConexao = new NpgsqlConnection(strStringConexao))
            {
                using (var objCommand = new NpgsqlCommand(strSelect, objConexao))
                {
                    try
                    {
                        objConexao.Open();

                        var objDataReader = objCommand.ExecuteReader();

                        if (objDataReader.HasRows)
                        {

                            while (objDataReader.Read())
                            {

                                string mat = objDataReader["material"].ToString();

                                lista.Add(mat);

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }

            return lista;
        }

        public string SqlGrid(int id_grupo, string cod_emp, string local)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = "select  material from resumo_5405 ";

            Where = $"WHERE  id_grupo = {id_grupo} and cod_emp = '{cod_emp}' and local = '{local}'  ";


            //Adiciona ORDER BY

            OrderBy = $"ORDER BY MATERIAL";

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }
    }

}
