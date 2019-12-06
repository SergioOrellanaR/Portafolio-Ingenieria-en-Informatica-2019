/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.vista;

import java.time.LocalDate;
import java.time.Month;
import java.time.ZoneId;
import java.util.ArrayList;
import java.util.Date;
import javax.swing.ImageIcon;
import javax.swing.JOptionPane;
import javax.swing.table.DefaultTableModel;
import processsaescritorio.controlador.*;
import processsaescritorio.modelo.*;

/**
 *
 * @author yo
 */
public class ManejadorUsuarios extends javax.swing.JInternalFrame {

    /**
     * Creates new form ManejadorUsuarios
     */
    ArrayList<UsuarioDTO> listaUsuarios;
    private boolean usuarioIdentificado = false;
    private int idGeneral = 0;

    public ManejadorUsuarios() {
        initComponents();

        actualizarListaUsuarios();
        listadoCompania();
        listadoRegion();
        listadoGenero();
        cbxProvince.setEnabled(false);
        cbxCommune.setEnabled(false);

    }

    public void resetearTabla() {
        listaUsuarios.removeAll(listaUsuarios);
        actualizarListaUsuarios();
    }

    public void listadoCompania() {
        for (CompaniaDTO compania : new Lista().listarCompanias()) {
            cbxCompany.addItem(compania.getId() + "-" + compania.getNombre());
        }
    }

    public void listadoRegion() {

        for (RegionDTO region : new Lista().listarRegiones()) {
            cbxRegion.addItem(region.getId() + "-" + region.getNombre());
        }
    }

    public void listadoGenero() {

        for (GeneroDTO genero : new Lista().listarGeneroPersona()) {
            if (genero.getNombre().contains("defined")) {
                genero.setNombre("Otro");
            }
            cbxGender.addItem(genero.getNombre());
        }
    }

    ///unidad interna buscada por undiad asignada por compañia
    public void listadoUnidadAsignada() {

        String[] arrayCompany = cbxCompany.getSelectedItem().toString().split("-");
        int id_company = Integer.parseInt(arrayCompany[0]);

        for (UnidadAsignadaDTO unidadAsignada : new Lista().listarUnidadAsignadaPorCompania(id_company)) {

            String nombre = new Consulta().buscarunidad(unidadAsignada.getId_internalUnit());
            cbxAssignedUnit.addItem(unidadAsignada.getId() + "-" + nombre);
        }
    }

    public void listadoProvincia() {

        String[] arrayRegion = cbxRegion.getSelectedItem().toString().split("-");
        int id_region = Integer.parseInt(arrayRegion[0]);

        for (ProvinciaDTO provincia : new Lista().listarProvincias(id_region)) {
            cbxProvince.addItem(provincia.getId() + "-" + provincia.getNombre());
        }
    }

    public void listadoComuna() {

        String[] arrayRegion = cbxProvince.getSelectedItem().toString().split("-");
        int id_province = Integer.parseInt(arrayRegion[0]);

        for (ComunaDTO comuna : new Lista().listarComunasPorProvincia(id_province)) {
            cbxCommune.addItem(comuna.getId() + "-" + comuna.getNombre());

        }
    }

    public Date convertToDateViaInstant(LocalDate dateToConvert) {
        return java.util.Date.from(dateToConvert.atStartOfDay()
                .atZone(ZoneId.systemDefault())
                .toInstant());
    }

    public LocalDate convertToLocalDate(Date dateToConvert) {
        return dateToConvert.toInstant().atZone(ZoneId.systemDefault()).toLocalDate();
    }

    public void actualizarDatosUsuario() {

        new UsuarioDAO().actualizarUsuario(idGeneral, txtName.getText());

    }

