using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WorkingExampleDotnet20 {
    class Program {
        static void Main(string[] args) {
            using(var context = new MyDbContext()) {

                //Works
                context.MainItems.Add(new MainItem {
                    CompositeItems = new List<CompositeItem> {
                        new CompositeItem {
                            Id = 1,
                            ItemType = CompositeItem.Type.TypeA
                        },
                        new CompositeItem {
                            Id = 2,
                            ItemType = CompositeItem.Type.TypeB
                        }
                    }
                });

                System.Console.WriteLine("Successfully added where the composite items use different ItemTypes ");

                //Works
                context.MainItems.Add(new MainItem {
                    CompositeItems = new List<CompositeItem> {
                        new CompositeItem {
                            Id = 3,
                            ItemType = CompositeItem.Type.TypeA
                        },
                        new CompositeItem {
                            Id = 4,
                            ItemType = CompositeItem.Type.TypeA
                        }
                    }
                });

                System.Console.WriteLine("Successfully added where the composite items share ItemType");

                context.SaveChanges();
            }
        }
    }
}
