using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Laboratiorio_2
{
    /*
     * Clase creada con el objeto de agrupar diversas funcionalidades para el manejo de cadenas 
     * de texto o Strings
     */
    internal class ControlString
    {
        /*
         * Método que comprueba si una cadena de texto ingresada como paramétro es vacia o no
         */
        public bool esVacia(String text)
        {
            if(text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /*
         * Método para indicar si la cadena de texto entregada como parametro corresponde a unicamente
         * un caracter y por lo tanto es la primera posicion de una cadena de texto
         */
        public bool esPrimerCaracter(String text)
        {
            if(text.Length == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /*
         * Método para indicar si la cadena de texto entregada como parametro corresponde es de longitud
         * dos, es decir, se esta ingresando el segundo caracter
         */
        public bool esSegundoCaracter(String text)
        {
            if(text.Length == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * Metodo que devuelve el ultimo caracter de una cadena de texto que se pone como paramétro
         * Si la cadena es vacia se devuelve la cadena de texto vacía.
         */
        public String ultCaracter(String text)
        {
            int n = text.Length;
            if(n == 0)
            {
                return "";
            }
            else
            {
                return text.Substring(n - 1,1);
            }
        }

        /*
         * Método para transformar una cadena de texto eliminando su ultima posición
         */
        public String borrarUltChar(String texto)
        {
            int n = texto.Length;
            if(n != 0)
            {
                return texto.Substring(0, n - 1);
            }
            else
            {
                return texto;
            }
        }

        /*
         * Método que permite obtener la penultima posición de una cadena de texto que se ingresa
         * commo paramétro de la función
         */
        public String penultimoCaracter(String texto)
        {
            int n = texto.Length-1;
            if(n == 0)
            {
                return "";
            }
            else
            {
                return texto.Substring(n - 1,1);
            }
        }
        
        /*
         * Extrae de una cadena de texto que representa una ecuación, el lado izquierdo de dicha 
         * ecuación al identificar el signo igual y cortar la cadena hasta dicha posición
         */
        public String ladoIzquierdo(String texto)
        {
            int n = texto.Length;
            if(n == 0)
            {
                return "";
            }
            else
            {
                n = texto.IndexOf("=");
                if(n != -1)
                {
                    return texto.Substring(0, n);
                }
                else
                {
                    return texto;
                }
                
            }
        }

        /*
         *Método que evalua si la cadena de texto que se ingresa como parametro de la función contiene
         *valores númericos
         */
        public bool hayNumeros(String texto)
        {
            int n = texto.Length;
            if(n == 0)
            {
                return false;
            }
            else
            {
                String caracter = "";
                for(int i=0; i < n; i++)
                {
                    caracter = texto.Substring(i, 1);
                    if (esDigito(caracter))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /*
         * Método para identificar si la cadena de texto ingresada como paramétro posee parentesis
         * izquierdos o de apertura: (
         */
        public bool hayParentesisIz(String texto)
        {
            int n = texto.Length;
            if(n == 0)
            {
                return false;
            }
            else
            {
                n = texto.IndexOf("(");
                if(n != -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /*
         * Método para identificar si la cadena de texto ingresada como paramétro posee parentesis
         * derechos o de cerradura: )
         */
        public bool hayParentesisDe(String texto)
        {
            int n = texto.Length;
            if (n == 0)
            {
                return false;
            }
            else
            {
                n = texto.IndexOf(")");
                if (n != -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /*
         * Método para evaluar si un caracter que se ingresa como paramétro
         * corresponde a alguno de los signos de trabajo para las ecuaciones lineales: +, - ó el 
         * signo =
         */
        public bool esSigno(String texto)
        {
            if(texto == "-" || texto == "+" || texto == "=")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * Método para evaluar si un caracter que se ingresa como paramétro
         * corresponde es un valor númerico o digito entre 0 y 9
         */
        public bool esDigito(String texto)
        {
            int n = texto.Length;
            if(n != 1)
            {
                return false;
            }
            else
            {
                String digitos = "0123456789";
                n = digitos.IndexOf(texto);
                if(n !=-1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /*
         * Método que evalúa si el texto ingresado como paramétro, el cual representa la ecuacion de
         * una recta, ya posee la variable independiente x en alguna de sus posiciones, de modo de poder
         * controlar que solo se escriba una única vez
         */
        public bool hayX(String texto)
        {
            int index = texto.IndexOf("x");
            if (index == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
         * Método para evaluar si la cadena de texto como paramétro y la cual representa una ecuación
         * lineal, posee el signo de igualdad en esta y controlar asi que no se repita
         */
        public bool hayIgual(String texto)
        {
            int index = texto.IndexOf("=");
            if(index == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       
        /*
         * Método que dada una cadena de texto como paramétro y en la cual, su ultima posición 
         * corresponde a un digito, identifica la cadena de texto hacia atras que conformaría un 
         * único número dentro del texto representativo de una ecuación lineal
         */
        public String getUltNumero(String texto)
        {
            int n = texto.Length;
            if(n == 0 || n ==1)
            {
                return "";
            }
            String ultDigito = ultCaracter(texto);
            int index = n;
            while(esDigito(ultDigito) || ultDigito == ",")
            {
                index--;
                ultDigito = texto.Substring(index,1);
            }
            index++;
            int longitud = n - index;
            if(longitud <= 0)
            {
                return "";
            }
            else
            {
                return texto.Substring(index, longitud);
            }
        }

        /*
         * Método que examina si en un texto que se ingresa como parametro existe la separación
         * decimal utilizada por el programa; una coma, y asi controlar el no repetirla para
         * una misma seccion que representa un único número
         */
        public bool hayComa(String texto)
        {
            int n = texto.Length;
            if(n == 0)
            {
                return false;
            }
            else
            {
                int index = texto.IndexOf(",");
                if(index != -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /*
         * Método que addiciona un parentesis de cerradura al final de una cadena de texto 
         * ingresada como paramétro
         */
        public String addParentesis(String texto)
        {
            int n = texto.Length;
            if (n == 0)
            {
                return texto;
            }
            if (hayParentesisIz(texto))
            {
                if (!hayParentesisDe(texto))
                {
                    return texto += ")";
                }
            }
            return texto;
        }

        /*
         * Método que adiciona un digito decimal igual a cero a una cadena de texto que representa
         * una ecuación lineal y cuyo ultimo caracter es un separador decimal : Una coma
         */
        public String addDecimal(String texto)
        {
            int n = texto.Length;   
            if(n == 0)
            {
                return texto;
            }
            if(ultCaracter(texto) == ",")
            {
                return texto += "0";
            }
            else
            {
                return texto;
            }
        }

        /*
         * Método especifico que dada la forma textual de una ecuación lineal y la variable booleana
         * que identifica si la forma en que esta escrita es canonica o punto pendiente y devuelve
         * un valor númerico de tipo doble que corresponde a la pendiente de la recta
         */
        public double getPendiente(String textoRecta, bool canonica)
        {
            double result = 0.0;
            int inicio = 0;
            int final = 0;
            String pendiente = "";
            inicio = textoRecta.IndexOf("=") + 1;
            if (canonica)
            {
                final = textoRecta.IndexOf("x");
            }
            else
            {
                final = textoRecta.IndexOf("(");
                if(final == -1)
                {
                    final = textoRecta.IndexOf("x");
                }
            }
            if (final == -1)
            {
                return 0.0;
            }
            else
            {
                int longitud = final - inicio;
                if (longitud == 0)
                {
                    return 1.0;
                }
                else
                {
                    pendiente = textoRecta.Substring(inicio, longitud);
                    if(pendiente == "-")
                    {
                        return -1.0;
                    }
                    result = Double.Parse(pendiente);
                }
            }
            return result;
        }

        /*
         * Método especifico que dada la forma textual de una ecuación lineal y la variable booleana
         * que identifica si la forma en que esta escrita es canonica o punto pendiente y devuelve
         * un valor númerico de tipo doble que corresponde al intercepto de la recta
         */
        public double getIntercepto(String textoRecta, double pend, bool canonica)
        {
            double result = 0.0;
            int index = textoRecta.IndexOf("x")+1;
            int n = textoRecta.Length - 1;
            if (canonica)
            {
                if (0< index && index < n)
                {
                    result = double.Parse(textoRecta.Substring(index));
                }
                else if(index ==0)
                {
                    index = textoRecta.IndexOf("=") + 1;
                    result = double.Parse(textoRecta.Substring(index));
                }
            }
            else
            {
                int final = textoRecta.IndexOf(")");
                if (final == -1)
                {
                    result = 0.0; 
                }
                else
                {
                    result = double.Parse(textoRecta.Substring(index, final - index));
                }
                result = pend * result;
                String izquierdo = ladoIzquierdo(textoRecta);
                izquierdo = izquierdo.Substring(1);
                double y1 = double.Parse(izquierdo);
                result -= y1;
            }
            return result;
        }

        /*
         * Método que identifica el simbolo de separación que utiliza el sistema operativo donde se
         * ejecutará el programa y si es diferente al trabajado en el programa cambia los textos
         * que representan valores númericos o ecuaciones de recta, de modo que se utilice el
         * separador decimal apropiado
         */
        public String sepDecimal(String texto)
        {
            String separador = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if(separador != ",")
            {
                texto.Replace(",", separador);
            }
            return texto;
        }
        

    }
}
