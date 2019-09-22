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
public class ProvinciaDTO {
    
    private String nombre;
    private int region;

    public ProvinciaDTO() {
    }

    public ProvinciaDTO(String nombre,int region) {
        this.nombre = nombre;
        this.region = region;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getRegion() {
        return region;
    }

    public void setRegion(int region) {
        this.region = region;
    }
    
    
    
    
    
    
    
}
