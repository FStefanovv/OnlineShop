namespace EFCoreVezba.Dto;

using Model;

public class GetUserDto {
    public GetUserDto(){}
    
    public string FirstName {get; set;}

    public string LastName {get; set;}

    public string EmailAddress {get; set;}

    public DateTime DateOfBirth {get; set;}

    public static GetUserDto ToDto(User user) {
  
        return new GetUserDto 
        {
            FirstName = user.FirstName, 
            LastName = user.LastName, EmailAddress = user.Email, 
            DateOfBirth = user.DateOfBirth
        };
    }
}