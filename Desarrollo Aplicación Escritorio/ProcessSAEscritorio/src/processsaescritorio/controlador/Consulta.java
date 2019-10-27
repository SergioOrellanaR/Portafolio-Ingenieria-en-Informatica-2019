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
 * @author Brayan
 */
public class Consulta {

    public UsuarioDTO obtenerUsuarioPorNombreClave(String email, String clave){
        return new UsuarioDAO().obtenerUsuarioPorIdBD(email, clave);
    }
    
    public int validarUsuario(String email, String clave){
        return new UsuarioDAO().validarUsuarioBD(email, clave);
    }  
    
    public String buscarunidad(int id){
        return new UnidadInternaDAO().nombreUnidad(id);
    }
    
     public String[] listarPorComuna(int id){
        return new ComunaDAO().listarProporComuna(id);
    } 
    
}
