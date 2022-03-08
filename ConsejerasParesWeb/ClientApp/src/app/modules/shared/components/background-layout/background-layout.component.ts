import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-background-layout',
  templateUrl: './background-layout.component.html',
  styleUrls: ['./background-layout.component.scss']
})
export class BackgroundLayoutComponent implements OnInit {
  sideBarOpen = true;

  constructor() { }

  ngOnInit(): void {
  }


  sideBarToggler(){
    this.sideBarOpen = !this.sideBarOpen;
  }

}
