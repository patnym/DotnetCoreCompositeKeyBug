using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkingExampleDotnet20 {

    public class MyDbContext : DbContext {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseInMemoryDatabase("MyDatabase");
        }

        public DbSet<MainItem> MainItems {
            get; set;
        }
        public DbSet<CompositeItem> CompositeItems {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<CompositeItem>()
                .HasKey(ci => new {
                    ci.Id,
                    ci.ItemType
                });

            modelBuilder.Entity<MainItem>()
                .HasMany(mi => mi.CompositeItems)
                .WithOne(ci => ci.MainItem);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class MainItem {
        [Key]
        public long Id {
            get; set;
        }
        public IEnumerable<CompositeItem> CompositeItems {
            get; set;
        }
    }

    public class CompositeItem {
        
        public long Id {
            get; set;
        }

        public Type ItemType {
            get; set;
        }

        public MainItem MainItem {
            get; set;
        }

        public enum Type {
            TypeA,
            TypeB
        }
    }
}
