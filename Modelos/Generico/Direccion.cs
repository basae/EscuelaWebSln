using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Generico
{
    public interface IDireccionGenerica
    {
        string CodigoPostal { get; set; }
        public Catalogo Colonia { get; set; }
        Catalogo Estado { get; set; }
        Catalogo Municipio { get; set; }
    }

    public class DireccionGenerica : IDireccionGenerica
    {
        public string CodigoPostal { get; set; }
        public Catalogo Municipio { get; set; } = new Catalogo();
        public Catalogo Estado { get; set; } = new Catalogo();
        public Catalogo Colonia { get; set; } = new Catalogo();
    }

    public interface IDireccion: IDireccionGenerica
    {
        string Calle { get; set; }
        int? Id { get; set; }
        decimal Lat { get; set; }
        decimal Lng { get; set; }
        string NoExt { get; set; }
        string NoInt { get; set; }
    }

    public class Direccion : DireccionGenerica, IDireccionGenerica, IDireccion
    {

        public int? Id { get; set; }
        public string Calle { get; set; }
        public string NoInt { get; set; }
        public string NoExt { get; set; } = string.Empty;
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }

        public Direccion() { }
        public Direccion(DataTable dt)
        {
            DataRow dr = dt.Rows[0];
            Id = dr.Field<int?>("Id");
            Calle = dr.Field<string>("Calle");
            NoExt = dr.Field<string>("NoExt");
            NoInt = dr.Field<string>("NoInt");
            CodigoPostal = dr.Field<string>("CodigoPostal");
            Colonia = new Catalogo(dr.Field<string>("Colonia_Id"), dr.Field<string>("Colonia_Desc"));
            Municipio = new Catalogo(dr.Field<string>("Municipio_Id"), dr.Field<string>("Municipio_Desc"));
            Estado = new Catalogo(dr.Field<string>("Estado_Id"), dr.Field<string>("Estado_Desc"));

        }
    }
}
