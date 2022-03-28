import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { UserRequestV2 } from 'src/data/schemas/request/UserRequestV2';
import { UserResponseV3 } from 'src/data/schemas/response/UserResponseV3';
import { UserService } from 'src/data/services/user.service';

declare var $: any;

@Component({
  selector: 'app-assigntment-participant',
  templateUrl: './assigntment-participant.component.html',
  styleUrls: ['./assigntment-participant.component.scss']
})
export class AssigntmentParticipantComponent implements OnInit {

  currentPageCounselors: number = 1;
  totalLengthCounselors: any;


  totalLengthParticipants: any;
  currentPageParticipants: number = 1;

  users !: UserResponseV3[];

  counselorForm!: NgForm;

  public counselorsRequest: UserRequestV2 = new UserRequestV2();
  public counselorsResult: UserResponseV3[] = []; 

  public participantsRequest: UserRequestV2 = new UserRequestV2();
  public participantsResult: UserResponseV3[] = [];

  constructor(private userService: UserService) { }

  filterParticipant = '';
  filterCounselor = '';

  ngOnInit(): void {
    this.filtersParticipant();
    this.filtersCounselor();
  }

  filtersCounselor(){
    this.userService.getByFiltersCounselors(this.counselorsRequest).subscribe((response)=>{
      console.log(response);
      if(response.code == 0){
        this.counselorsResult = response.listado;
        this.totalLengthCounselors = response.listado.length;
        console.log(this.counselorsResult);
        console.log(this.totalLengthCounselors);
      }
    });
  }

  filtersParticipant(){
    this.userService.getByFiltersParticipants(this.participantsRequest).subscribe((response)=>{
      console.log(response);
      if(response.code == 0){
        this.participantsResult = response.listado;
        this.totalLengthParticipants = response.listado.length;
        console.log(this.participantsResult);
        console.log(this.totalLengthParticipants);
      }
    });
  }

  changeCheckedAll(){ 

    // var chechbox = document.getElementById("selectedBox");

    // for(let i = 0; i < this.participantsResult.length; i++) {
    //   console.log($(`#${this.participantsResult[i].userID}`).prop('checked'));
    //    $(`#${this.participantsResult[i].userID}`).prop('checked', true);
    //  }
    // }

    // for(let i = 0; i < this.participantsResult.length; i++) {
    //   const isChecked = $(`#${this.participantsResult[i].userID}`).prop('checked');
    //   console.log(isChecked);
    //   }
  } 

}
