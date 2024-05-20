using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class Libro : Documento {
        private int numPaginas;

        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas) : base(titulo, autor, anio, numNormalizado, barcode) {
            this.numPaginas = numPaginas;
        }

        public string ISBN { get => this.NumNormalizado; }
        public int NumPaginas { get => numPaginas; }

        public static bool operator ==(Libro libro1, Libro libro2) {
            if(libro1.Barcode == libro2.Barcode || libro1.ISBN == libro2.ISBN || (libro1.Titulo == libro2.Titulo && libro1.Autor == libro2.Autor)) {
                return true;
            }

            return false;
        }
        
        public static bool operator !=(Libro libro1, Libro libro2) {
            return !(libro1 == libro2);
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine($"Numero de paginas: {this.numPaginas.ToString()}.");

            return sb.ToString();
        }
    }
}
