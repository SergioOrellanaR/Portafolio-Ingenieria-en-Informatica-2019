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
public class UnidadInternaDAO implements DatosConexion {

    private int id;
    private int idRol;
    private String nombre;

    public UnidadInternaDAO() {
    }

    public UnidadInternaDAO(int id, int idRol, String nombre) {
        this.id = id;
        this.idRol = idRol;
        this.nombre = nombre;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getIdRol() {
        return idRol;
    }

    public void setIdRol(int idRol) {
        this.idRol = idRol;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String registrarUnidadInterna() {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("Insert into Internal_Unit (id_role, name) values(" + this.getIdRol() + ",'" + this.getNombre() + "')");
            //Insert into Internal_Unit (id_role, name) values (3,'CEO');
            conexion.close();
            return "El registro de la Unidad interna fue exitoso.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo registrar la unidad interna : " + e;
        }
    }

    public ArrayList<UnidadInternaDTO> listar() {

        ArrayList<UnidadInternaDTO> listar = new ArrayList<UnidadInternaDTO>();
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT id ,id_role,name from Internal_unit");
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setIdRol(resultado.getInt(2));
                this.setNombre(resultado.getString(3));

                listar.add(new UnidadInternaDTO(this.getId(), this.getIdRol(), this.getNombre()));
            }
            conexion.close();
            return listar;
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return listar;
        }
    }

    public String nombreUnidad(int id) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT name from Internal_unit where id=" + id + "");
            while (resultado.next()) {
                this.setNombre(resultado.getString(1));
            }
            conexion.close();
            return this.getNombre();
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return " ";
        }
    }

    public UnidadInternaDTO UnidadPorID(int id) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT id,name,id_role from Internal_unit where id=" + id + "");
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setNombre(resultado.getString(2));
                this.setIdRol(resultado.getInt(3));
            }
            conexion.close();
        } catch (Exception e) {
            System.out.println("Error : " + e);

        }
        return new UnidadInternaDTO(this.getId(), this.getIdRol(), this.getNombre());
    }

}
