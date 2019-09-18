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
import java.util.Base64;

/**
 *
 * @author Brayan
 */
public class UsuarioDAO implements DatosConexion{
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
    
    public ArrayList<UsuarioDTO> obtenerTodosLosUsuariosBD(){
        ArrayList<UsuarioDTO> listaUsuarios = new ArrayList<UsuarioDTO>();
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT ID FROM USER_INFO");
            while (resultado.next()) {
                listaUsuarios.add(obtenerUsuarioPorIdBD(resultado.getInt(1)));
            }
            conexion.close();
        }catch(Exception e){
            System.out.println("Error en obtención de usuario desde BD: " + e);
        }
        return listaUsuarios;
    }   
    
    public UsuarioDTO obtenerUsuarioPorIdBD(int id){
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            ResultSet resultado = declaracion.executeQuery("SELECT USER_INFO.ID, USER_INFO.FIRSTNAME, USER_INFO.LASTNAME, USER_INFO.ADDRESS, USER_INFO.PHONE, USER_INFO.BIRTHDATE, USER_INFO.EMAIL, USUARIO.PASSWORD, "
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
        }catch(Exception e){
            System.out.println("Error en obtención de usuario desde BD: " + e);
        }
        return new UsuarioDTO(this.getId(), this.getFirstname(), this.getLastname(), this.getAddress(), this.getPhone(), this.getBirthdate(), this.getEmail(), 
                this.getPassword(), this.getIdCommune(), this.getIdAssignedUnit(), this.getIdCompany(), this.getIdGender());
    }    
    
    public int validarUsuarioBD(String email, String clave){
        int validacion = 0;
        try{
            Class.forName(DRIVER);
            Connection conexion =  DriverManager.getConnection(URL,USUARIO,CLAVE);
            Statement declaracion = conexion.createStatement();
            String encoded = Base64.getEncoder().encodeToString(clave.getBytes());
            ResultSet resultado = declaracion.executeQuery("SELECT COUNT(ID) FROM USUARIO WHERE NOMBRE = '" + email + "' AND CLAVE = '" + encoded + "'");
            while (resultado.next()) {
                validacion = resultado.getInt(1);
            }
            conexion.close();
        }catch(Exception e){
            System.out.println("Error en obtención de usuario desde BD: " + e);
        }
        return validacion;
    }
    
}
