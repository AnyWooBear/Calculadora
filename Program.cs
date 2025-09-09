using System;
using System.Windows.Forms;
using System.Drawing;

namespace CalculatorApp;
partial class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        //Crear ventana 
        Form ventana = new Form();
        ventana.Text = "Calculadora!";
        ventana.Width = 500;
        ventana.Height = 400;
        ventana.StartPosition = FormStartPosition.CenterScreen;

        //Opciones 
        Label etiqueta = new Label();
        etiqueta.Text = "Elige entre\nSuma / Resta / Mult / Div";
        etiqueta.Font = new Font("Arial", 18, FontStyle.Bold);
        etiqueta.ForeColor = Color.DarkBlue;
        etiqueta.AutoSize = true;
        etiqueta.Location = new Point(120, 30);

        //botones
        Button btnSuma = new Button();
        btnSuma.Text = "Suma";
        btnSuma.Font = new Font("Arial", 14);
        btnSuma.Size = new Size(100, 40);
        btnSuma.Location = new Point(20, 100);

        Button btnResta = new Button();
        btnResta.Text = "Resta";
        btnResta.Font = new Font("Arial", 14);
        btnResta.Size = new Size(100, 40);
        btnResta.Location = new Point(130, 100);

        Button btnMult = new Button();
        btnMult.Text = "Multi";
        btnMult.Font = new Font("Arial", 14);
        btnMult.Size = new Size(100, 40);
        btnMult.Location = new Point(240, 100);

        Button btnDiv = new Button();
        btnDiv.Text = "Div";
        btnDiv.Font = new Font("Arial", 14);
        btnDiv.Size = new Size(120, 50);
        btnDiv.Location = new Point(350, 100);

        // Etiquetas para los TextBox
        Label lblNum1 = new Label();
        lblNum1.Text = "Número 1:";
        lblNum1.Location = new Point(20, 170);
        lblNum1.AutoSize = true;

        TextBox txtNum1 = new TextBox();
        txtNum1.Location = new Point(100, 170);
        txtNum1.Width = 100;
        txtNum1.Text = ""; // Valor inicial vacío

        Label lblNum2 = new Label();
        lblNum2.Text = "Número 2:";
        lblNum2.Location = new Point(220, 170);
        lblNum2.AutoSize = true;

        TextBox txtNum2 = new TextBox();
        txtNum2.Location = new Point(300, 170);
        txtNum2.Width = 100;
        txtNum2.Text = ""; // Valor inicial vacío

        // Resultado final
        Label resultadoFinal = new Label();
        resultadoFinal.Text = "Resultado:";
        resultadoFinal.Font = new Font("Arial", 20, FontStyle.Bold);
        resultadoFinal.ForeColor = Color.DarkRed;
        resultadoFinal.AutoSize = true;
        resultadoFinal.Location = new Point(150, 250);

        // Eventos de los botones
        btnSuma.Click += (s, e) => CalculateResult(txtNum1, txtNum2, resultadoFinal, Addition);
        btnResta.Click += (s, e) => CalculateResult(txtNum1, txtNum2, resultadoFinal, Subtraction);
        btnMult.Click += (s, e) => CalculateResult(txtNum1, txtNum2, resultadoFinal, Multiplication);
        btnDiv.Click += (s, e) => CalculateResult(txtNum1, txtNum2, resultadoFinal, Division);

        // Agregar controles a la ventana
        ventana.Controls.Add(etiqueta);
        ventana.Controls.Add(btnSuma);
        ventana.Controls.Add(btnResta);
        ventana.Controls.Add(btnMult);
        ventana.Controls.Add(btnDiv);
        ventana.Controls.Add(lblNum1);
        ventana.Controls.Add(txtNum1);
        ventana.Controls.Add(lblNum2);
        ventana.Controls.Add(txtNum2);
        ventana.Controls.Add(resultadoFinal);

        // Mostrar ventana
        Application.Run(ventana);
    }
    
    //lógica de cálculo
    private static void CalculateResult(TextBox txt1, TextBox txt2, Label resultLabel, Func<double, double, double> operation)
    {
        if (double.TryParse(txt1.Text, out double num1) && double.TryParse(txt2.Text, out double num2))
        {
            if (operation == Division && num2 == 0)
            {
                resultLabel.Text = "División entre 0!";
            }
            else
            {
                resultLabel.Text = "Resultado: " + operation(num1, num2);
            }
        }
        else
        {
            resultLabel.Text = "Entrada no válida.";
        }
    }

    public static double Addition(double num1, double num2)
    {
        return num1 + num2;
    }

    public static double Subtraction(double num1, double num2)
    {
        return num1 - num2;
    }

    public static double Multiplication(double num1, double num2)
    {
        return num1 * num2;
    }

    public static double Division(double num1, double num2)
    {
        return num1 / num2;
    }

}