import {Component, NgModule} from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {MenuComponent} from './menu/menu.component';
import {ListComponent} from './list/list.component';
import {AddComponent} from './add/add.component';
import {DetailComponent} from './detail/detail.component';
import {GalleryComponent} from './gallery/gallery.component';

const routes: Routes = [
  {path: '', component: ListComponent},
  {path: 'menu', component: MenuComponent},
  {path: 'list', component: ListComponent},
  {path: 'add', component: AddComponent},
  {path: 'detail/:id', component: DetailComponent},
  {path: 'gallery', component: GalleryComponent},
  { path: '**', component: MenuComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
