using System.Collections.Generic;

namespace FailingExampleDotnet21 {
    class Program {
        static void Main(string[] args) {
            using(var context = new MyDbContext()) {
                var myItem = new MainItem {
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
                };

                context.MainItems.Add(myItem);
                context.SaveChanges();
            }
        }
    }
}
