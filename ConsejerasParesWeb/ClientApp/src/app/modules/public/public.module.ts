import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { LoginComponent } from "./pages/login/login.component";
import { PublicRoutingModule } from "./public-routing.module";

@NgModule({
    imports:[
        FormsModule,
        CommonModule,
        PublicRoutingModule
    ],
    declarations: [
        LoginComponent
    ],
    exports: [],
    providers: []
})

export class PublicModule{
    constructor(){
        
    }
}