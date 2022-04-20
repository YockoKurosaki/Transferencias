using DbCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace WebService
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Transactions
    {
        ClienteDataAccess _cliente = new ClienteDataAccess();
        TransaccionDataAccess _transaccion = new TransaccionDataAccess();

        [OperationContract]
        public List<ClienteDto> GetClientes()
        {
            var lista = Mapping.Mapper.Map<List<ClienteDto>>(_cliente.GetClientes());
            return lista;
        }

        [OperationContract]
        public List<CuentaDto> GetCuentas(int id)
        {
            var lista =  Mapping.Mapper.Map<List<CuentaDto>>(_cliente.GetCuentasCliente(id));
            return lista;
        }

        [OperationContract]
        public void InsTransaccion(TransaccionDto transaccion)
        {
            transaccion.Fecha = DateTime.Now;
            var model = Mapping.Mapper.Map<Transaccion>(transaccion);
            _transaccion.InsTransaccion(model);
        }

        [OperationContract]
        public List<TransaccionDto> GetTransacciones()
        {
            var list = Mapping.Mapper.Map<List<TransaccionDto>>(_transaccion.GetTransacciones().ToList());
            return list;
        }
    }
}
