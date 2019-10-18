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
     
    public ArrayList<ProvinciaDTO> listarProvincias(int region){
        ArrayList<ProvinciaDTO> listarProvincias = new ProvinciaDAO().listarProvinciasPorRegion(region);
        return listarProvincias;
    }
    
    public ArrayList<ComunaDTO> listarComunasPorProvincia(int comuna){
        ArrayList<ComunaDTO> listarComunas = new ComunaDAO().listarComunasPorProvincia(comuna);
        return listarComunas;
    }
       
    public ArrayList<AreaTrabajoDTO> listarAreasTrabajo(){
        ArrayList<AreaTrabajoDTO> listarAreasTrabajo = new AreaTrabajoDAO().obtenerAreasTrabajo();
        return listarAreasTrabajo;
    }
    
    public ArrayList<CompaniaDTO> listarCompanias(){
        ArrayList<CompaniaDTO> listarCompanias = new CompaniaDAO().obtenerCompanias();
        return listarCompanias;
    }
    
    public ArrayList<EstadoTareaDTO> listarEstadoTareas(){
        ArrayList<EstadoTareaDTO> listarEstadosTareas = new EstadoTareaDAO().obtenerEstadoTarea();
        return listarEstadosTareas;
    }   
    
    public ArrayList<UsuarioDTO> listarUsuarios(){
        ArrayList<UsuarioDTO> listaUsuarios = new UsuarioDAO().obtenerTodosLosUsuariosBD();
        return listaUsuarios;
    }
    
    public ArrayList<UnidadAsignadaDTO> listarUnidadAsignada(){
        ArrayList<UnidadAsignadaDTO> listaUnidadAsignada = new UnidadAsignadaDAO().obtenerUnidadAsignada();
        return listaUnidadAsignada;
    }
    
    public ArrayList<GeneroDTO> listarGeneroPersona(){
        ArrayList<GeneroDTO> listaGenero = new GeneroDAO().listarGenerosPersona();
        return listaGenero;
    }
    
     public ArrayList<UnidadAsignadaDTO> listarUnidadAsignadaPorCompania(int compania){
        ArrayList<UnidadAsignadaDTO> listaUnidadAsignada = new UnidadAsignadaDAO().listarPorCompania(compania);
        return listaUnidadAsignada;
    }
    
    
       
}
