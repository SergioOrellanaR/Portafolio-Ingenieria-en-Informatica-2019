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
import java.time.LocalDate;
import java.util.ArrayList;

/**
 *
 * @author yo
 */
public class RegionDAO implements DatosConexion {

    private int id;
    private String nombre;

    public RegionDAO() {
    }

    public RegionDAO(int id, String nombre) {
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
    
    public ArrayList<RegionDTO> obtenerRegionesBD(){
        
        ArrayList<RegionDTO> listaRegiones = new ArrayList<RegionDTO>();
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT id ,name FROM REGION");
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setNombre(resultado.getString(2));
                listaRegiones.add(new RegionDTO(this.getId(),this.getNombre()));              
            }  
            conexion.close();
            return listaRegiones;
        }catch(Exception e){
            System.out.println("Error : " + e);
            return listaRegiones;
        }
    } 
    
}
