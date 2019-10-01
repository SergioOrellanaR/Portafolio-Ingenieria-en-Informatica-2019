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
public class EstadoTareaDAO implements DatosConexion {
    
    private int id;
    private String status;

    public EstadoTareaDAO(int id, String status) {
        this.id = id;
        this.status = status;
    }

    public EstadoTareaDAO() {
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
    
       public ArrayList<EstadoTareaDTO> obtenerEstadoTarea(){
        
        ArrayList<EstadoTareaDTO> listarEstadoTarea = new ArrayList<EstadoTareaDTO>();
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT id ,status FROM task_status");
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setStatus(resultado.getString(2));
                listarEstadoTarea.add(new EstadoTareaDTO(this.getId(),this.getStatus()));              
            }  
            conexion.close();
            return listarEstadoTarea;
        }catch(Exception e){
            System.out.println("Error : " + e);
            return listarEstadoTarea;
        }
    } 
}
