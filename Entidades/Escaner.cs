using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class Escaner {
        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;

        public List<Documento> ListaDocumentos { get => listaDocumentos; }
        public Departamento Locacion { get => locacion; }
        public string Marca { get => marca; }
        public TipoDoc Tipo { get => tipo; }

        public Escaner(string marca, TipoDoc tipo) {
            this.listaDocumentos = new List<Documento>();
            this.marca = marca;
            this.tipo = tipo;

            if(tipo == TipoDoc.libro) {
                this.locacion = Departamento.procesosTecnicos;
            } else {
                this.locacion = Departamento.mapoteca;
            }
        }

        public static bool operator ==(Escaner e, Documento d) {
            if(d is Libro && e.tipo == TipoDoc.libro) {
                foreach (Libro doc in e.listaDocumentos) {
                    if (doc == (Libro) d) {
                        return true;
                    }
                }
            } else if(d is Mapa && e.tipo == TipoDoc.mapa) {
                foreach (Mapa doc in e.listaDocumentos) {
                    if (doc == (Mapa) d) {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator !=(Escaner e, Documento d) {
            return !(e == d);
        }
            
        public static bool operator +(Escaner e, Documento d) {
            if(e != d && d.Estado == Documento.Paso.Inicio && ((d is Libro && e.tipo == TipoDoc.libro) || (d is Mapa && e.tipo == TipoDoc.mapa))) {
                d.AvanzarEstado();
                e.listaDocumentos.Add(d);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Si el documento esta en el escaner, avanza el estado del documento
        /// </summary>
        /// <param name="d">Documento a avanzar el estado</param>
        /// <returns>true si se avanzo de estado, false si no</returns>
        public bool CambiarEstadoDocumento(Documento d) {
            // Si el documento esta en el escaner, avanzar estado
            if(this == d) {
                return d.AvanzarEstado();
            }

            return false;
        }

        public enum TipoDoc {
            libro,
            mapa
        }

        public enum Departamento {
            nulo,
            mapoteca,
            procesosTecnicos,
        }
    }
}
