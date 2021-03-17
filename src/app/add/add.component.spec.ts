import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddComponent } from './add.component';
import {RouterTestingModule} from '@angular/router/testing';
import {ToastrModule} from 'ngx-toastr';
import {ReactiveFormsModule} from '@angular/forms';
import {RegisterService} from '../_services/register.service';

describe('AddComponent', () => {
  let component: AddComponent;
  let fixture: ComponentFixture<AddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        ToastrModule.forRoot(),
        RouterTestingModule
      ],
      declarations: [ AddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('shall add new Member to registry Service', () => {
    component.newForm.patchValue({
      member: {
        firstName: 'A tester',
        lastName: 'A tester',
        email: 'tester@example.com',
        city: 'string',
        country: 'string',
        zip: 'string',
        birthday: 'string',
        password: 'string'
      }
    });
    const repository = TestBed.inject(RegisterService);
    const repositorySpy = spyOn(repository, 'addMember').and.callThrough();

    component.register();

    expect(repositorySpy.calls.any()).toBeTruthy();
  });
  it('shall have errors for invalid form values', () => {
    component.newForm.patchValue({
      member: {
        firstName: '',
        lastName: '',
        email: 'tester',
        city: 'string',
        country: 'string',
        zip: 'string',
        birthday: '',
        password: ''
      }
    });
    expect(component.newForm.valid).toBe(false);
    fixture.detectChanges();
    const emailInput: HTMLElement = fixture.nativeElement.querySelector('#email');
    expect(emailInput.className).toContain('ng-invalid');
});
});
