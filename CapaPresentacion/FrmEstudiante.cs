﻿using System;
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
    public partial class FrmEstudiante : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmEstudiante()
        {
            InitializeComponent();
            
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
            this.txtmatricula.Text = string.Empty;
            this.txtnombre.Text = string.Empty;

        }

        // habilitar controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtmatricula.ReadOnly = !valor;
            this.txtnombre.ReadOnly = !valor;
            this.cbcarrera.Enabled = valor;
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

            this.dataListado.DataSource = LEstudiante.mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = LEstudiante.buscar_nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

         private void llenar_combo()
        {
            this.cbcarrera.DataSource = LCarrera.mostrar();
            this.cbcarrera.DisplayMember = "idcarrera";
            this.cbcarrera.ValueMember = "idcarrera";
        }



        private void FrmEstudiante_Load(object sender, EventArgs e)
        {
            llenar_combo();
            this.ttmensaje.SetToolTip(txtmatricula, "Ingrese la matricula del estudiante");
            this.ttmensaje.SetToolTip(txtnombre, "Ingrese el nombre del estudiante");
            this.ttmensaje.SetToolTip(cbcarrera, "Seleccione la carrera");

            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtmatricula.Focus();
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
                        rpta = LEstudiante.insertar(this.txtmatricula.Text.Trim(), this.txtnombre.Text.Trim().ToUpper(), Convert.ToString(this.cbcarrera.SelectedValue));
                    }

                    if (this.IsEditar)
                    {
                        rpta = LEstudiante.editar(this.txtmatricula.Text.Trim(), this.txtnombre.Text.Trim().ToUpper(), Convert.ToString(this.cbcarrera.SelectedValue));
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
            if (!this.txtmatricula.Text.Equals(""))
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
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
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = LEstudiante.eliminar(Convert.ToString(codigo));

                            if (Rpta.Equals("OK"))
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



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
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

            this.txtmatricula.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["matricula"].Value);
            this.txtnombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.cbcarrera.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["idcarrera"].Value);
            // cambiar al otro tabpage

            this.tabControl1.SelectedIndex = 1;
        }
    }
}
