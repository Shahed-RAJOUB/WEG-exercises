import { Component, OnInit } from '@angular/core';
import {ToastrService} from 'ngx-toastr';
import {RegisterService} from '../_services/register.service';
import {Observable} from 'rxjs';
import {Member} from '../_modules/member';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent implements OnInit {

  members$: Observable<Member[]>;
  newForm: FormGroup;

  constructor(private  registerService: RegisterService, private toastr: ToastrService, private fb: FormBuilder , private rout: Router) {
    this.members$ = registerService.members$;
  }

  ngOnInit(): void {
    this.newForm = this.fb.group({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      city: new FormControl(''),
      country: new FormControl(''),
      zip: new FormControl(''),
      birthday: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required , Validators.minLength(8) , Validators.maxLength(15)]),
    });
  }

  register(): void{
    if (this.newForm){
      console.log(this.newForm);
      this.registerService.addMember(this.newForm);
      this.toastr.info('A neu member is added ');
      this.rout.navigate(['list']);
    }
  }
}
