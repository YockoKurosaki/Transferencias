using System.Collections.Generic;
using System.Linq;

namespace DbCliente
{
    public class TransaccionDataAccess
    {
        public int InsTransaccion(Transaccion model)
        {
            using (var _db = new BancoEntities())
            {

                _db.Transaccions.Add(model);
                _db.SaveChanges();

                return model.Id;
            }
        }

        public List<Transaccion> GetTransacciones()
        {
            using (var _db = new BancoEntities())
            {
                var lista = _db.Transaccions.ToList();
                return lista;
            }
        }
    }
}
