/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.controlador;
import processsaescritorio.modelo.*;
import processsaescritorio.modelo.*;

/**
 *
 * @author yo
 */


public class Eliminar {

    public Eliminar() {
    }
    
    public String eliminarUsuario (int id){
        return new UsuarioDAO().eliminarUsuario(id);
    }
    
    public String eliminarCompania (int id){
        return new CompaniaDAO().eliminarCompania(id);
    }
}
