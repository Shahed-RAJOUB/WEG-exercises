import { TestBed } from '@angular/core/testing';

import { RegisterService } from './register.service';
import {RouterTestingModule} from '@angular/router/testing';
import {Member} from '../_modules/member';
import {skip} from 'rxjs/operators';
import {FormControl, FormGroup} from '@angular/forms';

describe('RegisterService', () => {
  let service: RegisterService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
    });
    service = TestBed.inject(RegisterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('shall emit a new array of Members when a Member is added', (done) => {
    // tslint:disable-next-line:no-shadowed-variable
    const service: RegisterService = TestBed.inject(RegisterService);
    const newMember = new FormGroup({
      firstName: new FormControl('tester'),
      lastName: new FormControl('tester'),
      email: new FormControl('tester@example.com'),
      city: new FormControl('string'),
      country: new FormControl('string'),
      zip: new FormControl('string'),
      birthday: new FormControl('string'),
      password: new FormControl('string'),
    });
    let id: number;
    const member = new Member(
      id = 1,
      newMember.value.firstName,
      newMember.value.lastName,
      newMember.value.email,
      newMember.value.city,
      newMember.value.country,
      newMember.value.zip,
      newMember.value.birthday,
      newMember.value.password);
    service.members$
      .pipe(
        skip(1)
      )
      .subscribe(members => {
        expect(members.length).toBeGreaterThanOrEqual(1);
        expect(members).toContain(member);
        done();
      });
    service.addMember(newMember);
  });
});
