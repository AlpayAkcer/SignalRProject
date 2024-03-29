USE [SignalRMenuDb]
GO
/****** Object:  Trigger [dbo].[IncreaseOrderTotalPrice]    Script Date: 3.03.2024 23:56:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Trigger [dbo].[IncreaseOrderTotalPrice]
on [dbo].[OrderDetails]
After Insert
as
Declare @OrderID int
Declare @OrderPrice decimal
Select @OrderID = OrderID from inserted
Select @OrderPrice = TotalPrice from inserted
Update Orders Set TotalPrice = TotalPrice + @OrderPrice where OrderID = @OrderID