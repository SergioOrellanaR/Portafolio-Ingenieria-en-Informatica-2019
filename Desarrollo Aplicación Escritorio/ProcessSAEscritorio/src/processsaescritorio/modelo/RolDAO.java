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
public class RolDAO implements DatosConexion {
    
    private int id;
    private String nombre;

    public RolDAO() {
    }

    public RolDAO(int id, String nombre) {
        this.id = id;
        this.nombre = nombre;
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
    
    public String crearRol(){
        try{
          Class.forName(DRIVER);
          Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
          Statement declaracion = conexion.createStatement();
          declaracion.executeUpdate("INSERT INTO ROLE(NAME)VALUES " + "('"+this.getNombre()+"')'");
          return "El registro de rol fue exitoso.";
        }catch(Exception e){
         System.out.println("Error : " + e);
          return "No se pudo registrar el rol : " + e;
    }
    }
    
}
