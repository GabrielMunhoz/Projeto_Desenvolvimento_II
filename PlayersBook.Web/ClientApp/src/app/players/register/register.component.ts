import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IPlayerLogin } from 'src/app/models/IPlayerLogin';
import { IPlayer } from 'src/app/models/Player/IPlayer';
import { PlayerDataService } from 'src/app/_data-services/playerDataService';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup = this.fb.group({});
  spinner: boolean = false; 
  player: IPlayer = { id:'', name: '', lastname: '', email: '', nickname: '', password: '' }
  constructor(
    private fb: FormBuilder,
    private playerDataService: PlayerDataService,
    private router: Router) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      name : ['', [Validators.required]],
      lastname : ['', [Validators.required]],
      email : ['', [Validators.required]],
      nickname : ['', [Validators.required]],
      password : ['', [Validators.required]],
      confirmPassword : ['', [Validators.required]],
    })
  }

  register(){
    this.spinner = true; 
    this.player = this.registerForm.value; 
    this.playerDataService.post(this.player).subscribe(
      suc => {
        console.log(suc);
        this.login(this.player);
      },
      err => {
        this.spinner = !this.spinner
        console.log(err)
      }
    )

  }
  
  login(playerLogin: IPlayerLogin){
    this.playerDataService.authenticate(playerLogin).subscribe(
      suc => {
        if(suc){
          localStorage.setItem("PlayerLogged", JSON.stringify(suc));
          this.spinner = false; 
          this.router.navigate(['/']);
        }
    }, 
    err => {
      console.log(err)
    }); 
  }

}
