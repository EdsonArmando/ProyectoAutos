using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AutoVentas.Models
{
    public partial class DB_AUTOS:DbContext
    {
        public DB_AUTOS(): base("name=DB_Autos"){}
        public virtual DbSet<Rol> rol { get; set; }
        public virtual DbSet<Archivo> archivo { get; set; }
        public virtual DbSet<Usuario> usuario { get; set; }
        public virtual DbSet<Automovil> automovil { get; set; }
        public virtual DbSet<Compra> compra { get; set; }
        public virtual DbSet<Venta> venta { get; set; }

        public System.Data.Entity.DbSet<AutoVentas.Models.Marca> Marcas { get; set; }
    }
}