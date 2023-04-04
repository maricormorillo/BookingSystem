# README
This README file provides instructions on how to give an admin user access to admin privileges by updating the appropriate tables in the database.

## Prerequisites
Access to the database where the AspNetRoles, AspNetUsers, and AspNetUserRole tables are stored.
Basic understanding of SQL and how to run SQL queries.


## Steps to give admin account access to admin
1. Register an account for the admin user in the system. Make sure to collect the necessary user information such as email, password, and other required fields.

2. From the AspNetRoles table in the database, set the following values for the admin role:
   - '**Id**' = 1
   - '**Name**' = "Admin"

3. From the AspNetUsers table in the database, find the '**Id**' of the admin user that was just registered. Copy this value as it will be used in the next step.

4. From the AspNetUserRole table in the database, insert a new row with the following values:

   - '**UserId**' = the **Id** of the admin user that was copied in the previous step.
   - '**RoleId**' = 1 (the Id of the Admin role that was set in step 2)

Once these steps are completed, the admin user should now have access to the admin functionality in the system.

## Conclusion
This README file has provided the steps to give an admin account access to admin by updating the appropriate tables in the database. It is important to follow these steps carefully to ensure that the correct changes are made and that the admin user has the necessary access to perform their duties.
