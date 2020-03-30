# Bill Generator Task

### System Requirements
### VS 2019
### .Net core 3.0  

### Please follow the below steps to run the application 

git clone https://github.com/charankumarreddy/BillGeneratorTask.git <br />
cd BillGeneratorTask <br />
dotnet restore <br />
dotnet run  <br />

#### If requried change the sql connection string from appsettings.json file 

#### I have implemented below pages 
CRUD for Items <br />
CRUD for Item Categories(like Medicine and Groceries) <br />
Bill Generator page to add the items and implement below points as mentioned <br />

1. Create a .Net based solution to generate billing of the items. 

2. The solution should take item and quantity as input

3. Apply a 10 % discount on all grocery items.

4. Apply 5 % discount of medicines

5. Apply a GST of 11% on total cost

5. The program should output the summarized bill with discount
