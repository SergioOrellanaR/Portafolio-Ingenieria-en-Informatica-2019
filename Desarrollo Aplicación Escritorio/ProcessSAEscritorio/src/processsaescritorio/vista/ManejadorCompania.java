/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.vista;

import java.util.ArrayList;
import javax.swing.DefaultListModel;
import javax.swing.table.DefaultTableModel;
import processsaescritorio.controlador.Consulta;
import processsaescritorio.controlador.Eliminar;
import processsaescritorio.controlador.Lista;
import processsaescritorio.controlador.Registro;
import processsaescritorio.modelo.AreaTrabajoDTO;
import processsaescritorio.modelo.CompaniaDAO;
import processsaescritorio.modelo.CompaniaDTO;
import processsaescritorio.modelo.ComunaDTO;
import processsaescritorio.modelo.PermisoDTO;
import processsaescritorio.modelo.ProvinciaDTO;
import processsaescritorio.modelo.RegionDTO;

/**
 *
 * @author Brayan
 */
public class ManejadorCompania extends javax.swing.JInternalFrame {

    /**
     * Creates new form ManejadorCompania
     */
    ArrayList<CompaniaDTO> listaCompanias;
    private boolean companiaIdentificada=false;
    private int idGeneral=0;
    public ManejadorCompania() {
        initComponents();
        listadoRegion();       
        listadoAreaTrabajo();
        actualizarListaCompania();
        cbxProvince.setEnabled(false);
        cbxCommune.setEnabled(false);
    }
    
    public void resetearTabla()
    {
        listaCompanias.removeAll(listaCompanias);
        actualizarListaCompania();
    }
    
    public void limpiarFormulario()
    {
        tblCompania.getSelectionModel().clearSelection();
        txtName.setText("");
        txtAddress.setText("");
        btnBorrar.setEnabled(false);

        cbxRegion.setSelectedIndex(cbxRegion.getSelectedIndex());
    }

    public void listadoRegion(){
        
        for (RegionDTO region:new Lista().listarRegiones()) {
              cbxRegion.addItem(region.getId()+"-"+region.getNombre());
        }                  
    }
    
    public void listadoProvincia(){
        
        String[] arrayRegion= cbxRegion.getSelectedItem().toString().split("-");
        int id_region=Integer.parseInt(arrayRegion[0]);
        
        for (ProvinciaDTO provincia:new Lista().listarProvincias(id_region))
        {
            cbxProvince.addItem(provincia.getId()+"-"+provincia.getNombre());       
        }
    }
    
    
    public void listadoComuna(){
        
        String[] arrayRegion= cbxProvince.getSelectedItem().toString().split("-");
        int id_province=Integer.parseInt(arrayRegion[0]);
        
        
        for (ComunaDTO comuna:new Lista().listarComunasPorProvincia(id_province))
        {
            cbxCommune.addItem(comuna.getId()+"-"+comuna.getNombre());
   
        }
    }
    
    public void listadoAreaTrabajo(){
        
        for (AreaTrabajoDTO areaTrabajo:new Lista().listarAreasTrabajo()) {
              cbxWorkingArea.addItem(areaTrabajo.getId()+"-"+areaTrabajo.getNombre());
        }  
    }
    
