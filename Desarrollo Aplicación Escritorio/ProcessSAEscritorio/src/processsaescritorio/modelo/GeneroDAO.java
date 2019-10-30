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
public class GeneroDAO implements DatosConexion {
    
    private int id;
    private String nombre;

    public GeneroDAO(int id, String nombre) {
        this.id = id;
        this.nombre = nombre;
    }

    public GeneroDAO() {
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

    @Override
    public String toString() {
        return "GeneroDAO{" + "nombre=" + nombre + '}';
    }
    
    
     public ArrayList<GeneroDTO> listarGenerosPersona(){
        
        ArrayList<GeneroDTO> listarGenero = new ArrayList<GeneroDTO>();
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT id ,name FROM Gender");
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setNombre(resultado.getString(2));
                listarGenero.add(new GeneroDTO(this.getId(),this.getNombre()));              
            }  
            conexion.close();
            return listarGenero;
        }catch(Exception e){
            System.out.println("Error : " + e);
            return listarGenero;
        }
    } 
}
