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
 * @author yo
 */
public class PermisoDAO implements DatosConexion {
    
    private int id;
    private String nombre;
    private String descripcion;

    public PermisoDAO() {
    }

    public PermisoDAO(int id, String nombre, String descripcion) {
        this.id = id;
        this.nombre = nombre;
        this.descripcion = descripcion;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }
    
    public ArrayList<PermisoDTO> obtenerPermisos(){
        
        ArrayList<PermisoDTO> listarPermisos = new ArrayList<PermisoDTO>();
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT id,name, description FROM permission");
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setNombre(resultado.getString(2));
                this.setDescripcion(resultado.getString(3));
                listarPermisos.add(new PermisoDTO(this.getId(),this.getNombre(),this.getDescripcion()));              
            }  
            conexion.close();
            return listarPermisos;
        }catch(Exception e){
            System.out.println("Error : " + e);
            return listarPermisos;
        }
    } 
    
    
    public String registrarPermiso(){
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("INSERT INTO permission(NAME,description)VALUES ('"+this.getNombre()+"','"+this.getDescripcion()+"')");
            //INSERT INTO permission (NAME,description )VALUES ('dato de prueba','Permite probar2');
            conexion.close();
            return "El registro de permiso fue exitoso.";
        }catch(Exception e){
            System.out.println("Error : " + e);
            return "No se pudo registrar permiso : " + e;
        }        
    }

    public String actualizarPermiso(int id,String nombre,String descripcion){
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("UPDATE permission SET NAME = '" + nombre+ "', Descripcion = '" + descripcion + "'WHERE ID = " + id +")");
            conexion.close();
            return "Actualización de permiso fue exitosa.";
        }catch(Exception e){
            System.out.println("Error : " + e);
            return "No se pudo actualizar permiso : " + e;
        }    
    }
    
     
     
    
    
}
