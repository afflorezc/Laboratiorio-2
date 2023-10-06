using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboratiorio_2
{
    /*
     * Clase para el manejo y operaciones básicas entre rectas. Tiene como atributos, la pendiente
     * y el intercepto como valores númericos. La forma textual de la ecuación obtenida mediante el
     * ingreso del usuario y una instancia de la ControlString para el manejo de las cadenas de texto
     * para encontrar los parametros basicos como pendiente e intercepto
     */
    internal class Rectas
    {
        public double pendiente;
        public double intercepto;
        public String textoRecta ="";
        ControlString control = new ControlString();
        
        /*
         * Método que evalua si la forma en que se ha ingresado la recta es la forma canónica
         * y = mx +b y devuelve el booleano true. En caso contrario devuelve false
         */
        public bool formaCanonica()
        {
            String izquierdo = control.ladoIzquierdo(textoRecta);
            if(control.hayNumeros(izquierdo))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
         * Método que utiliza la forma textual asignada a la recta y los métodos apropiados de
         * la clase ControlString para asignar los valores respectivos para la pendiente y el 
         * intercepto de la recta
         */
        public void setParametros()
        {
            bool esCanonica = this.formaCanonica();
            pendiente = control.getPendiente(textoRecta, esCanonica);
            intercepto = control.getIntercepto(textoRecta, pendiente, esCanonica);
        }

        /*
         * Función Básica que asigna el texto que representa la ecuación de la recta tal como 
         * ha sido ingresada por el usuario
         */
        public void setTexto(String texto)
        {
            textoRecta = texto;
        }

        /*
         * Método que de acuerdo a los parametros asignados a dos diferentes rectas encuentra
         * la solución del sistema. Devuelve los valores especiales NaN y positiveInfinite para
         * el manejo de los casos en que las rectas son iguales o cuando las rectas son paralelas
         * tiene como paramétro un objeto de tipo Rectas que representa la segunda recta
         */

        public double resolver(Rectas recta2)
        {
            double xSol = 0.0;
            double m1 = this.pendiente;
            double b1 = this.intercepto;
            double m2 = recta2.pendiente;
            double b2 = recta2.intercepto;

            /*
             * Las rectas son paralelas o la misma recta, se devuelve el valor especial 
             * NaN para reconocer en el programa principal que se trata de la misma recta
             * o el valor PositiveInfinity para representar el caso en que las rectas son
             * paralelas
             */
            if(m1 == m2)
            {
                if(b1 == b2)
                {
                    return double.NaN;
                }
                else
                {
                    return double.PositiveInfinity;
                }
            }
            else
            {
                xSol = (b2 - b1) / (m1 - m2);
            }
            return xSol;
        }

        /*
         * Metodo evaluar, Obtiene el valor de la coordenada y de acuerdo al paramétro de ingreso el
         * cual es un valor númerico de tipo doble que corresponde al valor particular de la variable
         * independiente x
         */
        public double evaluar(double x)
        {
            return pendiente * x + intercepto;
        }

        /*
         * Metodo para reiniciar los valores de la recta para tener la instancia del objeto de tipo 
         * Rectas preparada para un nuevo problema
         */
        public void reset()
        {
            pendiente = 0.0;
            intercepto = 0.0;
            textoRecta = "";
        }
    }
}
