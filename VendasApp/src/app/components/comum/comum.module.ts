import { ComumRoutingModule } from './comum.routing.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';

@NgModule({
  imports: [
    CommonModule,
    ComumRoutingModule,
  ],
  declarations: [HomeComponent]
})
export class ComumModule { }
