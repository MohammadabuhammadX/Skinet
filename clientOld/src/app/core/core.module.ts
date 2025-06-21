import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';



@NgModule({
  declarations: [NavBarComponent],
  imports: [
    CommonModule   // gives us functionality that we've already used actually we uesed an ng4 directive earlier on, to loop through  the products and this fuctionality is contained inside this common module
  ],
  exports: [NavBarComponent]
})
export class CoreModule { }
