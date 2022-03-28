import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UserRequestV1 } from 'src/data/schemas/request/UserRequestV1';
import { AuthService } from 'src/data/services/auth.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  user: UserRequestV1 = new UserRequestV1();
  constructor(private authService: AuthService,private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    // if(this.authService.isAuthenticated()){
    //   Swal.fire('Login','Hola '+this.authService.usuario.names +" ya estas autenticado",'info');
    //   this.router.navigate(['/main/createUser']);
    // }
  }

  login(Login:NgForm):void{
    if(this.user.username==null || this.user.password ==null){
      Swal.fire('Error login','usuario  o contraseña vacia','error');
      return;
    }
    this.authService.Login(this.user).subscribe((res)=>{
      console.log(res.objeto.accessToken);
      this.authService.saveUser(res.objeto.accessToken);
      this.authService.guardarToken(res.objeto.accessToken);
      let usuario = this.authService.usuario;
      console.log(usuario);
      this.router.navigate(['/main/createUser']);
      Swal.fire('Login','Bienvenido '+usuario.fullName+", Haz iniciado sesion con exito",'success');
    },(err)=>{
      if(err.status == 401){
        Swal.fire('Error login','Usuario  o contraseña incorrecta','error');
      }
    })
  }

}
