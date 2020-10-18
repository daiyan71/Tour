Objective

  The objective of this project is to guide people to travel tourist spots of Bangladesh in a short time and in an affordable cost. 
In this website we will give information about famous places so that people don’t have to research about that.
As a result it will save their time. Hotels and tourist guide related information will also be given in the website. 
So that tourist can book hotels and tourist guide in advance through information given in the website and can have idea about the total cost beforehand.
People can also post blogs read blogs of other users. They can also communicate with us through the website.
 
Features
1•	Admin can see the list of all the locations,tour guides and hotels with image in a list view or with a image path in a list view.
2•	Admin can add,update or delete information of any location.
3•	Admin can add,update or delete information of any tour guide of a specific location.
4•	Admin can add,update or delete information of any hotel of a specific location.
5•	Admin can see the messages sent from the contact us page.
6•	Admin can delete any blog posted by the user.
7•	User can get an overview about different tourist places of Bangladesh.
8•	User can find tour guide according to the given location.
9•	User can  find hotel according to the given location.
10•	User can sign up.
11•	User can login and see user name on the navbar.
12•	User can see the information of the admin on the about us page.
13•	Login is needed to see detail information of tour guides and hotels.
14•	Only logged in user can post blogs.
15•	Any one can see the blogs posted by the users.
16•	Any one can send messgae with a subject to the admins through the contact us page.


Group member's cotribution:
	ID: 17.01.04.142 --> Features 7 ,8 ,9 ,13
	ID: 17.01.04.144 --> Features 10,11,12,14,15,16
	ID: 17.01.04.154 --> Features 1 ,2 ,3 ,4 ,5 ,6





<-----------------------------------------------------------------------------  HOW TO RUN THE PROJECT ---------------------------------------------------------------------------------->

	After unzipping the zip file open the database folder and import Tour.bacpac file to the latest microsoft sql manager. We used windows authentication to login.
	Then open the Tour folder and open the project. Before running the project,go to the webconfig file and look for <connectionStrings> . Then in the <add name="DbModels" .... line
	find source=DAIYAN\SQLEXPRESS. Then replace 'DAIYAN\SQLEXPRESS' with your server name.
	Now the project should run without any problem.



