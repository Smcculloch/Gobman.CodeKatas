Create procedure [dbo].[UpdatePerson]  
(  
   @FirstN nvarchar (200),  
   @LastN nvarchar (200),  
   @PhoneN nvarchar (15),
   @PersonId nvarchar (200)
)  
as  
begin  
   Update Person   
   set FirstName=@FirstN,  
   LastName=@LastN,  
   PhoneNumber=@PhoneN  
   where PersonId=@PersonId  
End