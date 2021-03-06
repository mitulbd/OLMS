import { UserProfile } from '../../model/userProfile';
import { BaseService } from '../../common/base.service';
import { Observable } from 'rxjs/Rx';
import { BaseRequestModel } from '../../request.model/base.request';
import { async } from 'rxjs/scheduler/async';
import { Router } from '@angular/router';

import { Teacher } from './../../model/teacher';
import { Component, OnInit } from '@angular/core';
import { Response } from '@angular/http';
import { TeacherService } from '../../service/teacher.service';
import { BaseController } from '../../common/controller/baseController';

@Component({
  selector: 'app-teacher-list',
  templateUrl: './teacher-list.component.html',
  styleUrls: ['./teacher-list.component.css']
})
export class TeacherListComponent extends BaseController<Teacher> implements OnInit {
  constructor(public teacherService: TeacherService, private router: Router,public authProfile:UserProfile) {
    super(teacherService,authProfile);
    this.reset();

  }

  ngOnInit() {

  }

  edit(student: Teacher) {
    this.router.navigate(['/teacher', student.id])
  }

  reset() {
    //this.requestModel = new BaseRequestModel();
    this.search();
  }
}
