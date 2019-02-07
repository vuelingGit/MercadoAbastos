using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MercadoAbastos.Models.Repositorio
{
    public class Repositorio : MercadoDeSantiagoEntities, IRepositorio
    {

        public Colaborador dameColaborador(String codColaborador)
        {
            return Colaborador.Find(codColaborador);
        }

        public Comentario dameComentario(String codComentario)
        {
            return Comentario.Find(codComentario);
        }

        public Puesto damePuesto(int codPuesto)
        {
            return Puesto.Find(codPuesto);
        }

        public DbSet<Comentario> dameComentarios()
        {
            return Comentario;
        }

        public DbSet<Puesto> damePuestos()
        {
            return Puesto;
        }
        public DbSet<Colaborador> dameColaboradores()
        {
            return Colaborador;
        }


        public bool añadeColaborador(Colaborador colaborador)
        {
            if (dameColaborador(colaborador.DNI) is null)
            {
                Colaborador.Add(colaborador);
                SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool añadeComentario(Comentario comentario)
        {
            if (dameComentario(comentario.Codigo) is null)
            {
                comentario.FechaHoraCreacion = DateTime.Now;
                Comentario.Add(comentario);
                SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool añadePuesto(Puesto puesto)
        {
           if (damePuesto(puesto.Numero_Puesto) is null)
            {

                Puesto.Add(puesto);
                SaveChanges();
                return true;
            }
           else
            {
                return false;
            }
        }


        public bool modificaColaborador(Colaborador colaborador)
        {
            Entry(Colaborador).State = EntityState.Modified;
            SaveChanges();
            return true;
        }

        public bool modificaComentario(Comentario comentario)
        {
            Entry(comentario).State = EntityState.Modified;
            comentario.FechaHoraCreacion = DateTime.Now;
            SaveChanges();
            return true;
        }

        public bool modificaPuesto(Puesto puesto)
        {
            Entry(puesto).State = EntityState.Modified;
            SaveChanges();
            return true;
        }

        public bool eliminaColaborador(Colaborador colaborador)
        {
            Colaborador.Remove(colaborador);
            SaveChanges();
            return true;
        }

        public bool eliminaComentario(Comentario comentario)
        {
            Comentario.Remove(comentario);
            SaveChanges();
            return true;
        }

        public bool eliminaPuesto(Puesto puesto)
        {
            Puesto.Remove(puesto);
            SaveChanges();
            return true;
        }
        public new void Dispose()
        {
            base.Dispose();
        }

        public List<Puesto> damePuestos(string codColaborador)
        {
            var puestos = damePuestos().Where(p => p.DNI == codColaborador);
            List<Puesto> lista = new List<MercadoAbastos.Puesto>();
            foreach(Puesto pue in puestos)
            {
                lista.Add(pue);
            }
            return lista;
        }

        public List<Comentario> dameComentarios(int Numero_Puesto)
        {
            var comentarios = dameComentarios().Where(p => p.Numero_Puesto == Numero_Puesto);
            List<Comentario> lista = new List<MercadoAbastos.Comentario>();
            foreach(Comentario com in comentarios)
            {
                lista.Add(com);
            }
            return lista;
        }
    }
}