# CodingTracker
Progress notes:
1. Getting the connection to the DB setup and creating it.

	Installing the ConfigurationManager package and setting up the initial connection string (in Program.cs - but before the Main method.):

		static string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

	In order to get that configured properly - i set it up in the App.Config file,
	which i got, by "adding item -> XML file -> name="App.Config" -> Then adding this code:

		<configuration>
			<appSettings>
				<add key ="ConnectionString" value="Data Source=db.sqlite"/>
			</appSettings>
		</configuration>

	Then i create a DatabaseManager class (remember to use shortcut to create new files).

	    DatabaseManager databaseManager = new(); // shortcut to create the class file.
        databaseManager.CreateTable(connectionString); // Shortcut to create the method with parameters set.

	In this class i create a 'CreateTable(string connectionString)'' method, in which i instantiate the SqliteConnection.
	I install "Microsoft.Data.Sqlite.Core" package. 
	The method opens the connection (making use of the 'using' statement to handle garbage collection and other stuff).
	I call the 'CreateCommand()' method to create an SQL command, and set the CommandText to be database creating query:

	internal void CreateTable(string connectionString)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText =
                @"CREATE TABLE IF NOT EXISTS coding (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Duration TEXT
                )";

            tableCmd.ExecuteNonQuery();

            connection.Close();
        }
    }

	ERROR Handling: Had downloaded Sqlite.Core instead of jut SQlite... Fixed and now database is up and running

	Making the INSERT method.
