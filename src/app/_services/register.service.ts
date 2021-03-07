import { Injectable } from '@angular/core';
import {Member} from '../_modules/member';
import {BehaviorSubject} from 'rxjs';
import {FormGroup} from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  public members: Member[] = [];
  private memberSubject = new BehaviorSubject<Member[]>(this.members);
  public members$ = this.memberSubject.asObservable();

  constructor() {
  }

  private nextId = 1;

  public addMember(member: FormGroup): void {
    const newMember = new Member(
      this.nextId++, member.value.firstName ,
      member.value.lastName ,
      member.value.email ,
      member.value.city,
      member.value.country ,
      member.value.zip ,
      member.value.birthday );
    this.members.push(newMember);
    this.memberSubject.next(this.members);
  }

  public find(id: number): Member{
    return this.members.find(member => member.id === id);
  }
}
