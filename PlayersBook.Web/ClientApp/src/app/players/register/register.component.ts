import { Component, OnInit } from '@angular/core';
import { AbstractControl, UntypedFormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { IPlayerLogin } from 'src/app/models/IPlayerLogin';
import { IPlayer } from 'src/app/models/Player/IPlayer';
import { PlayerDataService } from 'src/app/_data-services/player-Data.Service';

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
    private fb: UntypedFormBuilder,
    private playerDataService: PlayerDataService,
    private router: Router) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      name : ['', [Validators.required]],
      lastname : ['', [Validators.required]],
      email : ['', [Validators.required]],
      nickname : ['', [Validators.required]],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.compose([Validators.required, this.validateAreEqual.bind(this)])]],
    },);

  }

  validateAreEqual(fieldControl: FormControl) {
    return fieldControl.value === this.registerForm.controls?.password?.value ? null : {
        NotEqual: true
    };
}


  register(){
    console.log(this.registerForm)
    if(this.registerForm.invalid){
      console.log("invalido")
      return; 
    }
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
