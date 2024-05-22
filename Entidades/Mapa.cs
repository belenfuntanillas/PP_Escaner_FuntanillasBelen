using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class Mapa : Documento {
        private int ancho;
        private int alto;

        public Mapa(string titulo, string autor, int anio, string numNormalizado,string barcode, int ancho, int alto) : base(titulo, autor, anio, numNormalizado, barcode) {
            this.ancho = ancho;
            this.alto = alto;
        }

        public int Ancho { get => ancho; }
        public int Alto { get => alto; }
        public int Superficie { get => ancho * alto; }


        public static bool operator ==(Mapa mapa1, Mapa mapa2) {
            if(mapa1.Barcode == mapa2.Barcode || (mapa1.Titulo == mapa2.Titulo && mapa1.Autor == mapa2.Autor && mapa1.Anio == mapa2.Anio && mapa1.Superficie == mapa2.Superficie)) {
                return true;
            }

            return false;
        }

        public static bool operator !=(Mapa mapa1, Mapa mapa2) {
            return !(mapa1 == mapa2);
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Titulo: {this.Titulo}");
            sb.AppendLine($"Autor: {this.Autor}");
            sb.AppendLine($"Año: {this.Anio.ToString()}");
            sb.AppendLine($"Cod. de barras: {this.Barcode}");
            sb.AppendLine($"Superficie: {this.Alto} * {this.Ancho} = {this.Superficie} cm2.");

            return sb.ToString();
        }
    }
}
