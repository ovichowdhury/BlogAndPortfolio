import java.sql.*;
import java.math.*;


public class DbConnection{
	
	static String JDBC_DRV = "com.mysql.jdbc.Driver";
	static String DB_URL = "jdbc:mysql://localhost";
	
	public static void main(String [] args){
		try{
			Class.forName(JDBC_DRV);
			System.out.println("Driver found");
		}catch(SQlException e){
			System.out.println("Database error: " + e.getMessage());
		}
	}
	
}