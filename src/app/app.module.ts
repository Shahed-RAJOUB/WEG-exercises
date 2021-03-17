import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { ListComponent } from './list/list.component';
import { DetailComponent } from './detail/detail.component';
import { AddComponent } from './add/add.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FooterComponent } from './footer/footer.component';
import { GalleryComponent } from './gallery/gallery.component';
import {ServicesModule} from './_services/services.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {SharedModule} from './_modules/shared.modules';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {RouterTestingModule} from '@angular/router/testing';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    ListComponent,
    DetailComponent,
    AddComponent,
    FooterComponent,
    GalleryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    ServicesModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    SharedModule,
    BrowserAnimationsModule,
    RouterTestingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
