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

    private int idGeneral = 0;
    private int idTareaC = 0;

    CustomListModelT list_model = new CustomListModelT();

    public FlujoTareas() {
        initComponents();
        actualizarListaTarea();
        // listChildren.setModel(list_model);
        // listaChildren();
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
        listarChildren.removeAll(listarChildren);
        actualizarListaTarea();
    }

    public void limpiarFormularioTarea() {
        tblTareas.getSelectionModel().clearSelection();
        txtName.setText("");
        txtAreaTarea.setText("");
        //btnBorrar.setEnabled(false);
    }

    public void limpiarFormularioTareaC() {
        tblTareasC.getSelectionModel().clearSelection();
        txtNameC.setText("");
        txtAreaTareaC.setText("");
        cbxTareasC.setSelectedIndex(cbxTareasC.getSelectedIndex());
        //btnBorrar.setEnabled(false);
    }

    public void actualizarListaTarea() {
        listaTareas = new Lista().listarTareas();
        String[] columnas = {"ID", "Nombre", "Descripcion", "Activo"};
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
            String descripcion = String.valueOf(tarea.getDescripcion());
            String activo = Integer.valueOf(tarea.getActivo()) == 1 ? "Activo" : "Inactivo";
            Object[] elemento = {id, name, descripcion, activo};
            return elemento;
        }).forEachOrdered((elemento) -> {
            modeloTabla.addRow(elemento);
        });
        ;
        tblTareas.setModel(modeloTabla);
    }

    public void ListaTareaC() {
        listaTareas = new Lista().listarTareasChildren(idGeneral);
        String[] columnas = {"ID", "Nombre", "Descripcion", "Dependencia", "Activo"};
        DefaultTableModel modeloTabla = new DefaultTableModel(columnas, 0) {
            @Override
            public boolean isCellEditable(int filas, int columnas) {
                return false;
            }
        };

        listaTareas.stream().map((tarea) -> {
            String id = String.valueOf(tarea.getId());
            String name = String.valueOf(tarea.getNombre());
            String descripcion = String.valueOf(tarea.getDescripcion());
            String Dependencia = String.valueOf(tarea.getIdDependenciaTarea());
            String activo = Integer.valueOf(tarea.getActivo()) == 1 ? "Activo" : "Inactivo";
            Object[] elemento = {id, name, descripcion, Dependencia, activo};
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
        
        if (idTareaC!=0 && idGeneral!=0) {
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
        txtNameC = new javax.swing.JTextField();
        jScrollPane3 = new javax.swing.JScrollPane();
        txtAreaTareaC = new javax.swing.JTextArea();
        rdTareaC = new javax.swing.JRadioButton();
        rdTarea = new javax.swing.JRadioButton();
        btnGrabar = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        btnGrabarC = new javax.swing.JButton();
        cbxTareasC = new javax.swing.JComboBox<>();

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
        jScrollPane4.setViewportView(tblTareasC);

        txtAreaTareaC.setColumns(20);
        txtAreaTareaC.setRows(5);
        jScrollPane3.setViewportView(txtAreaTareaC);

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

        jLabel2.setText("Nombre");

        jLabel3.setText("Nombre");

        jLabel4.setText("Descripción");

        btnGrabarC.setText("Grabar");
        btnGrabarC.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnGrabarCActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(83, 83, 83)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                        .addComponent(txtName)
                        .addComponent(jScrollPane2, javax.swing.GroupLayout.DEFAULT_SIZE, 432, Short.MAX_VALUE)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(btnGrabar)
                            .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 430, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGroup(layout.createSequentialGroup()
                            .addComponent(rdTarea)
                            .addGap(20, 20, 20)))
                    .addComponent(jLabel1)
                    .addComponent(jLabel2))
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(566, 566, 566)
                        .addComponent(filler1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(182, 182, 182)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jScrollPane4, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(btnGrabarC)))
                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                        .addGroup(layout.createSequentialGroup()
                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(cbxTareasC, javax.swing.GroupLayout.PREFERRED_SIZE, 184, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addGap(18, 18, 18)
                            .addComponent(rdTareaC))
                        .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                            .addGap(182, 182, 182)
                            .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                .addComponent(jLabel3)
                                .addComponent(txtNameC, javax.swing.GroupLayout.PREFERRED_SIZE, 452, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addComponent(jScrollPane3, javax.swing.GroupLayout.PREFERRED_SIZE, 452, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addComponent(jLabel4)))))
                .addContainerGap(212, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(22, 22, 22)
                        .addComponent(filler1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(70, 70, 70)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(jLabel2)
                            .addComponent(jLabel3))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(txtName, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(txtNameC, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jLabel1)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 84, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(rdTarea))
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jLabel4)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(jScrollPane3, javax.swing.GroupLayout.PREFERRED_SIZE, 87, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                                    .addComponent(cbxTareasC, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(rdTareaC, javax.swing.GroupLayout.PREFERRED_SIZE, 23, javax.swing.GroupLayout.PREFERRED_SIZE))))))
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(10, 10, 10)
                        .addComponent(btnGrabar))
                    .addGroup(layout.createSequentialGroup()
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(btnGrabarC)))
                .addGap(26, 26, 26)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane4, javax.swing.GroupLayout.PREFERRED_SIZE, 292, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 292, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(102, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void tblTareasMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tblTareasMouseClicked
        int seleccion = tblTareas.rowAtPoint(evt.getPoint());
        int id = Integer.parseInt(String.valueOf(tblTareas.getValueAt(seleccion, 0)));

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
        txtNameC.setText(tareax.getNombre());
        txtAreaTareaC.setText(tareax.getDescripcion());
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
        if (resp == 0) {
            try {
                if (idGeneral != 0) {
                    if (rdTareaC.isSelected()) {
                        activo = 1;
                    } 
                    /*else {
                        activo = 0;
                    }*/

                   
                    int dependenciaId =0;

                    if (cbxTareasC.getSelectedItem().toString().length()==0) {
                       dependenciaId=0;
                    }else{
                      String[] arrayCommune = cbxTareasC.getSelectedItem().toString().split("-");
                       dependenciaId=Integer.parseInt(arrayCommune[0]);
                    }

                 //   nivelTarea(dependenciaId);
                    new Registro().registrarTarea(txtNameC.getText(), txtAreaTareaC.getText(), 1, 1, idGeneral, dependenciaId);
                    resetearTablaTareaC();
                    JOptionPane.showMessageDialog(null, "Grabado exitosamente.", "Grabar", JOptionPane.PLAIN_MESSAGE);
                }
            } catch (Exception e) {
                JOptionPane.showMessageDialog(null, "Ingrese datos correspondientes"+e, "Grabar", JOptionPane.PLAIN_MESSAGE);
            }
        }
    }//GEN-LAST:event_btnGrabarCActionPerformed


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnGrabar;
    private javax.swing.JButton btnGrabarC;
    private javax.swing.ButtonGroup buttonGroup1;
    private javax.swing.JComboBox<String> cbxTareasC;
    private javax.swing.Box.Filler filler1;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private javax.swing.JScrollPane jScrollPane4;
    private javax.swing.JRadioButton rdTarea;
    private javax.swing.JRadioButton rdTareaC;
    private javax.swing.JTable tblTareas;
    private javax.swing.JTable tblTareasC;
    private javax.swing.JTextArea txtAreaTarea;
    private javax.swing.JTextArea txtAreaTareaC;
    private javax.swing.JTextField txtName;
    private javax.swing.JTextField txtNameC;
    // End of variables declaration//GEN-END:variables
}
