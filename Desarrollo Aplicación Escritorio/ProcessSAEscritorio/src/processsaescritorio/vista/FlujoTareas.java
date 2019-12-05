/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.vista;

import java.awt.CheckboxGroup;
import java.util.ArrayList;
import javax.swing.DefaultListModel;
import javax.swing.JOptionPane;
import javax.swing.JRadioButton;
import javax.swing.table.DefaultTableModel;
import processsaescritorio.controlador.Lista;
import processsaescritorio.controlador.Registro;
import processsaescritorio.modelo.*;

/**
 *
 * @author yo
 */
public class FlujoTareas extends javax.swing.JInternalFrame {

    /**
     * Creates new form FlujoTareas
     */
    ArrayList<TareaDTO> listaTareas;
    ArrayList<TareaDTO> listarChildren;
    ArrayList<TareaDTO> tareasMas;
    private int idGeneral = 0;
    private int idTareaC = 0;

    CustomListModelT list_model = new CustomListModelT();

    public FlujoTareas() {
        initComponents();
        actualizarListaTarea();
       // tareasMas = new ArrayList();
        //listarChildren = new ArrayList();
        tblTareasC.setEnabled(false);
        tblTareasC.setVisible(false);
        cbxTareasC.setEnabled(false);
        cbxTareasC.setVisible(false);
        cbxTareasC.setEnabled(false);
        cbxTareasC.setVisible(false);
        rdTareaC.setEnabled(false);
        rdTareaC.setVisible(false);

    }

    /*
      @SuppressWarnings("unchecked")
    public void listaChildren(int idGeneral){
        listarChildren=new Lista().listarTareasChildren(idGeneral);
       
        DefaultListModel dfl=new DefaultListModel();
        
        for(TareaDTO tarea : listarChildren){
            String id       = String.valueOf(tarea.getId());
            String name     = String.valueOf(tarea.getNombre());
            String description = String.valueOf(tarea.getDescripcion());
   
            Object[] elemento = {id,name,description};
           
            
            list_model.addTarea(tarea);
            dfl.addElement(id+"-"+name+"-"+description);
        }
        
            //listPermisos.setModel(dfl);
    }*/
    public void resetearTablaTarea() {
        listaTareas.removeAll(listaTareas);
        actualizarListaTarea();
    }

    public void resetearTablaTareaC() {
        tblTareasC.setEnabled(true);
     
        ListaTareaC(); 
        
 
    }

    public void limpiarFormularioTarea() {
        tblTareas.getSelectionModel().clearSelection();
        txtName.setText("");
        txtAreaTarea.setText("");
        //btnBorrar.setEnabled(false);
    }

    public void limpiarFormularioTareaC() {
        tblTareasC.getSelectionModel().clearSelection();
        //txtNameC.setText("");
        //txtAreaTareaC.setText("");
        cbxTareasC.setSelectedIndex(cbxTareasC.getSelectedIndex());
        //btnBorrar.setEnabled(false);
    }

    public void actualizarListaTarea() {
        listaTareas = new Lista().listarTareas();
        String[] columnas = {"ID", "Nombre","Activo"};
        DefaultTableModel modeloTabla = new DefaultTableModel(columnas, 0) {
            @Override
            public boolean isCellEditable(int filas, int columnas) {
                return false;
            }
        };
        /*
        for (TareaDTO listaTarea : listaTareas) {
            JOptionPane.showConfirmDialog(rootPane, "Se ha encontrado y seleccionado la incidencia."+ listaTarea.getActivo());
        }*/

        listaTareas.stream().map((tarea) -> {
            String id = String.valueOf(tarea.getId());
            String name = String.valueOf(tarea.getNombre());
            String activo = Integer.valueOf(tarea.getActivo()) == 1 ? "Activo" : "Inactivo";
            Object[] elemento = {id, name, activo};
            return elemento;
        }).forEachOrdered((elemento) -> {
            modeloTabla.addRow(elemento);
        });
        ;
        tblTareas.setModel(modeloTabla);
    }

    public void ListaTareaC() {
        listaTareas = new Lista().listarTareasChildren(idGeneral);
        String[] columnas = {"ID", "Nombre","Dependencia", "Activo"};
        DefaultTableModel modeloTabla = new DefaultTableModel(columnas, 0) {
            @Override
            public boolean isCellEditable(int filas, int columnas) {
                return false;
            }
        };

        listaTareas.stream().map((tarea) -> {
            String id = String.valueOf(tarea.getId());
            String name = String.valueOf(tarea.getNombre());
            String Dependencia = String.valueOf(tarea.getIdDependenciaTarea());
            String activo = Integer.valueOf(tarea.getActivo()) == 1 ? "Activo" : "Inactivo";
            Object[] elemento = {id, name, Dependencia, activo};
            return elemento;
        }).forEachOrdered((elemento) -> {
            modeloTabla.addRow(elemento);
        });
        ;
        tblTareasC.setModel(modeloTabla);
    }

