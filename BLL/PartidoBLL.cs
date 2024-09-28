using System;
using System.Collections.Generic;
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

        // Validar y agregar un partido
        public void AgregarPartido(int idDeporte, string equipoLocal, string equipoVisitante, DateTime fechaPartido)
        {
            // Validación del deporte (Aunque se selecciona desde un combo box, se valida por si se manipula el valor)
            if (idDeporte <= 0)
            {
                throw new Exception("Debe seleccionar un deporte válido.");
            }

            // Validación del equipo local
            if (string.IsNullOrEmpty(equipoLocal) || equipoLocal.Length <= 5)
            {
                throw new Exception("El nombre del equipo local no puede estar vacío y debe tener más de 5 caracteres.");
            }

            // Validación del equipo visitante
            if (string.IsNullOrEmpty(equipoVisitante) || equipoVisitante.Length <= 5)
            {
                throw new Exception("El nombre del equipo visitante no puede estar vacío y debe tener más de 5 caracteres.");
            }

            // Validación de la fecha del partido
            if (fechaPartido.Date < DateTime.Now.Date)
            {
                throw new Exception("La fecha del partido no puede ser anterior a la fecha actual.");
            }

            try
            {
                // pasadas todas las validaciones se llama a la capa DAP para agregar el partido
                _partidoDal.AgregarPartido(idDeporte, equipoLocal, equipoVisitante, fechaPartido);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio al agregar el partido: " + ex.Message);
            }
        }

        // Método para obtener todos los partidos
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

        
        public void EliminarPartido(int idPartido)
        {
            if (idPartido <= 0)
            {
                throw new Exception("Debe proporcionar un ID de partido válido para eliminar.");
            }

            try
            {
                _partidoDal.EliminarPartido(idPartido);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio al eliminar el partido: " + ex.Message);
            }
        }

        // Método para actualizar el marcador
        public void ActualizarMarcador(int idPartido, int marcadorLocal, int marcadorVisitante)
        {
            Partido partido = _partidoDal.ObtenerPartidoPorId(idPartido); // Buscar el partido por ID

            // Validar si el partido se juega hoy
            if (partido.FechaPartido.Date != DateTime.Now.Date)
            {
                throw new Exception("No se puede modificar el marcador de un partido que no se juegue hoy.");
            }

            // Validar los marcadores
            if (marcadorLocal < 0)
            {
                throw new Exception("El marcador local no puede ser negativo.");
            }

            if (marcadorVisitante < 0)
            {
                throw new Exception("El marcador visitante no puede ser negativo.");
            }

            // Actualizar marcador en DAL
            try
            {
                _partidoDal.ActualizarMarcador(idPartido, marcadorLocal, marcadorVisitante);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el marcador en la capa de negocio: " + ex.Message);
            }
        }

        // Método para obtener la lista de deportes
        public List<Deporte> ObtenerDeportes()
        {
            try
            {
                return _partidoDal.ObtenerDeportes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los deportes: " + ex.Message);
            }
        }
    }
}
