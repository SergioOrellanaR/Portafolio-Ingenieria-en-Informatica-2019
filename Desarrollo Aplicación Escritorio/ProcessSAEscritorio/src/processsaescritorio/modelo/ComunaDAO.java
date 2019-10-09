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
public class ComunaDAO implements DatosConexion {

    private String nombre;
    private int Provincia;

    public ComunaDAO() {
    }

    public ComunaDAO(String nombre, int Provincia) {
        this.nombre = nombre;
        this.Provincia = Provincia;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getProvincia() {
        return Provincia;
    }

    public void setProvincia(int Provincia) {
        this.Provincia = Provincia;
    }
    
       public ArrayList<ComunaDTO> listarComunasPorProvincia(String nombre){
        ArrayList<ComunaDTO> listarComuna = new ArrayList<ComunaDTO>();
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT commune.name,province.id from commune JOIN province ON (province.ID = commune.id_province ) WHERE province.name=" + nombre);
            while (resultado.next()) {
                this.setNombre(resultado.getString(1));     
                this.setProvincia(resultado.getInt(2));
  
                listarComuna.add(new ComunaDTO(this.getNombre(),this.getProvincia()));
            }  
            conexion.close();
            return listarComuna;
        }catch(Exception e){
            System.out.println("Error : " + e);
            return listarComuna;
        }
    }      
}
