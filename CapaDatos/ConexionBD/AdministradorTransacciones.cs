using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ConexionBD
{
    public class AdministradorTransacciones : IAdministradorTransacciones
    {
        private readonly IDbTransaction dbTransaction;
        private readonly Action<AdministradorTransacciones> rollback;
        private readonly Action<AdministradorTransacciones> commited;
        public IDbTransaction Transaction { get; private set; }

        public AdministradorTransacciones(IDbTransaction dbTransaction, Action<AdministradorTransacciones> rollback,
                                          Action<AdministradorTransacciones> commited)
        {
            this.dbTransaction = dbTransaction;
            this.rollback = rollback;
            this.commited = commited;
        }
        public void Commit()
        {
            if (dbTransaction == null)
                throw new InvalidOperationException("no se puede guardar cambios si no existe ninguna transacción");
            dbTransaction.Commit();
            commited(this);
            dbTransaction.Dispose();
        }
        public void Rollback()
        {
            if (dbTransaction == null)
                throw new InvalidOperationException("no se puede guardar cambios si no existe ninguna transacción");
            dbTransaction.Rollback();
            rollback(this);
            dbTransaction.Dispose();
        }
        public IDbTransaction ObtenerTransaccion()
        {
            return dbTransaction;
        }

    }
}
