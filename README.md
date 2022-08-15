# LibraryManagementSystem

This library management system is designed using **ASP.NET MVC** to manage all the functions of a library. It helps the librarian to maintain the database of new books and the books that are borrowed by members along with their due dates. It also helps a user to borrow and return a book online. Defdaulters will be dealt with a fine.
### Features
> For Admin
 * Can *Approve* or *Reject* the request for any book.
 * Can perform *CRUD* operations on Account, Book, Author, Publisher, User tables.
 * Can View all the past *Records* of each user.
> For User
* Can views all the books and *Request* any book.
* Can view all the issued books and *Return* them.
* Can view all of his past *Records*.

> Landing Page

![Screenshot (6)](https://user-images.githubusercontent.com/109413947/184697020-b5d4f15b-e8d5-4659-a331-f7137d3bacdb.png)


> Login Page

![Screenshot (7)](https://user-images.githubusercontent.com/109413947/184697079-fb6eeef8-dfc9-4d91-8b8e-827d1c965fad.png)


> View Books Page



![Screenshot (9)](https://user-images.githubusercontent.com/109413947/184697147-14e3633f-a664-46d2-a9e8-545521ba9df4.png)



> Issue Records

![Screenshot (15)](https://user-images.githubusercontent.com/109413947/184697213-f03018a2-b3a0-44dc-83c8-58764c8aa6ba.png)


>User History

![Screenshot (16)](https://user-images.githubusercontent.com/109413947/184697265-892ad081-0bea-45f8-828c-31239acfe555.png)


>Book Request Aproval Page

![Screenshot (18)](https://user-images.githubusercontent.com/109413947/184698209-b93a4ae9-443e-4a29-bd15-1d0817247195.png)


>Book Inventory

![Screenshot (11)](https://user-images.githubusercontent.com/109413947/184698343-1ea4df67-7b11-4271-a8cd-0e399b412aa8.png)


>All Transactions

![Screenshot (12)](https://user-images.githubusercontent.com/109413947/184698453-f7a8bf07-f725-415e-8d7f-4b98fde41575.png)


## To get Started
### Softwares
* Microsoft Visual Studio Community 2022 (64-bit) Version **17.3.0**
* Microsoft SQL Server Management Studio Version **18.2.1**
* .NET Framework Version **5.0.17**

### Packages
> Inside your Visual Stdio Navigate to 
**Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution**
and install these packages

* Microsoft.EntityFrameworkCore Version **5.0.17**
* Microsoft.EntityFrameworkCore.Design Version **5.0.17**
* Microsoft.EntityFrameworkCore.Tools Version **5.0.17**
* Microsoft.EntityFrameworkCore.SqlServer Version **5.0.17**

### Commands
> Inside your Visual Stdio Navigate to 
**Tools** > **NuGet Package Manager** > **Package Manager Console**
and enter these commands
```sh
Add-Migration <Migration Name>
```
```sh
Update-Database
```
Make sure to update [appsettings.json] with the **Database Name** you want to give.
```sh
"Connection Strings":{
"DBConnection": "Server=localhost;Database=<Database Name>;Trusted_Connection=True;"}
```

> Schema Diagram

![Schema](https://user-images.githubusercontent.com/109413947/184699525-342e223e-777f-49f3-a683-7b56fddca1a3.png)

