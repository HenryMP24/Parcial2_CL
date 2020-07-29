
package javaapplication2;
import javax.swing.*;
import java.sql.*;
import javax.swing.table.DefaultTableModel;
public class basededatos {
    
   Connection conexion=null;
   String pass="123456";
   String user="postgres";
       
    public void conectarme(){
      try{
           conexion = DriverManager.getConnection("jdbc:postgresql://localhost:5432/academico",user,pass);
           JOptionPane.showMessageDialog(null,"Estas conectado");
       }
      catch(Exception e){
           JOptionPane.showMessageDialog(null,"Error conectar"+e);
      }
    }
    public void consultar(JTable tabla,String script){
        Statement codigoSQL=null;
        ResultSet resultados=null;
        
        try{
        DefaultTableModel t = new DefaultTableModel();
        tabla.setModel(t);
        
        conectarme();
        
        codigoSQL = conexion.createStatement();
        resultados=codigoSQL.executeQuery(script);
        ResultSetMetaData datos = resultados.getMetaData();
        
        int nc=datos.getColumnCount();
        for(int i=1;i<=nc;i++){
                t.addColumn(datos.getColumnLabel(i));
        }
        while(resultados.next()){
            Object [] f=new Object[nc];
            for(int i=0;i<nc;i++){
                f[i]=resultados.getObject(i+1);
            }
            t.addRow(f);
        }
        codigoSQL.close();
        resultados.close();
        conexion.close();
        }catch(Exception e){
            JOptionPane.showMessageDialog(null, e);
        }
    }
}
