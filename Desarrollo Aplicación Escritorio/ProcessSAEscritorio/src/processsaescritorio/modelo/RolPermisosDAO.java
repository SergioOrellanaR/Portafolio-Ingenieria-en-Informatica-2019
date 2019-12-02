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
public class RolPermisosDAO implements DatosConexion {

    private int idRol;
    private int idPermiso;

    public RolPermisosDAO() {
    }

    public RolPermisosDAO(int idRol, int idPermiso) {
        this.idRol = idRol;
        this.idPermiso = idPermiso;
    }

    public int getIdRol() {
        return idRol;
    }

    public void setIdRol(int idRol) {
        this.idRol = idRol;
    }

    public int getIdPermiso() {
        return idPermiso;
    }

    public void setIdPermiso(int idPermiso) {
        this.idPermiso = idPermiso;
    }

    public ArrayList<RolPermisosDTO> obtenerRolPermisos() {

        ArrayList<RolPermisosDTO> listar = new ArrayList<RolPermisosDTO>();
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT ID_ROLE,ID_PERMISSION FROM role_permissions");
            while (resultado.next()) {
                this.setIdRol(resultado.getInt(1));
                this.setIdPermiso(resultado.getInt(2));
                listar.add(new RolPermisosDTO(this.getIdRol(), this.getIdPermiso()));
            }
            conexion.close();
            return listar;
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return listar;
        }
    }

    //Registrar rol permisos
    public String registrarPermisoPorRol() {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("INSERT INTO role_permissions (id_role, id_permission) VALUES ('" + this.getIdRol() + "','" + this.getIdPermiso() + "')");
            //INSERT INTO permission (NAME,description )VALUES ('dato de prueba','Permite probar2');
            conexion.close();
            return "El registro de permiso fue exitoso.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo registrar permiso : " + e;
        }
    }

    public ArrayList<RolPermisosDTO> obtenerPermisosPorRoles(int rol) {

        ArrayList<RolPermisosDTO> listar = new ArrayList<RolPermisosDTO>();
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("select id,name from permission join role_permissions rp on permission.id=rp.id_permission where rp.id_role=" + rol);
            while (resultado.next()) {
                this.setIdRol(rol);
                this.setIdPermiso(resultado.getInt(1));
                listar.add(new RolPermisosDTO(this.getIdRol(), this.getIdPermiso()));
            }
            conexion.close();
            return listar;
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return listar;
        }
    }

    public RolPermisosDTO validarPermisoUsuarioBD(int idUsuario, int idPermiso) {

       /* int getAssignedUnit = 0;
        int getInternalUnit = 0;
        int getIdRole = 0;
        int getPermisoValido = 0;*/
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT INTERNAL_UNIT.ID_ROLE,ROLE_PERMISSIONS.ID_PERMISSION FROM INTERNAL_UNIT join  ROLE_PERMISSIONS ON INTERNAL_UNIT.ID_ROLE=ROLE_PERMISSIONS.id_role join ASSIGNED_UNIT on INTERNAL_UNIT.ID=assigned_unit.id_internalunit JOIN USER_INFO ON USER_INFO.ID_ASSIGNED_UNIT=assigned_unit.id  WHERE USER_INFO.ID = " + idUsuario + " and ROLE_PERMISSIONS.ID_PERMISSION = " + idPermiso);
            while (resultado.next()) {

                this.setIdRol(resultado.getInt(1));
                this.setIdPermiso(resultado.getInt(2));
            }
            conexion.close();
        } catch (Exception e) {
            System.out.println("Error en obtención de permiso desde BD: " + e);
        }
        ///RolDTO(this.getId(), this.getNombre());
        return new RolPermisosDTO(this.getIdRol(), this.getIdPermiso());
    }

}
