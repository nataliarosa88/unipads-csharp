using Npgsql;
using SistemasImobiliaria.Dao;
using SistemasImobiliaria.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemasImobiliaria.Controle
{
    class ImoveisCtr
    {
        ImoveisDao imoveisDao;

        public ImoveisCtr(NpgsqlConnection conexao)
        {
            imoveisDao = new ImoveisDao(conexao);
        }

        public bool setIncluiImoveis(Imoveis imoveis)
        {
            return imoveisDao.create(imoveis);   
        }
        
        public DataTable getConsultaImoveis()
        {
            return imoveisDao.retrieveAll();
        }

        public DataTable getConsultaImoveis(NpgsqlConnection conexao, int campo, int tipo, String descricao)
        {
            return imoveisDao.retrieveByField(campo, tipo, descricao);
        }

        public bool setExcluiImoveis(NpgsqlConnection conexao, int codigo)
        {
            return imoveisDao.delete(codigo);
        }

        public bool setAlteraImoveis(NpgsqlConnection conexao, Imoveis imoveis)
        {
            return imoveisDao.update(imoveis);
        }
    }
}
