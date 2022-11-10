import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IPlayerLogin } from 'src/app/models/IPlayerLogin';
import { PlayerDataService } from 'src/app/_data-services/player-Data.Service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  playerLogin: IPlayerLogin = {nickname: '', password :''}

  spinner: boolean = false; 

  loginForm :UntypedFormGroup = this.fb.group({})
  constructor(
    private fb: UntypedFormBuilder,
    private playerDataService: PlayerDataService,
    private router: Router, ) { }
  
  ngOnInit(): void {
    this.loginForm = this.fb.group({
      nickname : ['', [Validators.required]],
      password : ['', [Validators.required]],
      
    })
  }

  login(){
    this.playerLogin = this.loginForm.value;
    this.playerDataService.authenticate(this.playerLogin).subscribe(
      suc => {
        if(suc){
          localStorage.setItem("PlayerLogged", JSON.stringify(suc));
          this.router.navigate(['/']);
        }
    }, 
    err => {
      console.log(err)
    }); 
  }

  register(){
    this.router.navigate(['/register'])
  }
}
