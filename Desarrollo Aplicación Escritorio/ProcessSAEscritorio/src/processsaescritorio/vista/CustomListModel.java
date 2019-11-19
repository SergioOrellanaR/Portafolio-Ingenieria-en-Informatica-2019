/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.vista;

import java.util.ArrayList;
import javax.swing.AbstractListModel;
import processsaescritorio.modelo.PermisoDTO;

/**
 *
 * @author yo
 */
public class CustomListModel extends AbstractListModel {

    private ArrayList lista = new ArrayList<>();

    @Override
    public int getSize() {
        return lista.size();
    }

    @Override
    public Object getElementAt(int index) {
        PermisoDTO p = (PermisoDTO) lista.get(index);
        return p.getNombre();
    }

    public int getIdPermiso(int index) {
        PermisoDTO p = (PermisoDTO) lista.get(index);
        return p.getId();
    }

    public void addPermiso(PermisoDTO p) {
        lista.add(p);
        this.fireIntervalAdded(this, getSize(), getSize() + 1);
    }

    public void eliminarPersona(int index0) {
        lista.remove(index0);
        this.fireIntervalRemoved(index0, getSize(), getSize() + 1);
    }

    public int getIndic(int index) {
        return lista.indexOf(index);
    }

    public PermisoDTO getPermiso(int index) {
        return (PermisoDTO) lista.get(index);
    }

}
