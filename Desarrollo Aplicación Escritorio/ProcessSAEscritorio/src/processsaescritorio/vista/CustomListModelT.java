/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processsaescritorio.vista;

import java.util.ArrayList;
import javax.swing.AbstractListModel;
import processsaescritorio.modelo.PermisoDTO;
import processsaescritorio.modelo.TareaDTO;

/**
 *
 * @author yo
 */
public class CustomListModelT extends AbstractListModel {

    private ArrayList lista = new ArrayList<>();

    @Override
    public int getSize() {
        return lista.size();
    }

    @Override
    public Object getElementAt(int index) {
        TareaDTO p = (TareaDTO) lista.get(index);
        return p.getNombre();
    }

    public int getIdTarea(int index) {
        TareaDTO p = (TareaDTO) lista.get(index);
        return p.getId();
    }

 
    public void addTarea(TareaDTO p) {
        lista.add(p);
        this.fireIntervalAdded(this, getSize(), getSize() + 1);
    }

    public void eliminarTarea(int index0) {
        lista.remove(index0);
        this.fireIntervalRemoved(index0, getSize(), getSize() + 1);
    }

    public int getIndic(int index) {
        return lista.indexOf(index);
    }

    public TareaDTO getTarea(int index) {
        return (TareaDTO) lista.get(index);
    }

}