    public void actualizarListaCompania(){
        listaCompanias = new Lista().listarCompanias();
        String[] columnas = {"ID", "Nombre","Direccion","Area de Trabajo","Comuna"};
        DefaultTableModel modeloTabla = new DefaultTableModel(columnas, 0){
        @Override
        public boolean isCellEditable(int filas,int columnas){
            return false;
        }
        };
        
        for(CompaniaDTO compania : listaCompanias){
            String id       = String.valueOf(compania.getId());
            String name     = String.valueOf(compania.getNombre());
            String address     = String.valueOf(compania.getDireccion());
            String workingArea = String.valueOf(compania.getIdAreaTrabajo());
            String commune = String.valueOf(compania.getIdComuna());
   
            Object[] elemento = {id,name,address,workingArea,commune};
            modeloTabla.addRow(elemento);
        };
        tblCompania.setModel(modeloTabla);
    }
    

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        txtName = new javax.swing.JTextField();
        jLabel1 = new javax.swing.JLabel();
        txtAddress = new javax.swing.JTextField();
        jLabel2 = new javax.swing.JLabel();
        cbxWorkingArea = new javax.swing.JComboBox<>();
        jLabel3 = new javax.swing.JLabel();
        cbxCommune = new javax.swing.JComboBox<>();
        jLabel12 = new javax.swing.JLabel();
        cbxProvince = new javax.swing.JComboBox<>();
        jLabel14 = new javax.swing.JLabel();
        cbxRegion = new javax.swing.JComboBox<>();
        jLabel13 = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        tblCompania = new javax.swing.JTable();
        btnGrabar = new javax.swing.JButton();
        btnRefrescar = new javax.swing.JButton();
        btnBorrar = new javax.swing.JButton();

        setClosable(true);
        setMaximizable(true);

