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
public class TareaDTO {
    
    private int id;
    private String nombre,descripcion;
    private int predefinido;
    private int activo;
    private int idTareaSuperior;
    private int idDependenciaTarea;

    public TareaDTO(int id, String nombre, String descripcion, int predefinido, int activo, int idTareaSuperior, int idDependenciaTarea) {
        this.id = id;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.predefinido = predefinido;
        this.activo = activo;
        this.idTareaSuperior = idTareaSuperior;
        this.idDependenciaTarea = idDependenciaTarea;
    }
    
    public TareaDTO() {
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

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public int getPredefinido() {
        return predefinido;
    }

    public void setPredefinido(int predefinido) {
        this.predefinido = predefinido;
    }

    public int getActivo() {
        return activo;
    }

    public void setActivo(int activo) {
        this.activo = activo;
    }

    public int getIdTareaSuperior() {
        return idTareaSuperior;
    }

    public void setIdTareaSuperior(int idTareaSuperior) {
        this.idTareaSuperior = idTareaSuperior;
    }

    public int getIdDependenciaTarea() {
        return idDependenciaTarea;
    }

    public void setIdDependenciaTarea(int idDependenciaTarea) {
        this.idDependenciaTarea = idDependenciaTarea;
    }
       
      /*
    INSERT INTO task(name, description, ispredefined, isactive, id_superior_task, id_dependent_task)
    VALUES ('Organizar tiempos del proyecto', 
    'Se deben realizar documentos para la 
    organizacion del tiempo del proyecto',
    1,null,null,null);
    */

}
