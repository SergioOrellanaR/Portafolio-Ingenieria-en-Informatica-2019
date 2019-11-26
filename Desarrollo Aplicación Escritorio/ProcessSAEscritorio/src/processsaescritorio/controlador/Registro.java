/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.controlador;

import java.time.LocalDate;
import processsaescritorio.modelo.*;

/**
 *
 * @author Brayan
 */
public class Registro {

    public Registro() {
    }

    public String registrarCompania(String nombre, String direccion, int idAreaTrabajo, int idComuna) {
        return new CompaniaDAO(0, nombre, direccion, idAreaTrabajo, idComuna).registrarCompanias();
    }

    public String registrarUsuario(String nombre, String apellido, String direccion, String telefono, LocalDate cumpleanos, String email, String pass, int comuna, int unidad, int compania, int genero) {
        return new UsuarioDAO(0, nombre, apellido, direccion, telefono, cumpleanos, email, pass, comuna, unidad, compania, genero).crearUsuario();
    }

    public String registrarPermisoPorRol(int rol, int permiso) {
        return new RolPermisosDAO(rol, permiso).registrarPermisoPorRol();
    }

    public String registrarRol(int id, String nombre) {
        return new RolDAO(0, nombre).crearRol();
    }

    public String registrarTarea(String name, String description, int ispredefined, int isactive, int id_superior_task, int id_dependent_task) {
        return new TareaDAO(0, name, description, ispredefined, isactive, id_superior_task, id_dependent_task).crearTarea();
    }
}
