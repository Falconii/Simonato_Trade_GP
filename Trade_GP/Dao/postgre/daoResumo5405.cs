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

            String StringInsert = $"insert into resumo_5405(id_grupo, cod_emp, local, material, unid, fator) " +
                                  $"values({obj.id_grupo}, '{obj.cod_emp}', '{obj.local}', '{obj.material}','{obj.unid}',{obj.fator}) RETURNING  * ";
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

        public Resumo_5405 UpdateX(Resumo_5405 obj)
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

        public void Update(Resumo_5405 obj)
        {

            String StringUpdate = $" UPDATE resumo_5405 SET " +
                    $"  UNID = {obj.unid }  " +
                    $", FATOR = {obj.fator} " +
                    $"  where id_gupo = { obj.id_grupo} " +
                    $"  and cod_emp = '{obj.cod_emp}' and local = '{obj.local}' and material = '{obj.material}'; ";
            Console.WriteLine(StringUpdate);

            try
            {

                DataBase.RunCommand.CreateCommand(StringUpdate);

            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }

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
                material = objDataReader["material"].ToString(),
                unid = objDataReader["unid"].ToString(),
                fator = Convert.ToDouble(objDataReader["fator"])
            };

            return obj;
        }

        private Resumo_5405_01 PopulaResumo_01(NpgsqlDataReader objDataReader)
        {

            var obj = new Resumo_5405_01
            {
                material = objDataReader["material"].ToString(),
                unid = objDataReader["unid"].ToString(),
                fator = Convert.ToDouble(objDataReader["fator"])
            };

            return obj;
        }

        public List<Resumo_5405_01> getAll(int id_grupo, string cod_emp, string local)
        {

            List<Resumo_5405_01> lista = new List<Resumo_5405_01>();

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = SqlGrid(id_grupo, cod_emp, local);

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
                                var obj = PopulaResumo_01(objDataReader);

                                lista.Add(obj);

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

            string strSelect = "select  material, unid, fator from resumo_5405 ";

            Where = $"WHERE  id_grupo = {id_grupo} and cod_emp = '{cod_emp}' and local = '{local}'  ";


            //Adiciona ORDER BY

            OrderBy = $"ORDER BY MATERIAL";

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }
    }

}
