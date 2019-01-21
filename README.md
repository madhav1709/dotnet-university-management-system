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

Run `dotnet ef database update` to update the database.

### Step 6

Run the IdentityServer Project.

### Step 7

Send a POST request to https://localhost:5000/connect/token as follows:
* Headers
    * Content-Type: application/x-www-form-urlencoded
* Body
    * client_id: client
    * client_secret: secret
    * grant_type: client_credentials

### Step 8

Make a note of the "access_token" in the response.

### Step 9

Run the Membership.WebApi Project.

### Step 10

Use the "access_token" as the BearerAuth to make requests.

[dotnet-core-sdk]: https://dotnet.microsoft.com/download/dotnet-core/3.0
[sql-server]: https://www.microsoft.com/en-gb/sql-server/sql-server-downloads
