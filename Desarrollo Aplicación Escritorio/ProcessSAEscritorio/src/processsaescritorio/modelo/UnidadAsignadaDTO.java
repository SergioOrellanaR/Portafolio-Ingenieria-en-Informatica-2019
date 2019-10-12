/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.modelo;

/**
 *
 * @author Brayan
 */
public class UnidadAsignadaDTO {
    private int id, id_internalUnit, id_company, id_superior_unit;

    
    public UnidadAsignadaDTO() {
    }
    
    public UnidadAsignadaDTO(int id, int id_internalUnit, int id_company, int id_superior_unit) {
        this.id = id;
        this.id_internalUnit = id_internalUnit;
        this.id_company = id_company;
        this.id_superior_unit = id_superior_unit;
    }

    public int getId() {
        return id;
    }
    
    public void setId(int id) {
        this.id = id;
    }

    public int getId_internalUnit() {
        return id_internalUnit;
    }
    
    public void setId_internalUnit(int id_internalUnit) {
        this.id_internalUnit = id_internalUnit;
    }

    public int getId_company() {
        return id_company;
    }
    
    public void setId_company(int id_company) {
        this.id_company = id_company;
    }

    public int getId_superior_unit() {
        return id_superior_unit;
    }

    public void setId_superior_unit(int id_superior_unit) {
        this.id_superior_unit = id_superior_unit;
    }        
}
