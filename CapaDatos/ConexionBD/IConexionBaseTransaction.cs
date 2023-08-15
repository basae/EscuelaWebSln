namespace CapaDatos.ConexionBD
{
    public interface IConexionBaseTransaction
    {
        void CommitTransaccion();
        void CrearTransaccion();
        void RollBack();
    }
}