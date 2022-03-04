﻿using Srednja_skola_HCI.DAO.MySqlDAO;
using Srednja_skola_HCI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DAO
{
    public interface IPredajeDAO : IGenericDAO<Predaje>
    {
        public List<Predaje> GetDTOList(PredmetNaSmjeru predmetNaSmjeru);
    }
}
