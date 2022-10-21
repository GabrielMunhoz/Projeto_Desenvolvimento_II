import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPlayer } from 'src/app/models/Player/IPlayer';
import { PlayerDataService } from 'src/app/_data-services/playerDataService';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup = this.fb.group({});
  spinner: boolean = true; 
  player: IPlayer = { id:'', name: '', lastname: '', email: '', nickname: '', password: '' }
  constructor(
    private fb: FormBuilder,
    private playerDataService: PlayerDataService) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      name : ['', [Validators.required]],
      lastname : ['', [Validators.required]],
      nickname : ['', [Validators.required]],
      password : ['', [Validators.required]],
      
    })
  }

  register(){
    this.player = this.registerForm.value; 
    this.playerDataService.post(this.player).subscribe(
      suc => {},
      err => {}
    )

  }
  

}
