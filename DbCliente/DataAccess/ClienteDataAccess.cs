using System.Collections.Generic;
using System.Linq;

namespace DbCliente
{
    public class ClienteDataAccess
    {
        public List<Cliente> GetClientes()
        {
            using (var _db = new BancoEntities())
            {
                var lista = _db.Clientes.ToList();
                return lista;
            }
        }

        public List<Cuenta> GetCuentasCliente(int id)
        {
            using (var _db = new BancoEntities())
            {
                var lista = _db.Cuentas.Where(c => c.Cliente.Id == id).ToList();
                return lista;
            }
        }
    }
}
