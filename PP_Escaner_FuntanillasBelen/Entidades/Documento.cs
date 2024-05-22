using System.Text;

namespace Entidades {
    public abstract class Documento{
        private int anio;
        private string autor;
        private string barcode;
        private EPaso estado;
        private string numNormalizado;
        private string titulo;

        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode) {
            this.titulo = titulo;
            this.anio = anio;
            this.autor = autor;
            this.barcode = barcode;
            this.numNormalizado = numNormalizado;
            this.estado = EPaso.Inicio;
        }

        public int Anio { get => anio; }
        public string Autor { get => autor; }
        public string Barcode { get => barcode; }
        public EPaso Estado { get => estado; }
        protected string NumNormalizado { get => numNormalizado; }
        public string Titulo { get => titulo; }


        /// <summary>
        /// Avanza el estado del documento. Si ya estaba en Terminado, no hace nada.
        /// </summary>
        /// <returns>true si se avanzo el estado, false si el estado ya era Terminado</returns>
        public bool AvanzarEstado() {
            if(this.estado == EPaso.Terminado) {
                return false;
            }

            this.estado = (EPaso) (((int)this.estado) + 1);

            return true;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Titulo: {this.Titulo}");
            sb.AppendLine($"Autor: {this.Autor}");
            sb.AppendLine($"Año: {this.Anio.ToString()}");
            sb.AppendLine($"ISBN: {this.NumNormalizado}");
            sb.AppendLine($"Cod. de barras: {this.Barcode}");

            return sb.ToString();
        }
    }


}
