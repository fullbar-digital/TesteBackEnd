using Domain.Entities;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories
{
    public class SubjectRep : BaseRep<Subject>, ISubjectRep
    {
        private readonly Context.Context _context;
        public SubjectRep(Context.Context context) : base(context)
        {
            _context = context;
        }
    }
}
