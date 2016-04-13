CREATE VIEW [dbo].[vPersonOrdersSkus]
AS
SELECT
	p.FirstName
,	p.LastName
,	o.OrderId
,	o.[Description] AS OrderDesc
,	s.SkuId
,	s.[Description] AS SkuDesc
FROM dbo.tePerson p
	JOIN dbo.teOrder o ON p.PersonId = o.PersonId
	JOIN dbo.teSku s ON o.OrderId = s.OrderId