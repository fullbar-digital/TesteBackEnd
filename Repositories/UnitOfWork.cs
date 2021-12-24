using Domain.Entities;

using Microsoft.EntityFrameworkCore;

using Repositories.Core;

using System;
using System.Linq;


namespace Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region dispose

        /***********************************************************************************************************/
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        private EfDbContext _context;

        private DefaultRepository<Course> courseRepository = null;

        private SchoolReportRepository schoolReportRepository = null;

        private StudentRepository studentRepository = null;

        private DefaultRepository<Subject> subjectRepository = null;


        #region IDefault Core Repositories

        public IDefaultRepository<Course> CourseRepository
        {
            get
            {
                if (courseRepository == null)
                {
                    courseRepository = new DefaultRepository<Course>(_context);
                }
                return courseRepository;
            }
        }

        public SchoolReportRepository SchoolReportRepository
        {
            get
            {
                if (schoolReportRepository == null)
                {
                    schoolReportRepository = new SchoolReportRepository(_context);
                }
                return schoolReportRepository;
            }
        }
        public StudentRepository StudentRepository
        {
            get
            {
                if (studentRepository == null)
                {
                    studentRepository = new StudentRepository(_context);
                }
                return studentRepository;
            }
        }
        public IDefaultRepository<Subject> SubjectRepository
        {
            get
            {
                if (subjectRepository == null)
                {
                    subjectRepository = new DefaultRepository<Subject>(_context);
                }
                return subjectRepository;
            }
        }
        #endregion

        #region In And Out Operations
        public UnitOfWork(EfDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    var entries = _context.ChangeTracker.Entries()
                    .Where(e => e.Entity is EntityBase && (
                    e.State == EntityState.Added || e.State == EntityState.Modified));

                    foreach (var entityEntry in entries)
                    {
                        ((EntityBase)entityEntry.Entity).UpdateDate = DateTime.Now;

                        if (entityEntry.State == EntityState.Added)
                        {
                            ((EntityBase)entityEntry.Entity).CreateDate = DateTime.Now;
                        }
                    }

                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed);
        }


        #endregion
    }
}