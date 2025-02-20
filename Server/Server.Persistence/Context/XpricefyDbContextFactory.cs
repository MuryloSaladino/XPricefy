using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Server.Application.Config;

namespace Server.Persistence.Context;

public class XpricefyDbContextFactory : IDesignTimeDbContextFactory<XpricefyContext>
{
    public XpricefyContext CreateDbContext(string[] args)
    {
        DotEnv.Load();

        var optionsBuilder = new DbContextOptionsBuilder<XpricefyContext>();
        optionsBuilder.UseSqlServer(DotEnv.Get("DATABASE_URL"));

        return new XpricefyContext(optionsBuilder.Options);
    }
}