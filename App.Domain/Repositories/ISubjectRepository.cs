using System;
using System.Collections.Generic;
using App.Domain.Models;

namespace App.Domain.Repositories
{
    public interface ISubjectRepository
    {
        void AddSubject(Subject subject);
    }
}