        txtName.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtNameActionPerformed(evt);
            }
        });

        jLabel1.setText("Nombre");

        txtAddress.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtAddressActionPerformed(evt);
            }
        });

        jLabel2.setText("Dirección");

        cbxWorkingArea.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cbxWorkingAreaActionPerformed(evt);
            }
        });

        jLabel3.setText("Area de Trabajo");

        cbxCommune.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cbxCommuneActionPerformed(evt);
            }
        });

        jLabel12.setText("Comuna");

        cbxProvince.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cbxProvinceActionPerformed(evt);
            }
        });

        jLabel14.setText("Provincia");

        cbxRegion.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cbxRegionActionPerformed(evt);
            }
        });

        jLabel13.setText("Region");

        tblCompania.setModel(new javax.swing.table.DefaultTableModel(
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
        tblCompania.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tblCompaniaMouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(tblCompania);

        btnGrabar.setText("Grabar");
        btnGrabar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnGrabarActionPerformed(evt);
            }
        });

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

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(29, 29, 29)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(cbxWorkingArea, 0, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel13)
                            .addComponent(cbxRegion, javax.swing.GroupLayout.PREFERRED_SIZE, 149, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(cbxProvince, javax.swing.GroupLayout.PREFERRED_SIZE, 155, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jLabel14))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(cbxCommune, javax.swing.GroupLayout.PREFERRED_SIZE, 148, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jLabel12)))
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel3)
                            .addGroup(layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(txtName, javax.swing.GroupLayout.PREFERRED_SIZE, 157, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(jLabel1))
                                .addGap(41, 41, 41)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(jLabel2)
                                    .addComponent(txtAddress, javax.swing.GroupLayout.PREFERRED_SIZE, 301, javax.swing.GroupLayout.PREFERRED_SIZE)))
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(btnGrabar)
                                .addGap(29, 29, 29)
                                .addComponent(btnRefrescar)
                                .addGap(18, 18, 18)
                                .addComponent(btnBorrar)))
                        .addGap(0, 0, Short.MAX_VALUE)))
                .addGap(18, 18, 18)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 413, Short.MAX_VALUE)
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(52, 52, 52)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel1)
                    .addComponent(jLabel2))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(txtName, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(txtAddress, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addComponent(jLabel3)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(cbxWorkingArea, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(25, 25, 25)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jLabel13)
                        .addGap(3, 3, 3)
                        .addComponent(cbxRegion, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jLabel12)
                                .addGap(3, 3, 3))
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jLabel14)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)))
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(cbxProvince, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(cbxCommune, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))))
                .addGap(44, 44, 44)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btnGrabar)
                    .addComponent(btnRefrescar)
                    .addComponent(btnBorrar))
                .addContainerGap(93, Short.MAX_VALUE))
            .addGroup(layout.createSequentialGroup()
                .addGap(38, 38, 38)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 0, Short.MAX_VALUE)
                .addContainerGap())
        );

        setBounds(500, 150, 985, 410);
    }// </editor-fold>//GEN-END:initComponents

    private void txtNameActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtNameActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_txtNameActionPerformed

    private void txtAddressActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtAddressActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_txtAddressActionPerformed

    private void cbxCommuneActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cbxCommuneActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_cbxCommuneActionPerformed

    private void cbxProvinceActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cbxProvinceActionPerformed
        if (cbxProvince.getSelectedItem()!=null) {
            cbxCommune.setEnabled(true);
            cbxCommune.removeAllItems();
            listadoComuna();
        }
    }//GEN-LAST:event_cbxProvinceActionPerformed

    private void cbxRegionActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cbxRegionActionPerformed
        cbxProvince.setEnabled(true);
        cbxProvince.removeAllItems();
        listadoProvincia();
    }//GEN-LAST:event_cbxRegionActionPerformed

    private void btnGrabarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnGrabarActionPerformed
       
        String[] arrayWorkingArea = cbxWorkingArea.getSelectedItem().toString().split("-");   
        int id_workingArea=Integer.parseInt(arrayWorkingArea[0]);       
        
        String[] arrayCommune = cbxCommune.getSelectedItem().toString().split("-");   
        int id_commune=Integer.parseInt(arrayCommune[0]);
         
        new Registro().registrarCompania(txtName.getText(),txtAddress.getText(),id_workingArea,id_commune);
        btnBorrar.setEnabled(false);
        resetearTabla();
    }//GEN-LAST:event_btnGrabarActionPerformed

    private void btnRefrescarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnRefrescarActionPerformed

        limpiarFormulario();

    }//GEN-LAST:event_btnRefrescarActionPerformed

    private void btnBorrarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnBorrarActionPerformed
        new Eliminar().eliminarCompania(idGeneral);
        resetearTabla();
        limpiarFormulario();
    }//GEN-LAST:event_btnBorrarActionPerformed

    private void cbxWorkingAreaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cbxWorkingAreaActionPerformed
        
    }//GEN-LAST:event_cbxWorkingAreaActionPerformed

    private void tblCompaniaMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tblCompaniaMouseClicked
        int seleccion= tblCompania.rowAtPoint(evt.getPoint());
        int id=Integer.parseInt(String.valueOf(tblCompania.getValueAt(seleccion,0)));
        
        companiaIdentificada=true;
        idGeneral=id;
        btnBorrar.setEnabled(true);

       
        CompaniaDTO compania=new CompaniaDAO().obtenerCompaniaPorIdBD(id);
        txtName.setText(compania.getNombre());
        txtAddress.setText(compania.getDireccion());
        cbxWorkingArea.setSelectedItem(id);
        
        String[] hola= new Consulta().listarPorComuna(compania.getIdComuna());
        
        cbxRegion.setSelectedItem(hola[1]+"-"+hola[0]);
        cbxProvince.setSelectedItem(hola[3]+"-"+hola[2]);
        cbxCommune.setSelectedItem(hola[5]+"-"+hola[4]);
    }//GEN-LAST:event_tblCompaniaMouseClicked


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnBorrar;
    private javax.swing.JButton btnGrabar;
    private javax.swing.JButton btnRefrescar;
    private javax.swing.JComboBox<String> cbxCommune;
    private javax.swing.JComboBox<String> cbxProvince;
    private javax.swing.JComboBox<String> cbxRegion;
    private javax.swing.JComboBox<String> cbxWorkingArea;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel12;
    private javax.swing.JLabel jLabel13;
    private javax.swing.JLabel jLabel14;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTable tblCompania;
    private javax.swing.JTextField txtAddress;
    private javax.swing.JTextField txtName;
    // End of variables declaration//GEN-END:variables
}
