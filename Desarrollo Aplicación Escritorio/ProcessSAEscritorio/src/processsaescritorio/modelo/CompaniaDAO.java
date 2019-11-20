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
    
     @Override
    public String toString() {
        return "CompaniaDTO{" + "id=" + id + ", nombre=" + nombre + '}';
    }
    
    public ArrayList<CompaniaDTO> obtenerCompanias(){
        
        ArrayList<CompaniaDTO> listarCompanias = new ArrayList<CompaniaDTO>();
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT id ,name,address, id_working_area, id_commune FROM company");
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setNombre(resultado.getString(2));
                this.setDireccion(resultado.getString(3));
                this.setIdAreaTrabajo(resultado.getInt(4));
                this.setIdComuna(resultado.getInt(5));
                listarCompanias.add(new CompaniaDTO(this.getId(),this.getNombre(),this.getDireccion(),this.getIdAreaTrabajo(),getIdComuna()));
                       
            }  
            conexion.close();
            return listarCompanias;
        }catch(Exception e){
            System.out.println("Error : " + e);
            return listarCompanias;
        }
    } 
    
    public CompaniaDTO obtenerCompaniaPorIdBD(int id){
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT id ,name,address, id_working_area, id_commune FROM company WHERE ID = " + id);
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setNombre(resultado.getString(2));
                this.setDireccion(resultado.getString(3));
                this.setIdAreaTrabajo(resultado.getInt(4));
                this.setIdComuna(resultado.getInt(5));
            }
            conexion.close();
        }catch(Exception e){
            System.out.println("Error en obtención de compañia desde BD: " + e);
        }
        return new CompaniaDTO(this.getId(), this.getNombre(), this.getDireccion(), this.getIdAreaTrabajo(), this.getIdComuna());
    }    
    
    public String registrarCompanias(){
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("INSERT INTO COMPANY(NAME,ADDRESS,LOGO,ID_WORKING_AREA,ID_COMMUNE)VALUES ('"+this.getNombre()+"','"+this.getDireccion()+"',Null,"+this.getIdAreaTrabajo()+","+this.getIdComuna()+")");
            //INSERT INTO COMPANY(NAME,ADDRESS,LOGO,ID_WORKING_AREA,ID_COMMUNE) VALUES ('Ironplat','Hugo Bravo ',NULL,2,2);
            conexion.close();
            return "El registro de compañia fue exitoso.";
        }catch(Exception e){
            System.out.println("Error : " + e);
            return "No se pudo registrar compañia : " + e;
        }        
    }

    public String actualizarCompañia(int id,String nombre,String direccion,int idAreaTrabajo,int idComuna){
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("UPDATE COMPANY SET NAME = '" + nombre+ "', ADDRESS = '" + direccion + "', ID_WORKING_AREA = " + idAreaTrabajo +",ID_COMMUNE "+idComuna + " WHERE ID = " + id +")");
            conexion.close();
            return "Actualización de compañia fue exitosa.";
        }catch(Exception e){
            System.out.println("Error : " + e);
            return "No se pudo actualizar compañia : " + e;
        }    
    }
    
    public String eliminarCompania(int id){
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("Delete from COMPANY WHERE ID = "+ id +"");
            conexion.close(); 
           return "Se elimino exitosamente.";
        }catch(Exception e){
            System.out.println("Error : " + e);
            return "No se pudo eliminar compañia : " + e;
        } 
    }
    
     
}
        
        
        