    public void limpiarFormulario() {
        usuarioIdentificado = false;
        idGeneral = 0;
        tblUsuario.getSelectionModel().clearSelection();
        txtName.setText("");
        txtLastName.setText("");
        txtPhone.setText("");
        txtAddress.setText("");
        txtEmail.setText("");
        txtEmail.setEditable(true);
        btnBorrar.setEnabled(false);

        cbxRegion.setSelectedIndex(cbxRegion.getSelectedIndex());
        cbxGender.setSelectedIndex(cbxGender.getSelectedIndex());
        cbxCompany.setSelectedIndex(cbxCompany.getSelectedIndex());
        cbxAssignedUnit.setSelectedIndex(cbxAssignedUnit.getSelectedIndex());
        //arreglar estas dos
    }

    public void actualizarListaUsuarios() {
        listaUsuarios = new Lista().listarUsuarios();
        String[] columnas = {"ID", "Nombre", "Apellido"};
        DefaultTableModel modeloTabla = new DefaultTableModel(columnas, 0) {
            @Override
            public boolean isCellEditable(int filas, int columnas) {
                return false;
            }
        };

        for (UsuarioDTO usuario : listaUsuarios) {
            String id = String.valueOf(usuario.getId());
            String name = String.valueOf(usuario.getFirstname());
            String lastName = String.valueOf(usuario.getLastname());

            Object[] elemento = {id, name, lastName};
            modeloTabla.addRow(elemento);
        };
        tblUsuario.setModel(modeloTabla);
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jScrollPane1 = new javax.swing.JScrollPane();
        tblUsuario = new javax.swing.JTable();
        btnGrabar = new javax.swing.JButton();
        txtName = new javax.swing.JTextField();
        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        txtLastName = new javax.swing.JTextField();
        txtEmail = new javax.swing.JTextField();
        dateBorn = new com.toedter.calendar.JDateChooser();
        jLabel4 = new javax.swing.JLabel();
        cbxCompany = new javax.swing.JComboBox<>();
        jLabel5 = new javax.swing.JLabel();
        jLabel9 = new javax.swing.JLabel();
        cbxGender = new javax.swing.JComboBox<>();
        txtPhone = new javax.swing.JTextField();
        jLabel10 = new javax.swing.JLabel();
        jLabel11 = new javax.swing.JLabel();
        cbxAssignedUnit = new javax.swing.JComboBox<>();
        txtAddress = new javax.swing.JTextField();
        jLabel6 = new javax.swing.JLabel();
        cbxCommune = new javax.swing.JComboBox<>();
        jLabel12 = new javax.swing.JLabel();
        cbxRegion = new javax.swing.JComboBox<>();
        jLabel13 = new javax.swing.JLabel();
        cbxProvince = new javax.swing.JComboBox<>();
        jLabel14 = new javax.swing.JLabel();
        btnRefrescar = new javax.swing.JButton();
        lbl = new javax.swing.JLabel();
        btnBorrar = new javax.swing.JButton();
        jLabel7 = new javax.swing.JLabel();

        setClosable(true);
        setMaximizable(true);
        setResizable(true);
        setTitle("Manejo de Usuarios");

        tblUsuario.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            },
            new String [] {
                "Title 1", "Title 2", "Title 3", "Title 4"
            }
        ));
        tblUsuario.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tblUsuarioMouseClicked(evt);
            }
        });
        tblUsuario.addComponentListener(new java.awt.event.ComponentAdapter() {
            public void componentResized(java.awt.event.ComponentEvent evt) {
                tblUsuarioComponentResized(evt);
            }
        });
        jScrollPane1.setViewportView(tblUsuario);

        btnGrabar.setText("Grabar");
        btnGrabar.addChangeListener(new javax.swing.event.ChangeListener() {
            public void stateChanged(javax.swing.event.ChangeEvent evt) {
                btnGrabarStateChanged(evt);
            }
        });
        btnGrabar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnGrabarActionPerformed(evt);
            }
        });

        txtName.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtNameKeyTyped(evt);
            }
        });

        jLabel1.setText("Nombre");

        jLabel2.setText("Apellido");

        jLabel3.setText("Correo");

        txtLastName.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyPressed(java.awt.event.KeyEvent evt) {
                txtLastNameKeyPressed(evt);
            }
        });

        txtEmail.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtEmailKeyTyped(evt);
            }
        });

        dateBorn.setDateFormatString("MM,dd, yyyy");

        jLabel4.setText("Fecha de nacimiento");

        cbxCompany.setMaximumRowCount(4);
        cbxCompany.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cbxCompanyActionPerformed(evt);
            }
        });

        jLabel5.setText("Compañia");

        jLabel9.setText("Genero");

        cbxGender.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cbxGenderActionPerformed(evt);
            }
        });

        txtPhone.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtPhoneActionPerformed(evt);
            }
        });
        txtPhone.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtPhoneKeyTyped(evt);
            }
        });

        jLabel10.setText("Telefono");

        jLabel11.setText("Unidad Asignada");

        cbxAssignedUnit.setMaximumRowCount(4);
        cbxAssignedUnit.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cbxAssignedUnitActionPerformed(evt);
            }
        });

        txtAddress.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtAddressKeyTyped(evt);
            }
        });

        jLabel6.setText("Dirección");

        cbxCommune.setMaximumRowCount(4);
        cbxCommune.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cbxCommuneActionPerformed(evt);
            }
        });

        jLabel12.setText("Comuna");

        cbxRegion.setMaximumRowCount(4);
        cbxRegion.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cbxRegionActionPerformed(evt);
            }
        });

        jLabel13.setText("Region");

        cbxProvince.setMaximumRowCount(4);
        cbxProvince.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cbxProvinceActionPerformed(evt);
            }
        });

        jLabel14.setText("Provincia");

        btnRefrescar.setText("Refrescar");
        btnRefrescar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnRefrescarActionPerformed(evt);
            }
        });

        btnBorrar.setText("Eliminar");
        btnBorrar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnBorrarActionPerformed(evt);
            }
        });

        jLabel7.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabel7.setText("Manejador de Usuarios");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(lbl)
                        .addGap(141, 141, 141))
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addGap(29, 29, 29)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                    .addGroup(layout.createSequentialGroup()
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(jLabel5)
                                            .addComponent(cbxCompany, javax.swing.GroupLayout.PREFERRED_SIZE, 245, javax.swing.GroupLayout.PREFERRED_SIZE))
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(jLabel11)
                                            .addComponent(cbxAssignedUnit, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.PREFERRED_SIZE, 276, javax.swing.GroupLayout.PREFERRED_SIZE)))
                                    .addGroup(layout.createSequentialGroup()
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(jLabel13)
                                            .addComponent(cbxRegion, javax.swing.GroupLayout.PREFERRED_SIZE, 119, javax.swing.GroupLayout.PREFERRED_SIZE))
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(jLabel14)
                                            .addComponent(cbxProvince, javax.swing.GroupLayout.PREFERRED_SIZE, 119, javax.swing.GroupLayout.PREFERRED_SIZE))
                                        .addGap(18, 18, 18)
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(jLabel12)
                                            .addComponent(cbxCommune, javax.swing.GroupLayout.PREFERRED_SIZE, 278, javax.swing.GroupLayout.PREFERRED_SIZE)))
                                    .addGroup(layout.createSequentialGroup()
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(txtAddress, javax.swing.GroupLayout.PREFERRED_SIZE, 254, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addComponent(jLabel6))
                                        .addGap(18, 18, 18)
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(jLabel10)
                                            .addComponent(txtPhone, javax.swing.GroupLayout.PREFERRED_SIZE, 118, javax.swing.GroupLayout.PREFERRED_SIZE)))
                                    .addGroup(layout.createSequentialGroup()
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addGroup(layout.createSequentialGroup()
                                                .addComponent(txtName, javax.swing.GroupLayout.PREFERRED_SIZE, 157, javax.swing.GroupLayout.PREFERRED_SIZE)
                                                .addGap(24, 24, 24)
                                                .addComponent(txtLastName, javax.swing.GroupLayout.PREFERRED_SIZE, 164, javax.swing.GroupLayout.PREFERRED_SIZE))
                                            .addGroup(layout.createSequentialGroup()
                                                .addComponent(jLabel1)
                                                .addGap(144, 144, 144)
                                                .addComponent(jLabel2)))
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(jLabel9)
                                            .addComponent(cbxGender, javax.swing.GroupLayout.PREFERRED_SIZE, 119, javax.swing.GroupLayout.PREFERRED_SIZE)))
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(btnGrabar)
                                        .addGap(29, 29, 29)
                                        .addComponent(btnRefrescar)
                                        .addGap(18, 18, 18)
                                        .addComponent(btnBorrar))
                                    .addGroup(layout.createSequentialGroup()
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(txtEmail, javax.swing.GroupLayout.PREFERRED_SIZE, 254, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addComponent(jLabel3))
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(jLabel4, javax.swing.GroupLayout.PREFERRED_SIZE, 98, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addComponent(dateBorn, javax.swing.GroupLayout.PREFERRED_SIZE, 184, javax.swing.GroupLayout.PREFERRED_SIZE)))))
                            .addGroup(layout.createSequentialGroup()
                                .addGap(153, 153, 153)
                                .addComponent(jLabel7)))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 23, Short.MAX_VALUE)))
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 416, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(25, 25, 25))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jLabel7)
                        .addGap(9, 9, 9)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(jLabel1)
                            .addComponent(jLabel2)
                            .addComponent(jLabel9))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(txtName, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(txtLastName, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(cbxGender, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(24, 24, 24)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(jLabel6)
                            .addComponent(jLabel10))
                        .addGap(3, 3, 3)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addGroup(layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                                    .addComponent(txtAddress, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(txtPhone, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                                .addGap(18, 18, 18)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(jLabel12)
                                        .addGap(3, 3, 3)
                                        .addComponent(cbxCommune, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(jLabel13)
                                        .addGap(3, 3, 3)
                                        .addComponent(cbxRegion, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))))
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jLabel14)
                                .addGap(3, 3, 3)
                                .addComponent(cbxProvince, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(jLabel3)
                            .addComponent(jLabel4, javax.swing.GroupLayout.PREFERRED_SIZE, 26, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(txtEmail, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(dateBorn, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel11)
                            .addComponent(jLabel5))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(cbxAssignedUnit, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(cbxCompany, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(lbl)
                        .addGap(13, 13, 13)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(btnGrabar)
                            .addComponent(btnRefrescar)
                            .addComponent(btnBorrar)))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(0, 16, Short.MAX_VALUE)
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 396, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addGap(91, 91, 91))
        );

        setBounds(0, 0, 1049, 544);
    }// </editor-fold>//GEN-END:initComponents

    private void btnGrabarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnGrabarActionPerformed
        int resp = JOptionPane.showConfirmDialog(null, "¿Esta seguro?", "Grabar", JOptionPane.YES_NO_OPTION);
        // ImageIcon icon = new javax.swing.ImageIcon(getClass().getResource("/processsaescritorio/src/imagenes/ok.png"));

        if (resp == 0) {
            try {
                if (usuarioIdentificado) {
                    actualizarDatosUsuario();
                } else {
                    LocalDate birthdate = convertToLocalDate(dateBorn.getDate());;

                    String[] arrayCompany = cbxCompany.getSelectedItem().toString().split("-");
                    int id_company = Integer.parseInt(arrayCompany[0]);

                    String[] arrayCommune = cbxCommune.getSelectedItem().toString().split("-");
                    int id_commune = Integer.parseInt(arrayCommune[0]);

                    String[] arrayInternalU = cbxAssignedUnit.getSelectedItem().toString().split("-");
                    int id_unitAssig = Integer.parseInt(arrayInternalU[0]);

                    int assignedUnit = 0;

                    UnidadAsignadaDTO uni = new UnidadAsignadaDAO().obtenerUnidadPorNombre(arrayInternalU[1]);

                    int id_gender = 3;
                    if (cbxGender.getSelectedIndex() == 0) {
                        id_gender = 1;
                    } else if (cbxGender.getSelectedIndex() == 1) {
                        id_gender = 2;
                    } else {
                        id_gender = 3;
                    }
                    String pass = txtName.getText().substring(0, 2) + txtLastName.getText().substring(0, 2) + birthdate.getYear();
                    new UsuarioDAO(0, txtName.getText(), txtLastName.getText(), txtAddress.getText().trim(), txtPhone.getText().trim(), birthdate, txtEmail.getText().trim(), pass, id_commune, uni.getId(), id_company, id_gender).crearUsuario();
                }
                JOptionPane.showMessageDialog(null, "Grabado exitosamente.", "Grabar", JOptionPane.PLAIN_MESSAGE);
                resetearTabla();
            } catch (Exception e) {
                JOptionPane.showMessageDialog(null, "Ingrese datos correspondientes", "Grabar", JOptionPane.PLAIN_MESSAGE);
            }

        }

    }//GEN-LAST:event_btnGrabarActionPerformed

    private void cbxCompanyActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cbxCompanyActionPerformed
        if (cbxCompany.getSelectedItem() != null) {
            cbxAssignedUnit.removeAllItems();
            listadoUnidadAsignada();
        }
    }//GEN-LAST:event_cbxCompanyActionPerformed

    private void cbxGenderActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cbxGenderActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_cbxGenderActionPerformed

    private void txtPhoneActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtPhoneActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_txtPhoneActionPerformed

    private void cbxAssignedUnitActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cbxAssignedUnitActionPerformed

    }//GEN-LAST:event_cbxAssignedUnitActionPerformed

    private void cbxCommuneActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cbxCommuneActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_cbxCommuneActionPerformed

    private void cbxRegionActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cbxRegionActionPerformed
        cbxProvince.setEnabled(true);
        cbxProvince.removeAllItems();
        listadoProvincia();
    }//GEN-LAST:event_cbxRegionActionPerformed

    private void cbxProvinceActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cbxProvinceActionPerformed
        if (cbxProvince.getSelectedItem() != null) {
            cbxCommune.setEnabled(true);
            cbxCommune.removeAllItems();
            listadoComuna();
        }
    }//GEN-LAST:event_cbxProvinceActionPerformed

    private void btnRefrescarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnRefrescarActionPerformed

        limpiarFormulario();

    }//GEN-LAST:event_btnRefrescarActionPerformed

    private void tblUsuarioMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tblUsuarioMouseClicked
        int seleccion = tblUsuario.rowAtPoint(evt.getPoint());
        int id = Integer.parseInt(String.valueOf(tblUsuario.getValueAt(seleccion, 0)));

        usuarioIdentificado = true;
        idGeneral = id;
        cbxProvince.setEnabled(true);
        cbxCommune.setEnabled(true);
        txtEmail.setEditable(false);
        btnBorrar.setEnabled(true);

        UsuarioDTO usuario = new UsuarioDAO().obtenerUsuarioPorIdBD(id);
        txtName.setText(usuario.getFirstname());
        txtLastName.setText(usuario.getLastname());
        txtPhone.setText(usuario.getPhone());
        txtEmail.setText(usuario.getEmail());
        txtAddress.setText(usuario.getAddress());

        String[] locacionAsignada = new Consulta().listarPorComuna(usuario.getIdCommune());

        cbxRegion.setSelectedItem(locacionAsignada[1] + "-" + locacionAsignada[0]);
        cbxProvince.setSelectedItem(locacionAsignada[3] + "-" + locacionAsignada[2]);
        cbxCommune.setSelectedItem(locacionAsignada[5] + "-" + locacionAsignada[4]);

        dateBorn.setDate(convertToDateViaInstant(usuario.getBirthdate()));

        new Lista().listarCompanias().stream().filter((compania) -> (compania.getId() == usuario.getIdCompany())).forEachOrdered((compania) -> {
            cbxCompany.setSelectedItem(compania.toString());
        });
        new Lista().listarGeneroPersona().stream().filter((genero) -> (genero.getId() == usuario.getIdGender())).forEachOrdered((genero) -> {
            cbxGender.setSelectedItem(genero.toString());
        });

    }//GEN-LAST:event_tblUsuarioMouseClicked

    private void btnBorrarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnBorrarActionPerformed
        int resp = JOptionPane.showConfirmDialog(null, "¿Esta seguro?", "Eliminar", JOptionPane.YES_NO_OPTION);
        if (resp == 0) {

            new Eliminar().eliminarUsuario(idGeneral);
            resetearTabla();
            limpiarFormulario();
            JOptionPane.showMessageDialog(null, "Eliminado exitosamente.",
                    "Eliminar", JOptionPane.PLAIN_MESSAGE);
        }

    }//GEN-LAST:event_btnBorrarActionPerformed

    private void txtPhoneKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtPhoneKeyTyped
        // TODO add your handling code here:
        char c = evt.getKeyChar();
        if (c < '0' || c > '9') {
            evt.consume();
        }
    }//GEN-LAST:event_txtPhoneKeyTyped

    private void txtNameKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtNameKeyTyped
        // TODO add your handling code here:

        if (txtName.getText().length() >= 40) {
            evt.consume();
        }
    }//GEN-LAST:event_txtNameKeyTyped

    private void txtLastNameKeyPressed(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtLastNameKeyPressed
        // TODO add your handling code here:
    }//GEN-LAST:event_txtLastNameKeyPressed

    private void txtEmailKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtEmailKeyTyped
        // TODO add your handling code here:
        if (txtEmail.getText().length() >= 50) {
            evt.consume();
        }
    }//GEN-LAST:event_txtEmailKeyTyped

    private void txtAddressKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtAddressKeyTyped
        // TODO add your handling code here:
        if (txtAddress.getText().length() >= 50) {
            evt.consume();
        }
    }//GEN-LAST:event_txtAddressKeyTyped

    private void btnGrabarStateChanged(javax.swing.event.ChangeEvent evt) {//GEN-FIRST:event_btnGrabarStateChanged
        // TODO add your handling code here:
    }//GEN-LAST:event_btnGrabarStateChanged

    private void txtLastNameKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtLastNameKeyTyped
        // TODO add your handling code here:
        if (txtLastName.getText().length() >= 40) {
            evt.consume();
        }
    }//GEN-LAST:event_txtLastNameKeyTyped

    private void tblUsuarioComponentResized(java.awt.event.ComponentEvent evt) {//GEN-FIRST:event_tblUsuarioComponentResized
        // TODO add your handling code here:
        tblUsuario.getColumnModel().getColumn(0).setResizable(false);
        tblUsuario.getColumnModel().getColumn(0).setPreferredWidth(10);
        tblUsuario.getColumnModel().getColumn(1).setResizable(false);
        tblUsuario.getColumnModel().getColumn(1).setPreferredWidth(150);
        tblUsuario.getColumnModel().getColumn(2).setResizable(false);
        tblUsuario.getColumnModel().getColumn(2).setPreferredWidth(150);
        // tblRol.setAutoResizeMode(JTable.AUTO_RESIZE_LAST_COLUMN);
    }//GEN-LAST:event_tblUsuarioComponentResized


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnBorrar;
    private javax.swing.JButton btnGrabar;
    private javax.swing.JButton btnRefrescar;
    private javax.swing.JComboBox<String> cbxAssignedUnit;
    private javax.swing.JComboBox<String> cbxCommune;
    private javax.swing.JComboBox<String> cbxCompany;
    private javax.swing.JComboBox<String> cbxGender;
    private javax.swing.JComboBox<String> cbxProvince;
    private javax.swing.JComboBox<String> cbxRegion;
    private com.toedter.calendar.JDateChooser dateBorn;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel10;
    private javax.swing.JLabel jLabel11;
    private javax.swing.JLabel jLabel12;
    private javax.swing.JLabel jLabel13;
    private javax.swing.JLabel jLabel14;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JLabel jLabel7;
    private javax.swing.JLabel jLabel9;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JLabel lbl;
    private javax.swing.JTable tblUsuario;
    private javax.swing.JTextField txtAddress;
    private javax.swing.JTextField txtEmail;
    private javax.swing.JTextField txtLastName;
    private javax.swing.JTextField txtName;
    private javax.swing.JTextField txtPhone;
    // End of variables declaration//GEN-END:variables
}
