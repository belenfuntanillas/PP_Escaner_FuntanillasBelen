using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades {
    public static class Informes {
        /// <summary>
        /// Muestra los documentos de un escaner segun su estado.
        /// </summary>
        /// <param name="e">Escaner del que se van a mostrar los documentos</param>
        /// <param name="estado">Estado de los documentos que se quieren mostrar</param>
        /// <param name="extension">Parametro de tipo out donde se va a guardar la extension</param>
        /// <param name="cantidad">Parametro de tipo out donde se va a guardar la cantidad</param>
        /// <param name="resumen">Parametro de tipo out donde se va a guardar el resumen</param>
        private static void MostrarDocumentosPorEstado(Escaner e, Paso estado, out int extension, out int cantidad, out string resumen) {
            extension = 0;
            cantidad = 0;
            resumen = "";

            foreach (Documento doc in e.ListaDocumentos) {
                if (doc.Estado == estado) {
                    switch(e.Tipo) {
                        case Escaner.TipoDoc.libro:
                            extension += ((Libro)doc).NumPaginas;
                            break;
                        case Escaner.TipoDoc.mapa:
                            extension += ((Mapa)doc).Superficie;
                            break;
                    }

                    cantidad++;
                    resumen += doc.ToString() + "\n";
                }
            }
        }

        /// <summary>
        /// Muestra los documentos de un escaner con el estado en distribuido.
        /// </summary>
        /// <param name="e">Escaner del que se van a mostrar los documentos</param>
        /// <param name="extension">Parametro de tipo out donde se va a guardar la extension</param>
        /// <param name="cantidad">Parametro de tipo out donde se va a guardar la cantidad</param>
        /// <param name="resumen">Parametro de tipo out donde se va a guardar el resumen</param>
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen) {
            MostrarDocumentosPorEstado(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos de un escaner con el estado en escaner.
        /// </summary>
        /// <param name="e">Escaner del que se van a mostrar los documentos</param>
        /// <param name="extension">Parametro de tipo out donde se va a guardar la extension</param>
        /// <param name="cantidad">Parametro de tipo out donde se va a guardar la cantidad</param>
        /// <param name="resumen">Parametro de tipo out donde se va a guardar el resumen</param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen) {
            MostrarDocumentosPorEstado(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos de un escaner con el estado en revision.
        /// </summary>
        /// <param name="e">Escaner del que se van a mostrar los documentos</param>
        /// <param name="extension">Parametro de tipo out donde se va a guardar la extension</param>
        /// <param name="cantidad">Parametro de tipo out donde se va a guardar la cantidad</param>
        /// <param name="resumen">Parametro de tipo out donde se va a guardar el resumen</param>
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen) {
            MostrarDocumentosPorEstado(e, Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos de un escaner con el estado en terminado.
        /// </summary>
        /// <param name="e">Escaner del que se van a mostrar los documentos</param>
        /// <param name="extension">Parametro de tipo out donde se va a guardar la extension</param>
        /// <param name="cantidad">Parametro de tipo out donde se va a guardar la cantidad</param>
        /// <param name="resumen">Parametro de tipo out donde se va a guardar el resumen</param>
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen) {
            MostrarDocumentosPorEstado(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}
