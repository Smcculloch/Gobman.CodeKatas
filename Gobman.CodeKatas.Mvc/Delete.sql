Create procedure [dbo].[Delete]  
(  
   @Id nvarchar (200)
)  
as   
begin  
   Delete from Person where PersonId=@Id  
End