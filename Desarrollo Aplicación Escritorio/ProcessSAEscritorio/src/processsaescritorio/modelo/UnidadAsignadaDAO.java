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
 * @author Brayan
 */
public class UnidadAsignadaDAO {
        private int id, id_internalUnit, id_company, id_superior_unit;

    
    public UnidadAsignadaDAO() {
    }
    
    public UnidadAsignadaDAO(int id, int id_internalUnit, int id_company, int id_superior_unit) {
        this.id = id;
        this.id_internalUnit = id_internalUnit;
        this.id_company = id_company;
        this.id_superior_unit = id_superior_unit;
    }

    public int getId() {
        return id;
    }
    
    public void setId(int id) {
        this.id = id;
    }

    public int getId_internalUnit() {
        return id_internalUnit;
    }
    
    public void setId_internalUnit(int id_internalUnit) {
        this.id_internalUnit = id_internalUnit;
    }

    public int getId_company() {
        return id_company;
    }
    
    public void setId_company(int id_company) {
        this.id_company = id_company;
    }

    public int getId_superior_unit() {
        return id_superior_unit;
    }

    public void setId_superior_unit(int id_superior_unit) {
        this.id_superior_unit = id_superior_unit;
    }   
    
     @Override
    public String toString() {
        return "UnidadAsignada{" + "id=" + id + ", Unidad Interna=" + id_internalUnit + ", Compañia="+id_company+ ", Unidad Superior="+id_superior_unit+ '}';
    }
    
    public ArrayList<UnidadAsignadaDTO> obtenerUnidadAsignada(){
        
        ArrayList<UnidadAsignadaDTO> listarUnidadAsignada = new ArrayList<UnidadAsignadaDTO>();
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT id ,ID_INTERNALUNIT, ID_COMPANY, ID_SUPERIOR_UNIT  FROM ASSIGNED_UNIT");
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setId_internalUnit(resultado.getInt(2));
                this.setId_company(resultado.getInt(3));
                this.setId_superior_unit(resultado.getInt(4));
                listarUnidadAsignada.add(new UnidadAsignadaDTO(this.getId(),this.getId_internalUnit(), this.getId_company(), this.getId_superior_unit()));
                       
            }  
            conexion.close();
            return listarUnidadAsignada;
        }catch(Exception e){
            System.out.println("Error : " + e);
            return listarUnidadAsignada;
        }
    } 
        
    public String registrarUnidadAsignada(){
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("INSERT INTO ASSIGNED_UNIT(ID,ID_INTERNALUNIT,ID_COMPANY,ID_SUPERIOR_UNIT)VALUES ('"+this.getId()+"','"+this.getId_internalUnit()+"',"+this.getId_company()+","+this.getId_superior_unit()+")");
            conexion.close();
            return "El registro de Unidad Asignada fue exitoso.";
        }catch(Exception e){
            System.out.println("Error : " + e);
            return "No se pudo registrar Unidad Asignada : " + e;
        }        
    }

     public String actualizarUnidadAsignada(int id,int id_internalUnit, int id_company,int id_superior_unit){
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("UPDATE ASSIGNED_UNIT SET ID_INTERNALUNIT = '" + id_internalUnit+ "', ID_COMPANY = '" + id_company + "', ID_SUPERIOR_UNIT = " + id_superior_unit +" WHERE ID = " + id +")");
            conexion.close();
            return "Actualización de Unidad Asignada fue exitosa.";
        }catch(Exception e){
            System.out.println("Error : " + e);
            return "No se pudo actualizar Unidad Asignada : " + e;
        }    
    }
}
