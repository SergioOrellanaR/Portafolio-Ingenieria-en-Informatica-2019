/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.controlador;
import processsaescritorio.modelo.*;

/**
 *
 * @author Brayan
 */
public class Registro {

    public Registro() {
    }
    
    public String registrarCompania(String nombre, String direccion, int idAreaTrabajo, int idComuna){
       return new CompaniaDAO(0,nombre, direccion, idAreaTrabajo, idComuna).registrarCompanias();
    }
}
