USE [SignalRMenuDb]
GO
/****** Object:  Trigger [dbo].[SumMoneyCases]    Script Date: 3.03.2024 23:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Trigger [dbo].[SumMoneyCases]
on [dbo].[Orders]
After Update
As
Declare @Description Nvarchar(MAX)
Declare @TotalPrice decimal(18,2)

Select @Description= Description From inserted
Select @TotalPrice= TotalPrice From inserted

if(@Description ='Hesap Kapatıldı')
Begin

Update MoneyCases Set TotalAmount = TotalAmount + @TotalPrice

End
