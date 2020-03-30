"# apisep" 

There are a lot of files.  This is just to showcase a number of features that i have been playing with.

1. Except for the Uis, this is from a real-world application.  This application integrated with around 15 APIs and had to cater for multiple email clients.  Although there are no proprietry logic contained in these files, this is the basic architecture.  It followed an api approach with request and response pattern
2. We needed to enable auditing and insted of SQL Audit I used audit.net for entityFramework and/or triggers.  The benefit of the first is that i could pass details of the user through to be logged such as, IP, username, etc.
3. Dashboards were provided by SSRS Mobile reports  
4. Because of the repetative nature of most of the objects, i created a generic crud wcf service with generic logic layer that does exception logging.
5. We did not have access to production servers, and this was a multi-tenanted infrastructure (load balanced) and needed exception logging and be able to monitor server health in order to provide support.  NLog and elmah and asp.net server health monitoring was enabled and deployed as a separate api. 
