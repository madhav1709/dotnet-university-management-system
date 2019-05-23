# University Management System

## Usage

### Step 1

Download and install the [.NET Core SDK][dotnet-core-sdk].

### Step 2

Download and install [SQL Server Express LocalDB][sql-server].

### Step 3

Start the automatic instance named "MSSQLLocalDB".

### Step 4

Create a database named "UniversityManagementSystem".

### Step 5

Run `dotnet ef database update` from the Apps.WebApi Project.

### Step 6

Create a database named "UniversityManagementSystem.Identity".

### Step 7

Run `dotnet ef database update` from the Identity Project.

### Step 8

Run the Identity Project.

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

Run the Apps.WebApi Project.

### Step 12

Use the "access_token" as the BearerAuth to make requests.

[dotnet-core-sdk]: https://dotnet.microsoft.com/download/dotnet-core/3.0
[sql-server]: https://www.microsoft.com/en-gb/sql-server/sql-server-downloads
