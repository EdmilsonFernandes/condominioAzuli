using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;

namespace Azuli.Web.DAO.Interfaces
{
    public interface IEnquete
    {
        ListaEnquete resultadoEnquete();
        void cadastraVotacao(Enquete oEnquete);
    }
}
