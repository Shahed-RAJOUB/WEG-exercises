import { ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RegisterService} from './register.service';


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class ServicesModule {

  public static forRoot(): ModuleWithProviders<ServicesModule> {
    return {
      ngModule: ServicesModule,
      providers: [
        RegisterService
      ]
    };
  }

  constructor(@Optional() @SkipSelf() parentModule: ServicesModule) {
    if (parentModule) {
      throw new Error('ServicesModules is already loaded. Import it in the root app module only');
    }
  }
}
