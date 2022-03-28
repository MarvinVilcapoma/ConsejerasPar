import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
// import { MatTableDataSource } from '@angular/material/table';
import { UserRequestV2 } from 'src/data/schemas/request/UserRequestV2';
import { UserResponseV3 } from 'src/data/schemas/response/UserResponseV3';
import { AuthService } from 'src/data/services/auth.service';
import { UserService } from 'src/data/services/user.service';
import jwt_decode from "jwt-decode";

@Component({
  selector: 'app-search-user',
  templateUrl: './search-user.component.html',
  styleUrls: ['./search-user.component.scss']
})
export class SearchUserComponent implements OnInit {


  public currentPage:number = 0;

  public request: UserRequestV2 = new UserRequestV2();

  public userResult: UserResponseV3[] = []; 
  

  constructor(private userService: UserService, private authService: AuthService) { }

  ngOnInit(): void {

    var decoded = jwt_decode(this.authService.token);
    console.log(decoded);
    
    this.userService.getByFilters(this.request).subscribe((response)=>{
      if(response.code == 0){
        this.userResult = response.listado;
        console.log(this.userResult);
      }
    });

  }

  SearchUser(searchUser:NgForm):void{
    this.userService.getByFilters(this.request).subscribe((res)=>{
      if(res.code == 0){
        this.userResult = res.listado;
      }
    });
  }

  Clear(searchUser:NgForm):void{
    searchUser.reset();
  }
}
