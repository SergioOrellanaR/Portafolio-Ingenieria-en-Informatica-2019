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
public interface DatosConexion {
    public String URL     = "jdbc:oracle:thin:@localhost:1521:ORCL";
    public String USUARIO = "ProcessSA";
    public String CLAVE   = "pft2019";
    public String DRIVER  = "oracle.jdbc.OracleDriver";
}
