using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace UserManagement.Domain
{
    public class UserMap
    {
       public UserMap(EntityTypeBuilder<User> user)
       {
           user.HasKey(e =>e.ID);
           user.Property(e =>e.Email).IsRequired();
           user.Property(e =>e.Password).IsRequired();
           user.HasOne(e =>e.userProfile).WithOne(e =>e.user).HasForeignKey<UserProfile>(e =>e.ID); // One To One Relationship
       }
    }
}