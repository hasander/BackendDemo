# Backend Demo Project
<h2>How is installation?</h2>

<h3>Step 1:Clone Project</h3>
<ul>
<li>Please clone BackendDemo repository. "https://github.com/hasander/BackendDemo.git"</li>
</ul>

<h3>Step 2:Update Database</h3>
<ul>
<li>Open BackendDemo project in Visual Studio</li>
<li>Change 'ConnectionStrings:AppDb' value for your postgresql connection</li>
<li>Select BackendDemo.API project</li>
<li>Open Package Manager Console</li>
<li>Select BackendDemo.Data for 'Default Project'</li>
<li>Run 'update-database -context AppDbContext' in Package Manager Console</li>
</ul>

<h3>Step 3:Start Project</h3>
<ul>
<li>Start project and post request 'api/Auth/Login' default user firstname Admin lastname Admin in Postman or Swagger</li> 
<li>Getting AccessToken for access all request</li> 
<li>Adding header Authentication Berear 'AccessToken'</li> 
</ul>

<h2>İt is done! 👏</h2>
