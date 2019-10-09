/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.modelo;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;
import static processsaescritorio.modelo.DatosConexion.CLAVE;
import static processsaescritorio.modelo.DatosConexion.DRIVER;
import static processsaescritorio.modelo.DatosConexion.URL;
import static processsaescritorio.modelo.DatosConexion.USUARIO;

/**
 *
 * @author yo
 */
public class UnidadInternaDAO implements DatosConexion {
    
       
    private int id;
    private int idRol;
    private String nombre;

    public UnidadInternaDAO() {
    }

    public UnidadInternaDAO(int id, int idRol, String nombre) {
        this.id = id;
        this.idRol = idRol;
        this.nombre = nombre;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getIdRol() {
        return idRol;
    }

    public void setIdRol(int idRol) {
        this.idRol = idRol;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    
    public String registrarUnidadInterna(){
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("Insert into Internal_Unit (id_role, name) values("+this.getIdRol()+",'"+this.getNombre()+"'))");
            //Insert into Internal_Unit (id_role, name) values (3,'CEO');
            conexion.close();
            return "El registro de la Unidad interna fue exitoso.";
        }catch(Exception e){
            System.out.println("Error : " + e);
            return "No se pudo registrar la unidad interna : " + e;
        }        
    }
}