    /* public int nivelTarea(int idParental) {
        int nivel = 0;
        for (TareaDTO listaTarea : listarChildren) {
            if (listaTarea.getId() == idParental) {
                nivel++;
                for (TareaDTO listaTareax : listarChildren) {
                    if (listaTarea.getIdDependenciaTarea() == listaTareax.getId()) {
                        nivel++;
                    }
                }
            }
        }
        return nivel;
    }*/
    public void listadoTareaChildren() {
        
            if (idTareaC != 0 && idGeneral != 0) {
                for (TareaDTO tarea : new Lista().listarTareasChildrenDependientes(idTareaC, idGeneral)) {
                    cbxTareasC.addItem(tarea.getId() + "-" + tarea.getNombre());
                }
            }
        

    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        buttonGroup1 = new javax.swing.ButtonGroup();
        jScrollPane1 = new javax.swing.JScrollPane();
        tblTareas = new javax.swing.JTable();
        txtName = new javax.swing.JTextField();
        filler1 = new javax.swing.Box.Filler(new java.awt.Dimension(0, 0), new java.awt.Dimension(0, 0), new java.awt.Dimension(32767, 0));
        jScrollPane2 = new javax.swing.JScrollPane();
        txtAreaTarea = new javax.swing.JTextArea();
        jScrollPane4 = new javax.swing.JScrollPane();
        tblTareasC = new javax.swing.JTable();
        rdTareaC = new javax.swing.JRadioButton();
        rdTarea = new javax.swing.JRadioButton();
        btnGrabar = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        lblNombre = new javax.swing.JLabel();
        btnGrabarC = new javax.swing.JButton();
        cbxTareasC = new javax.swing.JComboBox<>();
        jSeparator1 = new javax.swing.JSeparator();
        jSeparator2 = new javax.swing.JSeparator();

        setClosable(true);
        setMaximizable(true);
        setResizable(true);

        tblTareas.setModel(new javax.swing.table.DefaultTableModel(
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
        tblTareas.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tblTareasMouseClicked(evt);
            }
        });
        tblTareas.addComponentListener(new java.awt.event.ComponentAdapter() {
            public void componentResized(java.awt.event.ComponentEvent evt) {
                tblTareasComponentResized(evt);
            }
        });
        jScrollPane1.setViewportView(tblTareas);

