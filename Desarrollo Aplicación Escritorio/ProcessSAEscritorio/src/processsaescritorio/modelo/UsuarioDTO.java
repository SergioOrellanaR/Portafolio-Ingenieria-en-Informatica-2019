/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.modelo;

import java.time.LocalDate;

/**
 *
 * @author Brayan
 */
public class UsuarioDTO {

    int id, idCommune, idAssignedUnit, idCompany, idGender;
    String firstname, lastname, address, phone, email, password;
    LocalDate birthdate;

    public UsuarioDTO(int id, String firstname, String lastname, String address, String phone, LocalDate birthdate, String email, String password, int idCommune, int idAssignedUnit, int idCompany, int idGender) {
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

    public UsuarioDTO() {
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

}
