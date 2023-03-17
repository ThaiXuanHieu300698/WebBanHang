# WebBanHang

## Install
1. Open file WebBanHang.sln
2. Right click the project WebBanHang.Data, choose Set as StartUp Project
3. Change ConnectionString(data source and user) in 2 file App.Config in project WebBanHang.Data and Web.config in project WebBanHang.Web
```
<connectionStrings>
  <add name="WebBanHangDbContext" connectionString="data source=DESKTOP-*******;initial catalog=WebBanHang;persist security info=True;user id=sa;password=******;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
</connectionStrings>
```
4. Choose Tools -> NuGet Package Manager -> Package Manager Console
5. Select Default Project become WebBanHang.Data
6. Type ``` Update-Database``` and press Enter
7. Press F5 to Run

## Pages
1. Login & Register
![login-register](https://user-images.githubusercontent.com/48479522/94161963-6c20a780-feb0-11ea-8b01-2856aa4ea1c0.png)
2. Forgot Password
![forgot-password](https://user-images.githubusercontent.com/48479522/94327300-3e348380-ffd4-11ea-8a4b-9ead75aa67ea.png)
3. Home
![home](https://user-images.githubusercontent.com/48479522/94162072-85295880-feb0-11ea-86f9-4488f7bf6a20.png)
4. Product Category
![category](https://user-images.githubusercontent.com/48479522/94162084-89ee0c80-feb0-11ea-83b5-aef41153862f.png)
5. Detail Product
![detail-product](https://user-images.githubusercontent.com/48479522/94162095-8c506680-feb0-11ea-92c4-02575afd8d9b.png)
6. Cart
![cart](https://user-images.githubusercontent.com/48479522/94162115-91151a80-feb0-11ea-8fc5-8af81c154e0d.png)
7. Orders
![orders](https://user-images.githubusercontent.com/48479522/94162120-92dede00-feb0-11ea-84bd-7d348da74de1.png)
8. Product Management
![product-management](https://user-images.githubusercontent.com/48479522/94162131-96726500-feb0-11ea-8683-ca96137dffba.png)
9. Add & Update Product
![add-update-product](https://user-images.githubusercontent.com/48479522/94162154-9b371900-feb0-11ea-862b-1cd068e17223.png)
