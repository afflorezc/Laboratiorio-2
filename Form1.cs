namespace Laboratiorio_2
{
    /*
     * Programa principal de la interfaz gráfica donde se da manejo a los diferentes eventos
     * básicos sobre varios elementos de interacción:
     * 1. Cajas de texto donde el usuario ingresa cada una de las ecuaciones deseadas
     * 2. Botones para ejecutar las funciones de limpiar el entorno para trabajo nuevo
     * y para dar solución al sistema
     */
    public partial class Form1 : Form
    {
        /*
         * Variables globales para el manejo de la información. Se definen varias cadenas de 
         * texto para almacenar las ecuaciones de las rectas ingresadas por el usuario,
         * y el texto donde se mostraran los resultados del calculo.
         * Se definen las variables númericas que recibiran los resultados de los calculos
         * y una instancia de la clase ControlString para poder utilizar los procedimientos
         * definidos en dicha clase cuyo proposito es realizar diferentes operaciones básicas sobre
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
         * Manejo de eventos sobre la caja de texto uno, la cual recibirá la información de la
         * ecuación de la primera de las rectas
         */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*
             * Se controla el ingreso del texto con función auxiliar y se actualiza en la propiedad
             * de texto de la caja de texto numero uno
             */
            String textoMostrar = controlEscritura(textBox1.Text);
            rectaUno = textoMostrar;
            textBox1.Text = textoMostrar;
            int n = textBox1.Text.Length;
            textBox1.SelectionStart = n;

        }

        /*
         * Manejo del evento, click al botón solucionar. Este método ejecuta comprobaciones finales
         * sobre el texto ingresado para cada una de las rectas, una vez obtenidas formas apropiadas
         * para dichos textos se utiliza el objeto de rectas para actualizar sus parametros
         * y calcular la solución del sistema si existe. Se informa al usuario de la solución obtenida
         */

        private void botonSol_Click(object sender, EventArgs e)
        {
            /*
             * Si el usuario no ha ingresado información de alguna o las dos rectas, se le informa
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
            if(solLabel.Text != "Solución:")
            {
                solLabel.Text = "Solución:";
            }
            /*
             * Se comprueba si es necesario adicionar un cero como decimal, en caso que se halla
             * dejado como ultimo carácter una coma, se revisa luego si hace falta cerrar el parentesis
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
                textoSolucion = "El sistema no tiene solución pues las rectas son paralelas";
            }
            else
            {
                ySol = lineaUno.evaluar(xSol);
                textoSolucion = $"La solución del sistema de ecuaciones es el punto: ( {xSol} , {ySol} )";
            }
            solLabel.Text = solLabel.Text + "\n" + textoSolucion;
           
        }

        /*
         * Manejo de evento al presionar el boton nuevo. Este boton esta diseñado para borrar
         * toda la información suministrada y obtenida hasta el momento y reiniciar un problema
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
            textoSolucion = "Solución:";
            solLabel.Text = textoSolucion;
        }

        /*
         * Manejo de eventos sobre la caja de texto dos, la cual recibirá la información de la
         * ecuación de la segunda de las rectas
         */
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            /*
             * Se controla el ingreso del texto con función auxiliar y se actualiza en la propiedad
             * de texto de la caja de texto número dos
             */
            String textoMostrar = controlEscritura(textBox2.Text);
            rectaDos = textoMostrar;
            textBox2.Text = textoMostrar;
            int n = textBox2.Text.Length;
            textBox2.SelectionStart = n;
        }

        /*
         * Método auxiliar que limita la entrada del texto sobre las cajas de texto de modo que
         * solo se escriban las ecuaciones en los formatos adecuados. E paramétro de entrada
         * es el texto que se recibe mediante las cajas de texto
         */

        private String controlEscritura(String texto)
        {
            /* 
             * se retorna la variable de textoMostrar que será asociada a la 
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
                 * más, un signo menos o un signo igual.
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
                     * Se controla el ingreso de texto no apropiado de acuerdo a la posición
                     * actual en relación con la anterior y el texto escrito en su totalidad
                     * hasta el momento. Solo se permite el ingreso de valores númericos
                     * la coma como separador decimal cuando sea apropiado adicionar, la letra x
                     * que representa la variable independiente, signos en sus posiciones adecuadas
                     * y parentesis, también en posiciones adecuadas
                     */

                    String penultChar = control.penultimoCaracter(texto);
                    textoMostrar = control.borrarUltChar(texto);

                    /*
                     * Después de ingresar un signo solo se puede recibir un valor númerico, 
                     * un parentesis que abre o un signo negativo si se esta comenzando el lado
                     * derecho de la ecuación pero solamente en el caso de que se desea escribir
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
                     * Después de una coma (separador decimal) solo se puede recibir un valor númerico
                     * pues su utilización implica un valor decimal
                     */

                    else if(penultChar == ",")
                    {
                        if (control.esDigito(ultChar))
                        {
                            textoMostrar = texto;
                        }
                    }

                    /*
                     * Después de ingresar la variable x, solo se permite adiccionar un signo 
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
                     * Cuando la posicion previa de la cadena de texto es númerica esta puede continuar
                     * recibiendo digitos, separador decimal si no existe para el mismo número, signo
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
                     * pendiente, el unico valor posible a escribir a continuación es la variable x
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