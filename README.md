After unzipping the zip file open the database folder and import Tour.bacpac file to the latest microsoft sql manager. We used windows authentication to login.
	Then open the Tour folder and open the project. Before running the project,go to the webconfig file and look for <connectionStrings> . Then in the <add name="DbModels" .... line
	find source=DAIYAN\SQLEXPRESS. Then replace 'DAIYAN\SQLEXPRESS' with your server name.
	Now the project should run without any problem.
