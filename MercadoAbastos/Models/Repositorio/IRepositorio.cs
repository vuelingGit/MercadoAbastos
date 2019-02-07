using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoAbastos.Models.Repositorio
{
    public interface IRepositorio    {
        Colaborador dameColaborador(String codColaborador);
        Comentario dameComentario(String codComentario);
        Puesto damePuesto(int puesto);
        DbSet<Colaborador> dameColaboradores();
        DbSet<Comentario> dameComentarios();
        List<Comentario> dameComentarios(int Numero_Puesto);
        DbSet<Puesto> damePuestos();
        List<Puesto> damePuestos(String codColaborador);
        bool añadeColaborador(Colaborador colaborador);
        bool añadeComentario(Comentario comentario);
        bool añadePuesto(Puesto puesto);
        bool modificaColaborador(Colaborador colaborador);
        bool modificaComentario(Comentario comentario);
        bool modificaPuesto(Puesto puesto);
        bool eliminaColaborador(Colaborador colaborador);
        bool eliminaComentario(Comentario comentario);
        bool eliminaPuesto(Puesto puesto);
        void Dispose();

    }
}
