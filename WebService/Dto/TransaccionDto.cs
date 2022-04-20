using System;

namespace WebService
{
    public class TransaccionDto
    {
        public int Id { get; set; }
        public int OrigenCuenta { get; set; }
        public int DestinoCuenta { get; set; }
        public int Valor { get; set; }
        public int ClienteOrigen { get; set; }
        public DateTime? Fecha { get; set; }
    }
}