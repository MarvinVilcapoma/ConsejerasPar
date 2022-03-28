import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserRequestV2 } from 'src/data/schemas/request/UserRequestV2';
import { UserResponseV3 } from 'src/data/schemas/response/UserResponseV3';
import { AuthService } from 'src/data/services/auth.service';
import { UserService } from 'src/data/services/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.scss']
})
export class CreateUserComponent implements OnInit {

  public request: UserRequestV2 = new UserRequestV2();

  public userResult: UserResponseV3[] = []; 
  constructor(private userService: UserService, private authService: AuthService) { }

  ngOnInit(): void {
    console.log( this.authService.token);
  }

  CreateUser(createUser:NgForm):void{
    this.userService.registerUser(this.request).subscribe((res)=>{
      if(res.code == 0){
        this.userResult = res.listado;
        Swal.fire('Usuario registrado con éxito');
      }else{
        Swal.fire('Ah ocurrido un error al registrar un usuario');
      }
    });
  }

  Clear(createUser:NgForm):void{
    createUser.reset();
  }
}
