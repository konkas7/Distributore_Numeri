using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributore_Numeri
{
    public class Distributore
    {
        private string id;
        private string ditta;
        private int numPartenza;
        private int numCorrente;
        private int massimo;
        private Func<int, int> funzioneSuccessivo;
        private List<int> bigliettiPresi = new List<int>();

        public Distributore(string id, string ditta, int numPartenza, int numCorrente, int massimo, Func<int, int> funzioneSuccessivo)
        {
            this.id = id;
            this.ditta = ditta;
            this.numPartenza = numPartenza;
            this.numCorrente = numCorrente;
            this.massimo = massimo;
            this.funzioneSuccessivo = funzioneSuccessivo;
        }

        public int NumeroCorrente()
        {
            return numCorrente;
        }

        public int PrendiBiglietto()
        {
            int numero = numCorrente;
            bigliettiPresi.Add(numero);
            numCorrente = funzioneSuccessivo(numCorrente);
            return numero;
        }

        public void Reset()
        {
            numCorrente = numPartenza;
            bigliettiPresi.Clear();
        }

        public bool VerificaSequenza(int[] sequenza)
        {
            int numCorrente = numPartenza;
            foreach (int numero in sequenza)
            {
                if (numero != numCorrente)
                {
                    return false;
                }
                numCorrente = funzioneSuccessivo(numCorrente);
            }
            return true;
        }

        public int[] OttieniPresi()
        {
            return bigliettiPresi.ToArray();
        }
    }

}
