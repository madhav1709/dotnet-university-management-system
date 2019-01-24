# University Management System

## Usage

### Step 1

Download and install the [.NET Core SDK][dotnet-core-sdk].

### Step 2

Download and install [SQL Server Express LocalDB][sql-server].

### Step 3

Start the automatic instance named "MSSQLLocalDB".

### Step 4

Create a database named "UniversityManagementSystem.Membership".

### Step 5

Run `dotnet ef database update` from the Membership.WebApi Project.

### Step 6

Create a database named "UniversityManagementSystem.Core".

### Step 7

Run `dotnet ef database update` from the Core.WebApi Project.

### Step 8

Run the IdentityServer Project.

### Step 9

Send a POST request to https://localhost:5000/connect/token as follows:
* Headers
    * Content-Type: application/x-www-form-urlencoded
* Body
    * client_id: client
    * client_secret: secret
    * grant_type: client_credentials

### Step 10

Make a note of the "access_token" in the response.

### Step 11

Run the Core and/or Membership WebApi Projects.

### Step 12

Use the "access_token" as the BearerAuth to make requests.

[dotnet-core-sdk]: https://dotnet.microsoft.com/download/dotnet-core/3.0
[sql-server]: https://www.microsoft.com/en-gb/sql-server/sql-server-downloads
