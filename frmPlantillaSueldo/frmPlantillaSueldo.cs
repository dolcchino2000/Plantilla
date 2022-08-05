using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmPlantillaSueldo
{
    public partial class frmPlantillaSueldo : Form
    {

        double neto;
     

        int cVentas, cMarketing,cLogistica, cPrestamos;
        double aVentas, aMarketing,aLogistica,aPrestamos;

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
        }
        public frmPlantillaSueldo()
        {
            InitializeComponent();
        }

        private void cbarea_SelectedIndexChanged(object sender, EventArgs e)
        {
      
           
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta seguro de salir?", "Planilla", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes) this.Close();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            string hijo = txthijo.Text;
            string nombre = txtEmpleado.Text;
            string area = cbarea.Text;
            string tiempo = timevox.Text;
            string condicion = cbCondicion.Text;
            double descuentomovi=0;
            if (neto>1000) descuentomovi = neto*0.10;
            double descu = 0;
            descu = neto * 0.120;

            double total = 0;
            total = neto + descuentomovi -descu;
            string asignacion = txtAsignacion.Text;

            // conteosyacumulaciones

            switch (area)
            {
                case "Ventas":
                    cVentas++;

                    aVentas += neto;

                    break;
                case "Marketing":
                    cMarketing++;
                    
                    break;
                case "Logistica":
                    cLogistica++;
                     
                    break;
                case "Prestamos":
                    cPrestamos++;
                   
                    break;
            }


            ListViewItem fila = new ListViewItem(nombre);
            fila.SubItems.Add(hijo);
            fila.SubItems.Add(area);
            
            fila.SubItems.Add(condicion);
            fila.SubItems.Add(tiempo);
            fila.SubItems.Add(descuentomovi.ToString("C"));
            fila.SubItems.Add(neto.ToString(""));
            fila.SubItems.Add(descu.ToString("C"));
            fila.SubItems.Add(asignacion);
            fila.SubItems.Add(total.ToString("C"));
            lvEmpleado.Items.Add(fila);
            // Imprimiendo las estadisticas
            lvEstadistica.Items.Clear();
            string[] elementosFila = new string[3];
            ListViewItem row;
            // Impresion de los datos del Jefe
            elementosFila[0] = "Total de Personal en el Area de Ventas";
            elementosFila[1] = cVentas.ToString();
            
            row = new ListViewItem(elementosFila);
            lvEstadistica.Items.Add(row);
            // Impresion de los datos del supervis
            elementosFila[0] = "Total de Personal en el Area de Marketing";
            elementosFila[1] = cMarketing.ToString();
            
            row = new ListViewItem(elementosFila);
            lvEstadistica.Items.Add(row);
            elementosFila[0] = "Total de Personal en el Area de Logistica";
            elementosFila[1] = cLogistica.ToString();
           
            row = new ListViewItem(elementosFila);
            lvEstadistica.Items.Add(row);
            elementosFila[0] = "Total de Personal en el Area de Prestamos";
            elementosFila[1] = cPrestamos.ToString();
            
            row = new ListViewItem(elementosFila);
            lvEstadistica.Items.Add(row);
            // Impresion de los datos del Vendedor


            // Limpiando los controles
            txthijo.Clear();
            txtEmpleado.Clear();
            cbCondicion.SelectedIndex = 1;
            lblSueldoneto.Text = (0).ToString("C");
            txtEmpleado.Focus();
        }

        

        private void cbCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string condicion = cbCondicion.Text;
            switch (condicion)
            {
                case "Personal": neto = 2500; break;
                case "Comision": neto = 1100; break;


            }
            lblSueldoneto.Text = neto.ToString("C");
        }

        private void frmPlanillaSueldo_load(object sender, EventArgs e)
        {
            lblFechas.Text = DateTime.Now.ToString("d");
        }

         

    }

}
