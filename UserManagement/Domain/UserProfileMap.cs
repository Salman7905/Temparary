using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace UserManagement.Domain
{
    public class UserProfileMap
    {
        public UserProfileMap(EntityTypeBuilder<UserProfile> userProfile)
        {
            userProfile.HasKey(e => e.ID);
            userProfile.Property(e => e.FirstName).IsRequired();
            userProfile.Property(e => e.LastName).IsRequired();
            userProfile.Property(e => e.Address);
        }
    }
}