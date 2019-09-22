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
public class CompaniaDAO {
    private int id;
    private String nombre;
    private String direccion;
    private int idAreaTrabajo;
    private int idComuna;

    public CompaniaDAO() {
    }

    public CompaniaDAO(int id, String nombre, String direccion, int idAreaTrabajo, int idComuna) {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.idAreaTrabajo = idAreaTrabajo;
        this.idComuna = idComuna;
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

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public int getIdAreaTrabajo() {
        return idAreaTrabajo;
    }

    public void setIdAreaTrabajo(int idAreaTrabajo) {
        this.idAreaTrabajo = idAreaTrabajo;
    }

    public int getIdComuna() {
        return idComuna;
    }

    public void setIdComuna(int idComuna) {
        this.idComuna = idComuna;
    }
    
        public ArrayList<CompaniaDTO> obtenerCompanias(){
        
        ArrayList<CompaniaDTO> listarCompanias = new ArrayList<CompaniaDTO>();
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT id ,name FROM company");
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setNombre(resultado.getString(2));
                listarCompanias.add(new CompaniaDTO(this.getId(),this.getNombre()));
                       
            }  
            conexion.close();
            return listarCompanias;
        }catch(Exception e){
            System.out.println("Error : " + e);
            return listarCompanias;
        }
    } 
}
