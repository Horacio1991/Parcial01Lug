using System;
using System.Collections.Generic;
using System.Transactions;
using DAL;
using Entity;

namespace BLL
{
    public class PartidoBLL
    {
        private readonly PartidoDAL _partidoDal;

        public PartidoBLL()
        {
            _partidoDal = new PartidoDAL();
        }

        
        public void AgregarPartido(Partido partido)
        {
           
            if (partido.Deporte == null || partido.Deporte.IdDeporte <= 0)
            {
                throw new Exception("Debe seleccionar un deporte válido.");
            }

            // Validación del equipo local
            if (string.IsNullOrEmpty(partido.EquipoLocal) || partido.EquipoLocal.Length <= 5)
            {
                throw new Exception("El nombre del equipo local no puede estar vacío y debe tener más de 5 caracteres.");
            }

            // Validación del equipo visitante
            if (string.IsNullOrEmpty(partido.EquipoVisitante) || partido.EquipoVisitante.Length <= 5)
            {
                throw new Exception("El nombre del equipo visitante no puede estar vacío y debe tener más de 5 caracteres.");
            }

            // Validación de la fecha del partido
            if (partido.FechaPartido.Date < DateTime.Now.Date)
            {
                throw new Exception("La fecha del partido no puede ser anterior a la fecha actual.");
            }

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _partidoDal.AgregarPartido(partido);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar el partido en la capa de negocio: " + ex.Message);
                }
            }
        }

       
        public List<Partido> ObtenerTodosLosPartidos()
        {
            try
            {
                return _partidoDal.ObtenerTodosLosPartidos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio al obtener los partidos: " + ex.Message);
            }
        }

        // Obtener la lista de deportes
        public List<Deporte> ObtenerDeportes()
        {
            try
            {
                return _partidoDal.ObtenerDeportes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio al obtener los deportes: " + ex.Message);
            }
        }

        
        public void EliminarPartido(int idPartido)
        {
            if (idPartido <= 0)
            {
                throw new Exception("Debe proporcionar un ID de partido válido para eliminar.");
            }

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _partidoDal.EliminarPartido(idPartido);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la capa de negocio al eliminar el partido: " + ex.Message);
                }
            }
        }

        
        public void ActualizarMarcador(int idPartido, int marcadorLocal, int marcadorVisitante)
        {
            if (idPartido <= 0)
            {
                throw new Exception("Debe proporcionar un ID de partido válido para actualizar el marcador.");
            }

            if (marcadorLocal < 0 || marcadorVisitante < 0)
            {
                throw new Exception("Los marcadores no pueden ser negativos.");
            }

            Partido partido = _partidoDal.ObtenerPartidoPorId(idPartido);
            if (partido == null)
            {
                throw new Exception("Partido no encontrado.");
            }

            if (partido.FechaPartido.Date != DateTime.Now.Date)
            {
                throw new Exception("No se puede modificar el marcador de un partido que no se juegue hoy.");
            }

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _partidoDal.ActualizarMarcador(idPartido, marcadorLocal, marcadorVisitante);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el marcador en la capa de negocio: " + ex.Message);
                }
            }
        }

        public void CargarPartidosMasivos(List<Partido> partidosEnMemoria)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    foreach (var partido in partidosEnMemoria)
                    {
                        // Validaciones antes de agregar el partido
                        if (partido.Deporte == null || partido.Deporte.IdDeporte <= 0)
                            throw new Exception("Debe seleccionar un deporte válido.");

                        if (string.IsNullOrEmpty(partido.EquipoLocal) || partido.EquipoLocal.Length <= 5)
                            throw new Exception("El nombre del equipo local no puede estar vacío y debe tener más de 5 caracteres.");

                        if (string.IsNullOrEmpty(partido.EquipoVisitante) || partido.EquipoVisitante.Length <= 5)
                            throw new Exception("El nombre del equipo visitante no puede estar vacío y debe tener más de 5 caracteres.");

                        if (partido.FechaPartido.Date < DateTime.Now.Date)
                            throw new Exception("La fecha del partido no puede ser anterior a la fecha actual.");

                        // Agregar el partido si todas las validaciones pasan
                        _partidoDal.AgregarPartido(partido);
                    }

                    // Completa la transaccin si todos los partidos son válidos
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la carga masiva: " + ex.Message);
                }
            }
        }
    }
}
