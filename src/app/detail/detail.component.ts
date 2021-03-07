import { Component, OnInit } from '@angular/core';
import {Observable, Subscription} from 'rxjs';
import {Member} from '../_modules/member';
import {RegisterService} from '../_services/register.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {
  private routeSubscription?: Subscription;

  public member?: Member;
  members$: Observable<Member[]>;
  constructor(private registerService: RegisterService,
              private activatedRoute: ActivatedRoute)
 { this.members$ = registerService.members$; }

  ngOnInit(): void {
    this.routeSubscription = this.activatedRoute.params.subscribe(params => {
      const memberId = + params['id'];
      this.member = this.registerService.find(memberId);
    });
  }
  // tslint:disable-next-line:use-lifecycle-interface
  ngOnDestroy(): void {
    this.routeSubscription?.unsubscribe();
  }

}
