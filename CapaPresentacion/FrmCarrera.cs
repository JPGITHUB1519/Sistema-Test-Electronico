using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaLogica;
namespace CapaPresentacion
{
    public partial class FrmCarrera : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmCarrera()
        {
            InitializeComponent();
        }

        private void FrmCarrera_Load(object sender, EventArgs e)
        {
            this.ttmensaje.SetToolTip(txtidcarrera, "Ingrese el codigo de la carrera");
            this.ttmensaje.SetToolTip(txtnombre, "Ingrese el nombre de la carrera");

            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        // Mostrar Mensaje de Confirmación

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Mensaje de Error

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // limpiar todos controles del form

        private void Limpiar()
        {
            this.txtidcarrera.Text = string.Empty;
            this.txtnombre.Text = string.Empty;

        }

        // habilitar controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtidcarrera.ReadOnly = !valor;
            this.txtnombre.ReadOnly = !valor;
        }

        // habilitar botones

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;

            }
        }

        // método para ocultar columnas

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;


        }

        // Método mostrar

        private void Mostrar()
        {

            this.dataListado.DataSource = LCarrera.mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = LCarrera.buscar_nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtidcarrera.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtnombre.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos datos, serán remarcados");
                    erroricono.SetError(txtnombre, "Ingrese un Nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = LCarrera.insertar(Convert.ToInt32(this.txtidcarrera.Text.Trim()), this.txtnombre.Text.Trim().ToUpper());
                    }

                    if (this.IsEditar)
                    {
                        rpta = LCarrera.editar(Convert.ToInt32(this.txtidcarrera.Text.Trim()), this.txtnombre.Text.Trim().ToUpper());
                    }

                    // validar si se inserto correctamente el registro

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            MensajeOk("Se insertó de forma correcta el registro");
                        }
                        else
                        {
                            MensajeOk("Se actualizó de forma correcta el registro");
                        }


                    }
                    // si es error
                    else
                    {
                        this.MensajeError(rpta);

                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtidcarrera.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {

                this.MensajeError("Debe seleccionar primero el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void chkeliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkeliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //codigo para poder usar el check del datagrid

            if (e.ColumnIndex == dataListado.Columns["eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkeliminar.Value = !Convert.ToBoolean(chkeliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            // al dar doble click en la celda se llenara en la cajas de texto

            this.txtidcarrera.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcarrera"].Value);
            this.txtnombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre_carrera"].Value);
            // cambiar al otro tabpage

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
             try
            {
                DialogResult Opcion;

                Opcion = MessageBox.Show("¿Realmente desea eliminar los registros?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";
                    string codigo;
                    int cont_eliminados = 0;
                    foreach(DataGridViewRow row in dataListado.Rows)
                    {
                        if(Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = LCarrera.eliminar(Convert.ToInt32(codigo));

                            if(Rpta.Equals("OK"))
                            {
                                cont_eliminados++;
                               
                            }

                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }

                    }

                    // show messages deletes
                    if (cont_eliminados > 0)
                    {
                        if (cont_eliminados == 1)
                        {
                            this.MensajeOk("Se elimino un registro");
                        }
                        else
                        {
                            this.MensajeOk("Se eliminaron " + cont_eliminados + " registros");
                        }
                    }

                    this.chkeliminar.Checked = false;

                    this.Mostrar();

                    this.Mostrar();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        
        }
        

        
    }
}
