using System.Data;

class DBConnection {
  private readonly IDbConnection connection;
  public DBConnection(IDbConnection connection) {
    this.connection = connection;
  }
  public void ExecuteQuery(string query) {
    // Execute the query and return the result set
  }
}
