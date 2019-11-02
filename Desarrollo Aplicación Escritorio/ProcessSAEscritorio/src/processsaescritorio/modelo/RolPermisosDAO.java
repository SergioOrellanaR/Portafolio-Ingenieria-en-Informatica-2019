/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.modelo;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import static processsaescritorio.modelo.DatosConexion.CLAVE;
import static processsaescritorio.modelo.DatosConexion.DRIVER;
import static processsaescritorio.modelo.DatosConexion.URL;
import static processsaescritorio.modelo.DatosConexion.USUARIO;

/**
 *
 * @author Brayan
 */
public class RolPermisosDAO implements DatosConexion{
    private int idRol;
    private int idPermiso;

    public RolPermisosDAO() {
    }

    public RolPermisosDAO(int idRol, int idPermiso) {
        this.idRol = idRol;
        this.idPermiso = idPermiso;
    }

    public int getIdRol() {
        return idRol;
    }

    public void setIdRol(int idRol) {
        this.idRol = idRol;
    }    
    
    public int getIdPermiso() {
        return idPermiso;
    }
    
    public void setIdPermiso(int idPermiso) {
        this.idPermiso = idPermiso;
    }
    
        public ArrayList<RolPermisosDTO> obtenerRolPermisos(){
        
        ArrayList<RolPermisosDTO> listar = new ArrayList<RolPermisosDTO>();
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT ID_ROLE,ID_PERMISSION FROM role_permissions");
            while (resultado.next()) {
                this.setIdRol(resultado.getInt(1));
                this.setIdPermiso(resultado.getInt(2));
               listar.add(new RolPermisosDTO(this.getIdRol(),this.getIdPermiso()));              
            }  
            conexion.close();
            return listar;
        }catch(Exception e){
            System.out.println("Error : " + e);
            return listar;
        }
    } 
    
}