        txtName.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtNameActionPerformed(evt);
            }
        });

        txtAreaTarea.setColumns(20);
        txtAreaTarea.setRows(5);
        jScrollPane2.setViewportView(txtAreaTarea);

        tblTareasC.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {},
                {},
                {},
                {}
            },
            new String [] {

            }
        ));
        tblTareasC.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tblTareasCMouseClicked(evt);
            }
        });
        tblTareasC.addComponentListener(new java.awt.event.ComponentAdapter() {
            public void componentResized(java.awt.event.ComponentEvent evt) {
                tblTareasCComponentResized(evt);
            }
        });
        jScrollPane4.setViewportView(tblTareasC);

        rdTareaC.setText("Activo");

        rdTarea.setText("Activo");
        rdTarea.setToolTipText("");

        btnGrabar.setText("Grabar");
        btnGrabar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnGrabarActionPerformed(evt);
            }
        });

        jLabel1.setText("Descripción");

        lblNombre.setText("Nombre");

        btnGrabarC.setText("Grabar");
        btnGrabarC.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnGrabarCActionPerformed(evt);
            }
        });

        jSeparator1.setOrientation(javax.swing.SwingConstants.VERTICAL);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(jSeparator2, javax.swing.GroupLayout.PREFERRED_SIZE, 901, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                        .addGroup(layout.createSequentialGroup()
                            .addGap(686, 686, 686)
                            .addComponent(filler1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGroup(layout.createSequentialGroup()
                            .addGap(25, 25, 25)
                            .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                .addComponent(lblNombre)
                                .addGroup(layout.createSequentialGroup()
                                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                                            .addComponent(txtName)
                                            .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                                                .addComponent(btnGrabar)
                                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                                .addComponent(rdTarea)
                                                .addGap(18, 18, 18))
                                            .addComponent(jScrollPane2, javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(jScrollPane1, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 432, Short.MAX_VALUE))
                                        .addComponent(jLabel1))
                                    .addGap(18, 18, 18)
                                    .addComponent(jSeparator1, javax.swing.GroupLayout.PREFERRED_SIZE, 11, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                        .addGroup(layout.createSequentialGroup()
                                            .addGap(61, 61, 61)
                                            .addComponent(btnGrabarC)
                                            .addGap(26, 26, 26)
                                            .addComponent(cbxTareasC, javax.swing.GroupLayout.PREFERRED_SIZE, 184, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addGap(18, 18, 18)
                                            .addComponent(rdTareaC))
                                        .addGroup(layout.createSequentialGroup()
                                            .addGap(16, 16, 16)
                                            .addComponent(jScrollPane4, javax.swing.GroupLayout.PREFERRED_SIZE, 424, javax.swing.GroupLayout.PREFERRED_SIZE))))))))
                .addContainerGap(44, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(22, 22, 22)
                .addComponent(filler1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(47, 47, 47)
                .addComponent(lblNombre)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(txtName, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addComponent(jLabel1)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 84, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(22, 22, 22)
                .addComponent(jSeparator2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jSeparator1, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.PREFERRED_SIZE, 267, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                                    .addComponent(btnGrabar)
                                    .addComponent(rdTarea))
                                .addGap(22, 22, 22))
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                                    .addComponent(cbxTareasC, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(rdTareaC, javax.swing.GroupLayout.PREFERRED_SIZE, 23, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(btnGrabarC))
                                .addGap(19, 19, 19)))
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(jScrollPane4, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.PREFERRED_SIZE, 212, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 212, javax.swing.GroupLayout.PREFERRED_SIZE))))
                .addContainerGap(193, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void tblTareasMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tblTareasMouseClicked
        int seleccion = tblTareas.rowAtPoint(evt.getPoint());
        int id = Integer.parseInt(String.valueOf(tblTareas.getValueAt(seleccion, 0)));
        if (id!=0) {
            tblTareasC.setEnabled(true);
            tblTareasC.setVisible(true);
            cbxTareasC.setEnabled(true);
            cbxTareasC.setVisible(true);
            cbxTareasC.setEnabled(true);
            cbxTareasC.setVisible(true);
            rdTareaC.setVisible(true);
            rdTareaC.setEnabled(true);
        }

        //companiaIdentificada=true;
        idGeneral = id;
        TareaDTO tarea = new TareaDAO().ObtenerTareasPorId(id);

        if (tarea.getActivo() == 1) {
            rdTarea.doClick();
            rdTarea.setSelected(true);
        } else {
            rdTarea.doClick();

            rdTarea.setSelected(false);

        }

        txtName.setText(tarea.getNombre());
        txtAreaTarea.setText(tarea.getDescripcion());

        //rdTarea.s(true);
        limpiarFormularioTareaC();
        ListaTareaC();
        cbxTareasC.removeAllItems();
        listadoTareaChildren();

        // listaChildren(idGeneral);
        // btnBorrar.setEnabled(true);
    }//GEN-LAST:event_tblTareasMouseClicked

    private void txtNameActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtNameActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_txtNameActionPerformed

    private void tblTareasCMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tblTareasCMouseClicked
        int seleccion = tblTareasC.rowAtPoint(evt.getPoint());
        int id = Integer.parseInt(String.valueOf(tblTareasC.getValueAt(seleccion, 0)));
        idTareaC = id;
        
        TareaDTO tareax = new TareaDAO().ObtenerTareasPorId(id);

        if (tareax.getActivo() == 1) {
            rdTareaC.doClick();
            rdTareaC.setSelected(true);
        } else {
            rdTareaC.doClick();
            rdTareaC.setSelected(false);
        }
        cbxTareasC.removeAllItems();
        listadoTareaChildren();
        txtName.setText(tareax.getNombre());
        txtAreaTarea.setText(tareax.getDescripcion());
    }//GEN-LAST:event_tblTareasCMouseClicked

    private void btnGrabarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnGrabarActionPerformed
        int activo = 0;

        int resp = JOptionPane.showConfirmDialog(null, "¿Esta seguro?", "Grabar", JOptionPane.YES_NO_OPTION);
        // ImageIcon icon = new javax.swing.ImageIcon(getClass().getResource("/processsaescritorio/src/imagenes/ok.png"));
        if (resp == 0) {
            try {
                if (rdTarea.isSelected()) {
                    activo = 1;
                } else {
                    activo = 0;
                }

                new Registro().registrarTarea(txtName.getText(), txtAreaTarea.getText(), 1, activo, 0, 0);
                resetearTablaTarea();
                JOptionPane.showMessageDialog(null, "Grabado exitosamente.", "Grabar", JOptionPane.PLAIN_MESSAGE);
            } catch (Exception e) {
                JOptionPane.showMessageDialog(null, "Ingrese datos correspondientes", "Grabar", JOptionPane.PLAIN_MESSAGE);
            }

        }
    }//GEN-LAST:event_btnGrabarActionPerformed

    private void btnGrabarCActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnGrabarCActionPerformed
        int activo = 0;

        int resp = JOptionPane.showConfirmDialog(null, "¿Esta seguro?", "Grabar", JOptionPane.YES_NO_OPTION);
        // ImageIcon icon = new javax.swing.ImageIcon(getClass().getResource("/processsaescritorio/src/imagenes/ok.png"));
        if (resp == 0) {
            try {
                if (rdTarea.isSelected()) {
                    activo = 1;
                } else {
                    activo = 0;
                }
                int dependenciaId = 0;
                if (cbxTareasC.getSelectedItem() != null) {
                    String[] arrayCommune = cbxTareasC.getSelectedItem().toString().split("-");
                    dependenciaId = Integer.parseInt(arrayCommune[0]);
                }

                new Registro().registrarTarea(txtName.getText(), txtAreaTarea.getText(), 1, 1, idGeneral, dependenciaId);
                resetearTablaTareaC();
                  //listarChildren.removeAll(listarChildren);
                //  ListaTareaC();
                JOptionPane.showMessageDialog(null, "Grabado exitosamente.", "Grabar", JOptionPane.PLAIN_MESSAGE);
            } catch (Exception e) {
                JOptionPane.showMessageDialog(null, "Ingrese datos correspondientes", "Grabar", JOptionPane.PLAIN_MESSAGE);
            }

        }
    }//GEN-LAST:event_btnGrabarCActionPerformed

    private void tblTareasComponentResized(java.awt.event.ComponentEvent evt) {//GEN-FIRST:event_tblTareasComponentResized
          // TODO add your handling code here:
        tblTareas.getColumnModel().getColumn(0).setResizable(false);
        tblTareas.getColumnModel().getColumn(0).setPreferredWidth(10);
        tblTareas.getColumnModel().getColumn(1).setResizable(false);
        tblTareas.getColumnModel().getColumn(1).setPreferredWidth(200);
        tblTareas.getColumnModel().getColumn(2).setResizable(false);
        tblTareas.getColumnModel().getColumn(2).setPreferredWidth(100);
        // tblRol.setAutoResizeMode(JTable.AUTO_RESIZE_LAST_COLUMN);
    }//GEN-LAST:event_tblTareasComponentResized

    private void tblTareasCComponentResized(java.awt.event.ComponentEvent evt) {//GEN-FIRST:event_tblTareasCComponentResized
        if (tblTareasC.isEnabled()) {
        tblTareasC.getColumnModel().getColumn(0).setResizable(false);
        tblTareasC.getColumnModel().getColumn(0).setPreferredWidth(10);
        tblTareasC.getColumnModel().getColumn(1).setResizable(false);
        tblTareasC.getColumnModel().getColumn(1).setPreferredWidth(200);
        tblTareasC.getColumnModel().getColumn(2).setResizable(false);
        tblTareasC.getColumnModel().getColumn(2).setPreferredWidth(50);
        tblTareasC.getColumnModel().getColumn(3).setResizable(false);
        tblTareasC.getColumnModel().getColumn(3).setPreferredWidth(50); 
        }
   
    }//GEN-LAST:event_tblTareasCComponentResized


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnGrabar;
    private javax.swing.JButton btnGrabarC;
    private javax.swing.ButtonGroup buttonGroup1;
    private javax.swing.JComboBox<String> cbxTareasC;
    private javax.swing.Box.Filler filler1;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane4;
    private javax.swing.JSeparator jSeparator1;
    private javax.swing.JSeparator jSeparator2;
    private javax.swing.JLabel lblNombre;
    private javax.swing.JRadioButton rdTarea;
    private javax.swing.JRadioButton rdTareaC;
    private javax.swing.JTable tblTareas;
    private javax.swing.JTable tblTareasC;
    private javax.swing.JTextArea txtAreaTarea;
    private javax.swing.JTextField txtName;
    // End of variables declaration//GEN-END:variables
}
