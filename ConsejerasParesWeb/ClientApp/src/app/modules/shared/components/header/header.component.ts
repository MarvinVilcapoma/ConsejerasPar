import { Component, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { MatMenuTrigger } from '@angular/material/menu';
import { Router } from '@angular/router';
import { UserResponseV2 } from 'src/data/schemas/response/UserResponseV2';
import { AuthService } from 'src/data/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  // username: string = this.authService.usuario.userName;
  
  // userName!: string | any;
  @Output() toggleSidebarForMe: EventEmitter<any> = new EventEmitter();

  constructor(private router: Router, private authService: AuthService) { }

  usuario: string = '';

  ngOnInit(): void {

    let user = JSON.parse(sessionStorage.getItem('user') || '{}');
    this.usuario = user.userName;

    // console.log(sessionStorage.getItem("user"));
    // let usuario = this.authService.usuario;
    // this.userName = sessionStorage.getItem("user.userName")?.toString();
    // console.log(this.username);

  }

  toggleSidebar() {
    this.toggleSidebarForMe.emit();
  }

  Logout(){
    this.authService.logout();
  }

}
