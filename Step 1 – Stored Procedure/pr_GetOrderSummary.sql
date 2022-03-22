CREATE OR ALTER PROCEDURE pr_GetOrderSummary
	@StartDate DATE,
	@EndDate DATE,
	@EmployeeID INT = NULL,
	@CustomerID NCHAR(5) = NULL 
	AS

SELECT cu.ContactName, 
	sh.CompanyName, 
	cu.CompanyName, 
	COUNT(*) AS NumberOfOrders, 
	DATEADD(DAY, 0, DATEDIFF(DAY, 0, o.OrderDate)) AS Date, 
	SUM(o.Freight) AS TotalFreightCost, 
	COUNT(DISTINCT p.ProductID) AS NumberOfDifferentProducts,
	SUM(od.UnitPrice * od.Quantity) AS TotalOrderValue
FROM Orders o WITH(NOLOCK)
JOIN Shippers sh WITH(NOLOCK)
	ON o.ShipVia = sh.ShipperID
JOIN Customers cu WITH(NOLOCK)
	ON o.CustomerID = cu.CustomerID
JOIN [Order Details] od WITH(NOLOCK)
	ON o.OrderID = od.OrderID
JOIN Products p WITH(NOLOCK)
	ON od.ProductID = p.ProductID
WHERE (o.OrderDate BETWEEN @StartDate AND @EndDate) AND
	(@EmployeeID IS NULL OR @EmployeeID = o.EmployeeID) AND
	(@CustomerID IS NULL OR @CustomerID = o.CustomerID)
GROUP BY o.OrderDate, cu.ContactName, cu.CompanyName, sh.CompanyName
