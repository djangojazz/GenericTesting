Create table teSku 
(
	SkuId int Identity Constraint PK_teSku_SkuId Primary Key
,	OrderId int Constraint FK_teSku_OrderId Foreign Key (OrderId) REFERENCES teOrder(OrderId)
,	Description varchar(128)
)