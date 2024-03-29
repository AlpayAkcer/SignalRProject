USE [SignalRMenuDb]
GO
/****** Object:  Trigger [dbo].[DecreaseOrderTotalPrice]    Script Date: 3.03.2024 23:56:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Trigger [dbo].[DecreaseOrderTotalPrice]
on [dbo].[OrderDetails]
After Delete
as
Declare @OrderID int
Declare @OrderPrice decimal
Select @OrderID = OrderID from deleted
Select @OrderPrice = TotalPrice from deleted
Update Orders Set TotalPrice = TotalPrice - @OrderPrice where OrderID = @OrderID