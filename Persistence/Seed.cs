using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
  public class Seed
  {
    public static void SeedData(DataContext context)
    {
      if (!context.Posts.Any())
      {
        var Posts = new List<Post>
            {
              new Post {
                Title = "Time",
                Date = DateTime.Now.AddDays(-10),
                Body = "Time you enjoy wasting, was not wasted. -John Lennon"
              },
              new Post {
                Title = "Pain",
                Date = DateTime.Now.AddDays(-7),
                Body = "If you are pained by any external thing, it is not this thing that disturbs you, but your own judgment about it. And it is in your power to wipe out this judgment now. -Marcus Aurelius"
              },
              new Post {
                Title = "Peace",
                Date = DateTime.Now.AddDays(-4),
                Body = "If everyone demanded peace instead of another television set, then there'd be peace. -John Lennon"
              }
            };

        context.Posts.AddRange(Posts);
        context.SaveChanges();
      }
    }
  }
}