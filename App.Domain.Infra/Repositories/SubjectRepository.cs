using System;
using System.Collections.Generic;
using System.Linq;
using App.Domain.Infra.Contexts;
using App.Domain.Models;
using App.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.Infra.Respositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationContext _appContext;
        public SubjectRepository(ApplicationContext AppContext)
        {
            _appContext = AppContext;
        }

        public void AddSubject(Subject subject)
        {
            _appContext.subjects.Add(subject);
            _appContext.SaveChanges();
        }
    }
}