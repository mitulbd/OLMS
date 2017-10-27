﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLMS.BackEnd.Model;
using OLMS.BackEnd.Repository;
using OLMS.BackEnd.RequestModel;
using OLMS.BackEnd.ViewModel;

namespace OLMS.BackEnd.Service
{
   public class TeacherService
   {
       private readonly BaseRepository<Teacher> _repository;
        public TeacherService()
        {
            _repository=new BaseRepository<Teacher>();
        }
        public bool Add(Teacher teacher)
        {
           return _repository.Add(teacher);
        }

       public List<TeacherGridViewModel> Search(TeacherRequestModel request)
       {
           IQueryable<Teacher> teachers = this._repository.Get();

           if (!string.IsNullOrWhiteSpace(request.Name))
           {
               teachers = teachers.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
           }
           teachers = teachers.OrderBy(x => x.Modified);

           if (!string.IsNullOrWhiteSpace(request.OrderBy))
           {
               if (request.OrderBy.ToLower() == "name")
               {
                   teachers = request.IsAscending ? teachers.OrderBy(x => x.Name) : teachers.OrderByDescending(x => x.Name);
               }
           }

           teachers = teachers.Skip((request.Page - 1) * request.PerPageCount).Take(request.PerPageCount);

           List<TeacherGridViewModel> list = teachers.ToList().ConvertAll(
               teacher => new TeacherGridViewModel(teacher)
           );

           return list;
       }

       public TeacherDetailViewModel Detail(string id)
       {
           var teacher = _repository.GetDetail(id);
           if (teacher == null)
           {
               throw new ObjectNotFoundException();
           }
           return new TeacherDetailViewModel(teacher);

       }
    }
}