/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.modelo;

/**
 *
 * @author yo
 */
public class CompaniaDTO {

    private int id;
    private String nombre;
    private String direccion;
    private int idAreaTrabajo;
    private int idComuna;

    public CompaniaDTO() {
    }

    public CompaniaDTO(int id, String nombre) {
        this.id = id;
        this.nombre = nombre;   
    }

    public CompaniaDTO(int id, String nombre, String direccion, int idAreaTrabajo, int idComuna) {
        this.id=id;
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



}
