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
public class ComunaDTO {
    
    private int id;
    private String nombre;
    private int provincia;

    public ComunaDTO() {
    }

    public ComunaDTO(int id,String nombre, int provincia) {
        this.id=id;
        this.nombre = nombre;
        this.provincia = provincia;
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

    public int getProvincia() {
        return provincia;
    }

    public void setProvincia(int provincia) {
        this.provincia = provincia;
    }
    
    
    
}
