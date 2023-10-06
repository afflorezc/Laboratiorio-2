namespace Laboratiorio_2
{
    /*
     * Programa principal de la interfaz gr�fica donde se da manejo a los diferentes eventos
     * b�sicos sobre varios elementos de interacci�n:
     * 1. Cajas de texto donde el usuario ingresa cada una de las ecuaciones deseadas
     * 2. Botones para ejecutar las funciones de limpiar el entorno para trabajo nuevo
     * y para dar soluci�n al sistema
     */
    public partial class Form1 : Form
    {
        /*
         * Variables globales para el manejo de la informaci�n. Se definen varias cadenas de 
         * texto para almacenar las ecuaciones de las rectas ingresadas por el usuario,
         * y el texto donde se mostraran los resultados del calculo.
         * Se definen las variables n�mericas que recibiran los resultados de los calculos
         * y una instancia de la clase ControlString para poder utilizar los procedimientos
         * definidos en dicha clase cuyo proposito es realizar diferentes operaciones b�sicas sobre
         * cadenas de texto
         */
        String rectaUno = "";
        String rectaDos = "";
        String textoSolucion = "";
        Rectas lineaUno = new Rectas();
        Rectas lineaDos = new Rectas();
        double xSol = 0.0;
        double ySol = 0.0;
        ControlString control = new ControlString();
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Manejo de eventos sobre la caja de texto uno, la cual recibir� la informaci�n de la
         * ecuaci�n de la primera de las rectas
         */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*
             * Se controla el ingreso del texto con funci�n auxiliar y se actualiza en la propiedad
             * de texto de la caja de texto numero uno
             */
            String textoMostrar = controlEscritura(textBox1.Text);
            rectaUno = textoMostrar;
            textBox1.Text = textoMostrar;
            int n = textBox1.Text.Length;
            textBox1.SelectionStart = n;

        }

        /*
         * Manejo del evento, click al bot�n solucionar. Este m�todo ejecuta comprobaciones finales
         * sobre el texto ingresado para cada una de las rectas, una vez obtenidas formas apropiadas
         * para dichos textos se utiliza el objeto de rectas para actualizar sus parametros
         * y calcular la soluci�n del sistema si existe. Se informa al usuario de la soluci�n obtenida
         */

        private void botonSol_Click(object sender, EventArgs e)
        {
            /*
             * Si el usuario no ha ingresado informaci�n de alguna o las dos rectas, se le informa
             * que se tiene un error en las entradas
             */
            if(control.esVacia(rectaUno) || control.esVacia(rectaDos))
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                String mensaje = "Error! No ha ingresado las ecuaciones completas";
                String caption = "Error en las entradas";
                DialogResult result;
                result = MessageBox.Show(mensaje, caption, buttons);
                return;
            }
            if(solLabel.Text != "Soluci�n:")
            {
                solLabel.Text = "Soluci�n:";
            }
            /*
             * Se comprueba si es necesario adicionar un cero como decimal, en caso que se halla
             * dejado como ultimo car�cter una coma, se revisa luego si hace falta cerrar el parentesis
             * cuando se trabaja en formato de punto pendiente. Se revisa el separador decimal
             * para un trabajo correcto posterior
             */
            rectaUno = control.addDecimal(rectaUno);
            rectaDos = control.addDecimal(rectaDos);
            rectaUno = control.addParentesis(rectaUno);
            rectaDos = control.addParentesis(rectaDos);
            textBox1.Text = rectaUno;
            textBox2.Text = rectaDos;
            rectaUno = control.sepDecimal(rectaUno);
            rectaDos = control.sepDecimal(rectaDos);
            lineaUno.setTexto(rectaUno);
            lineaDos.setTexto(rectaDos);
            lineaUno.setParametros();
            lineaDos.setParametros();
            xSol = lineaUno.resolver(lineaDos);
            
            if (double.IsNaN(xSol))
            {
                textoSolucion = "El sistema tiene soluciones infinitas, puesto que las dos rectas son la misma";
            }
            else if (xSol == double.PositiveInfinity)
            {
                textoSolucion = "El sistema no tiene soluci�n pues las rectas son paralelas";
            }
            else
            {
                ySol = lineaUno.evaluar(xSol);
                textoSolucion = $"La soluci�n del sistema de ecuaciones es el punto: ( {xSol} , {ySol} )";
            }
            solLabel.Text = solLabel.Text + "\n" + textoSolucion;
           
        }

        /*
         * Manejo de evento al presionar el boton nuevo. Este boton esta dise�ado para borrar
         * toda la informaci�n suministrada y obtenida hasta el momento y reiniciar un problema
         * nuevo
         */

        private void botonNuevo_Click(object sender, EventArgs e)
        {
            lineaUno.reset();
            lineaDos.reset();
            rectaUno = "";
            rectaDos = "";
            textBox1.Text = rectaUno;
            textBox2.Text = rectaDos;
            textoSolucion = "Soluci�n:";
            solLabel.Text = textoSolucion;
        }

        /*
         * Manejo de eventos sobre la caja de texto dos, la cual recibir� la informaci�n de la
         * ecuaci�n de la segunda de las rectas
         */
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            /*
             * Se controla el ingreso del texto con funci�n auxiliar y se actualiza en la propiedad
             * de texto de la caja de texto n�mero dos
             */
            String textoMostrar = controlEscritura(textBox2.Text);
            rectaDos = textoMostrar;
            textBox2.Text = textoMostrar;
            int n = textBox2.Text.Length;
            textBox2.SelectionStart = n;
        }

        /*
         * M�todo auxiliar que limita la entrada del texto sobre las cajas de texto de modo que
         * solo se escriban las ecuaciones en los formatos adecuados. E param�tro de entrada
         * es el texto que se recibe mediante las cajas de texto
         */

        private String controlEscritura(String texto)
        {
            /* 
             * se retorna la variable de textoMostrar que ser� asociada a la 
             * variable de texto de las cajas de texto
             */

            String textoMostrar = "";
            if (control.esVacia(texto))
            {
                return textoMostrar;
            }

            // el formato solo permite iniciar el texto con la letra y
            if (control.esPrimerCaracter(texto))
            {
                if (texto == "y")
                {
                    textoMostrar = texto;
                }
                return textoMostrar;
            }
            else
            {
                /* 
                 * Se hace manejo de los siguientes caracteres del texto de acuerdo a las
                 * diferentes condiciones del texto
                 */
                String ultChar = control.ultCaracter(texto);
                ultChar = ultChar.ToLower();

                /*
                 * El segundo caracter solo puede ser de tipo signo, en este caso puede ser un signo
                 * m�s, un signo menos o un signo igual.
                 */
                if (control.esSegundoCaracter(texto))
                {
                    if(control.esSigno(ultChar))
                    {
                        textoMostrar = texto;
                    }
                    else
                    {
                        textoMostrar = control.borrarUltChar(texto);
                    }
                    return textoMostrar;
                }
                else
                {
                    /*
                     * Se controla el ingreso de texto no apropiado de acuerdo a la posici�n
                     * actual en relaci�n con la anterior y el texto escrito en su totalidad
                     * hasta el momento. Solo se permite el ingreso de valores n�mericos
                     * la coma como separador decimal cuando sea apropiado adicionar, la letra x
                     * que representa la variable independiente, signos en sus posiciones adecuadas
                     * y parentesis, tambi�n en posiciones adecuadas
                     */

                    String penultChar = control.penultimoCaracter(texto);
                    textoMostrar = control.borrarUltChar(texto);

                    /*
                     * Despu�s de ingresar un signo solo se puede recibir un valor n�merico, 
                     * un parentesis que abre o un signo negativo si se esta comenzando el lado
                     * derecho de la ecuaci�n pero solamente en el caso de que se desea escribir
                     * en el formato de punto pendiente
                     */

                    if (control.esSigno(penultChar))
                    {
                        String izquierdo = control.ladoIzquierdo(texto);
                        if (control.esDigito(ultChar) || (ultChar =="x" && !control.hayX(textoMostrar))
                               || (ultChar == "(" && control.hayNumeros(izquierdo)) || (ultChar == "-" &&
                               penultChar == "="))
                        {
                            textoMostrar= texto;
                        }
                    }

                    /*
                     * Despu�s de una coma (separador decimal) solo se puede recibir un valor n�merico
                     * pues su utilizaci�n implica un valor decimal
                     */

                    else if(penultChar == ",")
                    {
                        if (control.esDigito(ultChar))
                        {
                            textoMostrar = texto;
                        }
                    }

                    /*
                     * Despu�s de ingresar la variable x, solo se permite adiccionar un signo 
                     * correspondiente a la suma o resta.
                     */

                    else if(penultChar == "x")
                    {
                        if(control.esSigno(ultChar) && ultChar != "=")
                        {
                            String izquierdo = control.ladoIzquierdo(texto);
                            if (!control.hayNumeros(izquierdo) || control.hayParentesisIz(texto))
                            {
                                textoMostrar = texto;
                            }
                        }
                    }

                    /*
                     * Cuando la posicion previa de la cadena de texto es n�merica esta puede continuar
                     * recibiendo digitos, separador decimal si no existe para el mismo n�mero, signo
                     * igual si aun se esta escribiendo el lado izquierdo de la ecuacion: formato
                     * punto pendiente, parentesis en el lado derecho para escritura en formato de
                     * punto pendiente
                     */

                    else if (control.esDigito(penultChar))
                    {
                        String ultNum = control.borrarUltChar(texto);
                        ultNum = control.getUltNumero(ultNum);
                        if((ultChar =="=" && !control.hayIgual(textoMostrar)) 
                                || (ultChar == "(" &&  !control.hayX(textoMostrar) && 
                                control.hayIgual(textoMostrar))
                                || (ultChar == "x" && !control.hayX(textoMostrar) && 
                                control.hayIgual(textoMostrar)) | control.esDigito(ultChar)
                                || ( ultChar == ")" && control.hayIgual(textoMostrar) && 
                                control.hayParentesisIz(textoMostrar))
                                || (ultChar =="," && !control.hayComa(ultNum)))
                        {
                            textoMostrar= texto;
                        }
                    }

                    /*
                     * Si se ha abierto un parentesis se desea escribir en el formato de punto
                     * pendiente, el unico valor posible a escribir a continuaci�n es la variable x
                     */
                    else if (penultChar == "(")
                    {
                        if(ultChar == "x")
                        {
                            textoMostrar = texto;
                        }
                    }
                    return textoMostrar;
                }

            }

        }
    }
}