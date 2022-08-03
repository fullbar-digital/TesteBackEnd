using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Infra.Interfaces;
using Service.Dto;
using Service.Interfaces;

namespace Service.Services
{
    public class SubjectSer : ISubjectSer
    {
        private readonly IMapper _mapper;
        private readonly ISubjectRep _subjectRep;
        private readonly ICourseSubjectRep _courseSubjectRep;

        public SubjectSer(IMapper mapper, ISubjectRep subjectrep, ICourseSubjectRep coursesubjectrep)
        {
            _mapper = mapper;
            _subjectRep = subjectrep;
            _courseSubjectRep = coursesubjectrep;
        }

        public async Task<SubjectDto> Create(Subject subjectDTO)
        {
            var subject = _mapper.Map<Subject>(subjectDTO);
            //subject.DateCreated = DateTime.Now;

            subject.Validate();

            var subjectCreated = await _subjectRep.Create(subject);
            return (_mapper.Map<SubjectDto>(subjectCreated));
        }
        public async Task Remove(int code)
        {
            var list = await _courseSubjectRep.ForSubject(code);
            foreach (var item in list)
            {
                await _courseSubjectRep.Remove(item.Code);
            }
            await _subjectRep.Remove(code);
        }

        public async Task<SubjectDto> Update(SubjectDto subjectDTO)
        {
            var subjectExist = await _subjectRep.Get(subjectDTO.Code);
            if (subjectExist == null)
                throw new DomainException("Não existe essa disciplina para ser alterada");

            var subject = _mapper.Map<Subject>(subjectDTO);
            subject.Validate();
            subject.UpdateSub(subjectDTO.Name, subjectDTO.ApproveMin);

            var subjectUpdate = await _subjectRep.Update(subject);
            return _mapper.Map<SubjectDto>(subjectUpdate);
        }

        public async Task<SubjectDto> Get(int code)
        {
            var subject = await _subjectRep.Get(code);

            return _mapper.Map<SubjectDto>(subject);
        }

        public async Task<List<SubjectDto>> Get()
        {
            var listSubject = await _subjectRep.Get();

            return _mapper.Map<List<SubjectDto>>(listSubject);
        }

        public Task<SubjectDto> Create(SubjectDto subjectDTO)
        {
            throw new NotImplementedException();
        }
    }
}
