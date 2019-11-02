/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.controlador;
import processsaescritorio.modelo.*;

/**
 *
 * @author yo
 */
public class Actualizacion {
    
               
        //actualizar compañia
    public String actualizarCompania(int id,String nombre,String direccion,int idAreaTrabajo,int idComuna){
        return new CompaniaDAO().actualizarCompañia(id, nombre, direccion, idAreaTrabajo, idComuna);
    }
    
    public String actualizarUsuario(int id,String nombre){
        return new UsuarioDAO().actualizarUsuario(id, nombre);
    }
    
   
    
    
    
}
