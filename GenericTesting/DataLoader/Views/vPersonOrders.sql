CREATE VIEW vPersonOrders
AS 
SELECT 
	p.PersonId
,	p.FirstName
,	p.LastName
,	o.OrderId
,	o.Description AS OrderDesc
FROM tePerson p
  INNER JOIN teOrder o ON p.PersonId = o.PersonId
