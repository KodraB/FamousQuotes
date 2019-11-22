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
                Title = "Justice",
                Date = DateTime.Now.AddDays(-10),
                Author = "John Rawls",
                Body = "Justice is the first virtue of social institutions, as truth is of systems of thought. A theory however elegant and economical must be rejected or revised if it is untrue; likewise laws and institutions no matter how efficient and well-arranged must be reformed or abolished if they are unjust. Each person possesses an inviolability founded on justice that even the welfare of society as a whole cannot override. For this reason justice denies that the loss of freedom for some is made right by a greater good shared by others. It does not allow that the sacrifices imposed on a few are outweighed by the larger sum of advantages enjoyed by many. Therefore in a just society the liberties of equal citizenship are taken as settled; the rights secured by justice are not subject to political bargaining or to the calculus of social interests."
              },
              new Post {
                Title = "In Praise of Idleness",
                Date = DateTime.Now.AddDays(-7),
                Author = "Bertrand Russell",
                Body = "Suppose that at a given moment a certain number of people are engaged in the manufacture of pins. They make as many pins as the world needs, working (say) eight hours a day. Someone makes an invention by which the same number of men can make twice as many pins as before. But the world does not need twice as many pins: pins are already so cheap that hardly any more will be bought at a lower price. In a sensible world everybody concerned in the manufacture of pins would take to working four hours instead of eight, and everything else would go on as before. But in the actual world this would be thought demoralizing. The men still work eight hours, there are too many pins, some employers go bankrupt, and half the men previously concerned in making pins are thrown out of work. There is, in the end, just as much leisure as on the other plan, but half the men are totally idle while half are still overworked. In this way it is insured that the unavoidable leisure shall cause misery all round instead of being a universal source of happiness. Can anything more insane be imagined?"
              },
              new Post {
                Title = "Questions",
                Date = DateTime.Now.AddDays(-4),
                Author = "Robert Pirsig",
                Body = "I would like not to cut any new channels of consciousness but simply dig deeper into old ones that have become silted in with the debris of thoughts grown stale and platitudes too often repeated. \"What's new?\" is an interesting and broadening eternal question, but one which, if pursued exclusively, results only in an endless parade of trivia and fashion, the silt of tomorrow. I would like, instead, to be concerned with the question \"What is best?,\" a question which cuts deeply rather than broadly, a question whose answers tend to move the silt downstream. There are eras of human history in which the channels of thought have been too deeply cut and no change was possible, and nothing new ever happened, and \"best\" was a matter of dogma, but that is not the situation now. Now the stream of our common consciousness seems to be obliterating its own banks, losing its central direction and purpose, flooding the lowlands, disconnecting and isolating the highlands and to no particular purpose other than the wasteful fulfillment of its own internal momentum. Some channel deepening seems called for."
              }
            };

        context.Posts.AddRange(Posts);
        context.SaveChanges();
      }
    }
  }
}