using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using VinaCent.Blaze.Authorization.Roles;
using VinaCent.Blaze.Authorization.Users;
using VinaCent.Blaze.MultiTenancy;
using VinaCent.Blaze.AppCore.FileUnits;
using VinaCent.Blaze.AppCore.TextTemplates;
using VinaCent.Blaze.AppCore.CommonDatas;
using VinaCent.Blaze.FirebaseCloudMessage;

namespace VinaCent.Blaze.EntityFrameworkCore
{
    // dotnet ef migrations add "Update.AddFcm.FcmUserTokenTopic" -p ./src/VinaCent.Blaze.EntityFrameworkCore -s ./src/VinaCent.Blaze.Web.Mvc --context BlazeDbContext
    // dotnet ef database update -p ./src/VinaCent.Blaze.EntityFrameworkCore -s ./src/VinaCent.Blaze.Web.Mvc --context BlazeDbContext
    // dotnet ef migrations remove -p ./src/VinaCent.Blaze.EntityFrameworkCore -s ./src/VinaCent.Blaze.Web.Mvc --context BlazeDbContext
    public class BlazeDbContext : AbpZeroDbContext<Tenant, Role, User, BlazeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<FileUnit> FileUnits { get; set; }

        public DbSet<TextTemplate> TextTemplates { get; set; }

        public DbSet<CommonData> CommonDatas { get; set; }

        public DbSet<FcmTopic> FcmTopics { get; set; }
        public DbSet<FcmUserTopic> FcmUserTopics { get; set; }
        public DbSet<FcmUserDeviceToken> FcmUserDeviceTokens { get; set; }
        public DbSet<FcmMessageLog> FcmMessageLogs { get; set; }
        public DbSet<FcmDeviceTokenTopic> FcmDeviceTokenTopics { get; set; }

        public BlazeDbContext(DbContextOptions<BlazeDbContext> options)
            : base(options)
        {
        }
    }
}