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

/**
 *
 * @author yo
 */
public class ProvinciaDAO implements DatosConexion {
    
    private String nombre;
    private int    region;
    
    public ProvinciaDAO() {
    }
    
    public ProvinciaDAO(String nombre, int region) {
        this.nombre = nombre;
        this.region = region;
    }

    
    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getRegion() {
        return region;
    }

    public void setRegion(int region) {
        this.region = region;
    }
    
     
    public ArrayList<ProvinciaDTO> listarProvinciasPorRegion(String nombre){
        ArrayList<ProvinciaDTO> listarProvincias = new ArrayList<ProvinciaDTO>();
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT province.name,region.id from PROVINCE JOIN REGION ON (REGION.ID = PROVINCE.Id_region) WHERE region.name=" + nombre);
            while (resultado.next()) {
                this.setNombre(resultado.getString(1));
                this.setRegion(resultado.getInt(2));

                listarProvincias.add(new ProvinciaDTO(this.getNombre(),this.getRegion()));
            }  
            conexion.close();
            return listarProvincias;
        }catch(Exception e){
            System.out.println("Error : " + e);
            return listarProvincias;
        }
    }      

}
