class DBConnection {
  private final Connection connection;
  public DBConnection(Connection connection) {
    this.connection = connection;
  }
  public void executeQuery(String query) {
    // Execute the query and return the result set
  }
}