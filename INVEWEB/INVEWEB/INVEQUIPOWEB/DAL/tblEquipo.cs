namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("tblEquipo")]
    public partial class tblEquipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEquipo()
        {
            tblReunion = new HashSet<tblReunion>();
        }

        [Key]
        public int? ID_Equipo { get; set; }

        [StringLength(100)]

        [DisplayName("Equipo")]
        public string NOM_EQUIPO { get; set; }

        [StringLength(50)]
        [DisplayName("Codigo Activo")]

        public string CODIGO_ACTIVO { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("Estado")]

        public string ACTIVO { get; set; }

        [DisplayName("Cantidad")]

        public int? CANTIDAD { get; set; }

        [StringLength(100)]
        [DisplayName("Tipo de Dispositivo")]

        public string DISPOSITIVO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReunion> tblReunion { get; set; }

        public List<tblEquipo> Listar()
        {
            try
            {
                using (var cn = new DBEquipo())
                {
                    return cn.tblEquipo.ToList();
                    //return cn.Database.SqlQuery<Curso>("Usp_ListarCurso").ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<tblEquipo> ListadoCmbEquipo()
        {
            //var equipo = new List<tblEquipo>();

            try
            {
                using (var cn = new DBEquipo())
                {

                    //equipo = cn.Database.SqlQuery<tblEquipo>("EXEC Usp_Sel_CmbEquipoPrestado @ID_Equipo", new SqlParameter("ID_Equipo", ID_Equipo)).ToList();
                    return cn.tblEquipo.ToList();
                    //return cn.Database.SqlQuery<tblPersonas>("EXEC Usp_Sel_CmbPersonas @IDPersona").ToList();
                    //return cn.Database.SqlQuery<tblPersonas>("Usp_Sel_CmbPersonas @IDPersona)", new SqlParameter("IDPersona", IDPersona)).ToList();

                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
            //return equipo;


        }


        public tblEquipo Obtener(int ID)
        {
            var Oequipo = new tblEquipo();

            try
            {
                using (var cn = new DBEquipo())
                {
                    //Oequipo = cn.tblEquipo.Where(x => x.ID_Equipo == ID).SingleOrDefault();
                    Oequipo = cn.tblEquipo.Where(x => x.ID_Equipo == ID).Single();    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Oequipo;

        }

        public JsonModel Guardar()
        {

            var rm = new JsonModel();

            try
            {
                using (var cn = new DBEquipo())
                {
                    if (this.ID_Equipo > 0)
                    {
                        cn.Entry(this).State = EntityState.Modified;
                        // cn.SaveChanges();
                    }
                    else
                    {
                        cn.Entry(this).State = EntityState.Added;
                    }

                    rm.SetResponse(true);
                    cn.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return rm;
        }

        public void Eliminar()
        {

            try
            {
                using (var cn = new DBEquipo())
                {
                    cn.Entry(this).State = EntityState.Deleted;
                    cn.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public tblEquipo ObtenerEquipo(int id)
        {
            var Oequipo = new tblEquipo();

            try
            {
                using (var cn = new DBEquipo())
                {
                    Oequipo = cn.tblEquipo.Include("tblReunion").Include("tblReunion.tblEquipo").Where(x => x.ID_Equipo == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Oequipo;
        }

        //public List<tblEquipo> tblEquipoDisponibles(int EquipoId = 0)
        //{
        //    var cursos = new List<tblEquipo>();
        //    try
        //    {
        //        using (var cn = new DBEquipo())
        //        {
        //            if (EquipoId > 0)
        //            {
        //                var cursos_actuales = cn.tblReunion.Where(x => x.Equipo_Id == EquipoId)
        //                    .Select(x => x.Persona_Id).ToList();
        //                cursos = cn.tblEquipo.Where(x => !cursos_actuales.Contains(x.ID_Equipo)).ToList();
        //                //forma sencilla
        //                //cursos = cn.Database.SqlQuery<Curso>("SELECT C.* FROM Curso AS c WHERE c.id NOT IN (SELECT ac.Curso_id FROM  alumnocurso ac WHERE ac.Curso_id=c.id AND ac.Alumno_id=@Alumno_id)", new SqlParameter("Alumno_id", IdAlumno)).ToList();
        //                //cursos = cn.Database.SqlQuery<Curso>("EXEC Usp_AlumnoCursos @Alumno_id)", new SqlParameter("Alumno_id", IdAlumno)).ToList();
        //            }
        //            else
        //            {
        //                cursos = cn.Curso.ToList();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return cursos;
        //}

        //public List<tblReunion> Listar(int Alumno_Id)
        //{
        //    var OalumnoCurso = new List<AlumnoCurso>();
        //    try
        //    {
        //        using (var cn = new BDCursos())
        //        {
        //            OalumnoCurso = cn.AlumnoCurso.Include("Curso").Where(x => x.Alumno_id == Alumno_Id).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return OalumnoCurso;
        //}



    }
}
