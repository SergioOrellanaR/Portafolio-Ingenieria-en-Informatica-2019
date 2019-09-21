/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.controlador;

import java.util.ArrayList;
import processsaescritorio.modelo.*;

/**
 *
 * @author yo
 */
public class Lista {

    public Lista() {
    }
    
     public ArrayList<RegionDTO> listarRegiones(){
        ArrayList<RegionDTO> listaRegiones = new RegionDAO().obtenerRegionesBD();
        return listaRegiones;
    }   
}
