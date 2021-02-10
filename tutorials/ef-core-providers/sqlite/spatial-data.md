---
PermaID: 1000010
Name: Spatial Data
---

# Spatial Data

Spatial data represents the physical location and the shape of objects. These objects can be point locations or more complex objects such as countries, roads, or lakes.

SQLite supports two spatial data types: the geometry data type and the geography data type.

 - **Geometry:** The geometry type represents data in a Euclidean (flat) coordinate system.
 - **Geography:** The geography type represents data in a round-earth coordinate system.

Both data types are implemented as .NET common language runtime (CLR) data types in SQLite. 

## Installation 

EF Core supports mapping to spatial data types using the `NetTopologySuite` spatial library. To use spatial data with EF Core, you need to install the [Microsoft.EntityFrameworkCore.Sqlite.NetTopologySuite](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite.NetTopologySuite) NuGet package.

```csharp
PM> Install-Package Microsoft.EntityFrameworkCore.Sqlite.NetTopologySuite
```

The `NetTopologySuite` is a spatial library for .NET. EF Core enables mapping to spatial data types in the database by using NTS types in your model.

Let's create the `SportsGround` model, which contains a `Point` data type available in `NetTopologySuite.Geometries`. It will save the geographic location of a sports ground.

```csharp
public class SportsGround
{
    public int ID { get; set; }
    public string Name { get; set; }
    public Point Location { get; set; }
}
```

To enable mapping to spatial types using `NetTopologySuite`, call the `UseNetTopologySuite` method on the provider's `DbContext` options builder. For SQLite, you can call it like as shown below.

```csharp
public class SportsGroundContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=D:\SportsGroundDb.db;",
            x => x.UseNetTopologySuite());
    }

    public DbSet<SportsGround> SportsGrounds { get; set; }
}
```

## Configuring SRID

In SpatiaLite, columns need to specify an SRID per column. The default SRID is `0`. Specify a different SRID using the `HasSrid` method.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<SportsGround>().Property(c => c.Location)
        .HasSrid(4326);
}
```

The `4326` refers to **WGS 84**, a standard used in GPS and other geographic systems.

Now we need to save some test data of sports ground to the database.

```csharp
var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
var currentLocation = geometryFactory.CreatePoint(new Coordinate(-69.938951, 18.481188));

using (var context = new SportsGroundContext())
{
    context.Database.EnsureCreated();
    var list = new List<SportsGround>()
    {
        new SportsGround()
        {
            Name = "Sports Complex",
            Location = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233)),
        },

        new SportsGround()
        {
            Name = "Gaddafi Stadium",
            Location = geometryFactory.CreatePoint(new Coordinate(-69.9118804, 18.4826214)),
        },

        new SportsGround()
        {
            Name = "Internation Sports Stadium",
            Location = geometryFactory.CreatePoint(new Coordinate(-69.9334673, 18.4718075)),
        }
    };
    context.SportsGrounds.AddRange(list);
    context.SaveChanges();
}
```

Let's say we want to query all the sports grounds whose distance to the current location is less than 2 km (2,000 meters).


```csharp
using (var context = new SportsGroundContext())
{
    var grounds = context.SportsGrounds
        .OrderBy(x => x.Location.Distance(currentLocation))
        .Where(x => x.Location.IsWithinDistance(currentLocation, 2000))
        .Select(x => new { x.Name, Distance = x.Location.Distance(currentLocation) })
        .ToList();

    foreach (var ground in grounds)
    {
        Console.WriteLine($"{ground.Name} ({ground.Distance.ToString("N0")} meters away)");
    }
}
```

Let's run your application and you will see the following output.

```csharp
Sports Complex (303 meters away)
Internation Sports Stadium (1,189 meters away)
```
