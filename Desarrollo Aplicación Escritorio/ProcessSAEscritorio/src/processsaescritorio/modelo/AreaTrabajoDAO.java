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
public class AreaTrabajoDAO implements DatosConexion {

    private int id;
    private String nombre;

    public AreaTrabajoDAO(int id, String nombre) {
        this.id = id;
        this.nombre = nombre;
    }

    public AreaTrabajoDAO() {
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
    
    public ArrayList<AreaTrabajoDTO> obtenerAreasTrabajo(){
        
        ArrayList<AreaTrabajoDTO> listarAreasTrabajo = new ArrayList<AreaTrabajoDTO>();
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT id ,name FROM working_area");
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setNombre(resultado.getString(2));
                listarAreasTrabajo.add(new AreaTrabajoDTO(this.getId(),this.getNombre()));              
            }  
            conexion.close();
            return listarAreasTrabajo;
        }catch(Exception e){
            System.out.println("Error : " + e);
            return listarAreasTrabajo;
        }
    } 
    
}
