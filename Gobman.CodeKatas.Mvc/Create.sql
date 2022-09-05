Create procedure [dbo].[Create]  
(  
   @FirstN nvarchar (200),  
   @LastN nvarchar (200),  
   @PhoneN nvarchar (15),
   @PersonId nvarchar (200)
)  
as  
begin  
   Insert into Person (FirstName,LastName,PhoneNumber, PersonId)
   values(@FirstN,@LastN,@PhoneN,@PersonId)
End