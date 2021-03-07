import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {Member} from '../_modules/member';
import {RegisterService} from '../_services/register.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  members$: Observable<Member[]>;
  constructor(private registerService: RegisterService,
              private rout: Router) {
    this.members$ = registerService.members$;
  }

  ngOnInit(): void {
  }
  getDetailes(id: number): void{
    this.rout.navigate(['detail/' + id]);
  }
}
