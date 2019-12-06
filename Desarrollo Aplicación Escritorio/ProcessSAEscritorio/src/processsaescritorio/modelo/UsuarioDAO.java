/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.modelo;

import java.sql.*;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Base64;

/**
 *
 * @author Brayan
 */
public class UsuarioDAO implements DatosConexion {

    int id, idCommune, idAssignedUnit, idCompany, idGender;
    String firstname, lastname, address, phone, email, password;
    LocalDate birthdate;

    public UsuarioDAO() {
    }

    public UsuarioDAO(int id, String firstname, String lastname, String address, String phone, LocalDate birthdate, String email, String password, int idCommune, int idAssignedUnit, int idCompany, int idGender) {
        this.id = id;
        this.idCommune = idCommune;
        this.idAssignedUnit = idAssignedUnit;
        this.idCompany = idCompany;
        this.idGender = idGender;
        this.firstname = firstname;
        this.lastname = lastname;
        this.address = address;
        this.phone = phone;
        this.email = email;
        this.password = password;
        this.birthdate = birthdate;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getIdCommune() {
        return idCommune;
    }

    public void setIdCommune(int idCommune) {
        this.idCommune = idCommune;
    }

    public int getIdAssignedUnit() {
        return idAssignedUnit;
    }

    public void setIdAssignedUnit(int idAssignedUnit) {
        this.idAssignedUnit = idAssignedUnit;
    }

    public int getIdCompany() {
        return idCompany;
    }

    public void setIdCompany(int idCompany) {
        this.idCompany = idCompany;
    }

    public int getIdGender() {
        return idGender;
    }

    public void setIdGender(int idGender) {
        this.idGender = idGender;
    }

    public String getFirstname() {
        return firstname;
    }

    public void setFirstname(String firstname) {
        this.firstname = firstname;
    }

    public String getLastname() {
        return lastname;
    }

    public void setLastname(String lastname) {
        this.lastname = lastname;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public LocalDate getBirthdate() {
        return birthdate;
    }

    public void setBirthdate(LocalDate birthdate) {
        this.birthdate = birthdate;
    }

    public ArrayList<UsuarioDTO> obtenerTodosLosUsuariosBD() {
        ArrayList<UsuarioDTO> listaUsuarios = new ArrayList<UsuarioDTO>();
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT ID FROM USER_INFO");
            while (resultado.next()) {
                listaUsuarios.add(obtenerUsuarioPorIdBD(resultado.getInt(1)));
            }
            conexion.close();
        } catch (Exception e) {
            System.out.println("Error en obtención de usuario desde BD: " + e);
        }
        return listaUsuarios;
    }

    public UsuarioDTO obtenerUsuarioPorIdBD(int id) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT USER_INFO.ID, USER_INFO.FIRSTNAME, USER_INFO.LASTNAME, USER_INFO.ADDRESS, USER_INFO.PHONE,TO_CHAR(USER_INFO.BIRTHDATE, 'YYYY-MM-DD'), USER_INFO.EMAIL, USER_INFO.PASSWORD, "
                    + "USER_INFO.ID_COMMUNE, USER_INFO.ID_ASSIGNED_UNIT, USER_INFO.ID_COMPANY, USER_INFO.ID_GENDER FROM USER_INFO WHERE USER_INFO.ID = " + id);
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setFirstname(resultado.getString(2));
                this.setLastname(resultado.getString(3));
                this.setAddress(resultado.getString(4));
                this.setPhone(resultado.getString(5));
                this.setBirthdate(LocalDate.parse(resultado.getString(6)));
                this.setEmail(resultado.getString(7));
                this.setPassword(resultado.getString(8));
                this.setIdCommune(resultado.getInt(9));
                this.setIdAssignedUnit(resultado.getInt(10));
                this.setIdCompany(resultado.getInt(11));
                this.setIdGender(resultado.getInt(12));
            }
            conexion.close();
        } catch (Exception e) {
            System.out.println("Error en obtención de usuario desde BD: " + e);
        }
        return new UsuarioDTO(this.getId(), this.getFirstname(), this.getLastname(), this.getAddress(), this.getPhone(), this.getBirthdate(), this.getEmail(),
                this.getPassword(), this.getIdCommune(), this.getIdAssignedUnit(), this.getIdCompany(), this.getIdGender());
    }

    public UsuarioDTO obtenerUsuarioPorIdBD(String email, String clave) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            String encoded = Base64.getEncoder().encodeToString(clave.getBytes());
            ResultSet resultado = declaracion.executeQuery("SELECT USER_INFO.ID, USER_INFO.FIRSTNAME, USER_INFO.LASTNAME, USER_INFO.ADDRESS, USER_INFO.PHONE,TO_CHAR(USER_INFO.BIRTHDATE, 'YYYY-MM-DD'), USER_INFO.EMAIL, USER_INFO.PASSWORD, "
                    + "USER_INFO.ID_COMMUNE, USER_INFO.ID_ASSIGNED_UNIT, USER_INFO.ID_COMPANY, USER_INFO.ID_GENDER FROM USER_INFO WHERE USER_INFO.EMAIL = '" + email + "'AND USER_INFO.PASSWORD = '" + encoded + "'");
            while (resultado.next()) {
                this.setId(resultado.getInt(1));
                this.setFirstname(resultado.getString(2));
                this.setLastname(resultado.getString(3));
                this.setAddress(resultado.getString(4));
                this.setPhone(resultado.getString(5));
                this.setBirthdate(LocalDate.parse(resultado.getString(6)));
                this.setEmail(resultado.getString(7));
                this.setPassword(resultado.getString(8));
                this.setIdCommune(resultado.getInt(9));
                this.setIdAssignedUnit(resultado.getInt(10));
                this.setIdCompany(resultado.getInt(11));
                this.setIdGender(resultado.getInt(12));
            }
            conexion.close();
        } catch (Exception e) {
            System.out.println("Error en obtención de usuario desde BD: " + e);
        }
        return new UsuarioDTO(this.getId(), this.getFirstname(), this.getLastname(), this.getAddress(), this.getPhone(), this.getBirthdate(), this.getEmail(),
                this.getPassword(), this.getIdCommune(), this.getIdAssignedUnit(), this.getIdCompany(), this.getIdGender());
    }

    public String codificarClave(String clave) {
        return Base64.getEncoder().encodeToString(clave.getBytes());
    }

    public int validarUsuarioBD(String email, String clave) {
        int validacion = 0;
        int getAssignedUnit = 0;
        int getInternalUnit = 0;
        int getIdRole = 0;
        int getPermisoValido = 0;
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            String encoded = Base64.getEncoder().encodeToString(clave.getBytes());
            ResultSet resultado = declaracion.executeQuery("SELECT COUNT(ID) FROM USER_INFO WHERE USER_INFO.EMAIL = '" + email + "' AND USER_INFO.PASSWORD = '" + encoded + "'");
            while (resultado.next()) {
                validacion = resultado.getInt(1);
                ResultSet id_assigned_unit = declaracion.executeQuery("SELECT ID_ASSIGNED_UNIT FROM USER_INFO WHERE USER_INFO.EMAIL = '" + email + "' AND USER_INFO.PASSWORD = '" + encoded + "'");
                if (id_assigned_unit.next()) {
                    getAssignedUnit = id_assigned_unit.getInt(1);
                }
                ResultSet id_internal_unit = declaracion.executeQuery("SELECT ID_INTERNALUNIT FROM ASSIGNED_UNIT WHERE ID = '" + getAssignedUnit + "'");
                if (id_internal_unit.next()) {
                    getInternalUnit = id_internal_unit.getInt(1);
                }
                ResultSet id_role = declaracion.executeQuery("SELECT ID_ROLE FROM INTERNAL_UNIT WHERE ID = '" + getInternalUnit + "'");
                if (id_role.next()) {
                    getIdRole = id_role.getInt(1);
                }
                ResultSet permisoValido = declaracion.executeQuery("SELECT ID_PERMISSION FROM ROLE_PERMISSIONS WHERE ID_ROLE = '" + getIdRole + "' AND ID_PERMISSION = 1");
                if (permisoValido.next()) {
                    if (true) {
                        getPermisoValido = permisoValido.getInt(1);
                        validacion = validacion + 1;
                    }
                }
            }
            conexion.close();
        } catch (Exception e) {
            System.out.println("Error en obtención de usuario desde BD: " + e);
        }
        return validacion;
    }

    public int validarPermisoUsuarioBD(int idUsuario, int idPermiso) {
        int validacion = 0;
        int getAssignedUnit = 0;
        int getInternalUnit = 0;
        int getIdRole = 0;
        int getPermisoValido = 0;
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT COUNT(ID) FROM USER_INFO WHERE USER_INFO.id =" + idUsuario);
            while (resultado.next()) {
                validacion = resultado.getInt(1);
                ResultSet id_assigned_unit = declaracion.executeQuery("SELECT ID_ASSIGNED_UNIT FROM USER_INFO WHERE USER_INFO.id = " + id);
                if (id_assigned_unit.next()) {
                    getAssignedUnit = id_assigned_unit.getInt(1);
                }
                ResultSet id_internal_unit = declaracion.executeQuery("SELECT ID_INTERNALUNIT FROM ASSIGNED_UNIT WHERE ID = '" + getAssignedUnit + "'");
                if (id_internal_unit.next()) {
                    getInternalUnit = id_internal_unit.getInt(1);
                }
                ResultSet id_role = declaracion.executeQuery("SELECT ID_ROLE FROM INTERNAL_UNIT WHERE ID = '" + getInternalUnit + "'");
                if (id_role.next()) {
                    getIdRole = id_role.getInt(1);
                }
                ResultSet permisoValido = declaracion.executeQuery("SELECT ID_PERMISSION,ID_ROLE FROM ROLE_PERMISSIONS WHERE ID_ROLE = '" + getIdRole + "' AND ID_PERMISSION =" + idPermiso);
                if (permisoValido.next()) {
                    if (true) {
                        getPermisoValido = permisoValido.getInt(1);
                        validacion = validacion + 1;
                    }
                }
            }
            conexion.close();
        } catch (Exception e) {
            System.out.println("Error en obtención de permiso desde BD: " + e);
        }
        return validacion;
    }

    public String crearUsuario() {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("INSERT INTO User_info(firstname,lastname,address,phone,birthdate,email,password,id_commune,id_assigned_unit,id_company,id_gender)VALUES "
                    + "('" + this.getFirstname() + "','" + this.getLastname() + "','" + this.getAddress() + "','" + this.getPhone() + "',TO_DATE('" + this.getBirthdate() + "','YYYY-MM-DD:HH24:MI:SS'),'" + this.getEmail() + "','" + codificarClave(this.getPassword()) + "'," + this.getIdCommune() + "," + this.getIdAssignedUnit() + "," + this.getIdCompany() + "," + this.getIdGender() + ")");
            return "El registro de compañia fue exitoso.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo registrar compañia : " + e;
        }
    }

    public String actualizarUsuario(int id, String firstName) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("UPDATE User_info SET firstname = '" + firstName + "' WHERE ID = " + id + "");
            conexion.close();
            return "Actualización  fue exitosa.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo actualizar compañia : " + e;
        }
    }

    public String actualizarUsuarioLastname(int id, String lastname) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("UPDATE User_info SET lastname = '" + lastname + "' WHERE ID = " + id + "");
            conexion.close();
            return "Actualización  fue exitosa.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo actualizar compañia : " + e;
        }
    }

    public String actualizarUsuarioAddress(int id, String address) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("UPDATE User_info SET address = '" + address + "' WHERE ID = " + id + "");
            conexion.close();
            return "Actualización  fue exitosa.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo actualizar compañia : " + e;
        }
    }

    public String actualizarUsuarioPhone(int id, String phone) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("UPDATE User_info SET phone = '" + phone + "' WHERE ID = " + id + "");
            conexion.close();
            return "Actualización  fue exitosa.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo actualizar compañia : " + e;
        }
    }

    public String actualizarUsuarioBorn(int id, LocalDate born) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("UPDATE User_info SET birthdate = TO_DATE('" + born + "','YYYY-MM-DD:HH24:MI:SS') WHERE ID = " + id + "");
            conexion.close();
            return "Actualización  fue exitosa.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo actualizar compañia : " + e;
        }
    }

    public String actualizarUsuarioCommune(int id, int commune) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("UPDATE User_info SET id_commune = " + commune + " WHERE ID = " + id + "");
            conexion.close();
            return "Actualización  fue exitosa.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo actualizar compañia : " + e;
        }
    }

    public String actualizarUsuarioAssigned(int id, int assigned) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("UPDATE User_info SET id_assigned_unit = " + assigned + " WHERE ID = " + id + "");
            conexion.close();
            return "Actualización  fue exitosa.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo actualizar compañia : " + e;
        }
    }
    
    public String actualizarUsuarioCompany(int id, int company) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("UPDATE User_info SET id_company = " + company + " WHERE ID = " + id + "");
            conexion.close();
            return "Actualización  fue exitosa.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo actualizar compañia : " + e;
        }
    }
    
    public String actualizarUsuarioGender(int id, int gender) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("UPDATE User_info SET id_gender = " + gender + " WHERE ID = " + id + "");
            conexion.close();
            return "Actualización  fue exitosa.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo actualizar compañia : " + e;
        }
    }

    public String eliminarUsuario(int id) {
        try {
            Class.forName(DRIVER);
            Connection conexion = DriverManager.getConnection(URL, USUARIO, CLAVE);
            Statement declaracion = conexion.createStatement();
            declaracion.executeUpdate("Delete from User_Info WHERE ID = " + id + "");
            conexion.close();
            return "Se elimino exitosamente  fue exitosa.";
        } catch (Exception e) {
            System.out.println("Error : " + e);
            return "No se pudo eliminar el usuario : " + e;
        }
    }

    //Insert into User_info (firstname, lastname, address, phone, birthdate, email, password, id_commune, id_assigned_unit, id_company, id_gender) values ('Sergio Leonel', 
    //'Orellana Rey', 'Williams Rebolledo 2605', '+56974241612',TO_DATE('16-04-1994', 'DD-MM-YYYY'), 'serorellanar@gmail.com', 'cG9ydGFmb2xpbzIwMTk=', 100, 1, 1, 1);
    //TO_DATE('" + fechaFormateada + "', 'YYYY-MM-DD:HH24:MI:SS'),
}
