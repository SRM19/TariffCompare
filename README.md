### Tariff Comparision

Develop a model to build up the following two products and to compare these prod ucts based on their annual costs. The comparison should accept the following input parameter:

 	Consumption (kWh/year) 
  
  and create a list of these products with the columns
  
 	Tariff name
  
 	Annual costs (€/year)
  
The list should be sorted by costs in ascending order.

Products  

Product A

Name: "basic electricity tariff"

```
Calculation model: base costs per month 5 € + consumption costs 22 cent/kWh
```

Examples

Consumption = 3500 kWh/year Annual costs = 830 €/year (5€ * 12 months = 60 € base costs + 3500 kWh/year 22 cent/kWh = 770 € consumption costs)
  
Consumption = 4500 kWh/year Annual costs = 1050 €/year (5€ * 12 months 60 € base costs + 4500 kWh/year * 22 cent/kWh 990 € consumption costs) 
 	
Consumption = 6000 kWh/year Annual costs - 1380 €/year (5€ * 12 months — 60€ base costs + 6000 kWh/year * 22 cent/kWh = 1320 € consumption costs)
 
 Product B
 
Name: "Packaged tariff"

```
Calculation model: 800 € for up to 4000 kWh/year and above 4000 kWh/year additionally 30 cent/kWh.
```

Examples

Consumption = 3500 kWh/year Annual costs = 800 €/year
  
Consumption = 4500 kWh/year Annual costs 950 €/year (800€ + 500 kWh * 30 cent/kWh = 150 € additional consumption costs)
  
Consumption = 6000 kWh/year Annual costs = 1400 €/year (800€ + 2000 kWh * 30 cent/kWh = 600 € additional consumption costs)

Notes:

Please implement this task in C#, C++ or Java or any other object oriented language.

If you write tests for your implementation please provide them with your implementation.

Please develop only the logic described above, and no UI (webpage, etc.). You do not need a data base. 

All sample data can be hardcoded or added to the implementation by any other method of your choice.

## Approach

Built a Console application using C#/.NET Core 6. 

Annual cost is calculated as sum of Base cost and Consumption cost

Consumption cost is calculated based on the calculation model of tariff product

Application accepts consumption value and returns the tariff products in ascending order

Unit tests are written to validate the input value and the products list in ascending order

## Assumptions

Consumption value cannot be negative or zero

Consumption value can be decimal 

Annual cost can be decimal (rounded off to 2 decimal places)

## Steps to Run

1. Launch the Console application from Visual Studio start up 

2. Or from dotnet CLI (give these commands from project root folder) dotnet restore, dotnet build, dotnet run

3. Application asks for consumption value, input the consumption value

4. Application displays the table with product name and annual costs

