using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taller
{
    public partial class PrestacionServicios : Form
    {
        public PrestacionServicios()
        {
            InitializeComponent();
            this.ActiveControl = txtNombrePaciente;
            RbFemenino.Checked = true;
            cboTipoDocumento.SelectedIndex = 0;
            cboRango.SelectedIndex = 0;
            txtCostoServicio.Text = "0";
        }

       
        private void txtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {
            cboTipoDocumento.Enabled = true;
            RbFemenino.Enabled = true;
            RbMasculino.Enabled = true;
            txtNombrePaciente.Enabled = true;
            cboRango.Enabled = true;
            txtCostoServicio.Enabled = true;
            erpMensaje.Clear();
        }

        private void txtNombrePaciente_TextChanged(object sender, EventArgs e)
        {
            cboTipoDocumento.Enabled = true;
            RbFemenino.Enabled = true;
            RbMasculino.Enabled = true;
            txtNumeroDocumento.Enabled = true;
            cboRango.Enabled = true;
            txtCostoServicio.Enabled = true;
            erpMensaje.Clear();
        }

        private void txtCostoServicio_TextChanged(object sender, EventArgs e)
        {
            cboTipoDocumento.Enabled = true;
            RbFemenino.Enabled = true;
            RbMasculino.Enabled = true;
            txtNombrePaciente.Enabled = true;
            txtNumeroDocumento.Enabled = true;
            cboRango.Enabled = true;
            erpMensaje.Clear();
        }

       

        private void txtNombrePaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sólo permitir ingresar Letras 
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else
            { e.Handled = true; }


        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sólo permitir ingresar números 
            if (Char.IsNumber(e.KeyChar))
            { e.Handled = false; }

            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }

            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else
            { e.Handled = true; }

        }

        private void txtCostoServicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sólo permitir ingresar números 
            if (Char.IsNumber(e.KeyChar))
            { e.Handled = false; }

            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }

            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else
            { e.Handled = true; }
        }

        private void btnCalcularPago_Click_1(object sender, EventArgs e)
        {
            double Pago = 0, Costo = 0;
            Costo = Double.Parse(txtCostoServicio.Text);
            if (cboRango.Text == "A")
            {
                Pago = Costo - (Costo * 0.3);
            }
            if (cboRango.Text == "B")
            {
                Pago = Costo - (Costo * 0.2);
            }
            if (cboRango.Text == "C")
            {
                Pago = Costo - (Costo * 0.1);
            }
            if (Pago >= 0)
            {

                DialogResult result = MessageBox.Show("Paciente: " + txtNombrePaciente.Text + "\nTotal a Pagar: $ " + Pago, "Resultado", MessageBoxButtons.OK);

                if (result.ToString() == "Confirmado")
                {
                    RbFemenino.Checked = true;
                    cboTipoDocumento.SelectedIndex = 0;
                    txtNombrePaciente.Text = string.Empty;
                    cboRango.SelectedIndex = 0;
                    txtNumeroDocumento.Text = string.Empty;
                    txtCostoServicio.Text = "0";
                }
            }
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            // VALIDAR NOMBRE
            if (string.IsNullOrEmpty(txtNombrePaciente.Text))
            {
                erpMensaje.SetError(txtNombrePaciente, "El campo de texto Nombre esta Vacio");
                MessageBox.Show("El campo de texto Nombre esta Vacio");

                cboTipoDocumento.Enabled = false;
                RbFemenino.Enabled = false;
                RbMasculino.Enabled = false;
                txtNumeroDocumento.Enabled = false;
                cboRango.Enabled = false;
                txtCostoServicio.Enabled = false;

                return;

            }


            if (string.IsNullOrEmpty(cboTipoDocumento.Text))
            {
                //TODO: VALIDAR EL TIPO DE DOCUMENTO
                erpMensaje.SetError(cboTipoDocumento, "¿Cual es su Tipo de Documento?");
                MessageBox.Show("¿Cual es su Tipo de Documento?");

                return;
            }
            if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
            {
                cboTipoDocumento.Enabled = false;
                RbFemenino.Enabled = false;
                RbMasculino.Enabled = false;
                txtNombrePaciente.Enabled = false;
                cboRango.Enabled = false;
                txtCostoServicio.Enabled = false;
                //TODO: VALIDAR NUMERO DE DOCUMENTO
                erpMensaje.SetError(txtNumeroDocumento, "Ingrese el numero de Documento");
                MessageBox.Show("Ingrese el numero de Documento");
                return;
            }


            if (cboTipoDocumento.Text.Equals("NUIP"))
            {
                long Low = Int64.Parse(txtNumeroDocumento.Text);

                if ((Low <= 1000000000) || (Low >= 9999999999))
                {
                    cboTipoDocumento.Enabled = false;
                    RbFemenino.Enabled = false;
                    RbMasculino.Enabled = false;
                    txtNombrePaciente.Enabled = false;
                    cboRango.Enabled = false;
                    txtCostoServicio.Enabled = false;
                    erpMensaje.SetError(txtNumeroDocumento, "ERROR. El valor No se encuentra en el Rango permitido");
                    MessageBox.Show("Error. El valor No se encuentra en el Rango permitido");
                    return;
                }
            }


            if (string.IsNullOrEmpty(cboRango.Text))
            {
                erpMensaje.SetError(cboRango, "El campo de Rango esta Vacio");
                MessageBox.Show("El campo de Rango esta Vacio");
                return;
            }
            if (string.IsNullOrEmpty(txtCostoServicio.Text))
            {
                cboTipoDocumento.Enabled = false;
                RbFemenino.Enabled = false;
                RbMasculino.Enabled = false;
                txtNombrePaciente.Enabled = false;
                cboRango.Enabled = false;
                txtNumeroDocumento.Enabled = false;
                erpMensaje.SetError(txtCostoServicio, "Ingrese el Costo de Servicio");
                MessageBox.Show("Ingrese el Costo de Servicio");
                return;
            }



            MessageBox.Show("El paciente fue Registrado Exitosamente");

            //Limpiamos cuadros de texto
            txtNombrePaciente.Text = "";
            txtNumeroDocumento.Text = "";
            cboRango.Text = "";
            txtCostoServicio.Text = "";
            cboTipoDocumento.Text = "";
            RbFemenino.Text = "";
            RbMasculino.Text = "";

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PrestacionServicios_Load(object sender, EventArgs e)
        {

        }
    }
}
