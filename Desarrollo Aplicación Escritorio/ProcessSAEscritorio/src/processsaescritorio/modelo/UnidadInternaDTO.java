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
public class UnidadInternaDTO {
    
    private int id;
    private int idRol;
    private String nombre;

    public UnidadInternaDTO() {
    }

    public UnidadInternaDTO(int id, int idRol, String nombre) {
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
    
    

}
