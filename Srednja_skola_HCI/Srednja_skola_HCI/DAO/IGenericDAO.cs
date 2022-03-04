using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DAO.MySqlDAO
{
    public interface IGenericDAO<T>
    {
        T GetDTO(T dto);

        List<T> GetDTOList();
        Boolean CreateDTO(T dto);
        Boolean UpdateDTO(T dto);
        Boolean DeleteDTOById(T dto);
    }
}
